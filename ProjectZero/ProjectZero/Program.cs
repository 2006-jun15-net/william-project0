using System;
using System.Threading.Tasks;
using ProjectZero.Library;
using ProjectZero.Library.RunnerClasses;

namespace ProjectZero
{
    class Program
    {
        const string CUSTOMER_FILE = "../../../customers.json";
        const string PRODUCT_FILE = "../../../products.json";
        const string STORE_FILE = "../../../stores.json";

        static async Task Main(string[] args)
        {
            Console.WriteLine("Hi! Welcome to Willy's!");

            // Populate data from file, if any exists

            await StoreLoopAsync();
            
        }

        public static async Task StoreLoopAsync()
        {
            // Take input
            string choice = "";
            // Program loop
            while (choice != "q" && choice != "quit")
            {
                // Display user options
                Console.WriteLine("\n[option] - (operation to execute)");
                Console.WriteLine("cc - Create new customer.");
                Console.WriteLine("dc - Display table of customers.");
                Console.WriteLine("do - Display details of an order.");
                Console.WriteLine("soh - Display store order history.");
                Console.WriteLine("coh - Display customer order history.");
                Console.WriteLine("open - Open a new store location.");
                Console.WriteLine("place - Place a new order.");
                Console.WriteLine("search - Search for customer by name.");
                Console.WriteLine("(q or quit) - Quit program.");
                Console.WriteLine("[h or help] - Display help.\n");

                choice = Console.ReadLine();
                switch (choice.ToLower())
                {
                    case "cc":
                        await CustomerRunner.CreateCustomerAsync(CUSTOMER_FILE);
                        break;
                    case "dc":
                        await CustomerRunner.DisplayCustomersAsync(CUSTOMER_FILE);
                        break;
                    case "do":
                        Console.WriteLine("order deets");
                        break;
                    case "soh":
                        Console.WriteLine("store hist");
                        break;
                    case "coh":
                        Console.WriteLine("cust hist");
                        break;
                    case "open":
                        Console.WriteLine("new loaction");
                        break;
                    case "place":
                        Console.WriteLine("place order");
                        break;
                    case "search":
                        Console.WriteLine("Found " + CustomerRunner.SearchForCustomer(CUSTOMER_FILE));
                        break;
                    case "q":
                    case "quit":
                        break;
                    default:
                        continue; // Display help (user options).
                        // help could give more details about options instead.
                }
            }
            //////
        }

    }
}
