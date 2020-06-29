using System;
using System.Collections.Generic;
using ProjectZero.Library.Model;

namespace ProjectZero.DataAccess.Entities
{
    [Serializable()]
    public class Customer
    {
        public string FirstName{ get; set; }
        public string LastName{ get; set; }
        public int CustomerId { get; set; }
        public string Email { get; set; }
        public virtual ICollection<OrderHistory> OrderHistory { get; set; }
       

        public string DefaultLocation { get; set; }

        public Customer()
        {
            OrderHistory = new HashSet<OrderHistory>();
        }

        public override string ToString()
        {
            return "Customer: " + FirstName + " | " + LastName + " | " + string.Join(",", OrderHistory);
        }

       
    }
}
