using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll_Nikolaev
{
    public class SalesReceiptTransaction : Transaction
    {
        private readonly DateTime date;
        private readonly double amount;
        private readonly int empId;

        public SalesReceiptTransaction(DateTime date, double amount, int empId)
        {
            this.date = date;
            this.amount = amount;
            this.empId = empId;
        }

        public void Execute()
        {
            Employee e = PayrollDatabase.GetEmployee(empId);
            if (e != null)
            {
                CommissionedClassification cc = e.Classification as CommissionedClassification;
                if (cc != null)
                {
                    cc.AddSalesReceipt(new SalesReceipt(date, amount));
                }
                else
                {
                    throw new InvalidOperationException("Попытка добавить карточку табельного учета " + "для работника не на почасовой оплате");
                }
            }
            else
            {
                throw new InvalidOperationException("Работник не найден.");
            }
        }
    }
}
