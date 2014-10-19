using System;
using System.Windows.Forms;
using System.Media;

namespace alarmClock
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SoundPlayer player= new SoundPlayer();  
          
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            //绑定到combobox
            for (int i = 0; i <= 23; i++)
            {
                cmbHour.Items.Add(i);
            }
            for (int j = 0; j < 60; j++)
            {
                cmbMinute.Items.Add(j);
            }
            //绑定铃声
            cmbRing.Items.Add("步步高音乐.wav");
            cmbRing.Items.Add("背景音乐.wav");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            lblNow.Text = DateTime.Now.ToString();           
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbRing.Text))
            {
                MessageBox.Show("请选择播放的铃声！！");
                return;
            }
            playSound();
        }
        /// <summary>
        /// 播放wav声音文件
        /// </summary>
        private void playSound()
        {            
            //用new出来的实例点SoundLocation指定想要播放的音乐名称
            player.SoundLocation = cmbRing.Text;//（将播放音乐放在应用程序Debug目录下）
            player.Load();
            //音乐播放
            player.Play();
        }
        
        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (cmbHour.Text==""&&cmbMinute.Text=="")
            {
                MessageBox.Show("没有设置闹铃的时刻");
                return;
            }
            timer2.Start();           
        }     

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Interval = 1000;
            string h = cmbHour.Text;
            string m = cmbMinute.Text;
            string nowH =DateTime.Now.Hour.ToString();
            string nowM = DateTime.Now.Minute.ToString();
            if (h == nowH && m == nowM)
            {
                playSound();
                //开启后停止线程
                timer2.Stop();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer2.Stop();
            player.Stop();
        }    
    }
}
