using System;
using System.Collections.Generic;
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

        public override string ToString()
        {
            return "Product: " + Name + "=" + Cost.ToString("C2");
        }
    }
}
