using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMS
{
    class CompetitorSelectorData
    {
        List<string> teams;
        List<bool> teamsSelected;
        List<Competitor> competitors;
        List<bool> competitorsSelected;

        public CompetitorSelectorData()
        {
            teams = new List<string>();
            teamsSelected = new List<bool>();
            competitors = new List<Competitor>();
            competitorsSelected = new List<bool>();
        }

        public int AddCompetitor(Competitor c)
        {
            bool exists = false;
            foreach (Competitor x in competitors)
            {
                if (x == c)
                {
                    exists = true;
                }
            }
            if (exists == false)
            {
                competitors.Add(c);
                competitorsSelected.Add(false);
            }
            return indexOf(c);
        }

        public int AddCompetitor(Competitor c, bool value)
        {
            bool exists = false;
            foreach (Competitor x in competitors)
            {
                if (x == c)
                {
                    exists = true;
                }
            }
            if (exists == false)
            {
                competitors.Add(c);
                competitorsSelected.Add(value);
            }
            return indexOf(c);
        }

        public int InsertCompetitorAt(Competitor c, int index)
        {
            bool exists = false;
            foreach (Competitor x in competitors)
            {
                if (x == c)
                {
                    exists = true;
                }
            }
            if (exists == true)
            {
                competitors.Insert(index, c);
                competitorsSelected.Insert(index, false);
            }
            return indexOf(c);
        }

        public void RemoveCompetitor(Competitor c)
        {
            if (indexOf(c) > 0)
            {
                competitors.Remove(c);
            }
        }

        public void RemoveCompetitorAt(int index)
        {
            if (competitors[index] != null)
            {
                competitors.RemoveAt(index);
            }
        }

        public Competitor GetCompetitorAt(int index)
        {
            if (competitors[index] != null)
            {
                return competitors[index];
            }
            else return null;
        }

        public int GetIndexOf(Competitor competitor)
        {
            return indexOf(competitor);
        }

        public bool CompetitorValue(Competitor competitor)
        {
            int index = indexOf(competitor);
            return competitorsSelected[index];
        }

        public bool CompetitorValue(int index)
        {
            return competitorsSelected[index];
        }

        public List<Competitor> GetCompetitors()
        {
            return competitors;
        }

        public void SetValue(Competitor c, bool value)
        {
            int index = indexOf(c);
            if (index != -1)
            {
                competitorsSelected[index] = value;
            }
        }

        public int CompetitorCount()
        {
            return competitors.Count;
        }

        public bool Contains(Competitor c)
        {
            if (indexOf(c) >= 0)
            {
                return true;
            }
            else return false;
        }

        public int AddTeam(string t)
        {
            bool exists = false;
            foreach (string x in teams)
            {
                if (x == t)
                {
                    exists = true;
                }
            }
            if (exists == false)
            {
                teams.Add(t);
                teamsSelected.Add(false);
            }
            return indexOf(t);
        }

        public int AddTeam(string t, bool value)
        {
            bool exists = false;
            foreach (string x in teams)
            {
                if (x == t)
                {
                    exists = true;
                }
            }
            if (exists == false)
            {
                teams.Add(t);
                teamsSelected.Add(value);
            }
            return indexOf(t);
        }

        public int InsertTeamAt(string t, int index)
        {
            bool exists = false;
            foreach (string x in teams)
            {
                if (x == t)
                {
                    exists = true;
                }
            }
            if (exists == true)
            {
                teams.Insert(index, t);
                teamsSelected.Insert(index, false);
            }
            return indexOf(t);
        }

        public void RemoveTeam(string t)
        {
            if (indexOf(t) > 0)
            {
                teams.Remove(t);
            }
        }

        public void RemoveTeamAt(int index)
        {
            if (teams[index] != null)
            {
                teams.RemoveAt(index);
            }
        }

        public string GetTeamAt(int index)
        {
            if (teams[index] != null)
            {
                return teams[index];
            }
            else return "";
        }

        public int GetIndexOf(string team)
        {
            return indexOf(team);
        }

        public bool TeamValue(string team)
        {
            int index = indexOf(team);
            return teamsSelected[index];
        }

        public bool TeamValue(int index)
        {
            return teamsSelected[index];
        }

        public List<string> GetTeams()
        {
            return teams;
        }

        public void SetValue(string t, bool value)
        {
            int index = indexOf(t);
            if (index != -1)
            {
                teamsSelected[index] = value;
            }
        }

        public int TeamCount()
        {
            return teams.Count;
        }

        public bool Contains(string t)
        {
            if (indexOf(t) >= 0)
            {
                return true;
            }
            else return false;
        }

        private int indexOf(Competitor c)
        {
            int index = -1;
            foreach (Competitor x in competitors)
            {
                if (x.ID == c.ID && x.name == c.name && x.nationality == c.nationality && x.team == c.team)
                {
                    index = competitors.IndexOf(x);
                }
            }
            return index;
        }

        private int indexOf(string t)
        {
            int index = -1;
            foreach (string team in teams)
            {
                if (team == t)
                {
                    index = teams.IndexOf(team);
                }
            }
            return index;
        }
    }
}
