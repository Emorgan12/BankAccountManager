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
                    string[] newAccount = CreateAccount();
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
        static string[] CreateAccount()
        {
            Console.WriteLine("Enter your name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Create a password: ");
            string password = Console.ReadLine();
            string[] account = new string[] { name, password };
            return account;
        }

        static void signIn(List<string[]> accountList)
        {
            bool found = false;
            Console.WriteLine("Enter name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter password: ");
            string password = Console.ReadLine();
            foreach (string[] account in accountList)
            {
                if (account[0] == name)
                {
                    found = true;
                    Console.WriteLine("Account found... checking password");
                    if (account[1] == password)
                        Console.WriteLine("Sign-in successful");
                    else
                        Console.WriteLine("Incorrect Password");
                }
                if (!found)
                    Console.WriteLine("Account does not exist");
            }
        }
    }
}