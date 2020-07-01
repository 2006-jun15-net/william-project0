using ProjectZero.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectZero.DataAccess;
using System.Diagnostics;
//using NLog;


namespace ProjectZero.Library.RunnerClasses
{
    public class CustomerRunner //: IProZeroRepo
    {
        //private static readonly ILogger s_logger = LogManager.GetCurrentClassLogger();
        //private readonly DataAccess.Model.ProZeroContext _dbContext;

        public static string[] SplitGetFirstAndLast(string firstLast)
        {
            return firstLast.Split();
        }


        public static void CreateCustomer()
        {
            Console.WriteLine("Enter first and last name (firstName lastName)");
            string[] tokens = Console.ReadLine().Split();
            string firstName = tokens[0].ToLower();
            string lastName = tokens[1].ToLower();
            try
            {
                

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

        public static void DisplayCustomerSearch()
        {
            Console.WriteLine("Enter first and last name to search (firstName lastName)");
            List<Customer> foundCustomers = SearchForCustomer(Console.ReadLine());

            foreach(Customer cust in foundCustomers)
            {
                Console.WriteLine("Customer: " + cust.FirstName + " " + cust.LastName);
            }
        }

        /// Search by first and last name
        public static List<Customer> SearchForCustomer(string firstLast)
        {
            try
            {
                string[] tokens = firstLast.Split();
                string firstName = tokens[0].ToLower();
                string lastName = tokens[1].ToLower();

                List<Customer> allCustomers = ProZeroRepo.DbContext.Customer.Select(Maps.Map).ToList();
                List<Customer> foundCustomers = new List<Customer>();

                // Get all customers
                if (allCustomers == null) throw new Exception("No customers in Database.");
                


                foreach(Customer cust in allCustomers)
                {
                    if(cust.FirstName == firstName && cust.LastName == lastName)
                    {
                        // remove cust from foundCustomers
                        Debug.WriteLine(cust.FirstName);
                        foundCustomers.Add(cust);
                    }
                }

                if (foundCustomers.Count > 0)
                {
                    return foundCustomers;
                }
                else
                {
                    Console.WriteLine("Customer not found.");
                    return new List<Customer>();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return new List<Customer>();
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

        /// <summary>
        /// Case "coh"
        /// Display details of customer.
        /// </summary>
        public static void DisplayCustomerDetails()
        {
            Console.WriteLine("Enter first and last name to search (firstName lastName)");
            List<Customer> customers = SearchForCustomer(Console.ReadLine());

            foreach (var cust in customers)
            {
                Console.WriteLine("Id: " + cust.CustomerId);

                // Get order history
                List<StoreOrder> orders = GetCustomerOrderHistory(cust);
                Console.Write("Order history: ");
                foreach(StoreOrder order in orders)
                {
                    // GetProductById
                    var query = ProZeroRepo.DbContext.Product.Where(p => p.ProductId == order.ProductId)
                        .FirstOrDefault();
                    Product product = Mapper.MapProduct(query);
                    Console.Write("{ qty=" + order.Amount + ": " + product.Name + " }");
                }
                Console.WriteLine();
            }
        }

        public static List<StoreOrder> GetCustomerOrderHistory(Customer customer)
        {
            var orders = ProZeroRepo.DbContext.Customer
                .Where(c => c.FirstName == customer.FirstName && c.LastName == customer.LastName)
                .SelectMany(o => o.OrderHistory)
                .SelectMany(h => h.StoreOrder);

            return orders.Select(Maps.Map).ToList();
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
