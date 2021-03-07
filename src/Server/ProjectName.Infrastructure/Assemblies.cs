using System.Reflection;
using ProjectName.Application.SeedWork;
using ProjectName.Domain.SharedKernel;

namespace ProjectName.Infrastructure
{
    public class Assemblies
    {
        public static Assembly Domain => Assembly.GetAssembly(typeof(EntityBase<>));

        public static Assembly Application => Assembly.GetAssembly(typeof(ISqlConnectionFactory));

        public static Assembly Infrastructure => Assembly.GetAssembly(typeof(ContainerSetup));

    }
}
