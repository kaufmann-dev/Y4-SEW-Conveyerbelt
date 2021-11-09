using System.Threading;

namespace Conveyorbelt
{
    static class Program
    {
        static void Main()
        {
            Thread t1 = new Thread(Treadmill.Run);
            Thread t2 = new Thread(MachineA.Run);
            Thread t3 = new Thread(MachineB.Run);
            
            t1.Start();
            t2.Start();
            t3.Start();
        }
    }
}