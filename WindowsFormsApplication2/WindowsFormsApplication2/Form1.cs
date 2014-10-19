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
    public partial class Form1 : Form
    {
        creatDesigner cd = new creatDesigner();
        readDesigner rd = new readDesigner();

        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            //dataGridView1.AllowUserToAddRows=false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string archName = "";
            string archDesigner = "";
            string countrySide = "";

            //建筑名称部分
            for (int i = 0; i < this.dataGridView1.RowCount - 1; i++)
            {
                archName += (("{\"ch\":\"" + (dataGridView1.Rows[i].Cells[0].Value) + "\",\"en\":\"" + (dataGridView1.Rows[i].Cells[1].Value) + "\"},"));
            }
            if (archName.Length > 0)
                archName = archName.Substring(0, archName.Length - 1);
            else
                archName = "{\"ch\":\"\",\"en\":\"\"}";

            //设计者部分
            for (int i = 0; i < this.dataGridView2.RowCount - 1; i++)
            {
                archDesigner += (("{\"ch\":\"" + dataGridView2.Rows[i].Cells[0].Value + "\",\"en\":\"" + dataGridView2.Rows[i].Cells[1].Value + "\"},"));
                //载入设计者
                if (archDesigner.Length > 0)
                    cd.archDesigner(dataGridView2.Rows[i].Cells[0].Value + "_" + dataGridView2.Rows[i].Cells[1].Value);
            }
            if (archDesigner.Length > 0)
                archDesigner = archDesigner.Substring(0, archDesigner.Length - 1);
            else
                archDesigner = "{\"ch\":\"\",\"en\":\"\"}";

            //国家城市
            for (int i = 0; i < this.dataGridView3.RowCount - 1; i++)
            {
                countrySide += (("{\"country_ch\":\"" + dataGridView3.Rows[i].Cells[0].Value + "\",\"state_ch\":\"" + dataGridView3.Rows[i].Cells[1].Value + "\",") +
                    ("\"city_ch\":\"" + dataGridView3.Rows[i].Cells[2].Value + "\",\"country_en\":\"" + dataGridView3.Rows[i].Cells[3].Value + "\",") +
                    ("\"state_en\":\"" + dataGridView3.Rows[i].Cells[4].Value + "\",\"city_en\":\"" + dataGridView3.Rows[i].Cells[5].Value + "\"},"));
            }
            if (countrySide.Length > 0)
                countrySide = countrySide.Substring(0, countrySide.Length - 1);
            else
                countrySide = "{\"country_ch\":\"\",\"state_ch\":\"\",\"city_ch\":\"\",\"country_en\":\"\",\"state_en\":\"\",\"city_en\":\"\"}";
            
            
            //建筑类型
            string businesstype = comboBox3.Text;
            businesstype=businesstype.Trim();

            string businesstypelist = comboBox4.Text;
            businesstypelist=businesstypelist.Trim();

            string businesstypelist2 = comboBox5.Text;
            businesstypelist2=businesstypelist2.Trim();

            string business = "";
            if (businesstypelist2.Equals(""))
                business = "\"" + businesstype + "." + businesstypelist + "\"";
            else
                business = "\"" + businesstype + "." + businesstypelist + "." + businesstypelist2 + "\"";

            if (business.Equals("\".\""))
                business = "\"\"";

            business=business.Replace("无", "");


            //时间
            string archYear = textBox2.Text;
            archYear=archYear.Trim();
            archYear = archYear.Replace("无","");

            string archMonth = comboBox1.Text;
            archMonth = archMonth.Trim();
            archMonth = archMonth.Replace("无", "");

            string archTime = "\"" + archYear + "-" + archMonth + "\"";

            if (archYear.Equals("") || archMonth.Equals(""))
            {
                archTime = archTime.Replace("-","");
            }

            if (archTime.Equals("\"-\""))
            {
                archTime="\"\"";
            }


            //面积
            string area = "\"" + textBox4.Text + comboBox2.Text + "\"";
            area = area.Trim();
            if (textBox4.Text.Equals("") || textBox4.Text.Equals("无"))
            {
                area = "\"\"";
            }

            //文件名
            string fileName = "00";

            //路径判断，如果拖入的最后一位没有斜杠，就加入一个
            string fName = textBox1.Text;
            if (fName.Equals("请您先将需要保存的位置拖进窗口，也可以点击右边的按钮选择要保存的位置！") || fName.Equals(""))
                MessageBox.Show("请设置路径！", "提示");
            else
            {
                archName = archName.Trim();
                archName = archName.Replace("无", "");

                archDesigner = archDesigner.Trim();
                archDesigner=archDesigner.Replace("无", "");

                countrySide = countrySide.Trim();
                countrySide = countrySide.Replace("无", "");
                
                int index = fName.LastIndexOf("\\");
                string folderPath = "";
                if (textBox1.Text.Length != index)
                    folderPath = textBox1.Text + "\\" + fileName + ".txt";
                //UTF8Encoding utf8 = new UTF8Encoding(false);//设为false为取消生成带签名的utf-8
                using (StreamWriter sw = new StreamWriter(folderPath, false, new UTF8Encoding(false)))
                {
                    sw.Write("{\"archname\":[" + archName + "],");
                    sw.Write("\"designer\":[" + archDesigner + "],");
                    sw.Write("\"country\":[" + countrySide + "],");
                    sw.Write("\"type\":" + business + ",");
                    sw.Write("\"archtime\":" + archTime + ",");
                    sw.Write("\"area\":" + area);
                    sw.Write("}");
                }
                


                DialogResult dr = MessageBox.Show("创建成功！", "提示", MessageBoxButtons.OK);
                if (dr == DialogResult.OK)
                {
                    ClearTextBox(this);
                    kongjianDisable();
                }
            }

            //File.WriteAllLines(folderPath, ok, utf8);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Show();
            this.button3.Focus();
            textBox1.ForeColor = Color.Gray;
            textBox1.Text = "请您先将需要保存的位置拖进窗口，也可以点击右边的按钮选择要保存的位置！";


            //载入建筑类型
            CreatArchType();

            //载入国家名称
            BindData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = folderBrowserDialog1.SelectedPath;
                textBox1.Text = path;
                kongjianEnable();
            }
        }

        //private void textBox1_Leave(object sender, EventArgs e)
        //{
        //    if (textBox1.Text == string.Empty)
        //    {
        //        textBox1.ForeColor = Color.Gray;
        //        textBox1.Text = "请您先将需要保存的位置拖进窗口，也可以点击右边的按钮选择要保存的位置！";
        //    }
        //}

        //private void textBox1_Enter(object sender, EventArgs e)
        //{
        //    if (textBox1.Text.Equals("请您先将需要保存的位置拖进窗口，也可以点击右边的按钮选择要保存的位置！"))
        //    {
        //        textBox1.Clear();
        //        textBox1.ForeColor = Color.Black;
        //        textBox1.Focus();
        //    }
        //}

        //拖得时候
        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else e.Effect = DragDropEffects.None;
        }

        //拖进来扔掉
        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            ClearTextBox(this);
            kongjianEnable();
            textBox1.ForeColor = Color.Black;
            string pathValue = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            if (File.Exists(pathValue))//如果得到的路径为文件路径
                pathValue = Path.GetDirectoryName(pathValue);//则设置路径为拖入文件所在的路径
            textBox1.Text = pathValue;
        }

        //清空页面上所有控件
        private void ClearTextBox(Control sender)
        {
            foreach (Control item in sender.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = string.Empty;
                    continue;
                }
                if (item.Controls.Count > 0)
                    ClearTextBox(item);
            }
            comboBox3.SelectedItem = null;
            comboBox4.SelectedItem = null;
            comboBox5.SelectedItem = null; ;
            comboBox1.SelectedItem = null;
            comboBox2.Text = "平方米";
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();

            textBox1.Text = "请您先将需要保存的位置拖进窗口，也可以点击右边的按钮选择要保存的位置！";
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string keyword = "";
            if (comboBox3.SelectedValue != null)
            {
                keyword = comboBox3.SelectedValue.ToString();
                if (!keyword.Equals("System.Data.DataRowView"))
                {
                    if (keyword.Equals("juZhu"))
                        comboBox5.Visible = true;
                    else
                        comboBox5.Visible = false;

                    XmlDocument doc = new XmlDocument();
                    string path = Properties.Resources.archType;//调用存入内部嵌入资源的archType
                    doc.LoadXml(path);
                    XmlNode xmlNode = doc.SelectSingleNode("Archtype");//得到根节点
                    XmlNodeList nodelist = xmlNode[keyword].ChildNodes;//得到根节点的所有子节点
                    DataTable data = new DataTable();
                    data.Columns.Add("Name");
                    data.Columns.Add("Code");

                    foreach (XmlNode item in nodelist)
                    {
                        DataRow row = data.NewRow();
                        XmlElement xe = (XmlElement)item;
                        row["Name"] = xe.GetAttribute("Name");//+ "_" + item.Attributes["Code"].InnerText item.Attributes["Name"].InnerText  item.Attributes["Code"].InnerText
                        row["Code"] = xe.GetAttribute("Code");
                        data.Rows.Add(row);
                    }
                    this.comboBox4.DataSource = data;
                    this.comboBox4.DisplayMember = "Name";
                    this.comboBox4.ValueMember = "Code";
                }
                comboBox4.Text = "";
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string keyword = "";
            if (comboBox4.SelectedValue != null)
            {
                keyword = comboBox4.SelectedValue.ToString();
                if (keyword.Equals("gongYu") || keyword.Equals("puTongZhuZhai") || keyword.Equals("gaoDuanZhuZhai"))
                {
                    XmlDocument doc = new XmlDocument();
                    string path = Properties.Resources.archType;//调用存入内部嵌入资源的archType
                    doc.LoadXml(path);
                    XmlNode xmlNode = doc.SelectSingleNode("Archtype");//得到根节点
                    XmlNode newNode = xmlNode.SelectSingleNode("juZhu");
                    XmlNodeList nodelist = newNode[keyword].ChildNodes;//得到根节点的所有子节点
                    DataTable data = new DataTable();
                    data.Columns.Add("Name");
                    data.Columns.Add("Code");

                    foreach (XmlNode item in nodelist)
                    {
                        DataRow row = data.NewRow();
                        XmlElement xe = (XmlElement)item;
                        row["Name"] = xe.GetAttribute("Name");//+ "_" + item.Attributes["Code"].InnerText item.Attributes["Name"].InnerText  item.Attributes["Code"].InnerText
                        row["Code"] = xe.GetAttribute("Code");
                        data.Rows.Add(row);
                    }
                    this.comboBox5.DataSource = data;
                    this.comboBox5.DisplayMember = "Name";
                    this.comboBox5.ValueMember = "Code";
                }
                else
                {
                    this.comboBox5.DataSource = null;
                }
                comboBox5.Text = "";
            }
        }


        //创建建筑类型
        private void CreatArchType()
        {

            XmlDocument doc = new XmlDocument();
            string path = Properties.Resources.archType;//调用存入内部嵌入资源的archType
            doc.LoadXml(path);
            XmlNode xmlNode = doc.SelectSingleNode("Archtype");//得到根节点
            XmlNodeList nodelist = xmlNode.ChildNodes;//得到根节点的所有子节点

            DataTable data = new DataTable();
            data.Columns.Add("Name");//要保存表里面的列
            data.Columns.Add("Code");//要保存表里面的列

            foreach (XmlNode item in nodelist)
            {
                DataRow row = data.NewRow();
                row["Name"] = item.Attributes["Name"].InnerText;//将xml里的所有子节点nodelist遍历出单个item，将每个item赋值给表里面的Name列
                row["Code"] = item.Attributes["Code"].InnerText;
                data.Rows.Add(row);
            }
            this.comboBox3.DataSource = data;//数据源为刚建好的表
            this.comboBox3.DisplayMember = "Name";//设置显示名称为Name
            this.comboBox3.ValueMember = "Code";//设置属性值为Code
            comboBox3.Text = "";
            comboBox2.Text = "平方米";
        }
        private DataGridViewComboEditBoxColumn CountryToColumn = new DataGridViewComboEditBoxColumn();
        private DataGridViewComboEditBoxColumn StateToColumn = new DataGridViewComboEditBoxColumn();
        private DataGridViewComboEditBoxColumn CityToColumn = new DataGridViewComboEditBoxColumn();

        private DataGridViewComboEditBoxColumn designerNameCH = new DataGridViewComboEditBoxColumn();
        private DataGridViewComboEditBoxColumn designerNameEN = new DataGridViewComboEditBoxColumn();

        private void BindData()
        {
            try
            {
                AutoCompleteStringCollection txtlist = new AutoCompleteStringCollection();
                string[] yearlist = Properties.Resources.yearList.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                txtlist.AddRange(yearlist);
                textBox2.AutoCompleteSource = AutoCompleteSource.CustomSource;
                textBox2.AutoCompleteCustomSource = txtlist;
                textBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;//补齐类型，1 Suggest 只列表没补齐,2 Append 只补齐文本框内容，没候选列表 3，SuggestAppend 补全列表都有

                //第三个dgv的第一列：国家名(中文)
                CountryToColumn.AutoComplete = true;
                CountryToColumn.HeaderText = "国家";
                CountryToColumn.Name = "Country";
                CountryToColumn.ReadOnly = false;
                dataGridView3.Columns.Insert(0, CountryToColumn);

                //第三个dgv的第二列：省/州名(中文)
                StateToColumn.AutoComplete = true;
                StateToColumn.HeaderText = "省/州";
                StateToColumn.Name = "State";
                StateToColumn.ReadOnly = false;
                dataGridView3.Columns.Insert(1, StateToColumn);

                //第三个dgv的第三列：城市名(中文)
                CityToColumn.AutoComplete = true;
                CityToColumn.HeaderText = "城市";
                CityToColumn.Name = "City";
                CityToColumn.ReadOnly = false;
                dataGridView3.Columns.Insert(2, CityToColumn);

                //dgv2的第一列：设计者(中文)
                designerNameCH.AutoComplete = true;
                designerNameCH.HeaderText = "中文";
                designerNameCH.Name = "zh";
                designerNameCH.Width = 145;
                designerNameCH.ReadOnly = false;
                dataGridView2.Columns.Insert(0, designerNameCH);

                //dgv2的第二列：设计者(英文)
                designerNameEN.AutoComplete = true;
                designerNameEN.HeaderText = "英文";
                designerNameEN.Name = "en";
                designerNameEN.Width = 145;
                designerNameEN.ReadOnly = false;
                dataGridView2.Columns.Insert(1, designerNameEN);

                //读取C盘目录底下的建筑者文本文档并载入进建筑者名称中
                string[] oneLineName;
                string[] spName = null;
                string rdAllName = rd.readArchDesigner();
                oneLineName = rdAllName.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < oneLineName.Length; i++)
                {
                    spName = oneLineName[i].Split('_');
                    designerNameCH.Items.Add(spName[0]);
                    designerNameEN.Items.Add(spName[1]);
                }


                XmlDocument doc = new XmlDocument();
                string path = Properties.Resources.chinese;//调用存入内部嵌入资源的archType
                doc.LoadXml(path);
                //doc.Load(@"C:\chinese.xml");
                XmlNode xmlNode = doc.SelectSingleNode("Location");//得到根节点
                XmlNode crNode = xmlNode.SelectSingleNode("CountryRegion");
                XmlNode ctNode = crNode.SelectSingleNode("State");
                XmlNodeList nodelist = xmlNode.ChildNodes;//得到根节点的所有子节点
                XmlNodeList crlist = crNode.ChildNodes;
                XmlNodeList ctlist = ctNode.ChildNodes;

                foreach (XmlNode item in nodelist)
                {
                    XmlElement xe = (XmlElement)item;

                    CountryToColumn.Items.Add(item.Attributes["Name"].Value);
                }
            }
            catch { }
        }


        private void dataGridView3_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView3_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {
            try
            {
                dataGridView3.NotifyCurrentCellDirty(true);
                int dgv3Row = dataGridView3.Rows.Count;
                for (int i = 0; i < dgv3Row; i++)
                {
                    if (dataGridView3.Rows[i].Cells[0].Value != null) //先根据国家查州
                    {
                        string a = dataGridView3.Rows[i].Cells[0].Value.ToString();
                        XmlDocument xmldoc = new XmlDocument();
                        string path = Properties.Resources.chinese;//调用存入内部嵌入资源的archType
                        xmldoc.LoadXml(path);
                        XmlNode node = xmldoc.SelectSingleNode("/Location/*[@Name='" + a + "']");//CountryRegion          
                        if (node != null)
                        {
                            XmlNodeList nodes = node.ChildNodes;
                            if (nodes.Count != 1 && nodes.Count != 0)
                            {
                                StateToColumn.Items.Clear();

                                if (dataGridView3.Rows[i].Cells[0].Selected)
                                {
                                    dataGridView3.Rows[i].Cells[1].Value = null;
                                    dataGridView3.Rows[i].Cells[2].Value = null;
                                }

                                foreach (XmlNode item in nodes)
                                {
                                    StateToColumn.Items.Add(item.Attributes["Name"].Value);
                                }

                                if (dataGridView3.Rows[i].Cells[1].Value != null) //再根据州查市
                                {
                                    string b = dataGridView3.Rows[i].Cells[1].Value.ToString();
                                    //XmlDocument citydoc = new XmlDocument();
                                    //string citypath = Properties.Resources.chinese;//调用存入内部嵌入资源的archType
                                    //citydoc.LoadXml(citypath);
                                    XmlNode citynode = xmldoc.SelectSingleNode("//State[@Name='" + b + "']");//CountryRegion  
                                    if (citynode != null)
                                    {
                                        XmlNodeList citynodes = citynode.ChildNodes;
                                        if (citynodes.Count != 0)
                                        {
                                            CityToColumn.Items.Clear();
                                            if (dataGridView3.Rows[i].Cells[1].Selected)//还有种方式就是IsInEditMode，编辑完毕以后，但是得点击一下才有效果
                                            {
                                                dataGridView3.Rows[i].Cells[2].Value = null;
                                            }
                                            foreach (XmlNode item in citynodes)//得到所有城市节点
                                            {
                                                CityToColumn.Items.Add(item.Attributes["Name"].Value);
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                StateToColumn.Items.Clear();
                                CityToColumn.Items.Clear();
                                dataGridView3.Rows[i].Cells[1].Value = "";

                                XmlNode nullState = node.SelectSingleNode("State");
                                XmlNodeList nullStateCity = nullState.ChildNodes;
                                foreach (XmlNode item in nullStateCity)
                                {
                                    CityToColumn.Items.Add(item.Attributes["Name"].Value);
                                }
                            }
                        }
                    }
                }
            }
            catch { }
        }

        //CityToColumn.Items.Add("123");

        //所有控件启用
        private void kongjianEnable()
        {
            dataGridView1.Enabled = true;//建筑名称
            dataGridView2.Enabled = true;//设计者
            dataGridView3.Enabled = true;//国家城市
            comboBox3.Enabled = true;//建筑类型
            comboBox4.Enabled = true;//建筑类型
            comboBox5.Enabled = true;//建筑类型
            textBox2.Enabled = true;//年
            comboBox1.Enabled = true;//月份
            textBox4.Enabled = true;//面积
            comboBox2.Enabled = true;//面积单位
        }

        //所有控件禁用
        private void kongjianDisable()
        {
            dataGridView1.Enabled = false;//建筑名称
            dataGridView2.Enabled = false;//设计者
            dataGridView3.Enabled = false;//国家城市
            comboBox3.Enabled = false;//建筑类型
            comboBox4.Enabled = false;//建筑类型
            comboBox5.Enabled = false;//建筑类型
            textBox2.Enabled = false;//年
            comboBox1.Enabled = false;//月份
            textBox4.Enabled = false;//面积
            comboBox2.Enabled = false;//面积单位
        }

        private void dataGridView2_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {
            try
            {
                dataGridView2.NotifyCurrentCellDirty(true);
            }
            catch { }
        }

    }
































































    //以下是生成DataGridViewComboEditBoxColumn控件
    //要加入的类
    public class DataGridViewComboEditBoxColumn : DataGridViewComboBoxColumn
    {
        public DataGridViewComboEditBoxColumn()
        {
            DataGridViewComboEditBoxCell obj = new DataGridViewComboEditBoxCell();
            this.CellTemplate = obj;
        }
    }
    //要加入的类
    public class DataGridViewComboEditBoxCell : DataGridViewComboBoxCell
    {
        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);

            ComboBox comboBox = (ComboBox)base.DataGridView.EditingControl;

            if (comboBox != null)
            {
                comboBox.DropDownStyle = ComboBoxStyle.DropDown;
                comboBox.AutoCompleteMode = AutoCompleteMode.Suggest;
                comboBox.Validating += new CancelEventHandler(comboBox_Validating);
            }
        }

        protected override object GetFormattedValue(object value, int rowIndex, ref DataGridViewCellStyle cellStyle, TypeConverter valueTypeConverter, TypeConverter formattedValueTypeConverter, DataGridViewDataErrorContexts context)
        {
            if (value != null)
            {
                if (value.ToString().Trim() != string.Empty)
                {
                    if (Items.IndexOf(value) == -1)
                    {
                        Items.Add(value);
                        DataGridViewComboBoxColumn col = (DataGridViewComboBoxColumn)OwningColumn;
                        col.Items.Add(value);
                    }
                }
            }
            return base.GetFormattedValue(value, rowIndex, ref cellStyle, valueTypeConverter, formattedValueTypeConverter, context);
        }

        void comboBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DataGridViewComboBoxEditingControl cbo = (DataGridViewComboBoxEditingControl)sender;
            if (cbo.Text.Trim() == string.Empty) return;

            DataGridView grid = cbo.EditingControlDataGridView;
            object value = cbo.Text;

            // Add value to list if not there
            if (cbo.Items.IndexOf(value) == -1)
            {
                DataGridViewComboBoxColumn cboCol = (DataGridViewComboBoxColumn)grid.Columns[grid.CurrentCell.ColumnIndex];
                // Must add to both the current combobox as well as the template, to avoid duplicate entries
                cbo.Items.Add(value);
                cboCol.Items.Add(value);
                grid.CurrentCell.Value = value;
            }
        }
        //添加完这两个类后，右键项目生成一次。
    }
}
