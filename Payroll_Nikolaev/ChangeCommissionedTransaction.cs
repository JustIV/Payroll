using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll_Nikolaev
{
    public class ChangeCommissionedTransaction : ChangeClassificationTransaction
    {
        private readonly double commissionRate;
        private readonly double salary;

        public ChangeCommissionedTransaction(int id, double commissionRate, double salary)
            : base(id)
        {
            this.commissionRate = commissionRate;
            this.salary = salary;
        }

        protected override PaymentClassification Classification
        {
            get { return new CommissionedClassification(commissionRate, salary); }
        }

        protected override PaymentSchedule Schedule
        {
            get { return new BiweeklySchedule(); }
        }
    }
}
