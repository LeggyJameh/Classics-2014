using System;
using System.Windows.Forms;
using System.Collections.Generic;
namespace CMS
{
    public enum EventType
    {
        Accuracy,
    }

    public enum EventStage
    {
        SetupRules = 0,
        SetupTeams = 1,
        Ready = 2
    }

    [Serializable]
    public struct TWind
    {
        public string time;
        public float speed;
        public ushort direction;
    }
}