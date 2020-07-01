using ProjectZero.DataAccess;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

namespace ProjectZero.Library.RunnerClasses
{
    public class StoreRunner
    {
        public static void DisplayStoreHistory()
        {
            Console.WriteLine("Enter the name of the store to get its order history.");
            try
            {
                string name = Console.ReadLine();
                GetStoreHistoryByName(name);
            }
            catch
            {
                Console.WriteLine("Invalid name entered.");
            }
            
        }
        public static void GetStoreHistoryByName(string name)
        {
            try
            {
                StoreLocation store = Mapper.MapLocation(ProZeroRepo.DbContext.StoreLocation?.Where(l => l.Name == name).First())
                    ?? throw new Exception($"No orders placed at {name}");

                //store.OrderHistory.First().
                foreach(OrderHistory order in store.OrderHistory)
                {
                    Console.WriteLine("Order: { CustomerID: " + order.CustomerId +
                        " | OrderID: " + order.OrderId +
                        "} was placed on " + order.Date + " @ " + order.Time);
                }

                if (store == null)
                {
                    Console.WriteLine("Store not found");
                    return;
                }

                List<StoreOrder> history = ProZeroRepo.DbContext.StoreOrder
                    .Where(s => s.Order.LocationId == store.LocationId)
                    .Select(Maps.Map).ToList();

                foreach(StoreOrder order in history)
                {
                    Console.WriteLine("Order ID: " + order.OrderId + " | item qty: " + order.Amount + " | Product ID: " + order.ProductId);
                    // Could also display customer that placed the order by
                    // Selecting order history of customer where
                }
            }
            catch
            {
                Debug.WriteLine("Exception getting store history in StoreRunner.");
            }
        }

        public static void PlaceOrder()
        {
            Console.WriteLine("Enter the name of a product to order");
            string name = Console.ReadLine();
            // GetProductByName
            var entProd = ProZeroRepo.DbContext.Product.Where(p => p.Name == name).First();

            // Get store location
            Console.WriteLine("Enter the name of a location to order from.");
            string storeName = Console.ReadLine();
            var entLoc = ProZeroRepo.DbContext.StoreLocation.First(s => s.Name == storeName);

            int? stockQty = entLoc?.Inventory?.Select(i => i.Amount)?.First() ?? 0;

            if(stockQty == 0)
            {
                Console.WriteLine("This product is out of stock.");
                return;
            }

            while (true)
            {
                Console.WriteLine("Enter the quantity of a product to order or 0 (zero) to cancel order.");
                int qty = int.Parse(Console.ReadLine());

                // check if that is too many.
                if(stockQty >= qty && qty > 0)
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
                            StoreOrder = new Collection<DataAccess.Model.StoreOrder>() { sord},
                            Customer = new DataAccess.Model.Customer() { FirstName = firstName, LastName = lastName}
                        }
                      );
                    // Save changes to database
                    ProZeroRepo.DbContext.SaveChanges();
                }
                if(qty == 0)
                {
                    Console.WriteLine("Canceling order...");
                }
            }
        }

        public static void CreateNewLocation()
        {
            try
            {
                Console.WriteLine("Enter a location name: ");
                string locName = Console.ReadLine();
                Console.WriteLine("Enter address of your new location.");
                string addr = Console.ReadLine();

                // Check if location already exists.

                // Add some inventory

                DataAccess.Model.StoreLocation entLoc =
                    new DataAccess.Model.StoreLocation()
                    {
                        Name = locName,
                        Address = addr,
                        Inventory = new Collection<DataAccess.Model.Inventory>()
                    };
                    
                ProZeroRepo.DbContext.StoreLocation.Add(entLoc);
                ProZeroRepo.DbContext.SaveChanges();
                Console.WriteLine("Location was added successfully.");
            }
            catch
            {
                Console.WriteLine("Location already exists or input was invalid.");
            }
            
        }
    }
}
