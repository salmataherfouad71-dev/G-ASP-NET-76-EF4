using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment._19.Models
{
    public class Account
    {
        public int AccountNumber { set; get; }
        public AccountType AccountType { set; get; }
        public decimal CurrentBalance { set; get; }
        public DateTime OpeningDate { set; get; }
        public int BranchId { set; get; }
        public Branch Branch { set; get; }
        public List<CustomerAccount> Customers { set; get; }
        public List <Transaction> Transactions { set; get; }
    }
}
