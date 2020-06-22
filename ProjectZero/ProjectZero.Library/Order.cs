using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectZero.Library
{
    class Order
    {
        Customer Customer { get; }
        Store Store { get; }
        string Time { get; }
        List<Product> Products { get; }

        public Order(Customer customer, Store store, string time, List<Product> products)
        {
            Customer = customer;
            Store = store;
            Time = time;
            Products = products;
        }


        public override string ToString()
        {
            string productsString = string.Join(",", Products);
            return "Order: " + Customer + " | " + productsString + " | " + Store + " | " + Time;
        }
    }
}
