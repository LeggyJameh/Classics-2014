using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMS.FAI_CP
{
    [Serializable]
    class FAI_CPLanding : Landing
    {
        [NonSerialized]
        public int index;
        [NonSerialized]
        public int windEnum;
        [NonSerialized]
        public bool completed;
        [NonSerialized]
        public bool lostInput;

        public string time;
        public int score;
        public int calculatedScore;
        public bool modified;
        public bool rejumpable;
        public int round;
        public TWind[] windDataPrior;
        public TWind[] windDataAfter;        
        public CPLandingType type;

        /// <summary>
        /// Empty Landing
        /// </summary>
        public FAI_CPLanding()
        {
            index = 0;
            windEnum = 0;
            completed = false;
            lostInput = false;

            time = "";
            score = 0;
            calculatedScore = 0;
            modified = false;
            rejumpable = false;
            round = 0;
            windDataPrior = new TWind[1];
            windDataAfter = new TWind[1];
            type = CPLandingType.Accuracy;
        }

        /// <summary>
        /// Used for manual landings
        /// </summary>
        public FAI_CPLanding(int score, int round, CPLandingType type)
        {
            this.score = score;
            this.round = round;
            this.calculatedScore = score;
            this.type = type;
            time = DateTime.Now.ToLongTimeString();
            modified = false;
            rejumpable = false;
            completed = true;
        }

        /// <summary>
        /// Used when creating the landing in all other circumstances.
        /// </summary>
        public FAI_CPLanding(string timeOfLanding, int score, int modifiedScore, bool modified, bool rejumpable, bool completed, TWind[] windDataPrior, TWind[] windDataAfter, CPLandingType type)
        {
            this.time = timeOfLanding;
            this.score = score;
            this.calculatedScore = modifiedScore;
            this.modified = modified;
            this.completed = completed;
            this.windDataPrior = windDataPrior;
            this.windDataAfter = windDataAfter;
            this.type = type;
        }
    }
}
