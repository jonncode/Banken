using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Banken
{
    class Program
    {
        static List<Customer> bankCustomers = new List<Customer>(); // Initialize list to store all customers using constructor List<>()
        /// <summary>
        /// Execute functions based on the choice chosen in SelectMenuItem using switch-case
        /// Loop after case: is done, until user exits by changing bool value of notDone
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            bool notDone = true; //
            while (notDone == true)
            {
                int Choice = SelectMenuItem();
                switch (Choice)
                {
                    case 1:
                        AddCustomer();
                        pauseProgram();
                        break;
                    case 2: 
                        ShowCustomers();
                        RemoveCustomer();
                        pauseProgram();
                        break;
                    case 3:
                        ShowCustomers();
                        pauseProgram();
                        break;
                    case 4:
                        ShowCustomers();
                        ShowBalance();
                        pauseProgram();
                        break;
                    case 5:
                        ShowCustomers();
                        AddBalance();
                        pauseProgram();
                        break;
                    case 6:
                        SubtractBalance();
                        pauseProgram();
                        break;
                    case 7:
                        notDone = false;
                        break;
                }
            }
        }
        /// <summary>
        /// Run welcome text and return input choice from user into main
        /// </summary>
        /// <returns></returns>
        static public int SelectMenuItem()
        {
            Console.WriteLine("Välkommen till banken!");
            Console.WriteLine("");
            Console.WriteLine("Ange vilket av följande alternativ du önskar att göra");
            Console.WriteLine("");
            Console.WriteLine("1 : Lägga till en användare");
            Console.WriteLine("2 : Ta bort en användare");
            Console.WriteLine("3 : Visa alla befintliga användare");
            Console.WriteLine("4 : Visa saldo för en användare");
            Console.WriteLine("5 : Gör en insättning för en användare");
            Console.WriteLine("6 : Gör ett uttag för en användare");
            Console.WriteLine("7 : Avsluta programmet");
            Console.WriteLine("");
            Console.Write("Skriv in ditt val: ");
            return int.Parse(Console.ReadLine());
        }
        /// <summary>
        /// Create new customer instance and fill class attributes name and balance, add first transaction (starting balance) to list.
        /// Add instanc into list withholding all customer objects.
        /// </summary>
        static void AddCustomer() {
            Customer customer = new Customer(); // Instanciate object customer with the constructor Customer();
            Console.Write("Vad är ditt namn? ");
            customer.Name = Console.ReadLine();
            Console.Write("Vad är ditt saldo? ");
            var balanceInput = decimal.Parse(Console.ReadLine(), System.Globalization.CultureInfo.InvariantCulture); // Use datatype decimal for more accurate calculations regarding money, change culture to use "." instead of ","
            customer.Balance = balanceInput;
            bankCustomers.Add(customer);
            customer.transactions.Add(balanceInput);
            Console.WriteLine("Lade till ny användare!");
            string json = JsonConvert.SerializeObject(customer);
            System.IO.File.AppendAllText(@"C:\Users\jonaerik\Desktop\Data.txt", json);
        }
        /// <summary>
        /// Remove customer from list with customers.
        /// </summary>
        static void RemoveCustomer()
        {
            Console.Write("Vem vill du ta bort? ");
            int Choice = int.Parse(Console.ReadLine());
            bankCustomers.Remove(bankCustomers[Choice - 1]);
            Console.WriteLine("Tog bort användare!");
        }
        /// <summary>
        /// Use for-loop through list and print all customers using string formatting.
        /// </summary>
        static void ShowCustomers()
        {
            int i = 1;
            foreach (var customer in bankCustomers)
            {
                Console.WriteLine("[{0}] Namn: {1}", i, customer.Name);
                i++;
            }
        }
        /// <summary>
        /// Use user input to select customer, print said customer's Balance attribute
        /// </summary>
        static void ShowBalance()
        {
            Console.Write("Vem vill du visa? ");
            int chosenCustomer = int.Parse(Console.ReadLine());
            Console.WriteLine(bankCustomers[chosenCustomer - 1].ShowCustomerBalance);
        }
        /// <summary>
        /// Use user input to select customer, convert second input from string to decimal and add into customer's Balance attribute.
        /// Add transaction to transaction array
        /// </summary>
        static void AddBalance()
        {

            Console.Write("Vem vill du göra en insättning på? ");
            int chosenCustomer = int.Parse(Console.ReadLine());
            Console.Write("Hur mycket vill du göra en insättning på? ");
            var addedBalance = decimal.Parse(Console.ReadLine(), System.Globalization.CultureInfo.InvariantCulture); // Change culture to use "." instead of ","
            bankCustomers[chosenCustomer - 1].transactions.Add(addedBalance);
            bankCustomers[chosenCustomer - 1].Balance += addedBalance;
        }
        /// <summary>
        /// Use user input to select customer, convert second input from string to decimal.
        /// Multiply second input by -1 to easier store in transactions array.
        /// Add said input into customer's Balance attribute and said transaction into transaction array.
        /// </summary>
        static void SubtractBalance()
        {
            Console.Write("Vem vill du göra ett uttag på? ");
            int chosenCustomer = int.Parse(Console.ReadLine());
            Console.Write("Hur mycket vill du göra ett uttag på? ");
            var subtractedBalance = decimal.Parse(Console.ReadLine(), System.Globalization.CultureInfo.InvariantCulture); // Change culture to use "." instead of ","
            bankCustomers[chosenCustomer - 1].transactions.Add(subtractedBalance * -1);
            bankCustomers[chosenCustomer - 1].Balance += subtractedBalance * -1;
            foreach (var customer in bankCustomers[chosenCustomer - 1].transactions)
            {
                Console.WriteLine(customer);
            }
        }
        /// <summary>
        /// Simple pause between end of function and continuing notDone while-loop.
        /// </summary>
        static void pauseProgram()
        {
            Console.WriteLine("");
            Console.WriteLine("Klicka på valfri knapp för att fortsätta");
            Console.ReadKey();
            Console.WriteLine("");
        }
            
    }
}
