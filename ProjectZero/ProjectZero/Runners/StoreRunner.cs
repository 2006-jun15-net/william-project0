﻿using ProjectZero.DataAccess;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

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
    }
}
