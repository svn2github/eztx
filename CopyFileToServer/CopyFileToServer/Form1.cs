using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace CopyFileToServer
{


    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Thread t = new Thread(new ThreadStart(paoMaDeng));
            t.IsBackground=true;
            t.Start();
            Control.CheckForIllegalCrossThreadCalls = false;//防止出现跨线程操作控件错误
        }

        FileManager fm = new FileManager();

        private string filePath = null;

        private int totalSize = 0;//文件总大小
        private int totalNum = 0;//文件个数
        private int finishFile = 0;//当前完成

        //复制文件
        private void SearchFiles(string filePath)
        {
            try
            {
                DirectoryInfo folder = new DirectoryInfo(filePath);
                FileInfo[] chldFiles = folder.GetFiles("*.jpg");
                foreach (FileInfo chlFile in chldFiles)
                {
                    string subName = System.IO.Path.GetFileName(chlFile.FullName);//只得到文件名
                    //chlFile.CopyTo("C:\\abc\\" + subName, true);
                    string desPath = "C:\\abc\\";
                    if (File.Exists(desPath))
                    {
                        File.Copy(chlFile.FullName, desPath + subName, true);
                    }
                    else {
                        Directory.CreateDirectory(desPath);
                        File.Copy(chlFile.FullName, desPath + subName, true);
                    }
                    FileLabelText(chlFile.FullName);
                    finishFile++;
                    this.label3.Text = "当前已完成 " + finishFile + " 文件";

                    //设置进度条
                    this.progressBar1.Value += Convert.ToInt32(chlFile.Length);

                    //设置百分比
                    double percent = 100 * (this.progressBar1.Value - this.progressBar1.Minimum) / (this.progressBar1.Maximum - this.progressBar1.Minimum);
                    this.label1.Text = "完成:" + percent + "%";

                    Thread.Sleep(25);
                }

                DirectoryInfo[] chldFolders = folder.GetDirectories();
                foreach (DirectoryInfo chlFolders in chldFolders)
                {
                    SearchFiles(chlFolders.FullName);
                }
            }
            catch { }
            isFinished();
        }

        //查找并设定进度条长度
        private void CalculateDirSize(string filePath)
        {
            try
            {
                DirectoryInfo folder = new DirectoryInfo(filePath);
                FileInfo[] chldFiles = folder.GetFiles("*.jpg");
                foreach (FileInfo chlFile in chldFiles)
                {
                    totalSize += Convert.ToInt32(chlFile.Length);
                    totalNum++;
                    this.label2.Visible = true;
                    this.label2.Text = "当前有 "+totalNum+" 个文件。";
                    Thread.Sleep(25);
                }

                DirectoryInfo[] chldFolders = folder.GetDirectories();
                foreach (DirectoryInfo chlFolders in chldFolders)
                {
                    CalculateDirSize(chlFolders.FullName);
                }
            }
            catch { }

            this.progressBar1.Minimum = 0;
            this.progressBar1.Maximum = totalSize;
            
        }

        private void FileLabelText(string fullName)
        {
            label2.Text = fullName;
        }   

        private void Form1_Load(object sender, EventArgs e)
        {
            closeControl();
        }

        private void enableControl()
        {
            foreach (Control ctrl in this.panel1.Controls)
            {
                ctrl.Enabled = true;
            }
            this.button2.Enabled = false;
        }

        private void disableControl()
        {
            foreach (Control ctrl in this.panel1.Controls)
            {
                ctrl.Enabled = false;
            }
        }

        private void openControl()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl.Visible == false)
                    ctrl.Visible = true;
            }
        }

        private void closeControl()
        {
            totalNum = 0;
            totalSize = 0;
            finishFile = 0;

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Label || ctrl is ProgressBar)
                {
                    ctrl.Visible = false;
                }
                
                if (ctrl is ProgressBar)
                {
                    (ctrl as ProgressBar).Value = 0; (ctrl as ProgressBar).Maximum = 0; (ctrl as ProgressBar).Minimum = 0;
                }
            }

            foreach (Control ctrl in this.panel1.Controls)
            {
                if (ctrl is TextBox)
                {
                    (ctrl as TextBox).Text = "";
                }
            }
            this.button2.Enabled = false;
        }

        private void startCopy()
        {
            SearchFiles(filePath);
        }

        private void calFils()
        {
            CalculateDirSize(filePath);
        }

        private void isFinished()
        {
            if ((this.progressBar1.Value == this.progressBar1.Maximum) && (this.progressBar1.Maximum != 0 && this.progressBar1.Value!=0))
            {
                MessageBox.Show("总共 "+totalNum.ToString()+" 个文件，复制完毕！");
                closeControl();
                enableControl();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            closeControl();
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string fp = folderBrowserDialog1.SelectedPath;
                textBox1.Text = fp;
                filePath = fp;
            }
            Thread t = new Thread(new ThreadStart(calFils));
            t.IsBackground = true;
            t.Start();
            //MessageBox.Show(t.ThreadState.ToString());
            //MessageBox.Show(t.ThreadState.ToString());
            //if (t.ThreadState == ThreadState.Stopped)
                this.button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openControl();
            disableControl();
            Thread at = new Thread(new ThreadStart(startCopy));
            at.IsBackground = true;
            at.Start();
            
        }

        private void paoMaDeng()
        {
            //this.Text += "  "+DateTime.Now.ToString("yyyy年MM月dd日 HH时mm分ss秒");
            this.label4.Text = "欢迎使用";
            if (label4.Left > -this.label4.Width)
            {
                label4.Left -= 3;
                Thread.Sleep(100);
            }
            else
            {
                label4.Left = this.panel2.Width;
            }
        }
    }
}
