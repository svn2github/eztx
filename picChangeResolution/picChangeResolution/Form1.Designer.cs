namespace picChangeResolution
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.beforeLength = new System.Windows.Forms.TextBox();
            this.beforeWidth = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.afterLength = new System.Windows.Forms.TextBox();
            this.afterWidth = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelBili = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.mesLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "长 Length";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "宽 Width";
            // 
            // beforeLength
            // 
            this.beforeLength.Location = new System.Drawing.Point(123, 26);
            this.beforeLength.Name = "beforeLength";
            this.beforeLength.Size = new System.Drawing.Size(113, 21);
            this.beforeLength.TabIndex = 2;
            this.beforeLength.TextChanged += new System.EventHandler(this.beforeLength_TextChanged);
            // 
            // beforeWidth
            // 
            this.beforeWidth.Location = new System.Drawing.Point(123, 53);
            this.beforeWidth.Name = "beforeWidth";
            this.beforeWidth.Size = new System.Drawing.Size(113, 21);
            this.beforeWidth.TabIndex = 3;
            this.beforeWidth.TextChanged += new System.EventHandler(this.beforeWidth_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "长 Length";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "宽 Width";
            // 
            // afterLength
            // 
            this.afterLength.Location = new System.Drawing.Point(123, 147);
            this.afterLength.Name = "afterLength";
            this.afterLength.Size = new System.Drawing.Size(113, 21);
            this.afterLength.TabIndex = 6;
            this.afterLength.TextChanged += new System.EventHandler(this.afterLength_TextChanged);
            // 
            // afterWidth
            // 
            this.afterWidth.Location = new System.Drawing.Point(123, 174);
            this.afterWidth.Name = "afterWidth";
            this.afterWidth.Size = new System.Drawing.Size(113, 21);
            this.afterWidth.TabIndex = 7;
            this.afterWidth.TextChanged += new System.EventHandler(this.afterWidth_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "转换前";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "转换后";
            // 
            // labelBili
            // 
            this.labelBili.AutoSize = true;
            this.labelBili.Location = new System.Drawing.Point(107, 89);
            this.labelBili.Name = "labelBili";
            this.labelBili.Size = new System.Drawing.Size(29, 12);
            this.labelBili.TabIndex = 10;
            this.labelBili.Text = "比例";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(89, 213);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(73, 26);
            this.button2.TabIndex = 12;
            this.button2.Text = "重置";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // mesLabel
            // 
            this.mesLabel.AutoSize = true;
            this.mesLabel.Location = new System.Drawing.Point(26, 112);
            this.mesLabel.Name = "mesLabel";
            this.mesLabel.Size = new System.Drawing.Size(0, 12);
            this.mesLabel.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 251);
            this.Controls.Add(this.mesLabel);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.labelBili);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.afterWidth);
            this.Controls.Add(this.afterLength);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.beforeWidth);
            this.Controls.Add(this.beforeLength);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "分辨率计算";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox beforeLength;
        private System.Windows.Forms.TextBox beforeWidth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox afterLength;
        private System.Windows.Forms.TextBox afterWidth;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelBili;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label mesLabel;
    }
}

