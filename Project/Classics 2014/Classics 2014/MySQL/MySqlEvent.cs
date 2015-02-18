using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMS.MySQL
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

        public MySqlEvent()
        {
            ID = -1;
            Name = "Event";
            Type = EventType.NONE;
            DateTime.TryParse("23/10/2077", out Date);
            Data = new byte[1];
        }
    }
}
