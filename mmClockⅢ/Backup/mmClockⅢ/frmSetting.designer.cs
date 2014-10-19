namespace mmClock
{
    partial class frmSetting
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSetting));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbShow = new System.Windows.Forms.CheckBox();
            this.nudTime = new System.Windows.Forms.NumericUpDown();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblInfo1 = new System.Windows.Forms.Label();
            this.lblInfo2 = new System.Windows.Forms.Label();
            this.cbIsLogin = new System.Windows.Forms.CheckBox();
            this.cbIsStart = new System.Windows.Forms.CheckBox();
            this.cbIsMin = new System.Windows.Forms.CheckBox();
            this.cbIsShowLogin = new System.Windows.Forms.CheckBox();
            this.pnl1 = new System.Windows.Forms.Panel();
            this.pnl2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tp1 = new System.Windows.Forms.TabPage();
            this.tp2 = new System.Windows.Forms.TabPage();
            this.tp3 = new System.Windows.Forms.TabPage();
            this.pnl3 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker4 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker5 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.nudTime)).BeginInit();
            this.pnl1.SuspendLayout();
            this.pnl2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tp1.SuspendLayout();
            this.tp2.SuspendLayout();
            this.tp3.SuspendLayout();
            this.pnl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(175, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "秒";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "消息框显示时间";
            // 
            // cbShow
            // 
            this.cbShow.AutoSize = true;
            this.cbShow.Location = new System.Drawing.Point(12, 73);
            this.cbShow.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbShow.Name = "cbShow";
            this.cbShow.Size = new System.Drawing.Size(147, 21);
            this.cbShow.TabIndex = 2;
            this.cbShow.Text = "下次是否再弹出消息框";
            this.cbShow.UseVisualStyleBackColor = true;
            // 
            // nudTime
            // 
            this.nudTime.Location = new System.Drawing.Point(111, 20);
            this.nudTime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nudTime.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudTime.Name = "nudTime";
            this.nudTime.Size = new System.Drawing.Size(58, 23);
            this.nudTime.TabIndex = 5;
            this.nudTime.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOk.BackColor = System.Drawing.SystemColors.Control;
            this.btnOk.Location = new System.Drawing.Point(224, 236);
            this.btnOk.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(87, 30);
            this.btnOk.TabIndex = 8;
            this.btnOk.Text = "确定并关闭";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.SystemColors.Control;
            this.btnClose.Location = new System.Drawing.Point(393, 236);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(70, 30);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "关 闭";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSubmit.BackColor = System.Drawing.SystemColors.Control;
            this.btnSubmit.Location = new System.Drawing.Point(317, 236);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(70, 30);
            this.btnSubmit.TabIndex = 9;
            this.btnSubmit.Text = "应 用";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(111, 52);
            this.txtTitle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTitle.MaxLength = 12;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(209, 23);
            this.txtTitle.TabIndex = 6;
            this.txtTitle.TextChanged += new System.EventHandler(this.txtTitle_TextChanged);
            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(111, 80);
            this.txtContent.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtContent.MaxLength = 30;
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtContent.Size = new System.Drawing.Size(209, 79);
            this.txtContent.TabIndex = 7;
            this.txtContent.TextChanged += new System.EventHandler(this.txtContent_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 17);
            this.label3.TabIndex = 14;
            this.label3.Text = "提示信息标题";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 17);
            this.label4.TabIndex = 15;
            this.label4.Text = "提示信息内容";
            // 
            // lblInfo1
            // 
            this.lblInfo1.AutoSize = true;
            this.lblInfo1.Location = new System.Drawing.Point(335, 55);
            this.lblInfo1.Name = "lblInfo1";
            this.lblInfo1.Size = new System.Drawing.Size(94, 17);
            this.lblInfo1.TabIndex = 16;
            this.lblInfo1.Text = "可以输入12个字";
            // 
            // lblInfo2
            // 
            this.lblInfo2.AutoSize = true;
            this.lblInfo2.Location = new System.Drawing.Point(335, 83);
            this.lblInfo2.Name = "lblInfo2";
            this.lblInfo2.Size = new System.Drawing.Size(94, 17);
            this.lblInfo2.TabIndex = 17;
            this.lblInfo2.Text = "可以输入30个字";
            // 
            // cbIsLogin
            // 
            this.cbIsLogin.AutoSize = true;
            this.cbIsLogin.Enabled = false;
            this.cbIsLogin.Location = new System.Drawing.Point(12, 45);
            this.cbIsLogin.Name = "cbIsLogin";
            this.cbIsLogin.Size = new System.Drawing.Size(244, 21);
            this.cbIsLogin.TabIndex = 1;
            this.cbIsLogin.Text = "登录 Windows 系统时，是否启动本程序";
            this.cbIsLogin.UseVisualStyleBackColor = true;
            // 
            // cbIsStart
            // 
            this.cbIsStart.AutoSize = true;
            this.cbIsStart.Location = new System.Drawing.Point(12, 101);
            this.cbIsStart.Name = "cbIsStart";
            this.cbIsStart.Size = new System.Drawing.Size(303, 21);
            this.cbIsStart.TabIndex = 3;
            this.cbIsStart.Text = "如果检测到闹钟列表中有开启项，是否自动开启闹钟";
            this.cbIsStart.UseVisualStyleBackColor = true;
            // 
            // cbIsMin
            // 
            this.cbIsMin.AutoSize = true;
            this.cbIsMin.Location = new System.Drawing.Point(12, 128);
            this.cbIsMin.Name = "cbIsMin";
            this.cbIsMin.Size = new System.Drawing.Size(195, 21);
            this.cbIsMin.TabIndex = 4;
            this.cbIsMin.Text = "自动开启闹钟后是否最小化窗体";
            this.cbIsMin.UseVisualStyleBackColor = true;
            // 
            // cbIsShowLogin
            // 
            this.cbIsShowLogin.AutoSize = true;
            this.cbIsShowLogin.Location = new System.Drawing.Point(12, 18);
            this.cbIsShowLogin.Name = "cbIsShowLogin";
            this.cbIsShowLogin.Size = new System.Drawing.Size(195, 21);
            this.cbIsShowLogin.TabIndex = 0;
            this.cbIsShowLogin.Text = "下次是否再次提醒开机自动启动";
            this.cbIsShowLogin.UseVisualStyleBackColor = true;
            this.cbIsShowLogin.CheckedChanged += new System.EventHandler(this.cbIsShowLogin_CheckedChanged);
            // 
            // pnl1
            // 
            this.pnl1.BackColor = System.Drawing.Color.AliceBlue;
            this.pnl1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnl1.Controls.Add(this.cbIsShowLogin);
            this.pnl1.Controls.Add(this.cbShow);
            this.pnl1.Controls.Add(this.cbIsLogin);
            this.pnl1.Controls.Add(this.cbIsMin);
            this.pnl1.Controls.Add(this.cbIsStart);
            this.pnl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl1.Location = new System.Drawing.Point(3, 3);
            this.pnl1.Name = "pnl1";
            this.pnl1.Size = new System.Drawing.Size(454, 189);
            this.pnl1.TabIndex = 0;
            // 
            // pnl2
            // 
            this.pnl2.BackColor = System.Drawing.Color.AliceBlue;
            this.pnl2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnl2.Controls.Add(this.label1);
            this.pnl2.Controls.Add(this.nudTime);
            this.pnl2.Controls.Add(this.label2);
            this.pnl2.Controls.Add(this.lblInfo2);
            this.pnl2.Controls.Add(this.txtTitle);
            this.pnl2.Controls.Add(this.lblInfo1);
            this.pnl2.Controls.Add(this.txtContent);
            this.pnl2.Controls.Add(this.label4);
            this.pnl2.Controls.Add(this.label3);
            this.pnl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl2.Location = new System.Drawing.Point(3, 3);
            this.pnl2.Name = "pnl2";
            this.pnl2.Size = new System.Drawing.Size(454, 189);
            this.pnl2.TabIndex = 23;
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tp1);
            this.tabControl1.Controls.Add(this.tp2);
            this.tabControl1.Controls.Add(this.tp3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(468, 228);
            this.tabControl1.TabIndex = 24;
            // 
            // tp1
            // 
            this.tp1.BackColor = System.Drawing.Color.White;
            this.tp1.Controls.Add(this.pnl1);
            this.tp1.Location = new System.Drawing.Point(4, 29);
            this.tp1.Name = "tp1";
            this.tp1.Padding = new System.Windows.Forms.Padding(3);
            this.tp1.Size = new System.Drawing.Size(460, 195);
            this.tp1.TabIndex = 0;
            this.tp1.Text = "基本设置";
            // 
            // tp2
            // 
            this.tp2.BackColor = System.Drawing.Color.White;
            this.tp2.Controls.Add(this.pnl2);
            this.tp2.Location = new System.Drawing.Point(4, 29);
            this.tp2.Name = "tp2";
            this.tp2.Padding = new System.Windows.Forms.Padding(3);
            this.tp2.Size = new System.Drawing.Size(460, 195);
            this.tp2.TabIndex = 1;
            this.tp2.Text = "消息框设置";
            // 
            // tp3
            // 
            this.tp3.BackColor = System.Drawing.Color.White;
            this.tp3.Controls.Add(this.pnl3);
            this.tp3.Location = new System.Drawing.Point(4, 29);
            this.tp3.Name = "tp3";
            this.tp3.Padding = new System.Windows.Forms.Padding(3);
            this.tp3.Size = new System.Drawing.Size(460, 195);
            this.tp3.TabIndex = 2;
            this.tp3.Text = "自定义设置";
            // 
            // pnl3
            // 
            this.pnl3.BackColor = System.Drawing.Color.AliceBlue;
            this.pnl3.Controls.Add(this.dateTimePicker5);
            this.pnl3.Controls.Add(this.dateTimePicker4);
            this.pnl3.Controls.Add(this.dateTimePicker3);
            this.pnl3.Controls.Add(this.dateTimePicker2);
            this.pnl3.Controls.Add(this.textBox5);
            this.pnl3.Controls.Add(this.textBox4);
            this.pnl3.Controls.Add(this.textBox3);
            this.pnl3.Controls.Add(this.textBox2);
            this.pnl3.Controls.Add(this.textBox1);
            this.pnl3.Controls.Add(this.dateTimePicker1);
            this.pnl3.Controls.Add(this.label9);
            this.pnl3.Controls.Add(this.label8);
            this.pnl3.Controls.Add(this.label7);
            this.pnl3.Controls.Add(this.label6);
            this.pnl3.Controls.Add(this.label5);
            this.pnl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl3.Location = new System.Drawing.Point(3, 3);
            this.pnl3.Name = "pnl3";
            this.pnl3.Size = new System.Drawing.Size(454, 189);
            this.pnl3.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "1.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 17);
            this.label6.TabIndex = 1;
            this.label6.Text = "2.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(18, 17);
            this.label7.TabIndex = 2;
            this.label7.Text = "3.";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 95);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(18, 17);
            this.label8.TabIndex = 3;
            this.label8.Text = "4.";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(19, 119);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(18, 17);
            this.label9.TabIndex = 4;
            this.label9.Text = "5.";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "HH:mm";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(149, 22);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowUpDown = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(62, 23);
            this.dateTimePicker1.TabIndex = 5;
            this.dateTimePicker1.Value = new System.DateTime(2011, 3, 28, 1, 45, 0, 0);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(43, 23);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 23);
            this.textBox1.TabIndex = 6;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(43, 44);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 23);
            this.textBox2.TabIndex = 7;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(43, 68);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 23);
            this.textBox3.TabIndex = 8;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(43, 92);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 23);
            this.textBox4.TabIndex = 9;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(43, 116);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 23);
            this.textBox5.TabIndex = 10;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "HH:mm";
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(149, 46);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.ShowUpDown = true;
            this.dateTimePicker2.Size = new System.Drawing.Size(62, 23);
            this.dateTimePicker2.TabIndex = 11;
            this.dateTimePicker2.Value = new System.DateTime(2011, 3, 28, 1, 45, 0, 0);
            // 
            // dateTimePicker3
            // 
            this.dateTimePicker3.CustomFormat = "HH:mm";
            this.dateTimePicker3.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker3.Location = new System.Drawing.Point(149, 70);
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.ShowUpDown = true;
            this.dateTimePicker3.Size = new System.Drawing.Size(62, 23);
            this.dateTimePicker3.TabIndex = 12;
            this.dateTimePicker3.Value = new System.DateTime(2011, 3, 28, 1, 45, 0, 0);
            // 
            // dateTimePicker4
            // 
            this.dateTimePicker4.CustomFormat = "HH:mm";
            this.dateTimePicker4.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker4.Location = new System.Drawing.Point(149, 94);
            this.dateTimePicker4.Name = "dateTimePicker4";
            this.dateTimePicker4.ShowUpDown = true;
            this.dateTimePicker4.Size = new System.Drawing.Size(62, 23);
            this.dateTimePicker4.TabIndex = 13;
            this.dateTimePicker4.Value = new System.DateTime(2011, 3, 28, 1, 45, 0, 0);
            // 
            // dateTimePicker5
            // 
            this.dateTimePicker5.CustomFormat = "HH:mm";
            this.dateTimePicker5.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker5.Location = new System.Drawing.Point(149, 118);
            this.dateTimePicker5.Name = "dateTimePicker5";
            this.dateTimePicker5.ShowUpDown = true;
            this.dateTimePicker5.Size = new System.Drawing.Size(62, 23);
            this.dateTimePicker5.TabIndex = 14;
            this.dateTimePicker5.Value = new System.DateTime(2011, 3, 28, 1, 45, 0, 0);
            // 
            // frmSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(468, 271);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOk);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "frmSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置";
            this.Load += new System.EventHandler(this.SettIngForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudTime)).EndInit();
            this.pnl1.ResumeLayout(false);
            this.pnl1.PerformLayout();
            this.pnl2.ResumeLayout(false);
            this.pnl2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tp1.ResumeLayout(false);
            this.tp2.ResumeLayout(false);
            this.tp3.ResumeLayout(false);
            this.pnl3.ResumeLayout(false);
            this.pnl3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbShow;
        private System.Windows.Forms.NumericUpDown nudTime;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblInfo1;
        private System.Windows.Forms.Label lblInfo2;
        private System.Windows.Forms.CheckBox cbIsLogin;
        private System.Windows.Forms.CheckBox cbIsStart;
        private System.Windows.Forms.CheckBox cbIsMin;
        private System.Windows.Forms.CheckBox cbIsShowLogin;
        private System.Windows.Forms.Panel pnl1;
        private System.Windows.Forms.Panel pnl2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tp1;
        private System.Windows.Forms.TabPage tp2;
        private System.Windows.Forms.TabPage tp3;
        private System.Windows.Forms.Panel pnl3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePicker5;
        private System.Windows.Forms.DateTimePicker dateTimePicker4;
        private System.Windows.Forms.DateTimePicker dateTimePicker3;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
    }
}