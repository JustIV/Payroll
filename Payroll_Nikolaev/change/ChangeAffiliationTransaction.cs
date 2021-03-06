﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll_Nikolaev
{
    public abstract class ChangeAffiliationTransaction : ChangeEmployeeTransaction
    {
        public ChangeAffiliationTransaction(int empId)
            : base(empId)
        { }

        protected override void Change(Employee e)
        {
            RecordMembership(e);
            Affiliation affiliation = Affiliation;
            e.Affiliation = affiliation;
        }

        protected abstract Affiliation Affiliation { get; }
        protected abstract void RecordMembership(Employee e);
    }
}
