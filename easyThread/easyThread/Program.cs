using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
namespace easyThread
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("开始一个新的线程，名为次线程");
            Thread t = new Thread(new ThreadStart(ThreadProc));
            t.Start();
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("主线程：" + i);
                Thread.Sleep(1000);
            }
            Console.WriteLine("调用Join函数等待次线程结束");
            //当次线程执行完毕后,Join阻塞调用线程，直到某个线程终止为止，本例为次线程  
            t.Join();
            Console.WriteLine("线程执行完毕");
            Console.ReadKey();
        }
        public static void ThreadProc()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("ThreadPorc:{0}", i);
                Thread.Sleep(1000);//将当前进程阻塞指定的毫秒数  
            }
        }
    }
}  
