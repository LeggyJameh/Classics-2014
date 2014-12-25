using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMS
{
    [Serializable]
    abstract class Landing
    {
        [NonSerialized]
        public int ID;
        [NonSerialized]
        public int eventID;
        [NonSerialized]
        public int UID;

        public Landing()
        {
            ID = 0;
            eventID = 0;
            UID = 0;
        }
    }
}
