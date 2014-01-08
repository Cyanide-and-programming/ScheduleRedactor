using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SheduleRedactor
{
    [Serializable]
    public class Subject: IEquatable<Subject>
    {
        public String Name { get; private set; }
        public KindOfSubject KindOfSubject { get; private set; }

        public Subject(String name = "NoName", 
            KindOfSubject kindOfSubject = SheduleRedactor.KindOfSubject.Lecture)
        {
            this.Name = name;
            this.KindOfSubject = kindOfSubject;
        }

        public override bool Equals(object obj)
        {

            if (obj == null || !(obj is Subject))
                return false;
            var other = obj as Subject;
            return this.Name.Equals(other.Name)
                && this.KindOfSubject.Equals(other.KindOfSubject);
        }

        public bool Equals(Subject other)
        {
            if (other == null)
                return false;
            return this.Name.Equals(other.Name)
                && this.KindOfSubject.Equals(other.KindOfSubject);
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() 
                + this.KindOfSubject.GetHashCode();
        }
    }
}