using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment._19.Models
{
    public class Branch
    {
        public string Code { set; get; }
        public string Name { set; get; }
        public string PhoneNumber { set; get; }
        public string Address { set; get; }
        public int ManagerId { set; get; }
        public Manager Manager { set; get; }
        public List<Account> Accounts { set; get; }
    }
}
