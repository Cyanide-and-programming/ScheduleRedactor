using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SheduleRedactor
{
    [Serializable]
    public class DayRow
    {
        private Audience audience;
        private String teacher;
        private Subject subject;

        public DayRow()
        {
            this.audience = new Audience();
            this.teacher = "NoTeacher";
            this.subject = new Subject();
            this.KindOfWeek = SheduleRedactor.KindOfWeek.Numerator;
        }

        public DayRow(Audience audience, string teacher, Subject subject,
             SheduleRedactor.KindOfWeek kindOfWeek)
        {
            this.audience = audience;
            this.teacher = teacher;
            this.subject = subject;
            this.KindOfWeek = kindOfWeek;
        }

        /// <summary>
        /// Аудиторія
        /// </summary>
        public Audience Audience
        {
            get { return this.audience; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException();

                audience = value;
            }
        }
        /// <summary>
        /// Викладач
        /// </summary>
        public String Teacher
        {
            get { return this.teacher; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException();
                if (value == String.Empty)
                    throw new ArgumentException();
                this.teacher = value;
            }
        }
        /// <summary>
        /// Предмет
        /// </summary>
        public Subject Subject
        {
            get { return this.subject; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException();

                this.subject = value;
            }
        }
        /// <summary>
        /// Вид тижня (чисельник/знаменник)
        /// </summary>
        public KindOfWeek KindOfWeek { get; set; }

        public Boolean HasAudience(Audience audience)
        {
            return this.audience.Equals(audience);
        }

        public Boolean HasAudience(String audienceNumber)
        {
            return this.audience.Number.Equals(audienceNumber);
        }

        public Boolean HasTeacher(String teacher)
        {
            return this.teacher.Equals(teacher);
        }

        public Boolean HasSubject(Subject subject)
        {
            return this.subject.Equals(subject);
        }


    }
}