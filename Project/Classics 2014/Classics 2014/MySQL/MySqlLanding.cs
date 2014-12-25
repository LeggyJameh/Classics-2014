using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMS.MySQL
{
    [Serializable]
    class MySqlLanding : Landing
    {
        public byte[] Data;
        public MySqlLanding()
        {
            Data = new Byte[1];
        }
    }
}
