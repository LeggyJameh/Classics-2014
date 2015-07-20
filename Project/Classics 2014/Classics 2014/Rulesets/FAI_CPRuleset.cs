using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMS.Ruleset
{
    [Serializable]
    public class FAI_CPRules : Ruleset
    {
        public string preset; /// The preset being used.
        public float windspeedRejump; /// Legal Windspeed. Above = Rejump.
        public int directionChange; /// Wind change allowed during FA.
        public float windspeedSafe; /// Safe windspeed. Competition suspended if above.
        public int windSecondsPriorLand; /// Wind seconds to be logged for the entire jump before impact.
        public int windSecondsAfterLand; /// Wind seconds to be logged for the entire jump after impact.
        public FAI_CPRules()
        {
            preset = "";
            windspeedRejump = 0f;
            directionChange = 0;
            windspeedSafe = 0f;
            windSecondsAfterLand = 0;
            windSecondsPriorLand = 0;
            competitorsPerTeam = 1;
        }
    }
}
