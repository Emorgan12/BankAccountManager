namespace BankAccountManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Create account [1] or sign-in [2]");
            string input = Console.ReadLine();
            if (input == "1")
            {
                //account creation
            }
            else if (input == "2")
            {
                //sign into existing account
            }
        }
    }
}