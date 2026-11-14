using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Assignment._19.Models;

namespace Assignment._19.Services
{
    public static class Helper
    {
        public static string GetString(string message)
        {
            string result;
            do
            {
                Console.Write(message);
                result = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(result));
            return result;
        }
        public static int GetInt(string message,int min,int max)
        {
            int result;
            do
            {
                Console.Write(message);
            } while (!int.TryParse(Console.ReadLine(),out result)&&result<=min&&result>=max);
            return result;
        }
        public static DateTime GetDate(string message)
        {
            DateTime result;
            do
            {
                Console.Write(message);
            } while (!DateTime.TryParseExact(Console.ReadLine(),"yyyy-MM-dd",CultureInfo.InvariantCulture,DateTimeStyles.None,out result));
            return result;
        }
        public static void AddCustomer(AppDbContext context)
        {
            Console.WriteLine("--- Add New Customer ---");
            string fullName = GetString("Full Name       : ");
            string nationalId = GetString("National ID     : ");
            DateTime dateOfBirth = GetDate("Date of Birth   : (yyyy-MM-dd)");
            string email = GetString("Email           : ");
            string phone = GetString("Phone           : ");
            string address = GetString("Address         : ");
            int choice = GetInt("Customer Type:\n\t1)Individual\n\t2)Business\nChoice:",1,2);
            CustomerType type = (choice == 1) ? CustomerType.Individual : CustomerType.Business;
            var customer= new Customer
            {
                FullName = fullName,
                NationalId = nationalId,
                DateOfBirth = dateOfBirth,
                Email = email,
                PhoneNumber = phone,
                Address = address,
                CustomerType = type
            };
            Console.WriteLine();
            context.Customers.Add(customer);
            context.SaveChanges();
            Console.WriteLine($"Customer created successfully. Customer Id = {customer.Id}");
            Console.WriteLine();
        }
    }
}
