using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectZero.Library.RunnerClasses
{
    public class OrderHistory
    {
        private DateTime _date;
        private TimeSpan _time;

        public DateTime Date
        {
            get => _date;
            set
            {
                if (value == null)
                    throw new Exception("Order Date must not be null.");
                else
                    _date = value;
            }
        }

        public TimeSpan Time
        {
            get => _time;
            set
            {
                if (value == null)
                    throw new Exception("Order Time must not be null.");
                else
                    _time = value;
            }
        }


        public int OrderId { get; set; }
        public int? CustomerId { get; set; }
        public int? LocationId { get; set; }

        public List<Customer> Customer { get; set; } = new List<Customer>();
        public List<StoreLocation> Location { get; set; } = new List<StoreLocation>();
        public List<StoreOrder> StoreOrder { get; set; } = new List<StoreOrder>();

        //public override string ToString()
        //{
        //    string productsString = string.Join(",", Products);
        //    return "Order: " + productsString + " | " + Store + " | " + Time;
        //}
    }
}





//public int OrderId { get; set; }
//public DateTime Date { get; set; }
//public TimeSpan Time { get; set; }
//public int? CustomerId { get; set; }
//public int? LocationId { get; set; }

//public virtual Customer Customer { get; set; }
//public virtual StoreLocation Location { get; set; }
//public virtual ICollection<StoreOrder> StoreOrder { get; set; }