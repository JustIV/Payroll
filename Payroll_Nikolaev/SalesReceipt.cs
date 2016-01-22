using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll_Nikolaev
{
    public class SalesReceipt
    {
        private readonly DateTime date;
        private readonly double amount;

        public SalesReceipt(DateTime date, double amount)
        {
            this.date = date;
            this.amount = amount;
        }

        public double Amount
        {
            get { return amount; }
        }

        public DateTime Date
        {
            get { return date; }
        }
    }
}
