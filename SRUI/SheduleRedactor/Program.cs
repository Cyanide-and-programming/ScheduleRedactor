using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text.RegularExpressions;

namespace SheduleRedactor
{
    class Program
    {
        static void Main(string[] args)
        {
            Week w = new Week();
            Console.WriteLine(w.Monday.DayOfWeek.ToString());
            Console.ReadKey();
        }
    }
}
