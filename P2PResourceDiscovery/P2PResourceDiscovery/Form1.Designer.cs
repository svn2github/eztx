namespace P2PResourceDiscovery
{
    partial class frmP2PresourceDis
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
            System.Windows.Forms.ColumnHeader columnHeader3;
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.comboxSharelist = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnRegister = new System.Windows.Forms.Button();
            this.tbxResourceName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxlocalport = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxlocalip = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxSeed = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lstViewOnlinePeer = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRemove);
            this.groupBox1.Controls.Add(this.comboxSharelist);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnRegister);
            this.groupBox1.Controls.Add(this.tbxResourceName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbxlocalport);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbxlocalip);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(292, 109);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "发布";
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(197, 78);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(53, 23);
            this.btnRemove.TabIndex = 9;
            this.btnRemove.Text = "撤销";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // comboxSharelist
            // 
            this.comboxSharelist.FormattingEnabled = true;
            this.comboxSharelist.Location = new System.Drawing.Point(89, 74);
            this.comboxSharelist.Name = "comboxSharelist";
            this.comboxSharelist.Size = new System.Drawing.Size(101, 21);
            this.comboxSharelist.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "分享";
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(187, 47);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(55, 23);
            this.btnRegister.TabIndex = 6;
            this.btnRegister.Text = "注册";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // tbxResourceName
            // 
            this.tbxResourceName.Location = new System.Drawing.Point(89, 47);
            this.tbxResourceName.Name = "tbxResourceName";
            this.tbxResourceName.Size = new System.Drawing.Size(89, 20);
            this.tbxResourceName.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "资源名";
            // 
            // tbxlocalport
            // 
            this.tbxlocalport.Location = new System.Drawing.Point(197, 20);
            this.tbxlocalport.Name = "tbxlocalport";
            this.tbxlocalport.Size = new System.Drawing.Size(45, 20);
            this.tbxlocalport.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(184, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "：";
            // 
            // tbxlocalip
            // 
            this.tbxlocalip.Location = new System.Drawing.Point(89, 20);
            this.tbxlocalip.Name = "tbxlocalip";
            this.tbxlocalip.Size = new System.Drawing.Size(89, 20);
            this.tbxlocalip.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "本地地址：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "种子";
            // 
            // tbxSeed
            // 
            this.tbxSeed.Location = new System.Drawing.Point(56, 144);
            this.tbxSeed.Name = "tbxSeed";
            this.tbxSeed.Size = new System.Drawing.Size(124, 20);
            this.tbxSeed.TabIndex = 2;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(186, 144);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "搜索";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lstViewOnlinePeer
            // 
            this.lstViewOnlinePeer.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            columnHeader3,
            this.columnHeader1,
            this.columnHeader2});
            this.lstViewOnlinePeer.Location = new System.Drawing.Point(12, 193);
            this.lstViewOnlinePeer.Name = "lstViewOnlinePeer";
            this.lstViewOnlinePeer.Size = new System.Drawing.Size(292, 127);
            this.lstViewOnlinePeer.TabIndex = 4;
            this.lstViewOnlinePeer.UseCompatibleStateImageBehavior = false;
            this.lstViewOnlinePeer.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "位置";
            this.columnHeader1.Width = 137;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "发布时间";
            this.columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            columnHeader3.DisplayIndex = 2;
            columnHeader3.Text = "";
            
            // 
            // frmP2PresourceDis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 348);
            this.Controls.Add(this.lstViewOnlinePeer);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.tbxSeed);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmP2PresourceDis";
            this.Text = "P2P 资源发现程序";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.ComboBox comboxSharelist;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.TextBox tbxResourceName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxlocalport;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxlocalip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxSeed;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ListView lstViewOnlinePeer;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}

