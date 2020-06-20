using System;

namespace ProjectZero
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hi! Welcome to Willy's!");

            // Populate data from file, if any exists

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

            


        }
    }
}
