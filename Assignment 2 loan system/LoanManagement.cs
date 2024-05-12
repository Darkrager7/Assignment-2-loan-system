using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2_loan_system
{
    public class LoanManagement
    {
        public List<Loan> loans = new List<Loan>();
        public List<Customer> customers = new List<Customer>();
        public List<Equipment> equipment = new List<Equipment>();

        public void CreateLoan(Customer customer, Equipment equipment, DateTime loanDate, int loanDuration)
        {
            //Function designed to initialise a loan based on whether or not the asked equipment is available.
            if(equipment.IsAvailable)
            {
                DateTime returnDate = loanDate.AddDays(loanDuration);

                Loan newLoan = new Loan(customer, equipment, loanDate, returnDate);
                
                equipment.IsAvailable = false;

                loans.Add(newLoan);

                Console.WriteLine("Loan created."); 
            }
            else
            {
                Console.WriteLine("Error, equipment may not be available.");
            }
        }

        public List<Loan> FindLoan(string searchQuery)
        {
            //Search for finding loan related to customers or equipment
            return loans.Where(loan =>
                loan.Customer.Name.Contains(searchQuery, StringComparison.OrdinalIgnoreCase) ||
                loan.Equipment.Name.Contains(searchQuery, StringComparison.OrdinalIgnoreCase)).ToList();
        }
        public void UpdateLoan(Loan loan, DateTime returnDate)
        {
            //Function to allow updating date and time of loan
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
            return equipment.Where(e => e.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Loan> GenerateOverdueReport()
        {
            //Generation of "loan overdue" report
            return loans.Where(loan => loan.ReturnDate < DateTime.Today).ToList();
        }

        public decimal CalculateFine(Loan loan)
        {
            //Calculating the total fine the overdue loan has incurred
            TimeSpan overdueDuration = DateTime.Today - loan.ReturnDate;
            int overdueDays = overdueDuration.Days;
            decimal fineAmount = overdueDays * 10; //£10 per day overdue
            return fineAmount;
        }
    }
}

