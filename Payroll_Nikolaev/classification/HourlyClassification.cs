using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll_Nikolaev
{
    public class HourlyClassification : PaymentClassification
    {
        private readonly double hourlyRate;
        private Hashtable timeCards = new Hashtable();

        public override double CalculatePay(Paycheck paycheck)
        {
            double totalPay = 0.0;
            foreach (TimeCard timeCard in timeCards.Values)
            {
                if (timeCard.Date == paycheck.PayDate)
                {
                    totalPay += CalculatePayForTimeCard(timeCard);
                }
                return totalPay;
            }
            return 0; // check
        }

        private double CalculatePayForTimeCard(TimeCard card)
        {
            double overtimeHours = Math.Max(0.0, card.Hours - 8);
            double normalHours = card.Hours - overtimeHours;
            return hourlyRate * normalHours + hourlyRate * 1.5 * overtimeHours;
        }

        public TimeCard GetTimeCard(DateTime date)
        {
            return timeCards[date] as TimeCard;
        }

        public void AddTimeCard(TimeCard card)
        {
            timeCards[card.Date] = card;
        }

        public HourlyClassification(double hourlyRate)
        {
            this.hourlyRate = hourlyRate;
        }

        public double HourlyRate
        {
            get { return hourlyRate; }
        }

        public override string ToString()
        {
            return String.Format("${0}", hourlyRate);
        }
    }
}
