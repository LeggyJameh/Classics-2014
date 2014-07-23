using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classics_2014
{
    abstract class Event
    {
        public bool RequiresSerial { get; private set; } // This is checked to see if Engine can Read the data without waiting (Psuedo Const)
    }
}
