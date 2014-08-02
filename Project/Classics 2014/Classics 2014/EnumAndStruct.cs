using System;
using System.Windows.Forms;
namespace Classics_2014
{
    public enum EventType
    {
        Accuracy,
    }
    [Serializable]
    public struct TAccuracyRuleSet 
    {
        public int Stage;
        public string preset;
        public bool allScoresUsed;
        public int noOfCompetitorsPerTeam;
        public float windout;
        public int directionOut;
        public float compHalt;
        public int maxScored;
        public int windSecondsPrior;
        public int windSecondsAfter;
        public float finalApproachTime;
    }

    [Serializable]
    public struct TWind
    {
        public string time;
        public float speed;
        public ushort direction;
    }

    [Serializable]
    public struct TCompetitor
    {
        public int ID;
        public string name;
        public string team;
        public string nationality;
    }

    [Serializable]
    public struct TMySQLEventReturn
    {
        public int ID;
        public DateTime Date;
        public string Name;
        public EventType Type;
        public byte[] Options;
    }
}