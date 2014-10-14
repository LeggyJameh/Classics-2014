using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Classics_2014.Accuracy
{
    [Serializable]
    public class AccuracyLanding
    {
        public int ID;
        [NonSerialized]
        public DataGridViewCell dataGridCell;
        public TWind[] windDataPrior;
        public int score;
        public int Index;
        public int WindInputs;
        public String TimeOfLanding;
        public TWind LandingWind;
        public TWind[] WindDataAfter;
        public bool isRejumpable;
        public bool isComplete;
        public bool LostInput;
        public int eventID;
    }
}
