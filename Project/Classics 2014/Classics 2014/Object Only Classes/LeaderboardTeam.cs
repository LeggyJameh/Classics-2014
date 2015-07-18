using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMS
{
    class LeaderboardTeam
    {
        public List<LeaderboardCompetitor> members;
        public int score;
        public int commonRound;
        public int rank;
        public string name;

        public LeaderboardTeam()
        {
            members = new List<LeaderboardCompetitor>();
            score = 0;
            commonRound = 0;
            rank = 0;
            name = "";
        }

        public LeaderboardTeam(int score, int commonRound, int rank, string name, List<LeaderboardCompetitor> members)
        {
            this.score = score;
            this.commonRound = commonRound;
            this.rank = rank;
            this.members = members;
            this.name = name;
        }

        public LeaderboardTeam(int score, int commonRound, int rank, string name, params LeaderboardCompetitor[] members)
        {
            this.score = score;
            this.commonRound = commonRound;
            this.rank = rank;
            this.name = name;

            this.members = new List<LeaderboardCompetitor>();
            if (members != null)
            {
                if (members.Length > 0)
                {
                    foreach (LeaderboardCompetitor c in members)
                    {
                        this.members.Add(c);
                    }
                }
            }
        }
    }
}
