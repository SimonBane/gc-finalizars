using System.Diagnostics;
using System.Threading;

namespace GC_Finalizaers
{
    public class WithoutDispose
    {
        private readonly Stopwatch _stopwatch;

        public WithoutDispose()
        {
            _stopwatch = new Stopwatch();
            _stopwatch.Start();
        }

        public void DoWork()
        {
            // simulate work
            double j = 0;
            for (int i = 0; i < 1000; i++)
            {
                j += i * i;
            }
        }

        ~WithoutDispose()
        {
            _stopwatch.Stop();
            Interlocked.Increment(ref Program.FinalisedObjects);
            Interlocked.Add(ref Program.TotalTime, _stopwatch.ElapsedMilliseconds);
        }
    }
}