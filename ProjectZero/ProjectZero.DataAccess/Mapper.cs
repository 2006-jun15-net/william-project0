using System;
using System.Linq;
using ProjectZero.Library;

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







    }

    class Maps
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
                Customer = orderHist.Customer.Select(Map).ToList(),
                Location = orderHist.Location.Select(Map).ToList(),
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
                //Customer = Mapper.MapCustomer(orderHist.Customer.),
                Location = orderHist.Location.Select(Map).ToList(),
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

    }
}
