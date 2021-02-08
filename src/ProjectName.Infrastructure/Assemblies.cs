using System.Reflection;
using ProjectName.Application;
using ProjectName.Domain.SharedKernel;

namespace ProjectName.Infrastructure
{
    public class Assemblies
    {
        public static Assembly DomainAssembly => Assembly.GetAssembly(typeof(EntityBase));

        public static Assembly ApplicationAssembly => Assembly.GetAssembly(typeof(ISqlConnectionFactory));

        public static Assembly InfrastructureAssembly => Assembly.GetAssembly(typeof(ContainerSetup));

    }
}
