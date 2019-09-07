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
        public int Balance { get; set; }

        public string ShowCustomer { get { return "Name: " + Name + "Saldo: " + Balance; } }
    }
}
