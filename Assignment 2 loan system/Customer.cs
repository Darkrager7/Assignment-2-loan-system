using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2_loan_system
{
    public class Customer
    {
        //Class designed to log customer details
        public string Name { get; set; }
        public string ContactDetails { get; set; }

        public Customer(string name, string contactDetails = "")
        {
            this.Name = name;
            this.ContactDetails = contactDetails;
        }

        public void UpdateName(string newName)
        {
            Name = newName;
        }

        public void UpdateContactDetails(string newContactDetails)
        {
            ContactDetails = newContactDetails;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Contact Details: {ContactDetails}";
        }

    }
}
