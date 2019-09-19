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
        public List<decimal> Transactions = new List<decimal>();

        public decimal Balance { get { return Transactions.Sum(); } }
        public string ShowCustomerBalance { get { return "Name: " + Name + ", Saldo: " + Math.Round(Balance, 2) + " SEK"; } }
    }
}
