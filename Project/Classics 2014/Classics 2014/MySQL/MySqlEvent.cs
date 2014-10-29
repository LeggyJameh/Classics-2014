using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classics_2014.MySQL
{
    [Serializable]
    class MySqlEvent
    {
        [NonSerialized]
        public int ID;
        [NonSerialized]
        public string Name;
        [NonSerialized]
        public EventType Type;
        [NonSerialized]
        public DateTime Date;
        public byte[] Data;
    }
}
