using System;
using System.Threading;

namespace Conveyorbelt
{
    public static class MachineA
    {
        public static readonly Semaphore Sma = new Semaphore(0, 1);
        
        public static void Run()
        {
            while (true)
            {
                Sma.WaitOne();
                Process();
                Treadmill.Stm.Release();
            }
            // ReSharper disable once FunctionNeverReturns
        }

        private static void Process()
        {
            Thread.Sleep(400);
            Console.WriteLine("MachineA: finished process");
        }
    }
}