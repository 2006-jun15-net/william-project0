using System.Collections.Generic;
using ProjectZero.Library.Model;

namespace ProjectZero.Library.Interfaces
{
    public interface IProZeroRepo
    {
        /// <summary>
        /// Get all orders with deferred execution.
        /// </summary>
        /// <returns>The collection of orders</returns>
        IEnumerable<StoreOrder> GetOrders(string search = null);

        /// <summary>
        /// Get a customer's storeorder by ID.
        /// </summary>
        /// <returns>The order</returns>
        StoreOrder GetOrderById(int id);

        /// <summary>
        /// Add a customer.
        /// </summary>
        /// <param name="customer">The customer</param>
        void AddCustomer(Customer customer);

        /// Display details of a single order.
        void DisplayOrderDetails(StoreOrder order);

        /// <summary>
        /// Persist changes to the data source.
        /// </summary>
        void Save();
    }
}
