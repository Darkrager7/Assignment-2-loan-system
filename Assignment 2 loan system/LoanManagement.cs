using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2_loan_system
{
    public class LoanManagement
    {
        public List<Loan> loans = new List<Loan>();
        public List<Customer> customers = new List<Customer>();
        public List<Equipment> availableEquipment = new List<Equipment>(); //List of available equipment

        public List<Equipment> AvailableEquipment => availableEquipment;

        public LoanManagement(List<Equipment> initialEquipment)
        {
            availableEquipment.AddRange(initialEquipment); //Initialising list of available equipment
        }

        public void CreateLoan(Customer customer, string equipmentName, DateTime loanDate, int loanDuration)
        {
            //Find the equipment in the list of available equipment
            Equipment foundEquipment = availableEquipment.FirstOrDefault(e => e.Name.Equals(equipmentName, StringComparison.OrdinalIgnoreCase));

            if (foundEquipment != null && foundEquipment.IsAvailable)
            {
                //Calculate return date based on the loan duration
                DateTime returnDate = loanDate.AddDays(loanDuration);

                //Create a new loan object
                Loan newLoan = new Loan(customer, foundEquipment, loanDate, returnDate);

                //Mark equipment as unavailable
                foundEquipment.MarkUnavailable();

                //Add the new loan to the list of loans
                loans.Add(newLoan);

                Console.WriteLine("Loan created.");
            }
            else
            {
                Console.WriteLine("Error: Equipment is not available.");
            }
        }

        public List<Loan> FindLoan(string searchQuery)
        {
            //Search for loans related to customers or equipment
            return loans.Where(loan =>
                loan.Customer.Name.Contains(searchQuery, StringComparison.OrdinalIgnoreCase) ||
                loan.Equipment.Name.Contains(searchQuery, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public void UpdateLoan(Loan loan, DateTime returnDate)
        {
            //Function to allow updating the return date of a loan
            loan.ReturnDate = returnDate;
            Console.WriteLine("Loan updated successfully.");
        }

        public List<Customer> FilterCustomers(string name)
        {
            //Filter customers by customer name
            return customers.Where(c => c.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Equipment> FilterEquipment(string name)
        {
            //Filter equipment by equipment name
            return availableEquipment.Where(e => e.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Loan> GenerateOverdueReport()
        {
            //Generation of "loan overdue" report
            return loans.Where(loan => loan.ReturnDate < DateTime.Today).ToList();
        }

        public decimal CalculateFine(Loan loan)
        {
            //Calculate the total fine the overdue loan has incurred
            TimeSpan overdueDuration = DateTime.Today - loan.ReturnDate;
            int overdueDays = overdueDuration.Days;
            //£10 per day overdue
            decimal fineAmount = overdueDays * 10; 
            return fineAmount;
        }
    }
}

