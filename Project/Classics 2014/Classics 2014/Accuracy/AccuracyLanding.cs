using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CMS.Accuracy
{
    [Serializable]
    class AccuracyLanding : Landing
    {
        [NonSerialized]
        public int index;
        [NonSerialized]
        public int windEnum; // Wind Enumerator.
        [NonSerialized]
        public bool completed;
        [NonSerialized]
        public bool lostInput;

        public string time;
        public int score;
        public bool modified;
        public bool rejumpable;
        public int round;
        public TWind[] windDataPrior;
        public TWind[] windDataAfter;

        /// <summary>
        /// Empty Landing
        /// </summary>
        public AccuracyLanding()
        {
            score = 0;
            round = 0;
            modified = false;
            rejumpable = false;
            completed = false;
        }

        /// <summary>
        /// Used for manual landings
        /// </summary>
        public AccuracyLanding(int score, int round)
        {
            this.score = score;
            this.round = round;
            time = DateTime.Now.ToLongTimeString();
            modified = false;
            rejumpable = false;
            completed = true;
        }

        /// <summary>
        /// Used when creating the landing in all other circumstances.
        /// </summary>
        /// <param name="timeOfLanding"></param>
        /// <param name="score"></param>
        /// <param name="modified"></param>
        /// <param name="rejumpable"></param>
        /// <param name="completed"></param>
        /// <param name="round"></param>
        /// <param name="windDataPrior"></param>
        /// <param name="windDataAfter"></param>
        public AccuracyLanding(string timeOfLanding, int score, bool modified, bool rejumpable, bool completed, int round, TWind[] windDataPrior, TWind[] windDataAfter)
        {
            this.time = timeOfLanding;
            this.score = score;
            this.modified = modified;
            this.rejumpable = rejumpable;
            this.completed = completed;
            this.round = round;
            this.windDataPrior = windDataPrior;
            this.windDataAfter = windDataAfter;
        }
    }
}
