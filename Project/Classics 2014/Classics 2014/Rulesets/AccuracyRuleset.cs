using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMS.Ruleset
{
    [Serializable]
    public class AccuracyRules : Ruleset
    {
        public string preset; /// The preset being used.
        public string scoresUsed; /// The scores being used, e.g. Top 5.
        public float windspeedRejump; /// Legal Windspeed. Above = Rejump.
        public int directionChangeFA; /// Wind change allowed during FA.
        public float windspeedSafe; /// Safe windspeed. Competition suspended if above.
        public int maxScore; /// Max available score for the competition.
        public int windSecondsPriorLand; /// Wind seconds to be logged for the entire jump before impact.
        public int windSecondsAfterLand; /// Wind seconds to be logged for the entire jump after impact.
        public float windspeedFA; /// Legal windspeed during FA.
        public int timePriorFA; /// FA time period before impact.
        public int timeAfterFA; /// FA time period after impact.
        public AccuracyRules()
        {
            preset = "";
            scoresUsed = "";
            windspeedRejump = 0f;
            directionChangeFA = 0;
            windspeedSafe = 0f;
            maxScore = 0;
            windSecondsAfterLand = 0;
            windSecondsPriorLand = 0;
            windspeedFA = 0f;
            timeAfterFA = 0;
            timePriorFA = 0;
        }
    }
}
