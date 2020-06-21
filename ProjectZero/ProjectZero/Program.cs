using System;

namespace ProjectZero
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hi! Welcome to Willy's!");

            // Populate data from file, if any exists

            StoreLoop();
            
        }

        public static void StoreLoop()
        {
            // Take input
            string choice = "";
            // Program loop
            while (choice != "q")
            {
                // Display user options
                Console.WriteLine("[option] - (operation to execute)");
                Console.WriteLine("cc - Create new customer.");
                Console.WriteLine("dc - Display table of customers.");
                Console.WriteLine("do - Display details of an order.");
                Console.WriteLine("soh - Display store order history.");
                Console.WriteLine("coh - Display customer order history.");
                Console.WriteLine("open - Open a new store location.");
                Console.WriteLine("place - Place a new order.");
                Console.WriteLine("search - Search for customer by name.");
                Console.WriteLine("(q or quit) - Quit program.");
                Console.WriteLine("[h or help] - Display help.");

                choice = Console.ReadLine();
                switch (choice.ToLower())
                {
                    case "cc":
                        Program.CreateCustomer();
                        break;
                    case "dc":
                        Console.WriteLine("cust table");
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
                        Console.WriteLine("search for customer");
                        break;
                    case "q":
                    case "quit":
                        Console.WriteLine("quit");
                        break;
                    default:
                        continue; // Display help (user options).
                        // help could give more details about options instead.
                }
            }
            //////
        }

        private static void CreateCustomer()
        {
            Console.WriteLine("Enter first and last name (firstName lastName)");

        }
    }
}
