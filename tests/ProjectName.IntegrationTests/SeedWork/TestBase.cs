using System;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;
using NSubstitute;
using NUnit.Framework;
using ProjectName.Application.SeedWork;
using ProjectName.Domain.Contracts;
using ProjectName.Domain.SharedKernel;
using ProjectName.Infrastructure;
using Serilog;

namespace ProjectName.IntegrationTests.SeedWork
{
     public class TestBase
    {
        protected string ConnectionString { get; private set; }

        protected ILogger Logger { get; private set; }

        protected IExecutor Executor { get; private set; }


        protected ExecutionContextMock ExecutionContext { get; private set; }

        [SetUp]
        public async Task BeforeEachTest()
        {
            const string connectionStringEnvironmentVariable =
                "ASPNETCORE_MyMeetings_IntegrationTests_ConnectionString";
            ConnectionString = EnvironmentVariablesProvider.GetVariable(connectionStringEnvironmentVariable);
            if (ConnectionString == null)
            {
                throw new ApplicationException(
                    $"Define connection string to integration tests database using environment variable: {connectionStringEnvironmentVariable}");
            }

            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                await ClearDatabase(sqlConnection);
            }

            Logger = Substitute.For<ILogger>();
            ExecutionContext = new ExecutionContextMock(Guid.NewGuid());

            StartupSetup.Initialize(
                ConnectionString,
                ExecutionContext,
                Logger);

            Executor = new Executor();
        }
        
        protected async Task ExecuteScript(string scriptPath)
        {
            var sql = await File.ReadAllTextAsync(scriptPath);

            await using var sqlConnection = new SqlConnection(ConnectionString);
            await sqlConnection.ExecuteScalarAsync(sql);
        }

        protected static void AssertBrokenRule<TRule>(AsyncTestDelegate testDelegate)
            where TRule : class, IBusinessRule
        {
            var message = $"Expected {typeof(TRule).Name} broken rule";
            var businessRuleValidationException = Assert.CatchAsync<BusinessRuleValidationException>(testDelegate, message);
            if (businessRuleValidationException != null)
            {
                Assert.That(businessRuleValidationException.BrokenRule, Is.TypeOf<TRule>(), message);
            }
        }

        protected static void AssertEventually(IProbe probe, int timeout)
        {
            new Poller(timeout).CheckAsync(probe);
        }

        private static async Task ClearDatabase(IDbConnection connection)
        {
            const string sql = "DELETE FROM ";
            
            await connection.ExecuteScalarAsync(sql);
        }
    }
}
