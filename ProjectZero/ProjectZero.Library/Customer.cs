using System;

namespace ProjectZero.Library
{
    [Serializable()]
    public class Customer
    {
        string firstName, lastName;

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
        }

        public override string ToString()
        {
            return "Customer: " + FirstName + " " + LastName;
        }

       
    }
}
