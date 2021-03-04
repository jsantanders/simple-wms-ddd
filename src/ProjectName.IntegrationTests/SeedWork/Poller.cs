using System.Threading;
using System.Threading.Tasks;

namespace ProjectName.IntegrationTests.SeedWork
{
    public class Poller
    {
        private readonly int timeoutMillis;

        private readonly int pollDelayMillis;

        public Poller(int timeoutMillis)
        {
            this.timeoutMillis = timeoutMillis;
            pollDelayMillis = 1000;
        }

        public async Task CheckAsync(IProbe probe)
        {
            var timeout = new Timeout(timeoutMillis);
            while (!probe.IsSatisfied())
            {
                if (timeout.HasTimedOut())
                {
                    throw new AssertErrorException(DescribeFailureOf(probe));
                }

                await Task.Delay(pollDelayMillis);
                await probe.SampleAsync();
            }
        }

        public async Task<T> GetAsync<T>(IProbe<T> probe)
            where T : class
        {
            var timeout = new Timeout(timeoutMillis);
            T sample = null;
            while (!probe.IsSatisfied(sample))
            {
                if (timeout.HasTimedOut())
                {
                    throw new AssertErrorException(DescribeFailureOf(probe));
                }

                await Task.Delay(pollDelayMillis);
                sample = await probe.GetSampleAsync();
            }

            return sample;
        }

        private static string DescribeFailureOf(IProbe probe)
        {
            return probe.DescribeFailureTo();
        }

        private static string DescribeFailureOf<T>(IProbe<T> probe)
        {
            return probe.DescribeFailureTo();
        }
    }
}
