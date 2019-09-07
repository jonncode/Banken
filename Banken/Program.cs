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
                        Console.WriteLine("Du valde 1");
                        AddCustomer();
                        break;
                    case 2:
                        RemoveCustomer();
                        break;
                    case 3:
                        ShowCustomers();
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
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
            customer.Balance = int.Parse(Console.ReadLine());
            bankCustomers.Add(customer);
            Console.WriteLine("Lade till ny användare!");
            Console.ReadKey();
            Console.WriteLine("");


        }
        static void RemoveCustomer()
        {
            int i = 1;
            foreach (var customer in bankCustomers)
            {
                Console.WriteLine(i + ": Namn " + customer.Name + " Saldo " + customer.Balance);
                i++;
            }
            Console.Write("Vem vill du ta bort? ");
            int Choice = int.Parse(Console.ReadLine());
            bankCustomers.Remove(bankCustomers[Choice - 1]);
            Console.WriteLine("Tog bort användare!");
            Console.ReadKey();
            Console.WriteLine("");
        }
        static void ShowCustomers()
        {

            foreach(var customer in bankCustomers)
            {
                Console.WriteLine("Namn " + customer.Name + " Saldo " + customer.Balance);
            }
            Console.ReadKey();
            Console.WriteLine("");
        }
            
    }
}
