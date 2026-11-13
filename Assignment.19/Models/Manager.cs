using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment._19.Models
{
    public class Manager
    {
        public int Id { set; get; }
        public string FullName { set; get; }
        public string Email { set; get; }
        public string PhoneNumber { set; get; }
        public DateTime HireDate { set; get; }
        public Branch Branch { set; get; }
    }
}
