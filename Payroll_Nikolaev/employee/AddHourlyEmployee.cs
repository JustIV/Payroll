using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll_Nikolaev
{
    public class AddHourlyEmployee : AddEmployeeTransaction
    {
        private readonly double hours;
        public AddHourlyEmployee(int id, string name, string address, double hours)
            : base(id, name, address)
        {
            this.hours = hours;
        }

        protected override PaymentClassification MakeClassification()
        {
            return new HourlyClassification(hours);
        }

        protected override PaymentSchedule MakeSchedule()
        {
            return new WeeklySchedule();
        }
    }
}
