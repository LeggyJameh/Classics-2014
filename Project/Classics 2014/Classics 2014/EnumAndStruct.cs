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
        public bool TeamsSetup;
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

    public struct TWind
    {
        public string time;
        public float speed;
        public ushort direction;
    }

    public struct TCompetitor
    {
        public int ID;
        public string name;
        public string team;
        public string nationality;
    }

    public struct TMySQLEventReturn
    {
        public int ID;
        public DateTime Date;
        public string Name;
        public EventType Type;
        public byte[] Options;
    }
}