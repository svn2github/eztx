using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace threadTest
{
    class Program
    {
        private static void a()
        { 
            for(int i=0;i<=10;i++)
            {
                Console.WriteLine("A线程"+i);
                Thread.Sleep(1000);
            }
            Console.WriteLine("A线程结束"); 
        }

        private static void b()
        {
            for (int i = 0; i <= 4; i++)
            {
                Console.WriteLine("B线程到此{0}游",i);
                Thread.Sleep(1000);
            }
            Console.WriteLine("B线程等待A线程结束");  
        }

        static void Main(string[] args)
        {
            Thread aT = new Thread(new ThreadStart(a)); 
            Thread bT = new Thread(new ThreadStart(b));
            bT.Start();
            aT.Start();

            bT.Join();
            Console.ReadKey();
        }
    }
}
