using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment._19.Models
{
    public class Transaction
    {
        public int TransactionNumber { set; get; }
        public DateTime TransactionDate { set; get; }
        public decimal Amount { set; get; }
        public string TransactionType { set; get; }
        public string Note { set; get; }
        public int AccountId { set; get; }
        public Account Account { set; get; }
    }
}
