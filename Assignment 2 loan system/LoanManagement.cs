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
        private List<Loan> loans = new List<Loan>();
        private List<Customer> customers = new List<Customer>();
        private List<Equipment> equipment = new List<Equipment>();

        public void CreateLoan(Customer customer, Equipment equipment, DateTime loanDate, int loanDuration)
        {
            //Function designed to initialise a loan based on whether or not the asked equipment is available.
            if(equipment.IsAvailable)
            {
                DateTime returnDate = loanDate.AddDays(loanDuration);

                Loan newLoan = new Loan
                {
                    Customer = customer,
                    Equipment = equipment,
                    LoanDate = loanDate,
                    ReturnDate = returnDate
                };

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
        }

        public void UpdateLoan(Loan loan, DateTime returnDate)
        {
            //Function to allow updating date and time of loan
        }

        public List<Customer> FilterCustomers(string name)
        {
            //Filter customers by customer name
        }

        public List<Equipment> FilterEquipment(string name)
        {
            //Filter equipment by equipment name
        }

        public List<Loan> GenerateOverdueReport()
        {
            //Generation of "loan overdue" report
        }

        public decimal CalculateFine(Loan loan)
        {
            //Calculating the total fine the overdue loan has incurred
        }
    }
}
