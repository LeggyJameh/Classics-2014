﻿using System;
namespace Classics_2014
{
    enum ScoreInputs
    {
        LandingPad,
    }

    [Serializable]
    public struct TAccuracyRuleSet
    {
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

    public struct Wind
    {
        public string time;
        public float speed;
        public ushort direction;
    }

    public struct TCompetitor
    {
        public int ID = -1;
        public string name = "";
        public string team = "";
        public string nationality = "";
    }

    public struct TLanding
    {
        public int ID;
        public string dataGridCell;
        public Wind[] windData;
        public int score;
    }
}