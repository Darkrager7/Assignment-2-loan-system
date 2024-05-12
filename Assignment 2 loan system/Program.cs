using Assignment_2_loan_system;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            //Load the LoanMangement class and create new instance
            LoanManagement loanManagement = new LoanManagement();

            //Main menu and welcome
            while (true)
            {
                Console.WriteLine("Welcome to GreenGear Rentals");
                Console.WriteLine("1. Record a new loan");
                Console.WriteLine("2. Find and update loans");
                Console.WriteLine("3. Filter customers and equipment");
                Console.WriteLine("4. View overdue items and fines");
                Console.WriteLine("5. Exit");
                Console.Write("Please enter your choice: ");

                //Reading user input
                string choice = Console.ReadLine();

                //User selecting the option they want to use
                switch (choice)
                {
                    case "1":
                        CreateLoan(loanManagement);
                        break;
                    case "2":
                        FindAndUpdateLoans(loanManagement);
                        break;
                    case "3":
                        FilterCustomersAndEquipment(loanManagement);
                        break;
                    case "4":
                        ViewOverdueItemsAndFines(loanManagement);
                        break;
                    case "5":
                        Console.WriteLine("Exiting program...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                //Linebreak
                Console.WriteLine(); 
            }
        }

        static void CreateLoan(LoanManagement loanManagement)
        {
            //Getting loan details from user input
            Console.Write("Enter customer name: ");
            string customerName = Console.ReadLine();

            Console.Write("Enter equipment name: ");
            string equipmentName = Console.ReadLine();

            Console.Write("Enter loan duration (in days): ");
            int loanDuration = Convert.ToInt32(Console.ReadLine());

            //Creating customer and equipment objects to record later
            Customer customer = new Customer(customerName);
            Equipment equipment = new Equipment(equipmentName);

            //Creation and recording new loan
            //Logging current date and time
            DateTime loanDate = DateTime.Now; 
            loanManagement.CreateLoan(customer, equipment, loanDate, loanDuration);

            Console.WriteLine("Loan recorded successfully.");
        }

        static void FindAndUpdateLoans(LoanManagement loanManagement)
        {
            //Search function
            Console.WriteLine("Not implemented");
        }

        static void FilterCustomersAndEquipment(LoanManagement loanManagement)
        {
            //Filter items/customer function
            Console.WriteLine("Not implemented");
        }

        static void ViewOverdueItemsAndFines(LoanManagement loanManagement)
        {
            //Overdue loans and fines function
            Console.WriteLine("Not implemented");
        }
    }
}