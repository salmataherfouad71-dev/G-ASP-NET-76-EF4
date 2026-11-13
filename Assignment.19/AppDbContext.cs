using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Assignment._19.Models;

namespace Assignment._19
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.; Database=National_Bank_Management_System; Trusted_Connection=True; TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Account> Accounts { set; get; }
        public DbSet<Branch> Branches { set; get; }
        public DbSet<Customer> Customers { set; get; }
        public DbSet<Manager> Managers { set; get; }
        public DbSet<Transaction> Transactions { set; get; }
        public DbSet<CustomerAccount> CustomerAccounts { set; get; } 
    }
}