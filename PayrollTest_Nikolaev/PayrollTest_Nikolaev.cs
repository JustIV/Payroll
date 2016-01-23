﻿using System;
using Payroll_Nikolaev;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PayrollTest_Nikolaev
{
    [TestClass]
    public class PayrollTest_Nikolaev
    {
        [TestMethod]
        public void TestEmployee()
        {
            int empId = 1;
            Employee e = new Employee(empId, "Bob", "Home");
            Assert.AreEqual("Bob", e.Name);
            Assert.AreEqual("Home", e.Address);
            Assert.AreEqual(empId, e.EmpId);  
        }

        [TestMethod]
        public void TestEmployeeToString()
        {
            int empId = 1;
            Employee e = new Employee(empId, "TestEmployee", "TestAddress");
            e.ToString();
        }

        [TestMethod]
        public void TestAddSalariedEmployee()
        {
            int empId = 1;
            AddSalariedEmployee t = new AddSalariedEmployee(empId, "Bob", "Home", 1000.00);
            t.Execute();
            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.AreEqual("Bob", e.Name);
            PaymentClassification pc = e.Classification;
            Assert.IsTrue(pc is SalariedClassification);
            SalariedClassification sc = pc as SalariedClassification;
            Assert.AreEqual(1000.00, sc.Salary, .001);
            PaymentSchedule ps = e.Schedule;
            Assert.IsTrue(ps is MonthlySchedule);
            PaymentMethod pm = e.Method;
            Assert.IsTrue(pm is HoldMethod);
        }
        [TestMethod]
        public void TestAddHourlyEmployee()
        {
            int empId = 1;
            AddHourlyEmployee t = new AddHourlyEmployee(empId, "Bob", "Home", 100.00);
            t.Execute();
            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.AreEqual("Bob", e.Name);
            PaymentClassification pc = e.Classification;
            Assert.IsTrue(pc is HourlyClassification);
            HourlyClassification sc = pc as HourlyClassification;
            Assert.AreEqual(100, sc.HourlyRate, 0.001);
            PaymentSchedule ps = e.Schedule;
            Assert.IsTrue(ps is WeeklySchedule);
            PaymentMethod pm = e.Method;
            Assert.IsTrue(pm is HoldMethod);
        }

        [TestMethod]
        public void TestAddCommissionedEmployee()
        {
            int empId = 1;
            AddCommissionedEmployee t = new AddCommissionedEmployee(empId, "Bob", "Home", 100.00, 50.00);
            t.Execute();
            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.AreEqual("Bob", e.Name);
            PaymentClassification pc = e.Classification;
            Assert.IsTrue(pc is CommissionedClassification);
            CommissionedClassification sc = pc as CommissionedClassification;
            Assert.AreEqual(100.00, sc.Salary, .001);
            Assert.AreEqual(50.00, sc.CommissionRate, .001);
            PaymentSchedule ps = e.Schedule;
            Assert.IsTrue(ps is BiweeklySchedule);
            PaymentMethod pm = e.Method;
            Assert.IsTrue(pm is HoldMethod);
        }

        [TestMethod]
        public void TestDeleteEmployee()
        {
            int empId = 1;
            AddCommissionedEmployee t = new AddCommissionedEmployee(empId, "Bill", "Home", 2500, 3.2);
            t.Execute();
            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(e);
            DeleteEmployeeTransaction dt = new DeleteEmployeeTransaction(empId);
            dt.Execute();
            e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNull(e);
        }

        [TestMethod]
        public void TimeCardTransaction()
        {
            int empId = 1;
            AddHourlyEmployee t = new AddHourlyEmployee(empId, "Bill", "Home", 15.25);
            t.Execute();
            TimeCardTransaction tct = new TimeCardTransaction(new DateTime(2015, 10, 31), 8.0, empId);
            tct.Execute();
            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(e);
            PaymentClassification pc = e.Classification;
            Assert.IsTrue(pc is HourlyClassification);
            HourlyClassification hc = pc as HourlyClassification;
            TimeCard tc = hc.GetTimeCard(new DateTime(2015, 10, 31));
            Assert.IsNotNull(tc);
            Assert.AreEqual(8.0, tc.Hours);
        }

        [TestMethod]
        public void SalesReceiptTransaction()
        {
            int empId = 1;
            AddCommissionedEmployee t = new AddCommissionedEmployee(empId, "Bill", "Home", 2000, 0.25);
            t.Execute();
            SalesReceiptTransaction tct = new SalesReceiptTransaction(new DateTime(2015, 10, 31), 10.0, empId);
            tct.Execute();
            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(e);
            PaymentClassification pc = e.Classification;
            Assert.IsTrue(pc is CommissionedClassification);
            CommissionedClassification cc = pc as CommissionedClassification;
            SalesReceipt tc = cc.GetSalesReceipt(new DateTime(2015, 10, 31));
            Assert.IsNotNull(tc);
            Assert.AreEqual(10.0, tc.Amount);
        }

        [TestMethod]
        public void AddServiceCharge()
        {
            int empId = 1;
            AddHourlyEmployee t = new AddHourlyEmployee(empId, "Bill", "Home", 15.25);
            t.Execute();
            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(e);
            UnionAffiliation af = new UnionAffiliation();
            e.Affiliation = af;
            int memberId = 86;
            PayrollDatabase.AddUnionMember(memberId, e);
            ServiceChargeTransaction sct = new ServiceChargeTransaction(memberId, new DateTime(2015, 11, 8), 10);
            sct.Execute();
            ServiceCharge sc = af.GetServiceCharge(new DateTime(2015, 11, 8));
            Assert.IsNotNull(sc);
            Assert.AreEqual(10, sc.Charge, .001);
        }

        [TestMethod]
        public void TestChangeNameTransaction()
        {
            int empId = 1;
            AddHourlyEmployee t = new AddHourlyEmployee(empId, "Bill", "Home", 15.25);
            t.Execute();
            ChangeNameTransaction cnt = new ChangeNameTransaction(empId, "Bob");
            cnt.Execute();
            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(e);
            Assert.AreEqual("Bob", e.Name);
        }
        [TestMethod]
        public void TestChangeAddressTransaction()
        {
            int empId = 1;
            AddHourlyEmployee t = new AddHourlyEmployee(empId, "Bill", "Home", 15.25);
            t.Execute();
            ChangeAddressTransaction cnt = new ChangeAddressTransaction(empId, "Wall street");
            cnt.Execute();
            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(e);
            Assert.AreEqual("Wall street", e.Address);
        }

        [TestMethod]
        public void TestChangeHourlyTransaction()
        {
            int empId = 1;
            AddCommissionedEmployee t = new AddCommissionedEmployee(empId, "Bill", "Home", 2000, 3.2);
            t.Execute();
            ChangeHourlyTransaction cht = new ChangeHourlyTransaction(empId, 27.52);
            cht.Execute();
            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(e);
            PaymentClassification pc = e.Classification;
            Assert.IsNotNull(pc);
            Assert.IsTrue(pc is HourlyClassification);
            HourlyClassification hc = pc as HourlyClassification;
            Assert.AreEqual(27.52, hc.HourlyRate, .001);
            PaymentSchedule ps = e.Schedule;
            Assert.IsTrue(ps is WeeklySchedule);
        }

        [TestMethod]
        public void TestChangeSalariedTransaction()
        {
            int empId = 1;
            AddCommissionedEmployee t = new AddCommissionedEmployee(empId, "Bill", "Home", 2000, 3.2);
            t.Execute();
            ChangeSalariedTransaction cht = new ChangeSalariedTransaction(empId, 3000);
            cht.Execute();
            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(e);
            PaymentClassification pc = e.Classification;
            Assert.IsNotNull(pc);
            Assert.IsTrue(pc is SalariedClassification);
            SalariedClassification sc = pc as SalariedClassification;
            Assert.AreEqual(3000, sc.Salary, .001);
            PaymentSchedule ps = e.Schedule;
            Assert.IsTrue(ps is MonthlySchedule);
        }

        [TestMethod]
        public void TestChangeCommissionedTransaction()
        {
            int empId = 1;
            AddSalariedEmployee t = new AddSalariedEmployee(empId, "Bill", "Home", 2000);
            t.Execute();
            ChangeCommissionedTransaction cht = new ChangeCommissionedTransaction(empId, 1000, 25.5);
            cht.Execute();
            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(e);
            PaymentClassification pc = e.Classification;
            Assert.IsNotNull(pc);
            Assert.IsTrue(pc is CommissionedClassification);
            CommissionedClassification cc = pc as CommissionedClassification;
            Assert.AreEqual(25.5, cc.CommissionRate, .001);
            Assert.AreEqual(1000, cc.Salary, .001);
            PaymentSchedule ps = e.Schedule;
            Assert.IsTrue(ps is BiweeklySchedule);
        }

        [TestMethod]
        public void TestChangeDirectMethodTransaction()
        {
            int empId = 1;
            AddSalariedEmployee t = new AddSalariedEmployee(empId, "Bill", "Home", 2000);
            t.Execute();
            ChangeDirectTransaction dt = new ChangeDirectTransaction(empId);
            dt.Execute();
            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(e);
            PaymentMethod pm = e.Method;
            Assert.IsNotNull(pm);
            Assert.IsTrue(pm is DirectDepositMethod);
        }

        [TestMethod]
        public void TestChangeMailMethodTransaction()
        {
            int empId = 1;
            AddSalariedEmployee t = new AddSalariedEmployee(empId, "Bill", "Home", 2000);
            t.Execute();
            ChangeMailTransaction dt = new ChangeMailTransaction(empId);
            dt.Execute();
            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(e);
            PaymentMethod pm = e.Method;
            Assert.IsNotNull(pm);
            Assert.IsTrue(pm is MailMethod);
        }

        [TestMethod]
        public void TestChangeUnionMember()
        {
            int empId = 1;
            AddHourlyEmployee t = new AddHourlyEmployee(empId, "Bill", "Home", 15.25);
            t.Execute();
            int memberId = 7743;
            ChangeMemberTransaction cmt = new ChangeMemberTransaction(empId, memberId, 99.42);
            cmt.Execute();
            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(e);
            Affiliation affiliation = e.Affiliation;
            Assert.IsNotNull(affiliation);
            Assert.IsTrue(affiliation is UnionAffiliation);
            UnionAffiliation uf = affiliation as UnionAffiliation;
            Assert.AreEqual(99.42, uf.Charge, .001);
            Employee member = PayrollDatabase.GetUnionMember(memberId);
            Assert.IsNotNull(member);
            Assert.AreEqual(e, member);
        }
    }
}
