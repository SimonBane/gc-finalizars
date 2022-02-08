using System;
using System.Threading;

namespace GC_Finalizaers
{
    class Program
    {
        public static long FinalisedObjects = 0;
        public static long TotalTime = 0;
        
        static void Main(string[] args)
        {
            for (int i = 0; i < 1000000; i++)
            {
                using var obj = new WithDispose();
                obj.DoWork();
            }

            double avgLifetime = 1.0 * TotalTime / FinalisedObjects;
            Console.WriteLine($"Number of disposed/finalised objects: {FinalisedObjects / 1000}k");
            Console.WriteLine($"Average resource lifetime: {avgLifetime}ms");
        }
    }
}
