namespace BankAccountManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List <string[]> allAccounts = new List<string[]>();
            Console.WriteLine("Create account [1] or sign-in [2]");
            string input = Console.ReadLine();
            if (input == "1")
            {
                string[] newAccount = CreateAccount();
                allAccounts.Add(newAccount);
            }
            else if (input == "2")
            {
                //sign into existing account
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
    }
}