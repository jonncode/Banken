using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace Banken
{
    class Program
    {
        static List<Customer> bankCustomers = new List<Customer>(); // Initialize list to store all customer objects using constructor List<>()
        static int selectedMenuInput = 0;
        static int chosenCustomer = 0;
        static decimal changedBalance = 0;
        /// <summary>
        /// Execute functions based on the choice chosen in SelectMenuItem using switch-case
        /// Loop after case: is done, until user exits by changing bool value of notDone
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            string dirname = @"datadir\";
            string filename = @"data.txt"; //Save file into project root directory
            string dirfile = dirname + filename;
            try
            {
                if (File.Exists(dirfile)) //If file does not exist
                {
                    string jsonText = File.ReadAllText(dirfile); //Read whole file and save into string var
                    bankCustomers = JsonConvert.DeserializeObject<List<Customer>>(jsonText); //Deserialize json into c# list format
                }
            }
            catch (JsonSerializationException) //If datafile has incorrect json formatting.
            {
                Console.WriteLine("");
                Console.WriteLine("Felaktigt format inuti datafilen {0}, kontrollera att det är korrekt och försök igen.", dirfile);
                pauseProgram();
            }
            catch (Exception ex) //If any other type of error occurs
            {
                Console.WriteLine("");
                Console.WriteLine("Ett fel uppstod!");
                Console.WriteLine(ex.Message);
                pauseProgram();
            }
            bool notDone = true;
            while (notDone == true) //Continue until user wishes to exit
            {
                try
                {
                    SelectMenuItem();
                    switch (selectedMenuInput) //Choose from range of options with input "selectedMenuInput"
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
                            if (Directory.Exists(dirname) == false)
                            {
                                Directory.CreateDirectory(dirname);
                            }
                            if (File.Exists(dirfile) == false) //If file does not exist
                            {
                                var createdFile = File.Create(dirfile); //Create file in selected directory
                                createdFile.Close();
                                string json = JsonConvert.SerializeObject(bankCustomers); //Convert list to json format
                                File.WriteAllText(dirfile, json); //Store list into into .txt file
                            }
                            notDone = false;
                            break;
                        default:
                            Console.WriteLine("");
                            Console.WriteLine("Felaktigt svar, försök igen!");
                            pauseProgram();
                            break;
                    }
                }
                catch (Exception ex) //If any other type of error occurs
                {
                    Console.WriteLine("");
                    Console.WriteLine("Ett fel uppstod!");
                    Console.WriteLine(ex.Message);
                    pauseProgram();
                }
            }
        }
        /// <summary>
        /// Run welcome text and return input choice from user into main
        /// </summary>
        /// <returns></returns>
        static void SelectMenuItem()
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
            int.TryParse(Console.ReadLine(), out selectedMenuInput);
        }
        /// <summary>
        /// Create new customer instance and fill class attributes name and balance, add first transaction (starting balance) to list.
        /// Add instance into list that withholds all customer objects.
        /// </summary>
        static void AddCustomer()
        {
            Customer customer = new Customer(); // Instanciate instance using class Customer with constructor Customer();
            Console.Write("Vad är ditt namn? ");
            customer.Name = Console.ReadLine();
            Console.WriteLine("Ange saldo: ");
            inputNum();
            customer.Transactions.Add(changedBalance);
            bankCustomers.Add(customer);
            Console.WriteLine("Lade till ny användare!");
        }
        /// <summary>
        /// Remove customer from list with customers using input. 
        /// </summary>
        static void RemoveCustomer()
        {
            Console.Write("Vem vill du ta bort? ");
            inputInt();
            bankCustomers.Remove(bankCustomers[chosenCustomer - 1]);
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
            inputInt();
            Console.WriteLine(bankCustomers[chosenCustomer - 1].ShowCustomerBalance);
        }
        /// <summary>
        /// Use user input to select customer, convert second input from string to decimal.
        /// Add decimal input into instance's Transaction list attribute.
        ///
        /// </summary>
        static void AddBalance()
        {

            Console.Write("Vem vill du göra en insättning på? ");
            inputInt();
            Console.Write("Hur mycket vill du göra en insättning på? ");
            inputNum(); // parse string into decimal datatype
            bankCustomers[chosenCustomer - 1].Transactions.Add(changedBalance);
        }
        /// <summary>
        /// Use user input to select customer, convert second input from string to decimal.
        /// Multiply second input by -1 to easier store in Transactions list.
        /// Add decimal input into instance's Transaction list attribute.
        /// </summary>
        static void SubtractBalance()
        {
            Console.Write("Vem vill du göra ett uttag på? ");
            inputInt();
            Console.Write("Hur mycket vill du göra ett uttag på? ");
            inputNum(); // parse string into decimal datatype
            bankCustomers[chosenCustomer - 1].Transactions.Add(changedBalance * -1);
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
        /// <summary>
        /// Uses input to ask for which customer the user would like to select
        /// </summary>
        static decimal inputInt()
        {
            var userInput = int.TryParse(Console.ReadLine(), out chosenCustomer);
            while (!userInput)
            {
                if (!userInput)
                {
                    Console.WriteLine("Error: Felaktigt format användes, använd endast siffror.");
                    Console.Write("Försök igen: ");
                    userInput = int.TryParse(Console.ReadLine(), out chosenCustomer); 
                }
            }
            return chosenCustomer;
        }
         /// <summary>
        /// Uses input to ask for what the changed in balance should be.
        /// </summary>
        static decimal inputNum()
        {
            var balanceInput = decimal.TryParse(Console.ReadLine(), out changedBalance); // Use datatype decimal for more accurate calculations regarding money
            while (!balanceInput)
            {
                if(!balanceInput)
                {
                    Console.WriteLine("Error: Felaktigt format användes, använd endast siffror och decimaltecken ','");
                    Console.Write("Försök igen: ");
                    balanceInput = decimal.TryParse(Console.ReadLine(), out changedBalance); // Use datatype decimal for more accurate calculations regarding money

                }
            }
            return changedBalance;
        }

    }
}
