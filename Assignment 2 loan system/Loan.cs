using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2_loan_system
{
    public class Loan
    {
        //Class to track loans via the customer, equipment loaned, and the date/time of the loan
        public Customer Customer { get; set; }
        public Equipment Equipment { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime ReturnDate { get; set; }

        public Loan(Customer customer, Equipment equipment, DateTime loanDate, DateTime returnDate)
        {
            this.Customer = customer;
            this.Equipment = equipment;
            this.LoanDate = loanDate;
            this.ReturnDate = returnDate;
        }

        public void UpdateReturnDate(DateTime newReturnDate)
        {
            ReturnDate = newReturnDate;
        }

        public override string ToString()
        {
            return $"Customer: {Customer.Name}, Equipment: {Equipment.Name}, Loan Date: {LoanDate}, Return Date: {ReturnDate}";
        }

    }
}
