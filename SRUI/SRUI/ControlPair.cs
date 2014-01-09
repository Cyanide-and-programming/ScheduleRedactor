using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SRUI
{
    class ControlPair<T> where T: Control
    {
        public T First { get; set; }
        public T Second { get; set; }
    }
}
