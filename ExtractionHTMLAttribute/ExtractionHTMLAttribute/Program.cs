using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;

namespace ExtractionHTMLAttribute
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "数据整理规划";//Console标题

            Console.ForegroundColor = ConsoleColor.Green;



            DateTime beginTime1 = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));//计算用时：开始时间

            string desPath = System.Environment.CurrentDirectory;//起始目录为程序当前启动目录
            DirectoryInfo folder = new DirectoryInfo(desPath);//得到目录的信息
            DirectoryInfo[] chldFolders = folder.GetDirectories();//将目录中文件夹存为序列

            int countFolder = 0;
            int countDHTML = 0;
            List<string> li = new List<string>();//用来存放没有生成数据的序列

            if (chldFolders.Count() > 0)
            {
                Console.WriteLine("已生成数据目录：");

                foreach (DirectoryInfo chdFolder in chldFolders)//先遍历出所有给定目录中所有文件夹
                {
                    DirectoryInfo fd = new DirectoryInfo(chdFolder.FullName);//先访问路径得到下面所有文件里的信息
                    FileInfo[] chldFiles = fd.GetFiles("d.html");//找出所有d.html的文件
                    foreach (FileInfo chdFile in chldFiles)//再遍历出当前文件夹下所有为d.html的文件
                    {
                        string dTXTPath = System.IO.Path.GetDirectoryName(chdFile.FullName);//d.html所在文件夹，这也是d.txt所需存入的文件夹
                        string dHTMLFile = chdFile.FullName;//d.html的路径
                        string getd = readHTML(dHTMLFile);//读取出d.html中的数据
                        countFolder++;//统计所有文件夹数量
                        bool isWrite = false;//判断是否写入数据
                        XmlDocument doc = new XmlDocument();
                        doc.LoadXml(getd);//以xml方式读取d.html中的数据

                        XmlNodeList pList = doc.SelectNodes("//*[@id=\"the_content\"]/p");//查询xml中id=the_content的节点中的p节点

                        foreach (XmlNode xmld in pList)
                        {
                            string dTXTData = xmld.InnerText;//得到需要节点的数据

                            string[] dTXTDataMany = dTXTData.Split(':');//按“:”号进行分割

                            if (dTXTData.Contains("Architect") && dTXTDataMany.Length > 3)//判断如果以":"分开，数量大于3个就添加            dTXTData.Replace(":", "|").Split('|').Length - 1 > 1
                            {
                                isWrite = true;//当前判断是写入数据，所以开关设为true

                                countDHTML++;//统计带d.html并且符合数据规范的文件夹数量

                                string[] oneHang = dTXTData.Split('\n');//将要写入文件夹的d.txt文件按行分割存入数组

                                if (oneHang.Count() == 1)//如果只有一行
                                {
                                    XmlNodeList ttNode = xmld.SelectNodes("text()");//遍历所有text()

                                    foreach (XmlNode xmlN in ttNode)//遍历所有text()
                                    {
                                        string dtData = xmlN.InnerText;
                                        dTXTData = dTXTData.Insert(dTXTData.IndexOf(dtData), "\n").Trim();//在每个得到的text()前加入换行
                                    }
                                }

                                string[] dtOneHang = dTXTData.Split('\n');

                                List<string> dTXTOneHangli = new List<string>();

                                dTXTOneHangli.AddRange(dtOneHang);//将按行分割出来的数据所生成的数组存入所建列表

                                string colData = "";

                                for (int dto = 0; dto < dTXTOneHangli.Count; dto++)
                                {
                                    if (dTXTOneHangli[dto].IndexOf(":") < 0 && dTXTOneHangli[dto].Length > 50)
                                    {
                                        dTXTOneHangli.Remove(dTXTOneHangli[dto]);//如果有一行不带“:”并且长度大于50就删除这行
                                    }
                                    else
                                    {
                                        colData += (dTXTOneHangli[dto] + "\n");//否则将添加
                                    }
                                }

                                dTXTData = colData.Trim();//整理完毕存入最终数据

                                writeTXT(dTXTPath, dTXTData);//将最终d.txt文件数据写入文件

                                Console.WriteLine(dTXTPath);//输出当前路径

                                XmlNodeList textNode = xmld.SelectNodes("text()");//找出当前节点中所有text() 

                                foreach (XmlNode xmlN in textNode)//遍历所有text()
                                {
                                    string finalData = xmlN.InnerText;

                                    if (finalData.IndexOf(":") > 0)//排除掉strong标签标错及有些别的片段插入进p标签中的情况
                                    {
                                        if (finalData.Length < 50)
                                        {
                                            finalData = finalData.Trim().Replace(":", "");//如果带“:”，则删除“:”
                                            writeProTXT(desPath + "\\property.txt", finalData);//每行写入属性文本
                                        }
                                    }
                                }
                            }
                        }
                        if (isWrite == false)//如果没有写入，则将未生成数据的目录路径添加到未生成数据目录列表中
                        {
                            if (!li.Contains(dTXTPath))//如果已经存在就不加入
                            {
                                li.Add(dTXTPath);
                            }
                        }
                    }
                }
            }

            Console.WriteLine("程序运行目录 " + desPath);//输出运行路径
            DateTime endTime1 = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));//计算用时：结束时间
            TimeSpan midTime = endTime1 - beginTime1;//计算用时
            Console.WriteLine("耗时 {0}时{1}分{2}秒。", midTime.Hours, midTime.Minutes, midTime.Seconds);//输出运行耗时
            
            Console.WriteLine("目录中包含 " + countFolder + " 个文件夹。符合条件的有 " + countDHTML + " 个，已成功生成数据。");

            if (li.Count > 0)//如果有未生成数据的目录再输出
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("未生成数据的目录：");
                for (int i = 0; i < li.Count; i++)
                {
                    Console.WriteLine(li[i]);
                }
            }

            Console.ReadLine();
        }


        //读取d.html里的内容
        private static string readHTML(string filePath)
        {
            string one = "";
            if (File.Exists(filePath))
            {
                StreamReader sr = new StreamReader(filePath, new UTF8Encoding(false));
                one = sr.ReadToEnd();
            }

            return one;
        }


        //写入d.txt文件
        private static void writeTXT(string filePath, string fileData)
        {
            StreamWriter sw = new StreamWriter(filePath + "\\d.txt", false, new UTF8Encoding(false));//直接全新覆盖写
            {
                sw.Write(fileData);
                sw.Close();
            }
        }


        //写入属性property.txt文件
        private static void writeProTXT(string filePath, string dataProperty)
        {
            if (File.Exists(filePath))//如果发现文件则先读取文件，判断是否存在重复的条目再决定是否往里面追加文件
            {
                StreamReader sr = new StreamReader(filePath);//读取文件
                string str = sr.ReadToEnd();
                sr.ReadLine();
                sr.Close();
                if (!str.ToUpper().Trim().Contains(dataProperty.ToUpper().Trim()))//同时把数据切换成大写比较，看看是否有重复
                {
                    StreamWriter sw = File.AppendText(filePath);//追加进属性文档
                    {
                        sw.WriteLine(dataProperty);
                        sw.Close();
                    }
                }
            }
            else//否则将新建个文本
            {
                StreamWriter sw = new StreamWriter(filePath, false, new UTF8Encoding(false));
                {
                    sw.WriteLine(dataProperty);
                    sw.Close();
                }
            }
        }
    }
}
