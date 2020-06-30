using System;
using System.Collections.Generic;
using System.IO;


namespace ProjectZero.Library.RunnerClasses
{
    public class Product
    {
        private string _name;
        private double? _price;

        public string Name
        {
            get=>_name;
            set
            {
                if (value.Length > 0)
                {
                    _name = value;
                }
                else
                {
                    throw new Exception("Product Name must not be null.");
                }
            }
        }

        public double? Price
        {
            get => _price;
            set
            {
                if(value >= 0.00)
                {
                    _price = value;
                }
                else
                {
                    throw new Exception("Product Price must not be null.");
                }
            }
        }

        public int ProductId { get; set; }

        public List<Inventory> Inventory { get; set; } = new List<Inventory>();
        public List<StoreOrder> Reviews { get; set; } = new List<StoreOrder>();
        //public override string ToString()
        //{
        //    return "Product: " + Name + "=" + Cost.ToString("C2");
        //}
    }
}


//public int ProductId { get; set; }
//public string Name { get; set; }
//public decimal? Price { get; set; }

//public virtual ICollection<Inventory> Inventory { get; set; }
//public virtual ICollection<StoreOrder> StoreOrder { get; set; }
