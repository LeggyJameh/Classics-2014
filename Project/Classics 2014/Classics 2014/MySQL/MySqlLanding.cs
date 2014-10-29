using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classics_2014.MySQL
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
