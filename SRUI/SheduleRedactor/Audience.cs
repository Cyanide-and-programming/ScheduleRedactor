using System;

namespace SheduleRedactor
{
    [Serializable]
    public class Audience: IEquatable<Audience>
    {
        /// <summary>
        /// Номер аудиторії
        /// </summary>
        public String Number { get; set; }
        /// <summary>
        /// Повертає логічне значення, що показує чи є в адиторії проект
        /// </summary>
        public Boolean HasProjector { get; set; }
        /// <summary>
        /// Місткість аудиторії
        /// </summary>
        public ushort Capacity { get; set; }

        public Audience(String number = "NoNumber",
            Boolean hasProjector = false, UInt16 capacity = 0)
        {
            this.Number = number;
            this.HasProjector = hasProjector;
            this.Capacity = capacity;
        }

        public override string ToString()
        {
            string projector = this.HasProjector ? "наявний" : "відсутній";
            return String.Format("Номер: {0}\t Місткість: {1}\t Проектор {2}{3}",
                this.Number, this.Capacity, projector, Environment.NewLine);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Audience))
                return false;
            return this.GetHashCode().Equals(obj.GetHashCode());
        }

        public bool Equals(Audience other)
        {
            return this.Number.Equals(other.Number)
                && this.HasProjector.Equals(other.HasProjector)
                && this.Capacity.Equals(other.Capacity);
        }

        public override int GetHashCode()
        {
            return this.Number.GetHashCode();
        }
    }
}