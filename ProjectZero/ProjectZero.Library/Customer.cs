using System;

namespace ProjectZero.Library
{
    public class Customer
    {
        string FirstName { get; }
        string LastName { get; }
        string DefaultLocation { get; set; }

        public Customer(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

    }
}
