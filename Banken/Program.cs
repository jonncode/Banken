using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banken
{
    class Program
    {
        static List<Customer> bankCustomers = new List<Customer>();
        static void Main(string[] args)
        {
            bool notDone = true;
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
        static void AddCustomer() {
            Customer customer = new Customer();
            Console.Write("Vad är ditt namn? ");
            customer.Name = Console.ReadLine();
            Console.Write("Vad är ditt saldo? ");
            var balanceInput = decimal.Parse(Console.ReadLine(), System.Globalization.CultureInfo.InvariantCulture);
            customer.Balance = Math.Round(balanceInput, 2);
            bankCustomers.Add(customer);
            customer.transactions.Add(balanceInput);
            Console.WriteLine("Lade till ny användare!");
        }
        static void RemoveCustomer()
        {
            Console.Write("Vem vill du ta bort? ");
            int Choice = int.Parse(Console.ReadLine());
            bankCustomers.Remove(bankCustomers[Choice - 1]);
            Console.WriteLine("Tog bort användare!");
        }
        static void ShowCustomers()
        {
            int i = 1;
            foreach (var customer in bankCustomers)
            {
                Console.WriteLine("[{0}] Namn: {1}", i, customer.Name);
                i++;
            }
        }
        static void ShowBalance()
        {
            Console.Write("Vem vill du visa? ");
            int chosenCustomer = int.Parse(Console.ReadLine());
            Console.WriteLine(bankCustomers[chosenCustomer - 1].ShowCustomerBalance);
        }
        static void AddBalance()
        {

            Console.Write("Vem vill du göra en insättning på? ");
            int chosenCustomer = int.Parse(Console.ReadLine());
            Console.Write("Hur mycket vill du göra en insättning på? ");
            var addedBalance = decimal.Parse(Console.ReadLine(), System.Globalization.CultureInfo.InvariantCulture);
            bankCustomers[chosenCustomer - 1].transactions.Add(addedBalance);
            bankCustomers[chosenCustomer - 1].Balance += addedBalance;
        }
        static void SubtractBalance()
        {
            Console.Write("Vem vill du göra ett uttag på? ");
            int chosenCustomer = int.Parse(Console.ReadLine());
            Console.Write("Hur mycket vill du göra ett uttag på? ");
            var subtractedBalance = decimal.Parse(Console.ReadLine(), System.Globalization.CultureInfo.InvariantCulture);
            bankCustomers[chosenCustomer - 1].transactions.Add(subtractedBalance * -1);
            bankCustomers[chosenCustomer - 1].Balance += subtractedBalance * -1;
            foreach (var customer in bankCustomers[chosenCustomer - 1].transactions)
            {
                Console.WriteLine(customer);
            }
        }
        static void pauseProgram()
        {
            Console.WriteLine("");
            Console.WriteLine("Klicka på valfri knapp för att fortsätta");
            Console.ReadKey();
            Console.WriteLine("");
        }
            
    }
}
