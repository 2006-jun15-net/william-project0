using System;
using System.Collections.Generic;

namespace ProjectZero.Library
{
    [Serializable()]
    public class Customer
    {
        string firstName, lastName;
        List<Order> history;

        public string FirstName
        {
            get { return firstName; }
        }
        public string LastName
        {
            get { return lastName; }
        }
       

        public string DefaultLocation { get; set; }

        public Customer(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            history = new List<Order>();
        }

        public override string ToString()
        {
            return "Customer: " + FirstName + " | " + LastName + " | " + string.Join(",", this.history);
        }

       
    }
}
