using Newtonsoft.Json;
using ProjectZero.Library.Interfaces;
using ProjectZero.Library.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
//using NLog;


namespace ProjectZero.Library.RunnerClasses
{
    public class CustomerRunner //: IProZeroRepo
    {
        //private static readonly ILogger s_logger = LogManager.GetCurrentClassLogger();
        private static readonly ProZeroContext _dbContext;

        

        public static async Task CreateCustomerAsync()
        {
            Console.WriteLine("Enter first and last name (firstName lastName)");

            try
            {
                string[] tokens = Console.ReadLine().Split();
                string firstName = tokens[0].ToLower();
                string lastName = tokens[1].ToLower();

                if(firstName.Length < 1 || lastName.Length < 1)
                {
                    throw new Exception("First and/or last name was empty.");
                }

                Customer customer = new Customer(){FirstName = firstName, LastName=lastName};
                new CustomerRunner().AddCustomer(customer);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Customer not created. Expected: (firstName lastName). " + ex.Message);
            }
        }

        public static async Task DisplayCustomersAsync()
        {
            try
            {
                List<Customer> customerList = _dbContext.Customer.ToList();
                // IEnumerable<Customer>customers = _dbContext.Customer;
                foreach(Customer customer in customerList)
                {
                    Console.WriteLine("Customer: " + customer);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("No customers added. " + ex.Message);
            }
        }

        /// Search by first and last name
        public static List<Customer> SearchForCustomer()
        {
            Console.WriteLine("Enter first and last name to search (firstName lastName)");

            try
            {
                string[] tokens = Console.ReadLine().Split();
                string firstName = tokens[0].ToLower();
                string lastName = tokens[1].ToLower();
                
                List<Customer> foundCustomers = _dbContext.Customer
                .Where(c => c.FirstName == firstName && c.LastName == lastName).ToList();

                if(foundCustomers.Count > 0)
                {
                    return foundCustomers;
                } else {
                    throw new Exception("Customer not found exception.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        // Add customer to database
        void AddCustomer(Customer cust)
        {
            _dbContext.Customer.Add((Customer)cust);
            Save();   
        }

        Customer GetCustomerById(int id, int? id2)
        {
            throw new NotImplementedException();
        }

        public static void DisplayCustomerDetails()
        {
            List<Customer> customers = SearchForCustomer();   
            foreach (var cust in customers)
            {
                Console.WriteLine("Id: " + cust.CustomerId);
                Console.WriteLine("Order history: " + cust.OrderHistory);
            }
        }

        List<StoreOrder> GetCustomerOrderHistory(Customer customer)
        {
            List<StoreOrder> orders = _dbContext.Customer.Where(c => c.FirstName == customer.FirstName && c.LastName == customer.LastName)
            .SelectMany(o => o.OrderHistory)
            .SelectMany(h => h.StoreOrder).ToList();
            return orders;
        }
        void Save()
        {
            //s_logger.Info("Saving changes to the database");
            _dbContext.SaveChanges();
        }




////////////// Why is it doing this?
        // void IProZeroRepo.AddObject(object obj)
        // {

        // }
        // void IProZeroRepo.DisplayObjectDetails(object obj)
        // {

        // }
        // object IProZeroRepo.GetObjectById(int id, int? id2)
        // {
        //     throw new NotImplementedException();
        // }
        // IEnumerable<object> IProZeroRepo.GetOrders(object searchBy)
        // {
        //     throw new NotImplementedException();
        // }
        // void IProZeroRepo.Save()
        // {
        // }
    }
}
