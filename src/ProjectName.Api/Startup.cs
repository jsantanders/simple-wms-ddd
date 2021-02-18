using Autofac;
using Autofac.Extensions.DependencyInjection;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProjectName.Api.Configurations.Authorization;
using ProjectName.Api.Configurations.ExecutionContext;
using ProjectName.Api.Configurations.Validations;
using ProjectName.Api.Extensions;
using ProjectName.Application.SeedWork;
using ProjectName.Application.SeedWork.Commands;
using ProjectName.Domain.SharedKernel;
using ProjectName.Infrastructure;
using Serilog;
using Serilog.Formatting.Compact;

namespace ProjectName.Api
{
    public class Startup
    {
        private const string ProjectNameConnectionString = "ProjectNameConnectionString";
        private readonly IConfiguration configuration;
        private static ILogger logger;

        public Startup(IWebHostEnvironment env)
        {
            configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json")
                .AddUserSecrets<Startup>()
                .AddEnvironmentVariables("ProjectName_")
                .Build();

            ConfigureLogger();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerDocumentation();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IExecutionContextAccessor, ExecutionContextAccessor>();

            services.AddProblemDetails(x =>
            {
                x.Map<InvalidCommandException>(ex => new InvalidCommandProblemDetails(ex));
                x.Map<BusinessRuleValidationException>(ex => new BusinessRuleValidationExceptionProblemDetails(ex));
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy(
                    HasPermissionAttribute.HasPermissionPolicyName,
                    policyBuilder => { policyBuilder.Requirements.Add(new HasPermissionAuthorizationRequirement()); });
            });

            services.AddScoped<IAuthorizationHandler, HasPermissionAuthorizationHandler>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var container = app.ApplicationServices.GetAutofacRoot();

            app.UseCors(builder =>
                builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            Initialize(container);

            app.UseMiddleware<CorrelationMiddleware>();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwaggerDocumentation();
                app.UseProblemDetails();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

        private static void ConfigureLogger()
        {
            logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Console(
                    outputTemplate:
                    "[{Timestamp:HH:mm:ss} {Level:u3}] [{Context}] {Message:lj}{NewLine}{Exception}")
                .WriteTo.RollingFile(new CompactJsonFormatter(), "logs/logs")
                .CreateLogger();
        }

        private void Initialize(ILifetimeScope container)
        {
            var httpContextAccessor = container.Resolve<IHttpContextAccessor>();
            var executionContextAccessor = new ExecutionContextAccessor(httpContextAccessor);

            StartupSetup.Initialize(
                configuration[ProjectNameConnectionString],
                executionContextAccessor,
                logger);
        }
    }
}