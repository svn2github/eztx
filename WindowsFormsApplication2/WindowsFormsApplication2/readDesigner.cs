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
    class readDesigner
    {
        public string readArchDesigner()
        {
            string filePath = "C:\\designerName.txt";//
            string one = "";
            if (File.Exists(filePath))
            {
                StreamReader sr = new StreamReader(filePath);
                one = sr.ReadToEnd();
            }
            return one;
        }
    }
}
