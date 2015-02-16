using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace CMS
{
    class Team : ICloneable
    {
        public int ID;
        public int EventID;
        public string Name;
        public List<EventCompetitor> Competitors;
        public Bitmap TeamImage;
        public Team()
        {
            Competitors = new List<EventCompetitor>();
            Name = "";
        }
        public Team(string Name)
        {
            this.Name = Name;
        }

        public object Clone()
        {
            Team newTeam = new Team();
            newTeam.Competitors = new List<EventCompetitor>();
            foreach (EventCompetitor c in Competitors)
            {
                newTeam.Competitors.Add((EventCompetitor)c.Clone());
            }
            newTeam.EventID = this.EventID;
            newTeam.ID = this.ID;
            newTeam.Name = this.Name;
            newTeam.TeamImage = this.TeamImage;
            return newTeam;
        }
    }
}
