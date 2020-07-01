using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectZero.Library.RunnerClasses
{
    public class StoreLocation
    {
        private string _name;
        private string _address;

        public int LocationId { get; set; }

        public string Name
        {
            get => _name;
            set
            {
                if(value.Length > 0)
                {
                    _name = value;
                }
                else
                {
                    throw new Exception("Store Name must not be null.");
                }
            }
        }
        public string Address
        {
            get => _address;
            set
            {
                if (value.Length > 0)
                {
                    _address = value;
                }
                else
                {
                    throw new Exception("Address must not be null.");
                }
            }
        }


        public List<Inventory> Inventory { get; set; } = new List<Inventory>();
        public List<OrderHistory> OrderHistory { get; set; } = new List<OrderHistory>();
    }
}



//public int LocationId { get; set; }
//public string Name { get; set; }
//public string Address { get; set; }

//public virtual ICollection<Inventory> Inventory { get; set; }
//public virtual ICollection<OrderHistory> OrderHistory { get; set; }