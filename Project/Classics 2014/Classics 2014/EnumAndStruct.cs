using System;
using System.Windows.Forms;
using System.Collections.Generic;
namespace Classics_2014
{
    public enum EventType
    {
        Accuracy,
    }

    #region Accuracy Variations

    #endregion 
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

    public struct MySqlCompetitorTeamReturn
    {
        public int UID;
        public string Team;
    }

    public struct MySqlTeamsReturn
    {
        public List<List<TCompetitor>> Teams;
        public List<string> TeamNames;
    }
}