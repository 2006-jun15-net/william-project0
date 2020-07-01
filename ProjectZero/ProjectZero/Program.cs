using System;
using System.Threading.Tasks;
using ProjectZero.Library.RunnerClasses;

namespace ProjectZero
{
    class Program
    {
        

        static async Task Main(string[] args)
        {
            Console.WriteLine("Hi! Welcome to Willy's!");

            // Populate database
            await ProZeroRepo.CreateProZeroDbContextAsync();


            StoreLoopAsync();
            
        }

        public static void StoreLoopAsync()
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
                //Console.WriteLine("do - Display details of an order.");
                Console.WriteLine("do - Display orders.");
                Console.WriteLine("soh - Display store order history.");
                Console.WriteLine("coh - Display customer order history.");
                Console.WriteLine("open - Open a new store location.");
                Console.WriteLine("place - Place a new order.");
                Console.WriteLine("search - Search for customer by name.");
                Console.WriteLine("(q or quit) - Quit program.");
                Console.WriteLine("[h or help] - Display help.\n");

                try
                {
                    choice = Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Invalid input. {ex.Message}");
                }
                switch (choice.ToLower())
                {
                    case "cc":
                        CustomerRunner.CreateCustomer(); ///
                        break;
                    case "dc":
                        CustomerRunner.DisplayCustomers(); ///
                        break;
                    case "do":
                        OrderRunner.DisplayOrders(); ///
                        break;
                    case "soh":
                        StoreRunner.DisplayStoreHistory(); ///
                        break;
                    case "coh":
                        CustomerRunner.DisplayCustomerDetails(); ///
                        break;
                    case "open":
                        StoreRunner.CreateNewLocation(); /// 
                        break;
                    case "place":
                        StoreRunner.PlaceOrder(); /// buggy
                        break;
                    case "search":
                        CustomerRunner.DisplayCustomerSearch(); ///
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
