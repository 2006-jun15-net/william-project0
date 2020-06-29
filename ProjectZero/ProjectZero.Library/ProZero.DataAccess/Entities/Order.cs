using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectZero.Library
{
    class Order
    {
        Store store;
        string time;
        List<Product> products;

        public Store Store { get {return store; } }
        public string Time { get { return time; } }
        public List<Product> Products { get { return products; } }

        public Order(Store store, string time, List<Product> products)
        {
            this.store = store;
            this.time = time;
            this.products = products;
        }


        public override string ToString()
        {
            string productsString = string.Join(",", Products);
            return "Order: " + productsString + " | " + Store + " | " + Time;
        }
    }
}
