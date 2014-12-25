using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMS
{
    class EventCompetitor : Competitor
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
            this.team = competitor.team;
        }
    }
}
