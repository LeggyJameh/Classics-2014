using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMS
{
    class Data_Accuracy : Data
    {
        public bool IsLanding;
        public byte LandingScore;

        public override string ToString()
        {
            string str = Time + " : " + Speed + " : " + Direction;
            if (IsLanding) { str += " : " + LandingScore; }
            return str;
        }
    }
}
