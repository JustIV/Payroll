using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll_Nikolaev
{
    public class Paycheck
    {
        private DateTime payDate;
        private double grossPay;
        private Hashtable fields = new Hashtable();
        private double deductions;
        private double netPay;

        public void SetField(string fieldName, string value)
        {
            fields[fieldName] = value;
        }

        public string GetField(string fieldName)
        {
            return fields[fieldName] as string;
        }

        public Paycheck(DateTime payDate)
        {
            this.payDate = payDate;
        }

        public DateTime PayDate
        {
            get { return payDate; }
        }

        public double GrossPay
        {
            get { return grossPay; }
            set { grossPay = value; }
        }

        public double Deductions
        {
            get { return deductions; }
            set { deductions = value; }
        }

        public double NetPay
        {
            get { return netPay; }
            set { netPay = value; }
        }
    }
}
