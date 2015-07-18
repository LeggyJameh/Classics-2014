using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace CMS
{
    class LeaderboardCompetitor
    {
        public EventCompetitor competitor;
        public dynamic landings;
        public int score;
        public int rank;

        public LeaderboardCompetitor()
        {
            this.score = 0;
            this.competitor = new EventCompetitor();
        }

        /// <summary>
        /// Initialiser for accuracy module.
        /// </summary>
        public LeaderboardCompetitor(EventCompetitor competitor, ObservableCollection<CMS.Accuracy.AccuracyLanding> landings, int score)
        {
            this.competitor = competitor;
            this.landings = landings;
            this.score = score;
        }
    }
}
