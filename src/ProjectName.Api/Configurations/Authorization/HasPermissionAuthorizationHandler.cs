using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using ProjectName.Application.Common;

namespace ProjectName.Api.Configurations.Authorization
{
    internal class HasPermissionAuthorizationHandler : AttributeAuthorizationHandler<
        HasPermissionAuthorizationRequirement, HasPermissionAttribute>
    {
        private readonly IExecutionContextAccessor executionContextAccessor;
        private readonly IExecutor executor;

        public HasPermissionAuthorizationHandler(
            IExecutionContextAccessor executionContextAccessor,
            IExecutor executor)
        {
            this.executionContextAccessor = executionContextAccessor;
            this.executor = executor;
        }

        protected override async Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            HasPermissionAuthorizationRequirement requirement,
            HasPermissionAttribute attribute)
        {
            // var permissions = await _userAccessModule.ExecuteQueryAsync(new GetUserPermissionsQuery(_executionContextAccessor.UserId));

            // if (!await AuthorizeAsync(attribute.Name, permissions))
            // {
            //     context.Fail();
            //     return;
            // }

            context.Succeed(requirement);
        }

//         private Task<bool> AuthorizeAsync(string permission, List<UserPermissionDto> permissions)
//         {
// #if !DEBUG
//             return Task.FromResult(true);
// #endif
//             return Task.FromResult(permissions.Any(x => x.Code == permission));
//         }
    }
}