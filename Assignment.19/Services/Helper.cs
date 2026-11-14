using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Assignment._19.Models;
using Microsoft.EntityFrameworkCore;

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
        public static void OpenAccount(AppDbContext context)
        {
            Console.WriteLine("--- Open New Account ---");
            int choiceType = GetInt("Account Type:\n\t1)Savings\n\t2)Current\n\t3)Business\nChoice:", 1, 3);
            AccountType type;
            if (choiceType == 1)
                type = AccountType.Savings;
            else if (choiceType == 2)
                type = AccountType.Current;
            else
                type = AccountType.Business;
            string branchCode = GetString("Branch Code     : ");
            int customerId = GetInt("Customer ID     : ",0,int.MaxValue);
            int choiceRole = GetInt("OwnerShip Role:\n\t1)Primary\n\t2)CoHolder\nChoice:", 1, 2);
            OwnerShipType role = (choiceRole == 1) ? OwnerShipType.Primary : OwnerShipType.CoHolder;
            Console.WriteLine($"Validating branch '{branchCode}' and customer #{customerId} ...");
            var branch = context.Branches.FirstOrDefault(b => b.Code == branchCode);
            var customer = context.Customers.FirstOrDefault(c => c.Id == customerId);
            if (branch == null )
            {
                Console.WriteLine("The branch is not found!");
                return;
            }
            if (customer == null)
            {
                Console.WriteLine("The customer is not found!");
                return;
            }
            var account = new Account
            {
                AccountType = type,
                CurrentBalance = 0,
                BranchId = branchCode
            };
            context.Accounts.Add(account);
            context.SaveChanges();
            var customerAccount = new CustomerAccount
            {
                CustomerId = customerId,
                AccountId = account.AccountNumber,
                OwnerShipType =role,
                AccountStatus=AccountStatus.Active
            };
            context.CustomerAccounts.Add(customerAccount);
            context.SaveChanges();
            Console.WriteLine($"Account '{account.AccountNumber}' created and linked to customer {customerId} as {role} owner.");
        }
        public static void UpdateStatus(AppDbContext context)
        {
            Console.WriteLine("--- Update Account Status ---");
            int accountId = GetInt("Account Number  : ",1,int.MaxValue);
            int customerId = GetInt("Customer ID     : ",1,int.MaxValue);
            var customerAccount=context.CustomerAccounts
            .FirstOrDefault(ca => ca.AccountId == accountId&&ca.CustomerId==customerId);
            if (customerAccount == null)
            {
                Console.WriteLine("The customer account is not found!");
                return;
            }
            int choice = GetInt("New Status:\n\t1)Active\n\t2)Closed\nChoice:", 1, 2);
            customerAccount.AccountStatus = (choice == 1) ? AccountStatus.Active : AccountStatus.Closed;
            context.SaveChanges();
            Console.WriteLine($"Status updated to {customerAccount.AccountStatus}.");
        }
    }
}
