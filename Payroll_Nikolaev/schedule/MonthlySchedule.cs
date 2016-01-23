using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll_Nikolaev
{
    public class MonthlySchedule : PaymentSchedule
    {
        private bool IsLastDayOfMonth(DateTime date)
        {
            int m1 = date.Month;
            int m2 = date.AddDays(1).Month;
            return (m1 != m2);
        }

        public bool IsPayDate(DateTime payDate)
        {
            return IsLastDayOfMonth(payDate);
        }

        public override string ToString()
        {
            return "monthly";
        }
    }
}
