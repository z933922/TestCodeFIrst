using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace task
{
    class Program
    {
        static void Main(string[] args)
        {
          //  Thread t1 = new Thread(()=> { Console.WriteLine(System.Threading.Thread.CurrentThread.Name); });

          //  t1.Start();


            Action a =()=> { Console.WriteLine(System.Threading.Thread.CurrentThread.Name); };

            Task.Run(a);
            Task.WaitAll();


            for (int i = 0; i < 5; i++)
            {
                new Thread(Run1).Start();
            }
            for (int i = 0; i < 5; i++)
            {
                Task.Run(() => { Run2(); });
            }


            Task<Int16> t = new Task<short>(()=> { return 10; });

            t.Start();
            t.Wait();
            Console.WriteLine("game over");
            Console.ReadKey();
           
        }

        static void Run1()
        {
            Console.WriteLine("Thread Id =" + Thread.CurrentThread.ManagedThreadId);
        }
        static void Run2()
        {
            Console.WriteLine("Task调用的Thread Id =" + Thread.CurrentThread.ManagedThreadId);
        }
    }
}
