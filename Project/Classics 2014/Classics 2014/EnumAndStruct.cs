using System;
using System.Windows.Forms;
using System.Collections.Generic;
namespace CMS
{
    public enum EventType
    {
        NONE = -1,
        FAI_ART = 0,
        FAI_CF_2 = 1,
        FAI_CF_4 = 2,
        FAI_CF_8 = 3,
        FAI_CP = 4,
        FAI_FS_4 = 5,
        FAI_FS_8 = 6,
        FAI_PARASKI = 7,
        FAI_SPEED = 8,
        FAI_STYLE_ACCURACY = 9,
        FAI_VFS = 10,
        FAI_WINGSUIT = 11,
        INTL_ACCURACY = 12,
        INTL_ART = 13,
        INTL_CF_2 = 14,
        INTL_CF_4 = 15,
        INTL_CP = 16,
        INTL_FS_4 = 17,
        INTL_FS_8 = 18,
        INTL_FS_SPEED = 19,
        INTL_PARASKI = 20,
        INTL_SPEED = 21,
        INTL_STYLE_ACCURACY = 22,
        INTL_VFS = 23,
        INTL_WINGSUIT = 24
    }

    public enum EventStage
    {
        SetupRules = 0,
        SetupTeams = 1,
        SetupEID = 2,
        Ready = 3
    }

    public enum CPLandingType
    {
        Accuracy = 0,
        Speed = 1,
        Distance = 2
    }

    [Serializable]
    public struct TWind
    {
        public string time;
        public float speed;
        public ushort direction;
    }

    public enum SelectedOption
    {
        All = 0,
        Selected = 1,
        Unselected = 2
    }

    public enum FilterOption
    {
        Both = 0,
        Full = 1,
        NotFull = 2
    }

    public enum TeamMode
    {
        Simple = 0,
        Advanced = 1
    }
}