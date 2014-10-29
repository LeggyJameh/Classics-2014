using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Classics_2014.MySQL;


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
                EventCompetitors.Add(CurrentCompetitor);
            }
            return EventCompetitors;
        }

        public static Ruleset.AccuracyRules ConvertByteArrayToAccuracyRules(byte[] Rules)
        {
            Ruleset.AccuracyRules CurrentRules = new Ruleset.AccuracyRules();
            ASCIIEncoding ascii = new ASCIIEncoding();
            string[] args = ascii.GetString(Rules).Split('*');
            CurrentRules.Stage = Convert.ToInt16(args[0]);
            CurrentRules.ScoresUsed = Convert.ToString(args[1]);
            CurrentRules.compHalt = Convert.ToSingle(args[2]);
            CurrentRules.directionOut = Convert.ToUInt16(args[3]);
            CurrentRules.windSpeedNeededForDirectionChangeRujumps = Convert.ToSingle(args[4]);
            CurrentRules.maxScored = Convert.ToInt16(args[5]);
            CurrentRules.noOfCompetitorsPerTeam = Convert.ToInt16(args[6]);
            CurrentRules.preset = args[7];
            CurrentRules.windout = Convert.ToSingle(args[8]);
            CurrentRules.windSecondsPrior = Convert.ToInt16(args[9]);
            CurrentRules.windSecondsAfter = Convert.ToInt16(args[10]);
            CurrentRules.timeCheckAngleChangePrior = Convert.ToInt16(args[11]);
            CurrentRules.timeCheckAngleChangeAfter = Convert.ToInt16(args[12]);
            return CurrentRules;
        }

        
    }
}
