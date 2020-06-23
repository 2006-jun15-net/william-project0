using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectZero.Library
{
    class Order
    {
        Customer customer;
        Store store;
        string time;
        List<Product> products;

        public Customer Customer { get { return customer; } }
        public Store Store { get {return store; } }
        public string Time { get { return time; } }
        public List<Product> Products { get { return products; } }

        public Order(Customer customer, Store store, string time, List<Product> products)
        {
            this.customer = customer;
            this.store = store;
            this.time = time;
            this.products = products;
        }


        public override string ToString()
        {
            string productsString = string.Join(",", Products);
            return "Order: " + Customer + " | " + productsString + " | " + Store + " | " + Time;
        }
    }
}
