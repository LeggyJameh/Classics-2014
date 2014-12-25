using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMS.MySQL
{
    [Serializable]
    class MySqlTeam
    {
        public int ID;
        public int EventID;
        public string Name;
        public byte[] Data;
        public byte[] Image;
    }
}
