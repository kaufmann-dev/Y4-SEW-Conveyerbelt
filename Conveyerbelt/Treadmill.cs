using System;
using System.Threading;

namespace Conveyorbelt
{
    public static class Treadmill
    {
        public static readonly Semaphore Stm = new Semaphore(0, 2);
        
        public static void Run()
        {
            Move("Warehouse1", "MachineA");
            MachineA.Sma.Release();
            Stm.WaitOne();
                
            Move("Warehouse1", "MachineA");
            Move("MachineA", "MachineB");
            MachineA.Sma.Release();
            MachineB.Smb.Release();
            Stm.WaitOne();
            Stm.WaitOne();
            
            while (true)
            {
                Move("Warehouse1", "MachineA");
                Move("MachineA", "MachineB");
                Move("MachineB", "Warehouse2");
                MachineA.Sma.Release();
                MachineB.Smb.Release();
                Stm.WaitOne();
                Stm.WaitOne();
            }
            // ReSharper disable once FunctionNeverReturns
        }

        private static void Move(string from, string to)
        {
            Thread.Sleep(500);
            Console.WriteLine($"Treadmill: Moving workpiece from {from} to {to}");
        }
    }
}