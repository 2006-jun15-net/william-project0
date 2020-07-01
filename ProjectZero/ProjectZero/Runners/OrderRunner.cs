using ProjectZero.DataAccess;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
                Console.WriteLine("Invalid input. Order canceled.");
            }
        }

        public static void DisplayOrders()
        {
            try
            {
                List<StoreOrder> orderList = ProZeroRepo.DbContext.StoreOrder?.Select(Maps.Map).ToList() 
                    ?? throw new Exception("No orders in Database. Nothing to display.");

                foreach (StoreOrder order in orderList)
                {
                    Console.WriteLine("Order ID: " + order.OrderId + " | item qty: " + order.Amount + " | Product ID: " + order.ProductId);
                    // Could also display customer that placed the order by
                    // Selecting order history of customer where 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
