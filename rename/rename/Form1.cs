using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace rename
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = folderBrowserDialog1.SelectedPath;
                textBox1.Text = path;
            }
        }

        private void GetFiles(string filePath, TreeNode node,string keyword,string suffix,string finishName)//得到文件的方法括号中传参数(文件路径，树节点)
        {
            try
            {
                DirectoryInfo folder = new DirectoryInfo(filePath);//得到传过来的文件路径中的文件夹详细情况
                node.Text = folder.Name;//树节点的名字根据文件夹的名字来设置
                node.Tag = folder.FullName;//节点的数据信息根据得到的当前文件chlFile的全名定义
                FileInfo[] chldFiles = folder.GetFiles("*."+suffix);//从总的驱动器信息中得到要读取文件信息的文件的类型并存入
                
                foreach (FileInfo chlFile in chldFiles)//开始循环得到文件chlFile
                {
                    
                    //TreeNode chldNode = new TreeNode();//得到树节点
                    //chldNode.Text = chlFile.Name;//节点标题根据得到的当前文件chlFile的名称命名
                    //chldNode.Tag = chlFile.FullName;//全路径文件名
                    string subName = System.IO.Path.GetFileNameWithoutExtension(chlFile.FullName);//只得到文件名
                    string newPath = System.IO.Path.GetDirectoryName(chlFile.FullName);//得到文件所在地
                    string newPathSuffix = System.IO.Path.GetExtension(chlFile.FullName);//得到文件扩展名
                    //chlFile.FullName.Substring(chlFile.FullName.LastIndexOf("\\"), chlFile.FullName.LastIndexOf("."));

                    if (subName.IndexOf(keyword)>-1)
                    {
                        for (int i = 0; i < subName.Length; i++) 
                        {
                            subName = subName.Replace(keyword,finishName);
                        }
                        File.Move(chlFile.FullName, newPath + "\\" + subName  + newPathSuffix);//将文件移动，相当于改名
                    }
                }

                DirectoryInfo[] chldFolders = folder.GetDirectories();////从总的驱动器信息中得到驱动器中文件夹的信息并存入
                foreach (DirectoryInfo chldFolder in chldFolders)//开始循环得到文件夹chldFolder
                {
                    TreeNode chldNode = new TreeNode();//得到树节点
                    chldNode.Text = folder.Name;//节点标题根据得到的当前文件夹chldFolder的名称命名
                    chldNode.Tag = folder.FullName;//节点的数据信息根据得到的当前文件夹chldFolder的全名定义
                    node.Nodes.Add(chldNode);//将当前节点添加进文件的总树节点中
                    GetFiles(chldFolder.FullName, chldNode,keyword,suffix,finishName);
                }
            }
            catch
            {
                //throw new OverflowException();//抛出异常
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string keyword = textBox2.Text;
            string suffix = comboBox1.Text;
            if (suffix.Equals("全部")||suffix.Equals(""))
                suffix = "*";
            string finishName = textBox3.Text;

            TreeNode root = new TreeNode();
            string path = textBox1.Text;
            GetFiles(path, root, keyword, suffix, finishName);//在双引号中可以输入绝对路径如"D:\dev"，也可以输入相对路径"." or ".."
            DialogResult dr = MessageBox.Show("转换成功！", "提示", MessageBoxButtons.OK);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Show();
            this.button1.Focus();
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string pathValue = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            if (File.Exists(pathValue))//如果得到的路径为文件路径
                pathValue = Path.GetDirectoryName(pathValue);//则设置路径为拖入文件所在的路径
            textBox1.Text = pathValue;
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else e.Effect = DragDropEffects.None;
        } 
    }
}
