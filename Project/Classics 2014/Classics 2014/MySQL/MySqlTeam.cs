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

        public MySqlTeam()
        {
            ID = -1;
            EventID = -1;
            Name = "";
            Data = new byte[1];
            Image = new byte[1];
        }
    }
}
