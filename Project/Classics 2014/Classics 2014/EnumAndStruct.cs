using System;
using System.Windows.Forms;
using System.Collections.Generic;
namespace Classics_2014
{
    public enum EventType
    {
        Accuracy,
    }

    public enum ModifyNameTypes
    {
        Competitor,
        Team,
        Scoring_Team
    }

    [Serializable]
    public struct TWind
    {
        public string time;
        public float speed;
        public ushort direction;
    }
}