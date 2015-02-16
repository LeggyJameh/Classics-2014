using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMS
{
    class EventCompetitor : Competitor, ICloneable
    {
        public string EID;
        public EventCompetitor()
        {
            EID = "";
        }

        public EventCompetitor(Competitor competitor)
        {
            EID = "";
            this.ID = competitor.ID;
            this.name = competitor.name;
            this.nationality = competitor.nationality;
            this.group = competitor.group;
        }

        public object Clone()
        {
            EventCompetitor newCompetitor = (EventCompetitor)base.Clone();
            newCompetitor.EID = this.EID;
            return newCompetitor;
        }
    }
}
