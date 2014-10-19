using System;
using System.Collections.Generic;
using System.Text;

namespace mmClock
{
    public partial class frmMain
    {
    
        [Serializable]
        class Clock
        {
            private string time;
            /// <summary>
            /// 时间
            /// </summary>
            public string Time
            {
                get { return time; }
                set { time = value; }
            }

            private string sTime;
            /// <summary>
            /// 剩余时间
            /// </summary>
            public string STime
            {
                get { return sTime; }
                set { sTime = value; }
            }

            private string state;
            /// <summary>
            /// 状态
            /// </summary>
            public string State
            {
                get { return state; }
                set { state = value; }
            }
        }

        [Serializable]
        class ClockList
        {
            public List<Clock> List;
            public ClockList()
            {
                List = new List<Clock>();
            }
        }
    }
}
