using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomerStruct
{
    public struct CustomerStruct
    {
        public int ID;
        public string name;
        public Customer(int customerID,String customerName)
        {
            ID=customerID;
            name=customerName;
        }
    }
    
    class TestClass
    {
        public static void Main(string[] args)
        {
            CustomerStruct customer=new CustomerStruct();
            System.Console.WriteLine("Struct values before initialization");
            System.Console.WriteLine("ID={0},Name={1}",customer.ID,customer.name);

            customer.ID=100;
            customer.name="Robert";
            System.Console.WriteLine("Struct values after initialization");
            System.Console.WriteLine("ID={0},Name={1}",customer.ID,customer.name);
        }
    }
}
