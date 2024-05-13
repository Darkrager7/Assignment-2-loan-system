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
            Console.WriteLine("Find and Update Loans");

            // Get search criteria from user
            Console.Write("Enter search query (customer name, equipment name, or loan date): ");
            string searchQuery = Console.ReadLine();

            // Find loans based on search query
            List<Loan> foundLoans = loanManagement.FindLoan(searchQuery);

            // Display search results
            if (foundLoans.Count > 0)
            {
                Console.WriteLine("Found Loans:");
                for (int i = 0; i < foundLoans.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {foundLoans[i]}");
                }

                // Prompt user to select a loan to update
                Console.Write("Enter the number of the loan you want to update (or 0 to cancel): ");
                int selectedIndex = Convert.ToInt32(Console.ReadLine());

                if (selectedIndex > 0 && selectedIndex <= foundLoans.Count)
                {
                    // Update selected loan
                    Loan selectedLoan = foundLoans[selectedIndex - 1];
                    Console.Write("Enter new return date (YYYY-MM-DD): ");
                    string newReturnDateString = Console.ReadLine();
                    if (DateTime.TryParse(newReturnDateString, out DateTime newReturnDate))
                    {
                        loanManagement.UpdateLoan(selectedLoan, newReturnDate);
                        Console.WriteLine("Loan updated successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid date format. Loan update cancelled.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid selection. Loan update cancelled.");
                }
            }
            else
            {
                Console.WriteLine("No loans found matching the search criteria.");
            }
        }

        static void FilterCustomersAndEquipment(LoanManagement loanManagement)
        {
            //Filter items/customer function
            Console.WriteLine("Filter Customers and Equipment");

            // Get filter criteria from user
            Console.Write("Enter name to filter by: ");
            string nameFilter = Console.ReadLine();

            // Filter customers
            List<Customer> filteredCustomers = loanManagement.FilterCustomers(nameFilter);

            // Display filtered customers
            Console.WriteLine("Filtered Customers:");
            foreach (Customer customer in filteredCustomers)
            {
                Console.WriteLine(customer);
            }

            // Filter equipment
            List<Equipment> filteredEquipment = loanManagement.FilterEquipment(nameFilter);

            // Display filtered equipment
            Console.WriteLine("Filtered Equipment:");
            foreach (Equipment equipment in filteredEquipment)
            {
                Console.WriteLine(equipment);
            }
        }

        static void ViewOverdueItemsAndFines(LoanManagement loanManagement)
        {
            //Overdue loans and fines function
            Console.WriteLine("View Overdue Items and Fines");

            // Get overdue loans from loan management
            List<Loan> overdueLoans = loanManagement.GenerateOverdueReport();

            // Check if there are any overdue loans
            if (overdueLoans.Count > 0)
            {
                Console.WriteLine("Overdue Items:");
                foreach (Loan loan in overdueLoans)
                {
                    // Calculate fine for the overdue loan
                    decimal fine = loanManagement.CalculateFine(loan);

                    // Display overdue loan details and fine
                    Console.WriteLine($"Customer: {loan.Customer.Name}, Equipment: {loan.Equipment.Name}, Return Date: {loan.ReturnDate}, Fine: £{fine}");
                }
            }
            else
            {
                Console.WriteLine("No overdue items found.");
            }
        }
    }
}