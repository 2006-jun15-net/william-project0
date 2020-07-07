using ProjectZero.DataAccess;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;


namespace ProjectZero.Library.RunnerClasses
{
    public class OrderRunner
    {
        public static void PlaceOrder()
        {
            Console.WriteLine("Enter the name of a product to order");
            try
            {
                string prodName = Console.ReadLine().ToLower();
                // GetProductByName
                var entProd = ProZeroRepo.DbContext.Product.Where(p => p.Name == prodName).First() ??
                    new DataAccess.Model.Product();

                // Get store location
                Console.WriteLine("Enter the name of a location to order from.");
                string storeName = Console.ReadLine().ToLower();
                ////////// Fix this
                DataAccess.Model.StoreLocation entLoc =
                    ProZeroRepo.DbContext.StoreLocation
                    .Where(l => l.Name == storeName)
                     ??
                        throw new Exception("No such location was found.");
                if(entLoc.Inventory.Count < 1)
                {
                    Debug.WriteLine("No inventory or failed to map");
                }

                ///
                int stockQty = entLoc.Inventory.Where(i => i.Location.Name == storeName)
                    .Where(p => p.Product.Name == prodName)
                    .First()
                    .Amount ??
                        throw new Exception("No such location was found.");
   //             System.InvalidOperationException: Sequence contains no elements
   //at System.Linq.ThrowHelper.ThrowNoElementsException()
   //at System.Linq.Enumerable.First[TSource](IEnumerable`1 source)
   //at ProjectZero.Library.RunnerClasses.OrderRunner.PlaceOrder() in C:\Revature\code\william - project0\ProjectZero\ProjectZero\Runners\OrderRunner.cs:line 29

                if (stockQty == 0)
                {
                    Console.WriteLine("This product is out of stock.");
                    return;
                }

                while (true)
                {
                    Console.WriteLine("Enter the quantity of a product to order or 0 (zero) to cancel order.");
                    int qty = int.Parse(Console.ReadLine());

                    // check if that is too many.
                    if (stockQty >= qty && qty > 0)
                    {
                        Console.WriteLine("What is the name for this order? (firstName lastName)");
                        string[] tokens = Console.ReadLine().Split();
                        string firstName = tokens[0].ToLower();
                        string lastName = tokens[1].ToLower();

                        stockQty -= qty;
                        var sord = new DataAccess.Model.StoreOrder()
                        {
                            Amount = stockQty,
                            Product = entProd,
                            Order = null
                        };
                        ProZeroRepo.DbContext.StoreOrder.Add(sord);

                        ProZeroRepo.DbContext.OrderHistory.Add(
                            new DataAccess.Model.OrderHistory()
                            {
                                Date = DateTime.Now.Date,
                                Time = DateTime.Now.TimeOfDay,
                                Location = entLoc,
                                StoreOrder = new Collection<DataAccess.Model.StoreOrder>() { sord },
                                Customer = new DataAccess.Model.Customer() { FirstName = firstName, LastName = lastName }
                            }
                          );
                        // Save changes to database
                        ProZeroRepo.DbContext.SaveChanges();
                    }
                    // Cancel order
                    if (qty == 0)
                    {
                        Console.WriteLine("Canceling order...");
                    }
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                Console.WriteLine(ex);
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
