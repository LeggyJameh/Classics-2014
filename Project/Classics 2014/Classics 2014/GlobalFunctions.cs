using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classics_2014
{
    static class GlobalFunctions
    {
        public static List<EventCompetitor> ConvertCompetitorsForEvent(List<Competitor> Competitors)
        {
            List<EventCompetitor> EventCompetitors = new List<EventCompetitor>();
            for (int i = 0; i < Competitors.Count; i++)
            {
                EventCompetitor CurrentCompetitor = new EventCompetitor();
                CurrentCompetitor.ID = Competitors[i].ID;
                CurrentCompetitor.name = Competitors[i].name;
                CurrentCompetitor.nationality = Competitors[i].nationality;
                CurrentCompetitor.team = Competitors[i].team;
                CurrentCompetitor.EID = "";
                EventCompetitors.Add(CurrentCompetitor);
            }
            return EventCompetitors;
        }

        public static Rulesets.AccuracyRuleset ConvertByteArrayToAccuracyRuleSet(byte[] ruleset)
        {
            Rulesets.AccuracyRuleset Rules = new Rulesets.AccuracyRuleset();
            ASCIIEncoding ascii = new ASCIIEncoding();
            string[] args = ascii.GetString(ruleset).Split('*');
            Rules.Stage = Convert.ToInt16(args[0]);
            Rules.ScoresUsed = Convert.ToString(args[1]);
            Rules.compHalt = Convert.ToSingle(args[2]);
            Rules.directionOut = Convert.ToUInt16(args[3]);
            Rules.windSpeedNeededForDirectionChangeRujumps = Convert.ToSingle(args[4]);
            Rules.maxScored = Convert.ToInt16(args[5]);
            Rules.noOfCompetitorsPerTeam = Convert.ToInt16(args[6]);
            Rules.preset = args[7];
            Rules.windout = Convert.ToSingle(args[8]);
            Rules.windSecondsPrior = Convert.ToInt16(args[9]);
            Rules.windSecondsAfter = Convert.ToInt16(args[10]);
            Rules.timeCheckAngleChangePrior = Convert.ToInt16(args[11]);
            Rules.timeCheckAngleChangeAfter = Convert.ToInt16(args[12]);
            return Rules;
        }

        public static Accuracy.MySqlReturnLanding CastAccLandingToMySqlReturnLanding(Accuracy.AccuracyLanding Landing)
        {
            Accuracy.MySqlReturnLanding NewLanding = new Accuracy.MySqlReturnLanding();

            NewLanding.dataGridCell = Landing.dataGridCell;
            NewLanding.ID = Landing.ID;
            NewLanding.Index = Landing.Index;
            NewLanding.LandingWind = Landing.LandingWind;
            NewLanding.score = Landing.score;
            NewLanding.TimeOfLanding = Landing.TimeOfLanding;
            NewLanding.WindDataAfter = Landing.WindDataAfter;
            NewLanding.windDataPrior = Landing.windDataPrior;
            NewLanding.WindInputs = Landing.WindInputs;

            NewLanding.Round = 0;
            NewLanding.UID = 0;
            NewLanding.Modified = false;

            return NewLanding;
        }
    }
}
