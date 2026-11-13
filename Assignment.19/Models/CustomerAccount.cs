using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment._19.Models
{
    public class CustomerAccount
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
        public DateTime OwnerShipStartDate { get; set; }
        public OwnerShipType OwnerShipType { get; set; }
        public AccountStatus AccountStatus { get; set; }
    }
}
