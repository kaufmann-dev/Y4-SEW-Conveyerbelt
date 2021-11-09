using System;
using System.Threading;

namespace Conveyorbelt
{
    public static class MachineB
    {
        public static readonly Semaphore Smb = new Semaphore(0, 1);
        
        public static void Run()
        {
            while (true)
            {
                Smb.WaitOne();
                Process();
                Treadmill.Stm.Release();
            }
            // ReSharper disable once FunctionNeverReturns
        }

        private static void Process()
        {
            Thread.Sleep(300);
            Console.WriteLine("MachineB: finished process");
        }
    }
}