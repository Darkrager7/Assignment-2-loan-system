using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2_loan_system
{
    public class Equipment
    {
        //Class to track equipment by name and availability
        public string Name { get; set; }
        public bool IsAvailable { get; private set; }

        public Equipment(string name)
        {
            Name = name;
            IsAvailable = true; //Make all equipment available on start
        }

        public void MarkUnavailable()
        {
            IsAvailable = false;
        }

        public void MarkAvailable()
        {
            IsAvailable = true;
        }

        public override string ToString()
        {
            string availability = IsAvailable ? "Available" : "Not Available";
            return $"Name: {Name}, Availability: {availability}";
        }
    }
}
