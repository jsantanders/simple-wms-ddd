using System;
using Microsoft.AspNetCore.Authorization;

namespace ProjectName.Api.Configurations.Authorization
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    internal class HasPermissionAttribute : AuthorizeAttribute
    {
        internal const string HasPermissionPolicyName = "HasPermission";

        public HasPermissionAttribute(string name)
            : base(HasPermissionPolicyName)
        {
            Name = name;
        }

        public string Name { get; }
    }
}