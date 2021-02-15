using NUnit.Framework;

[assembly: NonParallelizable]
[assembly: LevelOfParallelism(1)]

namespace ProjectName.IntegrationTests
{
    public class AssemblyInfo
    {
    }
}