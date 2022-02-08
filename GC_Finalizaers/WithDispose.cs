using System;
using System.Diagnostics;
using System.Threading;

namespace GC_Finalizaers
{
    public class WithDispose : IDisposable
    {
        private readonly Stopwatch _stopwatch;
        private bool _disposed = false;

        public WithDispose()
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
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                _stopwatch.Stop();
                Interlocked.Increment(ref Program.FinalisedObjects);
                Interlocked.Add(ref Program.TotalTime, _stopwatch.ElapsedMilliseconds);

                if (disposing)
                {
                    // explicitly called from user code
                    // you can do basically anything you want here
                }
                else
                {
                    // called from finaliser
                    // do not access references, run quickly etc
                }

                _disposed = true;
            }
        }
    }
}