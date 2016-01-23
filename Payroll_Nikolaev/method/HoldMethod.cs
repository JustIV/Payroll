using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll_Nikolaev
{
    public class HoldMethod : PaymentMethod
    {
        public override string ToString()
        {
            return "Hold";
        }

        public void Pay(Paycheck paycheck)
        {
            paycheck.SetField("Disposition", "Hold");
        }
    }
}
