using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Collections.Concurrent;

namespace Classics_2014
{
     partial class DebugIOWINDOW : Form
    {
        #region variables And Shiz
        public readonly ConcurrentQueue<Data> Data_queue;
        public readonly AutoResetEvent _signal;
        public int windDirection { get { return Convert.ToInt16(numericUpDownDirection.Value); } }
        public Single windSpeed { get { return Convert.ToSingle(numericUpDownSpeed.Value); } }
        Thread t;
        bool active = false;
        int newScoreVal;
        bool newScore;
        #endregion
        public DebugIOWINDOW(ConcurrentQueue<Data> Data_queue, AutoResetEvent _signal)
        {
            InitializeComponent();
            this.Data_queue = Data_queue;
            this._signal = _signal;
        }

        private void buttonPassScore_Click(object sender, EventArgs e)
        {
            newScoreVal = Convert.ToInt16(numericUpDownScore.Value);
            newScore = true;
        }

        private void timerInput_Tick(object sender, EventArgs e)
        {
            Data_Accuracy Data = new Data_Accuracy();
            if (newScore)
            {
                Data.IsLanding = true; Data.LandingScore = Convert.ToByte(newScoreVal);
            }
            Data.Speed = (float)windSpeed;
            Data.Direction = Convert.ToUInt16(windDirection);

            Data.Time = "";
            Data.Time += DateTime.Now.Hour.ToString("00");
            Data.Time += ":";
            Data.Time += DateTime.Now.Minute.ToString("00");
            Data.Time += ":";
            Data.Time += DateTime.Now.Second.ToString("00");
            Data.dataType = EventType.Accuracy;
            Data_queue.Enqueue(Data);
            _signal.Set();
        }

        private void buttonActivate_Click(object sender, EventArgs e)
        {
            if (active)
            {
                timerInput.Enabled = false;
                buttonActivate.BackColor = Color.Red;
                buttonActivate.Text = "Press to activate";
                active = false;
            }
            else
            {
                timerInput.Enabled = true;
                buttonActivate.BackColor = Color.Green;
                buttonActivate.Text = "Press to deactivate";
                active = true;
            }
        }
    }
}
