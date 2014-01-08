using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SheduleRedactor
{
    [Serializable]
    public class Week: IEnumerable<Day>
    {
        public List<Day> Days { get; private set; }

        public Week()
        {
            this.Days = new List<Day>{ 
                new Day(DayOfWeek.Monday),
                new Day(DayOfWeek.Tuesday),
                new Day(DayOfWeek.Wednesday),
                new Day(DayOfWeek.Thursday),
                new Day(DayOfWeek.Friday)};
        }

        public Day Monday
        {
            get
            {
                return this.Days.First(
                    value => value.DayOfWeek.Equals(DayOfWeek.Monday));
            }
        }
        public Day Tuesday
        {
            get
            {
                return this.Days.First(
                    value => value.DayOfWeek.Equals(DayOfWeek.Monday));
            }
        }
        public Day Wednesday
        {
            get
            {
                return this.Days.First(
                  value => value.DayOfWeek.Equals(DayOfWeek.Wednesday));
            }
        }
        public Day Thursday
        {
            get
            {
                return this.Days.First(
                  value => value.DayOfWeek.Equals(DayOfWeek.Thursday));
            }
        }
        public Day Friday
        {
            get
            {
                return this.Days.First(
                  value => value.DayOfWeek.Equals(DayOfWeek.Friday));
            }
        }

        public IEnumerator<Day> GetEnumerator()
        {
            foreach (var item in this.Days)
                yield return item;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            foreach (var item in this.Days)
                yield return item;
        }
    }
}
