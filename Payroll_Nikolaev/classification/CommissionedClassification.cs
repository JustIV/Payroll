using System;
using System.Collections;
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

        private Hashtable salesReceipt = new Hashtable();

        public CommissionedClassification(double salary, double commissionRate)
        {
            this.salary = salary;
            this.commissionRate = commissionRate;
        }

        public SalesReceipt GetSalesReceipt(DateTime date)
        {
            return salesReceipt[date] as SalesReceipt;
        }

        public void AddSalesReceipt(SalesReceipt sr)
        {
            salesReceipt[sr.Date] = sr;
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

        public override double CalculatePay(Paycheck paycheck)
        {
            return salary;
        }
    }
}
