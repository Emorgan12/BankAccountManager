using System;
using System.Diagnostics.SymbolStore;

namespace BankAccountManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List <string[]> allAccounts = new List<string[]>();
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Create account [1], sign-in [2], or exit [3]");
                string input = Console.ReadLine();
                if (input == "1")
                {
                    string[] newAccount = CreateAccount(allAccounts);
                    allAccounts.Add(newAccount);
                }
                else if (input == "2")
                {
                    signIn(allAccounts);
                }
                else if (input == "3")
                {
                    exit = true;
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            }
            Console.ReadKey();
        }
        static string[] CreateAccount(List<string[]>accountList)
        {
            bool found = false;
           
                Console.WriteLine("Enter a username: ");
                string username = Console.ReadLine();
                static string CheckUser(List<string[]> accountList,string name)
                {

                bool found = false;
                foreach (string[] account in accountList)
                    {
                        if (account[0] == name)
                        {
                            found = true;
                            Console.WriteLine("Username already exists");
                            return null;
                        }
                        else
                        {
                            return name;
                        }

                    }
                
            }
            string name = CheckUser(accountList, username);
            if (name != null)
            {
                Console.WriteLine("Create a password: ");
                string password = Console.ReadLine();
                string[] newAccount = new string[] { name, password };
                return newAccount;
            }
            else
                return null;
            
        }

        static void signIn(List<string[]> accountList)
        {
            bool found = false;
            Console.WriteLine("Enter username: ");
            string name = Console.ReadLine();
            foreach (string[] account in accountList)
            {
                if (account[0] == name)
                {
                    found = true;
                    Console.WriteLine("Account found, enter your password: ");
                    string password = Console.ReadLine();
                    if (account[1] == password)
                        Console.WriteLine("Sign-in successful");
                    else
                        Console.WriteLine("Incorrect Password");
                }
               
            }
            if (!found)
                Console.WriteLine("Account does not exist");
        }
    }
}