using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ProjectZero.Library.RunnerClasses
{
    public class CustomerRunner
    {
        public static async Task CreateCustomerAsync(string fileName)
        {
            Console.WriteLine("Enter first and last name (firstName lastName)");

            try
            {
                string[] tokens = Console.ReadLine().Split();
                string firstName = tokens[0].ToLower();
                string lastName = tokens[1].ToLower();

                FileStream fs;
                if (!File.Exists(fileName))
                {
                    fs = File.Create(fileName);
                    fs.Close();
                }

                List<Customer> customerList;
                using (StreamReader file = File.OpenText(fileName) )
                {
                    JsonSerializer serializer = new JsonSerializer();
                    customerList = (List<Customer>)serializer.Deserialize(file, typeof(List<Customer>))
                        ?? new List<Customer>();
                }

                customerList.Add(new Customer(firstName, lastName));
                // Convert customer and append to file
                string json = JsonConvert.SerializeObject(customerList);

                await File.WriteAllTextAsync(fileName, json);

                Console.WriteLine(Path.GetFullPath(fileName));
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception)
            {
                Console.WriteLine("Customer not created. Expected: (firstName lastName)");
            }

        }

        public static async Task DisplayCustomersAsync(string fileName)
        {
            try
            {
                using (StreamReader file = File.OpenText(fileName))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    List<Customer> customerList = (List<Customer>)serializer.Deserialize(file, typeof(List<Customer>));

                    foreach(Customer customer in customerList)
                    {
                        Console.WriteLine(customer);
                    }
                }
            }
            catch(IOException)
            {
                Console.WriteLine("No customers added or file not found.");
            }
            catch(Exception ex)
            {
                Console.WriteLine("No customers added. " + ex.Message);
            }
        }

        public static Customer SearchForCustomer(string fileName)
        {
            Console.WriteLine("Enter first and last name to search (firstName lastName)");
            string[] tokens = Console.ReadLine().Split();
            string firstName = tokens[0].ToLower();
            string lastName = tokens[1].ToLower();

            Customer customer = new Customer("", "");
            try
            {
                using (StreamReader file = File.OpenText(fileName))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    List<Customer> customerList = (List<Customer>)serializer.Deserialize(file, typeof(List<Customer>));

                    foreach (Customer cust in customerList)
                    {
                        if(cust.FirstName == firstName && cust.LastName == lastName)
                        {
                            customer = cust;
                            Console.WriteLine(customer);
                        }
                        
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Customer not found.");
            }

            return customer;
        }
    }
}
