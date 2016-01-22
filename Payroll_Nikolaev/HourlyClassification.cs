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
