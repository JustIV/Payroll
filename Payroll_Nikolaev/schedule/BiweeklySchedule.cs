using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll_Nikolaev
{
    public class BiweeklySchedule : PaymentSchedule
    {
        public override string ToString()
        {
            return "Biweekly";
        }

        public bool IsPayDate(DateTime date)
        {
            return (date.DayOfWeek == DayOfWeek.Friday) && (date.Day % 2 == 0);
        }

        public DateTime GetPayPeriodStartDate(DateTime date)
        {
            return date.AddDays(-6);
        }
    }
}
