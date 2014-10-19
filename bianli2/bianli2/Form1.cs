using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace bianli2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TreeNode root = new TreeNode();
            String a = System.Windows.Forms.Application.StartupPath;//获取启动了应用程序的可执行文件的路径。
            root.Text = a;
            //String a = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;//这个是得到当前文件完整路径，包括文件名。
            //String a = System.Environment.CurrentDirectory;//得到当前文件的所在文件夹位置
            //String a = System.IO.Directory.GetCurrentDirectory();
            //String a = System.AppDomain.CurrentDomain.BaseDirectory;//获取程序的基目录。
            
            GetFiles(@".", root);//在双引号中可以输入绝对路径如"D:\dev"，也可以输入相对路径"." or ".."
            treeView1.Nodes.Add(root);//将创建的所在路径中的treeview存入treeview1窗体中
            treeView1.ExpandAll();//默认就将所有的节点展开
            this.treeView1.Nodes[0].EnsureVisible();//设置滚动条默认在最上面
        }


        private void GetFiles(string filePath, TreeNode node)//得到文件的方法括号中传参数(文件路径，树节点)
        {
            try
            {
                DirectoryInfo folder = new DirectoryInfo(filePath);//得到传过来的文件路径中的文件夹详细情况
                node.Text = folder.Name;//树节点的名字根据文件夹的名字来设置
                node.Tag = folder.FullName;//节点的数据信息根据得到的当前文件chlFile的全名定义

                FileInfo[] chldFiles = folder.GetFiles("*.*");//从总的驱动器信息中得到要读取文件信息的文件的类型并存入
                foreach (FileInfo chlFile in chldFiles)//开始循环得到文件chlFile
                {
                    TreeNode chldNode = new TreeNode();//得到树节点
                    chldNode.Text = chlFile.Name;//节点标题根据得到的当前文件chlFile的名称命名
                    chldNode.Tag = chlFile.FullName;//节点的数据信息根据得到的当前文件chlFile的全名定义
                    node.Nodes.Add(chldNode);//将当前节点添加进文件的总树节点中
                }

                DirectoryInfo[] chldFolders = folder.GetDirectories();////从总的驱动器信息中得到驱动器中文件夹的信息并存入
                foreach (DirectoryInfo chldFolder in chldFolders)//开始循环得到文件夹chldFolder
                {
                    TreeNode chldNode = new TreeNode();//得到树节点
                    chldNode.Text = folder.Name;//节点标题根据得到的当前文件夹chldFolder的名称命名
                    chldNode.Tag = folder.FullName;//节点的数据信息根据得到的当前文件夹chldFolder的全名定义
                    node.Nodes.Add(chldNode);//将当前节点添加进文件的总树节点中
                    GetFiles(chldFolder.FullName, chldNode);
                }
            }
            catch 
            {
                //throw new OverflowException();//抛出异常
            }
        } 
    }
}