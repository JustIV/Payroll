﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll_Nikolaev
{
    public class MailMethod : PaymentMethod
    {
        public override string ToString()
        {
            return "Mail";
        }

        public void Pay(Paycheck paycheck)
        {

        }
    }
}
