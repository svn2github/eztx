using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace readJPG
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "";
            button2.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = folderBrowserDialog1.SelectedPath;
                textBox1.Text = path;
                textBox2.Enabled = false;
                button3.Enabled = false;
                if (!File.Exists(path))
                {
                    label1.Text = "为目录，点击按钮将会把该目录下所有图片转正";
                    button2.Visible = true;
                }
                else {
                    label1.Text = "为图片，点击按钮将会把图片转正";
                    button2.Visible = true;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.Filter = "图片文件(*.jpg)|*.jpg|所有文件(*.*)|*.*"; ;
            //FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();

            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = this.openFileDialog1.FileName;
                //string path = folderBrowserDialog1.SelectedPath;
                textBox1.Enabled = false;
                button1.Enabled = false;
                textBox2.Text = path;
                if (!File.Exists(path))
                {
                    label1.Text = "为目录，点击按钮将会把该目录下所有图片转正";
                    button2.Visible = true;
                }
                else
                {
                    label1.Text = "为图片，点击按钮将会把图片转正";
                    button2.Visible = true;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            label1.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            button2.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string path = "";
            if (textBox1.Text != "")
                path = textBox1.Text;
            else
                path = textBox2.Text;
            Exif exif = new Exif(path);
            if (File.Exists(path))
            {
                if (exif.orientation == null)
                    MessageBox.Show("该图片Exif信息中暂无“方向(orientation)”数据，不能实施自动转换", "提示", MessageBoxButtons.OK);
                else
                {
                    string a=exif.orientation;
                    if (a.Equals("上/左")) 
                    {
                        Bitmap bitmap = new Bitmap(path);
                        Bitmap bmp = this.Rotate(bitmap, 90);
                        bmp.Save(System.IO.Path.GetExtension(path) + System.IO.Path.GetFileNameWithoutExtension(path) + "_re" + System.IO.Path.GetExtension(path), System.Drawing.Imaging.ImageFormat.Jpeg);
                        MessageBox.Show("完成");
                    }
                }
                    
            }
            if (Directory.Exists(path)) 
            {
                
            }
        }

        private void GetFiles(string filePath, TreeNode node, string keyword, string suffix, string finishName)//得到文件的方法括号中传参数(文件路径，树节点)
        {
            try
            {
                DirectoryInfo folder = new DirectoryInfo(filePath);//得到传过来的文件路径中的文件夹详细情况
                node.Text = folder.Name;//树节点的名字根据文件夹的名字来设置
                node.Tag = folder.FullName;//节点的数据信息根据得到的当前文件chlFile的全名定义
                FileInfo[] chldFiles = folder.GetFiles("*." + suffix);//从总的驱动器信息中得到要读取文件信息的文件的类型并存入

                foreach (FileInfo chlFile in chldFiles)//开始循环得到文件chlFile
                {
                    string subName = System.IO.Path.GetFileNameWithoutExtension(chlFile.FullName);//只得到文件名
                    string newPath = System.IO.Path.GetDirectoryName(chlFile.FullName);//得到文件所在地
                    string newPathSuffix = System.IO.Path.GetExtension(chlFile.FullName);

                    if (subName.IndexOf(keyword) > -1)
                    {
                        for (int i = 0; i < subName.Length; i++)
                        {
                            subName = subName.Replace(keyword, finishName);
                        }
                        File.Move(chlFile.FullName, newPath + "\\" + subName + newPathSuffix);//将文件移动，相当于改名
                    }
                }

                DirectoryInfo[] chldFolders = folder.GetDirectories();////从总的驱动器信息中得到驱动器中文件夹的信息并存入
                foreach (DirectoryInfo chldFolder in chldFolders)//开始循环得到文件夹chldFolder
                {
                    TreeNode chldNode = new TreeNode();//得到树节点
                    chldNode.Text = folder.Name;//节点标题根据得到的当前文件夹chldFolder的名称命名
                    chldNode.Tag = folder.FullName;//节点的数据信息根据得到的当前文件夹chldFolder的全名定义
                    node.Nodes.Add(chldNode);//将当前节点添加进文件的总树节点中
                    GetFiles(chldFolder.FullName, chldNode, keyword, suffix, finishName);
                }
            }
            catch
            {
                //throw new OverflowException();//抛出异常
            }
        }


        /// <summary>
        /// 以逆时针为方向对图像进行旋转
        /// </summary>
        /// <param name="b">位图流</param>
        /// <param name="angle">旋转角度[0,360](前台给的)</param>
        /// <returns></returns>
        public Bitmap Rotate(Bitmap b, int angle)
        {
            angle = angle % 360;
            //弧度转换
            double radian = angle * Math.PI / 180.0;
            double cos = Math.Cos(radian);
            double sin = Math.Sin(radian);
            //原图的宽和高
            int w = b.Width;
            int h = b.Height;
            int W = (int)(Math.Max(Math.Abs(w * cos - h * sin), Math.Abs(w * cos + h * sin)));
            int H = (int)(Math.Max(Math.Abs(w * sin - h * cos), Math.Abs(w * sin + h * cos)));
            //目标位图
            Bitmap dsImage = new Bitmap(W, H);
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(dsImage);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bilinear;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            //计算偏移量
            Point Offset = new Point((W - w) / 2, (H - h) / 2);
            //构造图像显示区域：让图像的中心与窗口的中心点一致
            Rectangle rect = new Rectangle(Offset.X, Offset.Y, w, h);
            Point center = new Point(rect.X + rect.Width / 2, rect.Y + rect.Height / 2);
            g.TranslateTransform(center.X, center.Y);
            g.RotateTransform(360 - angle);
            //恢复图像在水平和垂直方向的平移
            g.TranslateTransform(-center.X, -center.Y);
            g.DrawImage(b, rect);
            //重至绘图的所有变换
            g.ResetTransform();
            g.Save();
            g.Dispose();
            //dsImage.Save("yuancd.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            return dsImage;
        }
    }
}
