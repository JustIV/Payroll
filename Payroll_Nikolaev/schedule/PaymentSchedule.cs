﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll_Nikolaev
{
    public interface PaymentSchedule
    {
        bool IsPayDate(DateTime date);
    }
}
