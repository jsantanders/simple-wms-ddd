using System;

namespace ProjectName.IntegrationTests.SeedWork
{
    public class AssertErrorException : Exception
    {
        public AssertErrorException(string message)
            : base(message)
        {
        }
    }
}
