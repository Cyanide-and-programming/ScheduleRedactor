using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SheduleRedactor
{
    [Serializable]
    public class Day : IEnumerable<DayRowPair>
    {
        //public List<Tuple<DayRow, DayRow>> Lessons { get; private set;}
        public List<DayRowPair> Lessons { get; private set; }

        public DayOfWeek DayOfWeek { get; private set; }

        public Day()
        {
            this.Lessons = new List<DayRowPair>();
            this.DayOfWeek = System.DayOfWeek.Monday;          
        }

        public Day(DayOfWeek dayOfWeek):this()
        {
            this.DayOfWeek = dayOfWeek;
        }

        public void AddLesson(DayRowPair lesson)
        {
            if (this.Lessons.Count == 7)
                throw new Exception("Неможливо додати ще одну пару. Максимальна к-сть пар - 7");
            this.Lessons.Add(lesson);
        }

        public void AddLesson(DayRow lesson, KindOfWeek kindOfWeek = KindOfWeek.Numerator)
        {
            if(this.Lessons.Count == 7)
                throw new Exception("Неможливо додати ще одну пару. Максимальна к-сть пар - 7");

            DayRowPair temp = (kindOfWeek.Equals(KindOfWeek.Numerator))
                                  ? new DayRowPair {Numerator = lesson, Denominator = null}
                                  : new DayRowPair {Numerator = null, Denominator = lesson};
            this.Lessons.Add(temp);
        }

        public void AddLesson(DayRow numeratorLesson, DayRow denominatorlesson)
        {
            if (this.Lessons.Count == 7)
                throw new Exception("Неможливо додати ще одну пару. Максимальна к-сть пар - 7");

            this.Lessons.Add(new DayRowPair
                {
                    Numerator = numeratorLesson, Denominator = denominatorlesson
                });
        }

        public IEnumerator<DayRowPair> GetEnumerator()
        {
            foreach (var item in this.Lessons)
                yield return item;
        }

        public IEnumerator<DayRow> GetNumeratorEnumerator()
        {
            foreach (var item in this)
                yield return item.Numerator;
        }

        public IEnumerator<DayRow> GetDenominatorEnumerator()
        {
            foreach (var item in this)
                yield return item.Denominator;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            foreach (var item in this.Lessons)
                yield return item;
        }
    }
}
