using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace WindowsFormsApplication2
{
    class creatDesigner
    {
        public void archDesigner(string designerName)
        {
            string filePath = "C:\\designerName.txt";
            string[] sArray = designerName.Split('_');

            if (sArray[0].Equals("") || sArray[1].Equals(""))
            {
                designerName=designerName.Replace("_", "");
            }

            if (File.Exists(filePath))
            {
                StreamReader sr = new StreamReader(filePath);
                string str = sr.ReadToEnd();
                sr.Close();
                if (str.IndexOf(designerName) < 0)
                {
                    StreamWriter sw = File.AppendText(filePath);
                    {
                        sw.WriteLine(designerName);
                        sw.Close();
                    }
                }
            }
            else
            {
                StreamWriter sw = new StreamWriter(filePath, false, new UTF8Encoding(false));
                {
                    sw.WriteLine(designerName);
                    sw.Close();
                }
            }
        }
    }
}
