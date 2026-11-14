using Assignment._19.Services;
namespace Assignment._19
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using AppDbContext context = new AppDbContext();
            bool running = true;
            while (running)
            {
                Console.Clear();
                DisplayMenu();
                Console.WriteLine("Enter choice:");
                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input! Try again (0-5)");
                    Pause();
                    continue;
                }
                switch (choice)
                {
                    case 1:
                        Helper.AddCustomer(context);
                        Pause();
                        break;
                    case 2:
                        Helper.OpenAccount(context);
                        Pause();
                        break;
                    case 3:
                        Helper.UpdateStatus(context);
                        Pause();
                        break;
                    case 4:
                        Helper.RemoveAccount(context);
                        Pause();
                        break;
                    case 5:
                        Helper.ListAllCustomers(context);
                        Pause();
                        break;
                    case 0:
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input!");
                        Pause();
                        break;
                }
            }
        }
        static void DisplayMenu()
        {
            Console.WriteLine("======================================");
            Console.WriteLine("National Bank - Management");
            Console.WriteLine("======================================");
            Console.WriteLine("1)Add a new customer");
            Console.WriteLine("2)Open a new Account for a customer");
            Console.WriteLine("3)Update Account Status (Active / Closed)");
            Console.WriteLine("4)Remove an Account from a Customer");
            Console.WriteLine("5)List All Customers (with Accounts)");
            Console.WriteLine("0)Exit");
            Console.WriteLine("--------------------------------------");
        }
        static void Pause ()
        {
            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }
    }
}
