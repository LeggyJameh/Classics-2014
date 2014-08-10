using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classics_2014
{
    public static class GlobalFunctions
    {
        public static Rulesets.AccuracyRuleset ConvertByteArrayToAccuracyRuleSet(byte[] ruleset)
        {
            Rulesets.AccuracyRuleset Rules = new Rulesets.AccuracyRuleset();
            ASCIIEncoding ascii = new ASCIIEncoding();
            string[] args = ascii.GetString(ruleset).Split('*');
            Rules.Stage = Convert.ToInt16(args[0]);
            Rules.ScoresUsed = Convert.ToString(args[1]);
            Rules.compHalt = Convert.ToSingle(args[2]);
            Rules.directionOut = Convert.ToUInt16(args[3]);
            Rules.finalApproachTime = Convert.ToSingle(args[4]);
            Rules.maxScored = Convert.ToInt16(args[5]);
            Rules.noOfCompetitorsPerTeam = Convert.ToInt16(args[6]);
            Rules.preset = args[7];
            Rules.windout = Convert.ToSingle(args[8]);
            Rules.windSecondsPrior = Convert.ToInt16(args[9]);
            Rules.windSecondsAfter = Convert.ToInt16(args[10]);

            return Rules;
        }
    }
}
