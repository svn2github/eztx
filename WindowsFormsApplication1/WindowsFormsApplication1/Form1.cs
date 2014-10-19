using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //在TreeView1中显示磁盘目录及文件
            string[] strDir = Directory.GetLogicalDrives();//获取本地计算机上格式为《驱动器名》：\的逻辑驱动器的名称
            tvMenu.Nodes.Clear();//清空TreeViee

            tvMenu.BeginUpdate();//首先禁止TreeViee的重绘

            foreach (string item in strDir)//循环将磁盘名称加入到TreeView中
            {
                TreeNode tn = new TreeNode(item);

                tvMenu.Nodes.Add(tn);
            }


            for (int i = 0; i < strDir.Length - 1; i++)
            {
                DirectoryInfo dInfo = new DirectoryInfo(strDir[i]);

                FileSystemInfo[] fsInfos = dInfo.GetFileSystemInfos();

                foreach (FileSystemInfo item in fsInfos)
                {
                    if (item is Directory)
                    {

                        DirectoryInfo dirInfo = new DirectoryInfo(item.FullName);

                        TreeNode tn = new TreeNode(dirInfo.Name);

                        tvMenu.Nodes[i].Nodes.Add(tn);

                    }
                    else
                    {
                        FileInfo fInfo = new FileInfo(item.FullName);

                        TreeNode tn = new TreeNode(fInfo.Name);

                        tvMenu.Nodes[i].Nodes.Add(tn);

                    }
                }
            }

            tvMenu.EndUpdate();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
          
        }
    }
}
