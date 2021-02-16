using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ProjectName.Api.Configurations.ExecutionContext
{
    internal class CorrelationMiddleware
    {
        internal const string CorrelationHeaderKey = "CorrelationId";
        private readonly RequestDelegate next;

        public CorrelationMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var correlationId = Guid.NewGuid();

            context.Request?.Headers.Add(CorrelationHeaderKey, correlationId.ToString());

            await next.Invoke(context);
        }
    }
}