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
        public List<decimal> transactions = new List<decimal>();

        public decimal Balance { get { return transactions.Sum(); } }
        public string ShowCustomerBalance { get { return "Name: " + Name + " Saldo: " + Math.Round(Balance, 2); } }
    }
}
