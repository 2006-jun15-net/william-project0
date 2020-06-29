using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProjectZero.Library
{
    class Product
    {
        string Name { get; }
        double Cost { get; }

        public Product(string name, double cost)
        {
            Name = name;
            Cost = cost;
        }

        public static void DisplayProducts(string productFile)
        {
            try
            {
                FileOps.CheckFileExists(productFile);

                List<Product> productList;
                using (StreamReader file = File.OpenText(productFile))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    productList = (List<Product>)serializer.Deserialize(file, typeof(List<Product>))
                        ?? new List<Product>();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public override string ToString()
        {
            return "Product: " + Name + "=" + Cost.ToString("C2");
        }
    }
}
