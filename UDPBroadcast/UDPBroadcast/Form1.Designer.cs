namespace UDPBroadcast
{
    partial class UdpBroadcasefrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkbxJoinGtoup = new System.Windows.Forms.CheckBox();
            this.tbxGroupIp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxlocalport = new System.Windows.Forms.TextBox();
            this.tbxlocalip = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.tbxMessageSend = new System.Windows.Forms.TextBox();
            this.chkbxBroadcast = new System.Windows.Forms.CheckBox();
            this.tbxSendToGroupIp = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lstMessageBox = new System.Windows.Forms.ListBox();
            this.btnReceive = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkbxJoinGtoup);
            this.groupBox1.Controls.Add(this.tbxGroupIp);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbxlocalport);
            this.groupBox1.Controls.Add(this.tbxlocalip);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(287, 89);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "本地设置";
            // 
            // chkbxJoinGtoup
            // 
            this.chkbxJoinGtoup.AutoSize = true;
            this.chkbxJoinGtoup.Location = new System.Drawing.Point(171, 48);
            this.chkbxJoinGtoup.Name = "chkbxJoinGtoup";
            this.chkbxJoinGtoup.Size = new System.Drawing.Size(62, 17);
            this.chkbxJoinGtoup.TabIndex = 5;
            this.chkbxJoinGtoup.Text = "加入组";
            this.chkbxJoinGtoup.UseVisualStyleBackColor = true;
            this.chkbxJoinGtoup.Click += new System.EventHandler(this.chkbxJoinGtoup_Click);
            // 
            // tbxGroupIp
            // 
            this.tbxGroupIp.Location = new System.Drawing.Point(62, 46);
            this.tbxGroupIp.Name = "tbxGroupIp";
            this.tbxGroupIp.Size = new System.Drawing.Size(100, 20);
            this.tbxGroupIp.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(168, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "：";
            // 
            // tbxlocalport
            // 
            this.tbxlocalport.Location = new System.Drawing.Point(187, 20);
            this.tbxlocalport.Name = "tbxlocalport";
            this.tbxlocalport.Size = new System.Drawing.Size(72, 20);
            this.tbxlocalport.TabIndex = 2;
            // 
            // tbxlocalip
            // 
            this.tbxlocalip.Location = new System.Drawing.Point(62, 20);
            this.tbxlocalip.Name = "tbxlocalip";
            this.tbxlocalip.Size = new System.Drawing.Size(100, 20);
            this.tbxlocalip.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "地址：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSend);
            this.groupBox2.Controls.Add(this.tbxMessageSend);
            this.groupBox2.Controls.Add(this.chkbxBroadcast);
            this.groupBox2.Controls.Add(this.tbxSendToGroupIp);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(13, 144);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(286, 116);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "发送到";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(211, 60);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(47, 23);
            this.btnSend.TabIndex = 8;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // tbxMessageSend
            // 
            this.tbxMessageSend.Location = new System.Drawing.Point(80, 63);
            this.tbxMessageSend.Name = "tbxMessageSend";
            this.tbxMessageSend.Size = new System.Drawing.Size(125, 20);
            this.tbxMessageSend.TabIndex = 7;
            // 
            // chkbxBroadcast
            // 
            this.chkbxBroadcast.AutoSize = true;
            this.chkbxBroadcast.Location = new System.Drawing.Point(26, 63);
            this.chkbxBroadcast.Name = "chkbxBroadcast";
            this.chkbxBroadcast.Size = new System.Drawing.Size(50, 17);
            this.chkbxBroadcast.TabIndex = 6;
            this.chkbxBroadcast.Text = "广播";
            this.chkbxBroadcast.UseVisualStyleBackColor = true;
            this.chkbxBroadcast.Click += new System.EventHandler(this.chkbxBroadcast_Click);
            // 
            // tbxSendToGroupIp
            // 
            this.tbxSendToGroupIp.Location = new System.Drawing.Point(61, 31);
            this.tbxSendToGroupIp.Name = "tbxSendToGroupIp";
            this.tbxSendToGroupIp.Size = new System.Drawing.Size(100, 20);
            this.tbxSendToGroupIp.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "组：";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lstMessageBox);
            this.groupBox3.Controls.Add(this.btnReceive);
            this.groupBox3.Controls.Add(this.btnStop);
            this.groupBox3.Controls.Add(this.btnClear);
            this.groupBox3.Location = new System.Drawing.Point(13, 266);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(286, 175);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "接收";
            // 
            // lstMessageBox
            // 
            this.lstMessageBox.FormattingEnabled = true;
            this.lstMessageBox.Location = new System.Drawing.Point(7, 60);
            this.lstMessageBox.Name = "lstMessageBox";
            this.lstMessageBox.Size = new System.Drawing.Size(251, 95);
            this.lstMessageBox.TabIndex = 12;
            // 
            // btnReceive
            // 
            this.btnReceive.Location = new System.Drawing.Point(207, 29);
            this.btnReceive.Name = "btnReceive";
            this.btnReceive.Size = new System.Drawing.Size(51, 23);
            this.btnReceive.TabIndex = 11;
            this.btnReceive.Text = "接收";
            this.btnReceive.UseVisualStyleBackColor = true;
            this.btnReceive.Click += new System.EventHandler(this.btnReceive_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(63, 29);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(51, 23);
            this.btnStop.TabIndex = 10;
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(6, 29);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(51, 23);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "清空";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // UdpBroadcasefrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 454);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "UdpBroadcasefrm";
            this.Text = "UDP广播组播";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkbxJoinGtoup;
        private System.Windows.Forms.TextBox tbxGroupIp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxlocalport;
        private System.Windows.Forms.TextBox tbxlocalip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox tbxMessageSend;
        private System.Windows.Forms.CheckBox chkbxBroadcast;
        private System.Windows.Forms.TextBox tbxSendToGroupIp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox lstMessageBox;
        private System.Windows.Forms.Button btnReceive;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnClear;
    }
}

