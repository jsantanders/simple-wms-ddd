using System;

namespace ProjectName.IntegrationTests.SeedWork
{
    public class Timeout
    {
        private readonly DateTime endTime;

        public Timeout(int duration)
        {
            this.endTime = DateTime.Now.AddMilliseconds(duration);
        }

        public bool HasTimedOut()
        {
            return DateTime.Now > endTime;
        }
    }
}