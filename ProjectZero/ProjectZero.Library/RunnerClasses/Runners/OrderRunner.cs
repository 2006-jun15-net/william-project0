using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace ProjectZero.Library.RunnerClasses
{
    class OrderRunner
    {
        public static void PlaceOrder(string fileName)
        {
            Console.WriteLine("Enter a name for your order (firstName lastName)");

            try
            {
                string[] tokens = Console.ReadLine().Split();
                string firstName = tokens[0].ToLower(),
                        lastName = tokens[1].ToLower();

                Console.WriteLine("Enter product code to order:");




            }
            catch (Exception)
            {
                Console.WriteLine("Order canceled");
            }
        }
    }
}
