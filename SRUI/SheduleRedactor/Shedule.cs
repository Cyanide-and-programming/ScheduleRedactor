using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SheduleRedactor
{
    public class Shedule
    {
        public String Group { get; set; }
        public Week Week { get; private set; }

        public Shedule(Week week = null, String group = "")
        {
            this.Week = week;
            this.Group = group;
        }
    }
}
