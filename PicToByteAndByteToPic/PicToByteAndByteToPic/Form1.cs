using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace PicToByteAndByteToPic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 图片转为Byte字节数组
        /// </summary>
        /// <param name="FilePath">路径</param>
        /// <returns>字节数组</returns>
        private byte[] imageToByteArray(string FilePath)
        {
            using (MemoryStream ms = new MemoryStream())
            {

                using (Image imageIn = Image.FromFile(FilePath))
                {

                    using (Bitmap bmp = new Bitmap(imageIn))
                    {
                        bmp.Save(ms, imageIn.RawFormat);
                    }

                }
                return ms.ToArray();
            }
        }

        /// <summary>
        /// 字节数组生成图片
        /// </summary>
        /// <param name="Bytes">字节数组</param>
        /// <returns>图片</returns>
        private Image byteArrayToImage(byte[] Bytes)
        {
            using (MemoryStream ms = new MemoryStream(Bytes))
            {
                Image outputImg = Image.FromStream(ms);
                return outputImg;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            byte[] temp = imageToByteArray("C:\\123.jpg");
            StringBuilder Sb = new StringBuilder();
            for (int i = 0; i < temp.Length; i++)
            {
                Sb.Append(temp[i].ToString());
            }
            MessageBox.Show(Sb.Length.ToString());
            this.textBox1.Text = Sb.ToString();
            this.pictureBox1.Image = byteArrayToImage(temp);
        }
    }
}
