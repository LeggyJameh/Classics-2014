using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classics_2014.Rulesets
{
    [Serializable]
    public class AccuracyRuleset : Ruleset
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
    }
}
