using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banken
{
    class Customer
    {
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public List<decimal> transactions = new List<decimal>();

        public string ShowCustomerBalance { get { return "Name: " + Name + "Saldo: " + Balance; } }
    }
}
