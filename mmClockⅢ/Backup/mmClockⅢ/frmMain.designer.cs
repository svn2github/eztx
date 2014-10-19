namespace mmClock
{
    public partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.tmrTime = new System.Windows.Forms.Timer(this.components);
            this.lblTime = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblInfo1 = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.lblInfo2 = new System.Windows.Forms.Label();
            this.gbSetting = new System.Windows.Forms.GroupBox();
            this.pnlSet = new System.Windows.Forms.Panel();
            this.btnPlaySound = new System.Windows.Forms.Button();
            this.imgSmall = new System.Windows.Forms.ImageList(this.components);
            this.btnShow = new System.Windows.Forms.Button();
            this.txtMin = new System.Windows.Forms.TextBox();
            this.txtHour = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cmsSetting = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.系统设置ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.音乐路径ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.快速定时ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.分钟后ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.分钟后ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.分钟后ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.分钟后ToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.个小时后ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.自定义定时ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.修改ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.重新启动ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbClockList = new System.Windows.Forms.GroupBox();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.c1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsDGV = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除闹铃ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改闹钟状态ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblInfo3 = new System.Windows.Forms.Label();
            this.lblInfo4 = new System.Windows.Forms.Label();
            this.pnlTime = new System.Windows.Forms.Panel();
            this.ttInfo = new System.Windows.Forms.ToolTip(this.components);
            this.txtSounPath = new System.Windows.Forms.TextBox();
            this.gbSetting.SuspendLayout();
            this.pnlSet.SuspendLayout();
            this.cmsSetting.SuspendLayout();
            this.gbClockList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.cmsDGV.SuspendLayout();
            this.pnlTime.SuspendLayout();
            this.SuspendLayout();
            // 
            // tmrTime
            // 
            this.tmrTime.Interval = 1000;
            this.tmrTime.Tick += new System.EventHandler(this.tmrTime_Tick);
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.BackColor = System.Drawing.Color.Transparent;
            this.lblTime.Font = new System.Drawing.Font("Meiryo", 50.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTime.ForeColor = System.Drawing.Color.White;
            this.lblTime.Location = new System.Drawing.Point(-9, 44);
            this.lblTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(352, 100);
            this.lblTime.TabIndex = 0;
            this.lblTime.Text = "00:00:00";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDate.Font = new System.Drawing.Font("华文行楷", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDate.ForeColor = System.Drawing.Color.White;
            this.lblDate.Location = new System.Drawing.Point(4, 9);
            this.lblDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(220, 36);
            this.lblDate.TabIndex = 1;
            this.lblDate.Text = "1900年01月01日";
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.White;
            this.btnStart.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnStart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStart.ForeColor = System.Drawing.Color.Teal;
            this.btnStart.Location = new System.Drawing.Point(12, 67);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(133, 40);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "开  启";
            this.ttInfo.SetToolTip(this.btnStart, "开 始 启 动");
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblInfo1
            // 
            this.lblInfo1.AutoSize = true;
            this.lblInfo1.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblInfo1.ForeColor = System.Drawing.Color.White;
            this.lblInfo1.Location = new System.Drawing.Point(7, 111);
            this.lblInfo1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInfo1.Name = "lblInfo1";
            this.lblInfo1.Size = new System.Drawing.Size(52, 27);
            this.lblInfo1.TabIndex = 7;
            this.lblInfo1.Text = "就绪";
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.White;
            this.btnStop.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnStop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStop.ForeColor = System.Drawing.Color.Teal;
            this.btnStop.Location = new System.Drawing.Point(193, 67);
            this.btnStop.Margin = new System.Windows.Forms.Padding(4);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(133, 40);
            this.btnStop.TabIndex = 4;
            this.btnStop.Text = "停  止";
            this.ttInfo.SetToolTip(this.btnStop, "停 止 闹 钟");
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // lblInfo2
            // 
            this.lblInfo2.AutoSize = true;
            this.lblInfo2.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblInfo2.ForeColor = System.Drawing.Color.White;
            this.lblInfo2.Location = new System.Drawing.Point(7, 140);
            this.lblInfo2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInfo2.Name = "lblInfo2";
            this.lblInfo2.Size = new System.Drawing.Size(52, 27);
            this.lblInfo2.TabIndex = 10;
            this.lblInfo2.Text = "就绪";
            // 
            // gbSetting
            // 
            this.gbSetting.Controls.Add(this.pnlSet);
            this.gbSetting.Controls.Add(this.txtMin);
            this.gbSetting.Controls.Add(this.txtHour);
            this.gbSetting.Controls.Add(this.label2);
            this.gbSetting.Controls.Add(this.label1);
            this.gbSetting.Controls.Add(this.lblInfo2);
            this.gbSetting.Controls.Add(this.btnStart);
            this.gbSetting.Controls.Add(this.lblInfo1);
            this.gbSetting.Controls.Add(this.btnAdd);
            this.gbSetting.Controls.Add(this.btnStop);
            this.gbSetting.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbSetting.ForeColor = System.Drawing.Color.White;
            this.gbSetting.Location = new System.Drawing.Point(12, 161);
            this.gbSetting.Name = "gbSetting";
            this.gbSetting.Size = new System.Drawing.Size(339, 173);
            this.gbSetting.TabIndex = 0;
            this.gbSetting.TabStop = false;
            this.gbSetting.Text = "闹钟设置";
            // 
            // pnlSet
            // 
            this.pnlSet.BackColor = System.Drawing.Color.White;
            this.pnlSet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSet.Controls.Add(this.btnPlaySound);
            this.pnlSet.Controls.Add(this.btnShow);
            this.pnlSet.Location = new System.Drawing.Point(256, 138);
            this.pnlSet.Name = "pnlSet";
            this.pnlSet.Size = new System.Drawing.Size(70, 30);
            this.pnlSet.TabIndex = 19;
            // 
            // btnPlaySound
            // 
            this.btnPlaySound.BackColor = System.Drawing.Color.Transparent;
            this.btnPlaySound.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPlaySound.BackgroundImage")));
            this.btnPlaySound.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPlaySound.FlatAppearance.BorderSize = 0;
            this.btnPlaySound.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlaySound.ImageList = this.imgSmall;
            this.btnPlaySound.Location = new System.Drawing.Point(10, 4);
            this.btnPlaySound.Name = "btnPlaySound";
            this.btnPlaySound.Size = new System.Drawing.Size(20, 20);
            this.btnPlaySound.TabIndex = 5;
            this.ttInfo.SetToolTip(this.btnPlaySound, "播放/暂停音乐");
            this.btnPlaySound.UseVisualStyleBackColor = false;
            this.btnPlaySound.Click += new System.EventHandler(this.btnPlaySound_Click);
            // 
            // imgSmall
            // 
            this.imgSmall.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgSmall.ImageStream")));
            this.imgSmall.TransparentColor = System.Drawing.Color.Transparent;
            this.imgSmall.Images.SetKeyName(0, "4.gif");
            this.imgSmall.Images.SetKeyName(1, "71.gif");
            this.imgSmall.Images.SetKeyName(2, "51.gif");
            // 
            // btnShow
            // 
            this.btnShow.BackColor = System.Drawing.Color.Transparent;
            this.btnShow.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnShow.BackgroundImage")));
            this.btnShow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnShow.FlatAppearance.BorderSize = 0;
            this.btnShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShow.ImageList = this.imgSmall;
            this.btnShow.Location = new System.Drawing.Point(39, 4);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(20, 20);
            this.btnShow.TabIndex = 6;
            this.ttInfo.SetToolTip(this.btnShow, "设置");
            this.btnShow.UseVisualStyleBackColor = false;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // txtMin
            // 
            this.txtMin.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtMin.Location = new System.Drawing.Point(86, 26);
            this.txtMin.MaxLength = 2;
            this.txtMin.Name = "txtMin";
            this.txtMin.Size = new System.Drawing.Size(31, 34);
            this.txtMin.TabIndex = 1;
            this.txtMin.TabStop = false;
            this.txtMin.Text = "00";
            this.txtMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMin.TextChanged += new System.EventHandler(this.txtMin_TextChanged);
            this.txtMin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMin_KeyPress);
            this.txtMin.Validating += new System.ComponentModel.CancelEventHandler(this.txtMin_Validating);
            // 
            // txtHour
            // 
            this.txtHour.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtHour.Location = new System.Drawing.Point(12, 28);
            this.txtHour.MaxLength = 2;
            this.txtHour.Name = "txtHour";
            this.txtHour.Size = new System.Drawing.Size(31, 34);
            this.txtHour.TabIndex = 0;
            this.txtHour.TabStop = false;
            this.txtHour.Text = "00";
            this.txtHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtHour.TextChanged += new System.EventHandler(this.txtHour_TextChanged);
            this.txtHour.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMin_KeyPress);
            this.txtHour.Validating += new System.ComponentModel.CancelEventHandler(this.txtHour_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(123, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 27);
            this.label2.TabIndex = 12;
            this.label2.Text = "分";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(49, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 27);
            this.label1.TabIndex = 11;
            this.label1.Text = "时";
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.White;
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAdd.ForeColor = System.Drawing.Color.Teal;
            this.btnAdd.Location = new System.Drawing.Point(162, 22);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(163, 40);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "添加到计划列表";
            this.ttInfo.SetToolTip(this.btnAdd, "添 加 到 闹 钟 列 表");
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cmsSetting
            // 
            this.cmsSetting.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设置ToolStripMenuItem,
            this.toolStripSeparator2,
            this.快速定时ToolStripMenuItem,
            this.自定义定时ToolStripMenuItem,
            this.toolStripSeparator1,
            this.重新启动ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.cmsSetting.Name = "contextMenuStrip1";
            this.cmsSetting.Size = new System.Drawing.Size(153, 148);
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.系统设置ToolStripMenuItem1,
            this.音乐路径ToolStripMenuItem});
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.设置ToolStripMenuItem.Text = "设置";
            // 
            // 系统设置ToolStripMenuItem1
            // 
            this.系统设置ToolStripMenuItem1.Name = "系统设置ToolStripMenuItem1";
            this.系统设置ToolStripMenuItem1.Size = new System.Drawing.Size(157, 22);
            this.系统设置ToolStripMenuItem1.Text = "系统设置...";
            this.系统设置ToolStripMenuItem1.Click += new System.EventHandler(this.系统设置ToolStripMenuItem_Click);
            // 
            // 音乐路径ToolStripMenuItem
            // 
            this.音乐路径ToolStripMenuItem.Name = "音乐路径ToolStripMenuItem";
            this.音乐路径ToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.音乐路径ToolStripMenuItem.Text = "音乐路径设置...";
            this.音乐路径ToolStripMenuItem.Click += new System.EventHandler(this.设置音乐路径ToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // 快速定时ToolStripMenuItem
            // 
            this.快速定时ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.分钟后ToolStripMenuItem,
            this.分钟后ToolStripMenuItem1,
            this.分钟后ToolStripMenuItem2,
            this.分钟后ToolStripMenuItem3,
            this.个小时后ToolStripMenuItem});
            this.快速定时ToolStripMenuItem.Name = "快速定时ToolStripMenuItem";
            this.快速定时ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.快速定时ToolStripMenuItem.Text = "快速定时";
            // 
            // 分钟后ToolStripMenuItem
            // 
            this.分钟后ToolStripMenuItem.Name = "分钟后ToolStripMenuItem";
            this.分钟后ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.分钟后ToolStripMenuItem.Tag = "1";
            this.分钟后ToolStripMenuItem.Text = "1分钟后";
            this.分钟后ToolStripMenuItem.Click += new System.EventHandler(this.快速定时ToolStripMenuItem_Click);
            // 
            // 分钟后ToolStripMenuItem1
            // 
            this.分钟后ToolStripMenuItem1.Name = "分钟后ToolStripMenuItem1";
            this.分钟后ToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.分钟后ToolStripMenuItem1.Tag = "2";
            this.分钟后ToolStripMenuItem1.Text = "5分钟后";
            this.分钟后ToolStripMenuItem1.Click += new System.EventHandler(this.快速定时ToolStripMenuItem_Click);
            // 
            // 分钟后ToolStripMenuItem2
            // 
            this.分钟后ToolStripMenuItem2.Name = "分钟后ToolStripMenuItem2";
            this.分钟后ToolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
            this.分钟后ToolStripMenuItem2.Tag = "3";
            this.分钟后ToolStripMenuItem2.Text = "10分钟后";
            this.分钟后ToolStripMenuItem2.Click += new System.EventHandler(this.快速定时ToolStripMenuItem_Click);
            // 
            // 分钟后ToolStripMenuItem3
            // 
            this.分钟后ToolStripMenuItem3.Name = "分钟后ToolStripMenuItem3";
            this.分钟后ToolStripMenuItem3.Size = new System.Drawing.Size(152, 22);
            this.分钟后ToolStripMenuItem3.Tag = "4";
            this.分钟后ToolStripMenuItem3.Text = "30分钟后";
            this.分钟后ToolStripMenuItem3.Click += new System.EventHandler(this.快速定时ToolStripMenuItem_Click);
            // 
            // 个小时后ToolStripMenuItem
            // 
            this.个小时后ToolStripMenuItem.Name = "个小时后ToolStripMenuItem";
            this.个小时后ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.个小时后ToolStripMenuItem.Tag = "5";
            this.个小时后ToolStripMenuItem.Text = "1个小时后";
            this.个小时后ToolStripMenuItem.Click += new System.EventHandler(this.快速定时ToolStripMenuItem_Click);
            // 
            // 自定义定时ToolStripMenuItem
            // 
            this.自定义定时ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripMenuItem6,
            this.修改ToolStripMenuItem});
            this.自定义定时ToolStripMenuItem.Name = "自定义定时ToolStripMenuItem";
            this.自定义定时ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.自定义定时ToolStripMenuItem.Text = "自定义时间";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem2.Text = "00:00";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.自定义定时toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem3.Text = "00:00";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.自定义定时toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem4.Text = "00:00";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.自定义定时toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem5.Text = "00:00";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.自定义定时toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem6.Text = "00:00";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.自定义定时toolStripMenuItem2_Click);
            // 
            // 修改ToolStripMenuItem
            // 
            this.修改ToolStripMenuItem.Name = "修改ToolStripMenuItem";
            this.修改ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.修改ToolStripMenuItem.Text = "修改设置...";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // 重新启动ToolStripMenuItem
            // 
            this.重新启动ToolStripMenuItem.Name = "重新启动ToolStripMenuItem";
            this.重新启动ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.重新启动ToolStripMenuItem.Text = "重新启动...";
            this.重新启动ToolStripMenuItem.Click += new System.EventHandler(this.重新启动ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.退出ToolStripMenuItem.Text = "退出...";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // gbClockList
            // 
            this.gbClockList.Controls.Add(this.dgvList);
            this.gbClockList.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbClockList.ForeColor = System.Drawing.Color.Black;
            this.gbClockList.Location = new System.Drawing.Point(355, 12);
            this.gbClockList.Name = "gbClockList";
            this.gbClockList.Size = new System.Drawing.Size(292, 265);
            this.gbClockList.TabIndex = 2;
            this.gbClockList.TabStop = false;
            this.gbClockList.Text = "闹钟计划列表";
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.AllowUserToResizeColumns = false;
            this.dgvList.AllowUserToResizeRows = false;
            this.dgvList.BackgroundColor = System.Drawing.Color.DarkSlateGray;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c1,
            this.c3,
            this.Column2});
            this.dgvList.ContextMenuStrip = this.cmsDGV;
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.GridColor = System.Drawing.Color.Turquoise;
            this.dgvList.Location = new System.Drawing.Point(3, 25);
            this.dgvList.MultiSelect = false;
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.RowHeadersVisible = false;
            this.dgvList.RowTemplate.Height = 23;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(286, 237);
            this.dgvList.TabIndex = 0;
            this.dgvList.TabStop = false;
            this.dgvList.SelectionChanged += new System.EventHandler(this.dgvList_SelectionChanged);
            // 
            // c1
            // 
            this.c1.DataPropertyName = "Time";
            this.c1.HeaderText = "时间";
            this.c1.Name = "c1";
            this.c1.ReadOnly = true;
            this.c1.ToolTipText = "闹铃提醒时间";
            this.c1.Width = 80;
            // 
            // c3
            // 
            this.c3.DataPropertyName = "STime";
            this.c3.HeaderText = "剩余";
            this.c3.Name = "c3";
            this.c3.ReadOnly = true;
            this.c3.ToolTipText = "离提示剩余时间";
            this.c3.Width = 120;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "State";
            this.Column2.HeaderText = "状态";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.ToolTipText = "是否启动闹钟";
            this.Column2.Width = 80;
            // 
            // cmsDGV
            // 
            this.cmsDGV.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除闹铃ToolStripMenuItem,
            this.修改闹钟状态ToolStripMenuItem});
            this.cmsDGV.Name = "tsmiDGV";
            this.cmsDGV.Size = new System.Drawing.Size(158, 48);
            // 
            // 删除闹铃ToolStripMenuItem
            // 
            this.删除闹铃ToolStripMenuItem.Name = "删除闹铃ToolStripMenuItem";
            this.删除闹铃ToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.删除闹铃ToolStripMenuItem.Text = "删除闹铃...";
            this.删除闹铃ToolStripMenuItem.Click += new System.EventHandler(this.删除闹铃ToolStripMenuItem_Click);
            // 
            // 修改闹钟状态ToolStripMenuItem
            // 
            this.修改闹钟状态ToolStripMenuItem.Name = "修改闹钟状态ToolStripMenuItem";
            this.修改闹钟状态ToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.修改闹钟状态ToolStripMenuItem.Text = "更改闹钟状态...";
            this.修改闹钟状态ToolStripMenuItem.Click += new System.EventHandler(this.修改闹钟状态ToolStripMenuItem_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.White;
            this.btnClear.Enabled = false;
            this.btnClear.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClear.ForeColor = System.Drawing.Color.Teal;
            this.btnClear.Location = new System.Drawing.Point(358, 334);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(291, 40);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "清 空 闹 钟 列 表";
            this.ttInfo.SetToolTip(this.btnClear, "清 空 闹 钟 计 划 列 表");
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblInfo3
            // 
            this.lblInfo3.AutoSize = true;
            this.lblInfo3.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblInfo3.ForeColor = System.Drawing.Color.White;
            this.lblInfo3.Location = new System.Drawing.Point(357, 280);
            this.lblInfo3.Name = "lblInfo3";
            this.lblInfo3.Size = new System.Drawing.Size(56, 25);
            this.lblInfo3.TabIndex = 15;
            this.lblInfo3.Text = "就 绪";
            // 
            // lblInfo4
            // 
            this.lblInfo4.AutoSize = true;
            this.lblInfo4.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblInfo4.ForeColor = System.Drawing.Color.White;
            this.lblInfo4.Location = new System.Drawing.Point(357, 305);
            this.lblInfo4.Name = "lblInfo4";
            this.lblInfo4.Size = new System.Drawing.Size(56, 25);
            this.lblInfo4.TabIndex = 16;
            this.lblInfo4.Text = "就 绪";
            // 
            // pnlTime
            // 
            this.pnlTime.BackColor = System.Drawing.Color.Teal;
            this.pnlTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlTime.Controls.Add(this.lblDate);
            this.pnlTime.Controls.Add(this.lblTime);
            this.pnlTime.ForeColor = System.Drawing.Color.White;
            this.pnlTime.Location = new System.Drawing.Point(12, 12);
            this.pnlTime.Name = "pnlTime";
            this.pnlTime.Size = new System.Drawing.Size(339, 143);
            this.pnlTime.TabIndex = 17;
            // 
            // txtSounPath
            // 
            this.txtSounPath.BackColor = System.Drawing.Color.DarkSlateGray;
            this.txtSounPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSounPath.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSounPath.ForeColor = System.Drawing.Color.White;
            this.txtSounPath.Location = new System.Drawing.Point(12, 342);
            this.txtSounPath.Name = "txtSounPath";
            this.txtSounPath.ReadOnly = true;
            this.txtSounPath.Size = new System.Drawing.Size(339, 29);
            this.txtSounPath.TabIndex = 6;
            this.txtSounPath.TabStop = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(659, 382);
            this.Controls.Add(this.pnlTime);
            this.Controls.Add(this.lblInfo3);
            this.Controls.Add(this.lblInfo4);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.txtSounPath);
            this.Controls.Add(this.gbClockList);
            this.Controls.Add(this.gbSetting);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "木木闹钟Beta3.0";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.gbSetting.ResumeLayout(false);
            this.gbSetting.PerformLayout();
            this.pnlSet.ResumeLayout(false);
            this.cmsSetting.ResumeLayout(false);
            this.gbClockList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.cmsDGV.ResumeLayout(false);
            this.pnlTime.ResumeLayout(false);
            this.pnlTime.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer tmrTime;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblInfo1;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label lblInfo2;
        private System.Windows.Forms.GroupBox gbSetting;
        private System.Windows.Forms.TextBox txtMin;
        private System.Windows.Forms.TextBox txtHour;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.GroupBox gbClockList;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.ContextMenuStrip cmsDGV;
        private System.Windows.Forms.ToolStripMenuItem 删除闹铃ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改闹钟状态ToolStripMenuItem;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblInfo3;
        private System.Windows.Forms.DataGridViewTextBoxColumn c1;
        private System.Windows.Forms.DataGridViewTextBoxColumn c3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Label lblInfo4;
        private System.Windows.Forms.Panel pnlTime;
        private System.Windows.Forms.ToolTip ttInfo;
        private System.Windows.Forms.ContextMenuStrip cmsSetting;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.ImageList imgSmall;
        private System.Windows.Forms.Button btnPlaySound;
        private System.Windows.Forms.Panel pnlSet;
        private System.Windows.Forms.TextBox txtSounPath;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 重新启动ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 快速定时ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 分钟后ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 分钟后ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 分钟后ToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem 分钟后ToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem 个小时后ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 系统设置ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 音乐路径ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 自定义定时ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem 修改ToolStripMenuItem;
    }
}

