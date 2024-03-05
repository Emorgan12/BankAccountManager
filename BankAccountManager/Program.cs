using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BankAccountManager
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Account> allAccounts = new List<Account>();
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Create account [0], sign-in [1], or exit [2]");
                string input = Console.ReadLine();
                if (input == "0")
                {
                    List<string> newAccount = CreateNewAccount(allAccounts);
                    Account account = new Account { username = newAccount[0], password = newAccount[1], balance = 0 };
                    allAccounts.Add(account);
                }
                else if (input == "1")
                    signIn(allAccounts);
                else if (input == "2")
                    exit = true;
                else
                    Console.WriteLine("Invalid input");
            };

            Console.ReadKey();

        }

static List<string> CreateNewAccount(List<Account> accountList)
        {
            bool notFound = true;
            bool passwordLength1 = false;
            bool passwordLength2 = false;
                while (notFound)
                {
                    Console.WriteLine("Enter a username: ");
                    string username = Console.ReadLine();
                    if (accountList.Count == 0)
                    {
                        notFound = false;
                        while (!passwordLength1)
                        {
                            Console.WriteLine("Create a password: ");
                            string password = Console.ReadLine();
                            if (password.Length < 8)
                            {
                                Console.WriteLine("Password must be at least 8 characters");
                            }
                            else
                            {
                                List<string> newAccount = new List<string> { username, password };
                                passwordLength1 = true;
                                return newAccount;
                            }
                        }
                    }
                    foreach (Account account in accountList)
                    {
                        if (account.username==username)
                        {
                            Console.WriteLine("Username already exists");
                            notFound = false;
                        }
                        else
                        {
                            while (!passwordLength2)
                            {
                                Console.WriteLine("Create a password: ");
                                string password = Console.ReadLine();
                                if (password.Length < 8)
                                {
                                    Console.WriteLine("Password must be at least 8 characters");
                                }
                                else
                                {
                                    List<string> newAccount = new List<string> { username, password };
                                    passwordLength1 = true;
                                    return newAccount;
                                }
                            }
                        }

                    }
                }
            return null; 
        }

        static void signIn(List<Account> accountList)
        {
            bool found = false;
            bool dIntInput = false;
            bool wIntInput = false;
            bool exit = false;
            Console.WriteLine("Enter username: ");
            string name = Console.ReadLine();
            foreach (Account account in accountList)
            {
                if (account.username == name)
                {
                    found = true;
                    Console.WriteLine("Account found, enter your password: ");
                    string password = Console.ReadLine();
                    if (account.password == password)
                    {
                        Console.WriteLine("Sign-in successful");
                        while (!exit)
                        {
                            Console.WriteLine("Withdraw funds[0], Deposit Funds[1], Check Balance[2], or sign out[3]");
                            string input = Console.ReadLine();
                            if (input == "0")
                            {
                                dIntInput = false;

                                while (!dIntInput)
                                {
                                    Console.WriteLine("How much money to withdraw");
                                    string WFunds = Console.ReadLine();
                                    if (int.TryParse(WFunds, out int withdraw))
                                    {
                                        dIntInput = true;
                                        if (account.balance > withdraw)
                                            account.balance = account.balance - withdraw;
                                        else
                                            Console.WriteLine("You do not have enough funds for this");
                                    }
                                    else
                                        Console.WriteLine("Please enter a number");

                                }
                            }
                            else if (input == "1")
                            {
                                while (!wIntInput)
                                {
                                    Console.WriteLine("How much money to deposit?");
                                    string DFunds = Console.ReadLine();
                                    if (int.TryParse(DFunds, out int deposit))
                                    {
                                        wIntInput = true;
                                        account.balance = account.balance + deposit;
                                        Console.WriteLine("Funds deposited");
                                    }
                                    else
                                        Console.WriteLine("Please enter a number");
                                }

                            }
                            else if (input == "2")
                                Console.WriteLine("Your bank balance is " + account.balance);
                            else if (input == "3")
                                exit = true;
                            else
                                Console.WriteLine("Invalid input");
                        }
                    }
                    else
                        Console.WriteLine("Incorrect Password");
                }
               
            }
            if (!found)
                Console.WriteLine("Account does not exist");
        }
    }
}
