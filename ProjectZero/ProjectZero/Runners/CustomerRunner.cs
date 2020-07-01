using ProjectZero.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectZero.DataAccess;
//using NLog;


namespace ProjectZero.Library.RunnerClasses
{
    public class CustomerRunner //: IProZeroRepo
    {
        //private static readonly ILogger s_logger = LogManager.GetCurrentClassLogger();
        //private readonly DataAccess.Model.ProZeroContext _dbContext;



        public static void CreateCustomer()
        {
            Console.WriteLine("Enter first and last name (firstName lastName)");

            try
            {
                string[] tokens = Console.ReadLine().Split();
                string firstName = tokens[0].ToLower();
                string lastName = tokens[1].ToLower();

                if (firstName.Length < 1 || lastName.Length < 1)
                {
                    throw new Exception("First and/or last name was empty.");
                }

                DataAccess.Model.Customer customer = new DataAccess.Model.Customer() { FirstName = firstName, LastName = lastName };
                new CustomerRunner().AddCustomer(customer);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Customer not created. Expected: (firstName lastName). " + ex.Message);
            }
        }

        public static void DisplayCustomers()
        {
            try
            {
                List<Customer> customerList = ProZeroRepo.DbContext.Customer.Select(Maps.Map).ToList();
                if(customerList == null) throw new Exception("No customers in Database. Nothing to display.");
                // IEnumerable<Customer>customers = _dbContext.Customer;
                foreach (Customer customer in customerList)
                {
                    Console.WriteLine("Customer: " + customer.FirstName + " " + customer.LastName);
                }
            }
            catch (Exception ex)
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

                List<Customer> foundCustomers = ProZeroRepo.DbContext.Customer.Select(Maps.Map).ToList();

                if (foundCustomers == null) throw new Exception("No customers in Database.");
                //.Where(c => c.FirstName == firstName && c.LastName == lastName).ToList();
                foreach(Customer cust in foundCustomers)
                {
                    if(cust.FirstName != firstName || cust.LastName != lastName)
                    {
                        foundCustomers.Remove(cust);
                    }
                }

                if (foundCustomers.Count > 0)
                {
                    return foundCustomers;
                }
                else
                {
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
        void AddCustomer(DataAccess.Model.Customer cust)
        {
            if (cust == null) throw new Exception("null cust");
            if (ProZeroRepo.DbContext == null) throw new Exception("It's not good.");
            ProZeroRepo.DbContext.Customer.Add(cust);
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

        List<DataAccess.Model.StoreOrder> GetCustomerOrderHistory(Customer customer)
        {
            List<DataAccess.Model.StoreOrder> orders = ProZeroRepo.DbContext.Customer.Where(c => c.FirstName == customer.FirstName && c.LastName == customer.LastName)
            .SelectMany(o => o.OrderHistory)
            .SelectMany(h => h.StoreOrder).ToList();
            return orders;
        }
        void Save()
        {
            //s_logger.Info("Saving changes to the database");
            ProZeroRepo.DbContext.SaveChanges();
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
