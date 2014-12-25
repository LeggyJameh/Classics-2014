using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMS.MySQL;
using System.Reflection;
using System.ComponentModel;


namespace CMS
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
            CurrentRules.stage = (EventStage)Convert.ToInt16(args[0]);
            CurrentRules.scoresUsed = Convert.ToString(args[1]);
            CurrentRules.windspeedSafe = Convert.ToSingle(args[2]);
            CurrentRules.directionChangeFA = Convert.ToUInt16(args[3]);
            CurrentRules.windspeedFA = Convert.ToSingle(args[4]);
            CurrentRules.maxScore = Convert.ToInt16(args[5]);
            CurrentRules.competitorsPerTeam = Convert.ToInt16(args[6]);
            CurrentRules.preset = args[7];
            CurrentRules.windspeedRejump = Convert.ToSingle(args[8]);
            CurrentRules.windSecondsPriorLand = Convert.ToInt16(args[9]);
            CurrentRules.windSecondsAfterLand = Convert.ToInt16(args[10]);
            CurrentRules.timePriorFA = Convert.ToInt16(args[11]);
            CurrentRules.timeAfterFA = Convert.ToInt16(args[12]);
            return CurrentRules;
        }        
    }
}
