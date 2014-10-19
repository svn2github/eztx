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
            /// ʱ��
            /// </summary>
            public string Time
            {
                get { return time; }
                set { time = value; }
            }

            private string sTime;
            /// <summary>
            /// ʣ��ʱ��
            /// </summary>
            public string STime
            {
                get { return sTime; }
                set { sTime = value; }
            }

            private string state;
            /// <summary>
            /// ״̬
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
