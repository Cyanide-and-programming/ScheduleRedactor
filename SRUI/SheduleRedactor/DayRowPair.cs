using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SheduleRedactor
{
    [Serializable]
    public class DayRowPair
    {
        public DayRow Numerator { get; set; }
        public DayRow Denominator { get; set; }

        public DayRowPair()
        {
            this.Numerator = null;
            this.Denominator = null;
        }
    }
}
