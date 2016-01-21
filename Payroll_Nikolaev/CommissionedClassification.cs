using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll_Nikolaev
{
    public class CommissionedClassification : PaymentClassification
    {
        private readonly double salary;
        private readonly double commissionRate;

        public CommissionedClassification(double salary, double commissionRate)
        {
            this.salary = salary;
            this.commissionRate = commissionRate;
        }

        public double CommissionRate
        {
            get { return commissionRate; }
        }

        public double Salary
        {
            get { return salary; }
        }

        public override string ToString()
        {
            return String.Format("${0} ${1}", commissionRate, salary);
        }
    }
}
