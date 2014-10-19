namespace alarmClock
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lalFromTime = new System.Windows.Forms.Label();
            this.lblTotime = new System.Windows.Forms.Label();
            this.lblContent = new System.Windows.Forms.Label();
            this.lblNow = new System.Windows.Forms.Label();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOpen = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.cmbHour = new System.Windows.Forms.ComboBox();
            this.cmbMinute = new System.Windows.Forms.ComboBox();
            this.lblRing = new System.Windows.Forms.Label();
            this.cmbRing = new System.Windows.Forms.ComboBox();
            this.btnPreview = new System.Windows.Forms.Button();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.btnStop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lalFromTime
            // 
            this.lalFromTime.AutoSize = true;
            this.lalFromTime.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lalFromTime.Location = new System.Drawing.Point(33, 43);
            this.lalFromTime.Name = "lalFromTime";
            this.lalFromTime.Size = new System.Drawing.Size(70, 12);
            this.lalFromTime.TabIndex = 0;
            this.lalFromTime.Text = "当前时刻：";
            // 
            // lblTotime
            // 
            this.lblTotime.AutoSize = true;
            this.lblTotime.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTotime.Location = new System.Drawing.Point(33, 83);
            this.lblTotime.Name = "lblTotime";
            this.lblTotime.Size = new System.Drawing.Size(70, 12);
            this.lblTotime.TabIndex = 1;
            this.lblTotime.Text = "闹铃时刻：";
            // 
            // lblContent
            // 
            this.lblContent.AutoSize = true;
            this.lblContent.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblContent.Location = new System.Drawing.Point(33, 170);
            this.lblContent.Name = "lblContent";
            this.lblContent.Size = new System.Drawing.Size(70, 12);
            this.lblContent.TabIndex = 2;
            this.lblContent.Text = "提示内容：";
            // 
            // lblNow
            // 
            this.lblNow.AutoSize = true;
            this.lblNow.Font = new System.Drawing.Font("Nina", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNow.ForeColor = System.Drawing.Color.Blue;
            this.lblNow.Location = new System.Drawing.Point(116, 37);
            this.lblNow.Name = "lblNow";
            this.lblNow.Size = new System.Drawing.Size(50, 17);
            this.lblNow.TabIndex = 3;
            this.lblNow.Text = "label1";
            // 
            // txtContent
            // 
            this.txtContent.BackColor = System.Drawing.Color.PaleTurquoise;
            this.txtContent.Location = new System.Drawing.Point(116, 161);
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(199, 21);
            this.txtContent.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(170, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "时";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(257, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "分";
            // 
            // btnOpen
            // 
            this.btnOpen.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOpen.BackgroundImage")));
            this.btnOpen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOpen.Location = new System.Drawing.Point(60, 211);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(87, 23);
            this.btnOpen.TabIndex = 9;
            this.btnOpen.Text = "开启闹钟";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // cmbHour
            // 
            this.cmbHour.FormattingEnabled = true;
            this.cmbHour.Location = new System.Drawing.Point(116, 75);
            this.cmbHour.Name = "cmbHour";
            this.cmbHour.Size = new System.Drawing.Size(46, 20);
            this.cmbHour.TabIndex = 10;
            // 
            // cmbMinute
            // 
            this.cmbMinute.FormattingEnabled = true;
            this.cmbMinute.Location = new System.Drawing.Point(203, 75);
            this.cmbMinute.Name = "cmbMinute";
            this.cmbMinute.Size = new System.Drawing.Size(46, 20);
            this.cmbMinute.TabIndex = 11;
            // 
            // lblRing
            // 
            this.lblRing.AutoSize = true;
            this.lblRing.Location = new System.Drawing.Point(33, 126);
            this.lblRing.Name = "lblRing";
            this.lblRing.Size = new System.Drawing.Size(70, 12);
            this.lblRing.TabIndex = 12;
            this.lblRing.Text = "铃声选择：";
            // 
            // cmbRing
            // 
            this.cmbRing.FormattingEnabled = true;
            this.cmbRing.Location = new System.Drawing.Point(116, 118);
            this.cmbRing.Name = "cmbRing";
            this.cmbRing.Size = new System.Drawing.Size(133, 20);
            this.cmbRing.TabIndex = 13;
            // 
            // btnPreview
            // 
            this.btnPreview.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPreview.BackgroundImage")));
            this.btnPreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPreview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnPreview.Location = new System.Drawing.Point(255, 116);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(60, 23);
            this.btnPreview.TabIndex = 14;
            this.btnPreview.Text = "试听";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // btnStop
            // 
            this.btnStop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnStop.BackgroundImage")));
            this.btnStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnStop.Location = new System.Drawing.Point(188, 211);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(87, 23);
            this.btnStop.TabIndex = 15;
            this.btnStop.Text = "停止闹钟";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(336, 264);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.cmbRing);
            this.Controls.Add(this.lblRing);
            this.Controls.Add(this.cmbMinute);
            this.Controls.Add(this.cmbHour);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtContent);
            this.Controls.Add(this.lblNow);
            this.Controls.Add(this.lblContent);
            this.Controls.Add(this.lblTotime);
            this.Controls.Add(this.lalFromTime);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "小闹钟";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lalFromTime;
        private System.Windows.Forms.Label lblTotime;
        private System.Windows.Forms.Label lblContent;
        private System.Windows.Forms.Label lblNow;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ComboBox cmbHour;
        private System.Windows.Forms.ComboBox cmbMinute;
        private System.Windows.Forms.Label lblRing;
        private System.Windows.Forms.ComboBox cmbRing;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button btnStop;
    }
}

