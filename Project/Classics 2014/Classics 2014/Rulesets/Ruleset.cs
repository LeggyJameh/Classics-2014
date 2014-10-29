using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classics_2014.Ruleset
{
    [Serializable]
    public class Ruleset
    {
        public int Stage;
        public int noOfCompetitorsPerTeam;
        public Ruleset()
        {
            Stage = 0;
            noOfCompetitorsPerTeam = 0;
        }
    }
}
