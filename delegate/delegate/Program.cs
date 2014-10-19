using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace @delegate
{
    public delegate void GreetingDelegate(string name);

    //新建的GreetingManager类
    public class GreetingManager
    {

        public event GreetingDelegate gd;

        public void GreetPeople(string name)
        {
            gd(name);
        }
    }

    class Program
    {
        //注意此方法，它接受k一个GreetingDelegate类型的方法作为参数
        private static void AGreeting(string name)
        {
            Console.WriteLine("A said: " + name);
        }

        private static void BGreeting(string name)
        {
            Console.WriteLine("B said: " + name);
        }

        static void Main(string[] args)
        {
            string getInput = null;
            GreetingManager gm = new GreetingManager();
            gm.gd -= AGreeting;
            gm.gd += BGreeting;

            Console.Write("Please input your favorite word:");
            getInput = Console.ReadLine();
            gm.GreetPeople(getInput);
            Console.ReadKey();
        }
    }
}