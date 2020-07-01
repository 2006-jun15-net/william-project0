using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectZero.DataAccess
{
    /// <summary>
    /// Map from RunnerClasses <=> Model
    /// Does null checking on Model (partial) classes
    /// </summary>
    public class Mapper
    {
        /// <summary>
        /// Customer Mappers
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public static Library.RunnerClasses.Customer MapCustomer(Model.Customer customer)
        {
            return new Library.RunnerClasses.Customer
            {
                CustomerId = customer.CustomerId,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                OrderHistory = customer.OrderHistory.Select(Maps.Map).ToList()
            };
        }
        public static Model.Customer MapCustomer(Library.RunnerClasses.Customer customer)
        {
            return new Model.Customer
            {
                CustomerId = customer.CustomerId,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                OrderHistory = customer.OrderHistory.Select(Maps.Map).ToList(),
            };
        }
        /// <summary>
        /// Map StoreLocation from RunnerClasses <=> Model
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public static Library.RunnerClasses.StoreLocation MapLocation(Model.StoreLocation location)
        {
            return new Library.RunnerClasses.StoreLocation
            {
                LocationId = location.LocationId,
                Address = location.Address,
                Name = location.Name,
                Inventory = location.Inventory.Select(Maps.Map).ToList(),
                OrderHistory = location.OrderHistory.Select(Maps.Map).ToList()
            };
        }
        public static Model.StoreLocation MapLocation(Library.RunnerClasses.StoreLocation location)
        {
            return new Model.StoreLocation
            {
                LocationId = location.LocationId,
                Address = location.Address,
                Name = location.Name,
                Inventory = location.Inventory.Select(Maps.Map).ToList(),
                OrderHistory = location.OrderHistory.Select(Maps.Map).ToList()
            };
        }
        /// <summary>
        /// Map Product from RunnerClasses <=> Model
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public static Library.RunnerClasses.Product MapProduct(Model.Product product)
        {
            return new Library.RunnerClasses.Product
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Price = product.Price ?? 0.00m,
                StoreOrder = product.StoreOrder.Select(Maps.Map).ToList(),
                Inventory = product.Inventory.Select(Maps.Map).ToList()
            };
        }
        public static Model.Product MapProduct(Library.RunnerClasses.Product product)
        {
            return new Model.Product
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Price = product.Price ?? throw new Exception("Null Price on Product in mapper maps."),
                StoreOrder = product.StoreOrder.Select(Maps.Map).ToList(),
                Inventory = product.Inventory.Select(Maps.Map).ToList()
            };
        }








    }

    public class Maps
    {
        /// <summary>
        /// Maps OrderHistory to other OrderHistory
        /// </summary>
        /// <param name="orderHist"></param>
        /// <returns></returns>
        public static Library.RunnerClasses.OrderHistory Map(Model.OrderHistory orderHist)
        {
            return new Library.RunnerClasses.OrderHistory
            {
                OrderId = orderHist.OrderId,
                CustomerId = orderHist.CustomerId ?? throw new Exception("Null Customer Id in mapper maps."),
                LocationId = orderHist.LocationId ?? throw new Exception("Null Location ID in Mapper Maps"),
                Date = orderHist.Date,
                Time = orderHist.Time,
                Customer = Mapper.MapCustomer(orderHist.Customer),
                Location = Mapper.MapLocation(orderHist.Location),
                StoreOrder = orderHist.StoreOrder.Select(Map).ToList()
            };
        }
        public static Model.OrderHistory Map(Library.RunnerClasses.OrderHistory orderHist)
        {
            return new Model.OrderHistory
            {
                OrderId = orderHist.OrderId,
                CustomerId = orderHist.CustomerId ?? throw new Exception("Null Customer Id in mapper maps."),
                LocationId = orderHist.LocationId ?? throw new Exception("Null Location ID in Mapper Maps"),
                Date = orderHist.Date,
                Time = orderHist.Time,
                Customer = Mapper.MapCustomer(orderHist.Customer),
                Location = Mapper.MapLocation(orderHist.Location),
                StoreOrder = orderHist.StoreOrder.Select(Map).ToList()
            };
        }
        /// <summary>
        /// Maps Customer to other Customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public static Library.RunnerClasses.Customer Map(Model.Customer customer)
        {
            return new Library.RunnerClasses.Customer
            {
                CustomerId = customer.CustomerId,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                OrderHistory = customer.OrderHistory.Select(Map).ToList()
            };
        }
        public static Model.Customer Map(Library.RunnerClasses.Customer customer)
        {
            return new Model.Customer
            {
                CustomerId = customer.CustomerId,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                OrderHistory = customer.OrderHistory.Select(Map).ToList()
            };
        }
        /// <summary>
        /// Maps Inventory to other Inventory
        /// </summary>
        /// <param name="inventory"></param>
        /// <returns></returns>
        public static Library.RunnerClasses.Inventory Map(Model.Inventory inventory)
        {
            return new Library.RunnerClasses.Inventory
            {
                LocationId = inventory.LocationId,
                ProductId = inventory.ProductId,
                Amount = inventory.Amount ?? throw new Exception("Null amount of inventory in mapper maps."),
                Location = Mapper.MapLocation(inventory.Location),
                Product = Mapper.MapProduct(inventory.Product)
            };
        }
        public static Model.Inventory Map(Library.RunnerClasses.Inventory inventory)
        {
            return new Model.Inventory
            {
                LocationId = inventory.LocationId,
                ProductId = inventory.ProductId,
                Amount = inventory.Amount ?? throw new Exception("Null amount of inventory in mapper maps."),
                Location = Mapper.MapLocation(inventory.Location),
                Product = Mapper.MapProduct(inventory.Product)
            };
        }
        /// <summary>
        /// Maps StoreOrder to other StoreOrder
        /// </summary>
        /// <param name="storeOrder"></param>
        /// <returns></returns>
        public static Library.RunnerClasses.StoreOrder Map(Model.StoreOrder storeOrder)
        {
            return new Library.RunnerClasses.StoreOrder
            {
                OrderId = storeOrder.OrderId,
                ProductId = storeOrder.ProductId,
                Amount = storeOrder.Amount ?? throw new Exception("Null amount of StoreOrder in mapper maps.")
            };
        }
        public static Model.StoreOrder Map(Library.RunnerClasses.StoreOrder storeOrder)
        {
            return new Model.StoreOrder
            {
                OrderId = storeOrder.OrderId,
                ProductId = storeOrder.ProductId,
                Amount = storeOrder.Amount ?? throw new Exception("Null amount of StoreOrder in mapper maps.")
            };
        }

    }
}
