using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2_loan_system
{
    public class Equipment
    {
        //class to track equipment by name and availability
        public string Name { get; set; }
        public bool IsAvailable { get; set; }

        public Equipment(string name)
        {
            Name = name;
            IsAvailable = true;
        }

        public void UpdateName(string newName)
        {
            Name = newName;
        }

        public void MarkAvailable()
        {
            IsAvailable = true;
        }

        public void MarkUnavailable()
        {
            IsAvailable = false;
        }

        public override string ToString()
        {
            string availability = IsAvailable ? "Available" : "Not Available";
            return $"Name: {Name}, Availability: {availability}";
        }
    }
}
