using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll_Nikolaev
{
    public class DirectDepositMethod : PaymentMethod
    {
        public override string ToString()
        {
            return "DirectDeposit";
        }
    }
}
