using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classics_2014.Ruleset
{
    [Serializable]
    public class AccuracyRules : Ruleset
    {
        public string preset;
        public string ScoresUsed;
        public float windout;
        public int directionOut;
        public float compHalt;
        public int maxScored;
        public int windSecondsPrior;
        public int windSecondsAfter;
        public float windSpeedNeededForDirectionChangeRujumps;
        public int timeCheckAngleChangePrior;
        public int timeCheckAngleChangeAfter;
        public AccuracyRules()
        {
            preset = "";
            ScoresUsed = "";
            windout = 0f;
            directionOut = 0;
            compHalt = 0f;
            maxScored = 0;
            windSecondsAfter = 0;
            windSecondsPrior = 0;
            windSpeedNeededForDirectionChangeRujumps = 0f;
            timeCheckAngleChangeAfter = 0;
            timeCheckAngleChangePrior = 0;
        }
    }
}
