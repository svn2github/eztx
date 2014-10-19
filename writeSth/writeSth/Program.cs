using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace writeSth
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\MyTest.txt";
            try
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }

                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine("This");
                    sw.WriteLine("is some text");
                    sw.WriteLine("to test");
                    sw.WriteLine("Reading");
                    sw.WriteLine("Complete");
                }

                using (StreamReader sr = new StreamReader(path))
                {
                    while (sr.Peek() >= 0)
                    {
                        string str = sr.ReadLine();
                        Console.WriteLine(str);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
            Console.Read();
        }
    }
}
