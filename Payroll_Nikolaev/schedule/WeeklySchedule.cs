using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll_Nikolaev
{
    public class WeeklySchedule : PaymentSchedule
    {
        public bool IsPayDate(DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Friday;
        }

        public override string ToString()
        {
            return "weekly";
        }
    }
}
