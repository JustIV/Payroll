using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll_Nikolaev
{
    public class ServiceCharge
    {
        private readonly DateTime date;
        private readonly double hours;
        private readonly double charge = 10;

        public ServiceCharge(DateTime date, double hours)
        {
            this.date = date;
            this.hours = hours;
        }

        public double Hours
        {
            get { return hours; }
        }

        public DateTime Date
        {
            get { return date; }
        }

        public double Charge
        {
            get { return charge; }
        }
    }
}
