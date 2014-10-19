namespace textOnpaint
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
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.customTabControl1 = new System.Windows.Forms.CustomTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cusRadioButton1 = new textOnpaint.CusRadioButton();
            this.cusColorCheck1 = new textOnpaint.CusColorCheck();
            this.cusCheckbox1 = new textOnpaint.CusCheckbox();
            this.cusButton1 = new textOnpaint.CusButton();
            this.customTabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(12, 60);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(96, 16);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "默认Checkbox";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(12, 104);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(113, 16);
            this.radioButton1.TabIndex = 5;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "默认RadioButton";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // customTabControl1
            // 
            this.customTabControl1.Controls.Add(this.tabPage1);
            this.customTabControl1.Controls.Add(this.tabPage2);
            // 
            // 
            // 
            this.customTabControl1.DisplayStyleProvider.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.customTabControl1.DisplayStyleProvider.BorderColorHot = System.Drawing.SystemColors.ControlDark;
            this.customTabControl1.DisplayStyleProvider.BorderColorSelected = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            this.customTabControl1.DisplayStyleProvider.CloserColor = System.Drawing.Color.DarkGray;
            this.customTabControl1.DisplayStyleProvider.FocusColor = System.Drawing.Color.Transparent;
            this.customTabControl1.DisplayStyleProvider.FocusColor2 = System.Drawing.Color.Transparent;
            this.customTabControl1.DisplayStyleProvider.FocusTrack = true;
            this.customTabControl1.DisplayStyleProvider.HotTrack = true;
            this.customTabControl1.DisplayStyleProvider.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.customTabControl1.DisplayStyleProvider.Opacity = 1F;
            this.customTabControl1.DisplayStyleProvider.Overlap = 0;
            this.customTabControl1.DisplayStyleProvider.Padding = new System.Drawing.Point(6, 3);
            this.customTabControl1.DisplayStyleProvider.Radius = 2;
            this.customTabControl1.DisplayStyleProvider.ShowTabCloser = false;
            this.customTabControl1.DisplayStyleProvider.TabBackColorSelect = System.Drawing.Color.WhiteSmoke;
            this.customTabControl1.DisplayStyleProvider.TabFont = new System.Drawing.Font("宋体", 9F);
            this.customTabControl1.DisplayStyleProvider.TabFontSelect = new System.Drawing.Font("宋体", 9F);
            this.customTabControl1.DisplayStyleProvider.TextColor = System.Drawing.SystemColors.ControlText;
            this.customTabControl1.DisplayStyleProvider.TextColorDisabled = System.Drawing.SystemColors.ControlDark;
            this.customTabControl1.DisplayStyleProvider.TextColorSelected = System.Drawing.SystemColors.ControlText;
            this.customTabControl1.HotTrack = true;
            this.customTabControl1.Location = new System.Drawing.Point(12, 166);
            this.customTabControl1.Name = "customTabControl1";
            this.customTabControl1.SelectedIndex = 0;
            this.customTabControl1.Size = new System.Drawing.Size(598, 222);
            this.customTabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(590, 195);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(590, 195);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cusRadioButton1
            // 
            this.cusRadioButton1.AutoSize = true;
            this.cusRadioButton1.CheckColor = System.Drawing.Color.Red;
            this.cusRadioButton1.Location = new System.Drawing.Point(12, 82);
            this.cusRadioButton1.Name = "cusRadioButton1";
            this.cusRadioButton1.Size = new System.Drawing.Size(149, 16);
            this.cusRadioButton1.TabIndex = 4;
            this.cusRadioButton1.TabStop = true;
            this.cusRadioButton1.Text = "自定义多色RadioButton";
            this.cusRadioButton1.UseVisualStyleBackColor = true;
            // 
            // cusColorCheck1
            // 
            this.cusColorCheck1.AutoSize = true;
            this.cusColorCheck1.checkBgColor = System.Drawing.Color.Transparent;
            this.cusColorCheck1.CheckColor = System.Drawing.Color.Black;
            this.cusColorCheck1.Location = new System.Drawing.Point(12, 38);
            this.cusColorCheck1.Name = "cusColorCheck1";
            this.cusColorCheck1.Size = new System.Drawing.Size(132, 16);
            this.cusColorCheck1.TabIndex = 2;
            this.cusColorCheck1.Text = "自定义多色Checkbox";
            this.cusColorCheck1.UseVisualStyleBackColor = true;
            // 
            // cusCheckbox1
            // 
            this.cusCheckbox1.AutoSize = true;
            this.cusCheckbox1.BackColor = System.Drawing.Color.Transparent;
            this.cusCheckbox1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cusCheckbox1.Location = new System.Drawing.Point(12, 12);
            this.cusCheckbox1.Name = "cusCheckbox1";
            this.cusCheckbox1.Size = new System.Drawing.Size(108, 16);
            this.cusCheckbox1.TabIndex = 1;
            this.cusCheckbox1.Text = "自定义checkbox";
            this.cusCheckbox1.UseVisualStyleBackColor = false;
            this.cusCheckbox1.Value = "";
            // 
            // cusButton1
            // 
            this.cusButton1.BackColor = System.Drawing.Color.Transparent;
            this.cusButton1.CurrentSelect = false;
            this.cusButton1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cusButton1.Location = new System.Drawing.Point(188, 12);
            this.cusButton1.Name = "cusButton1";
            this.cusButton1.Size = new System.Drawing.Size(92, 42);
            this.cusButton1.TabIndex = 0;
            this.cusButton1.Text = "大家好";
            this.cusButton1.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 400);
            this.Controls.Add(this.customTabControl1);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.cusRadioButton1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.cusColorCheck1);
            this.Controls.Add(this.cusCheckbox1);
            this.Controls.Add(this.cusButton1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "测试自定义控件";
            this.customTabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CusButton cusButton1;
        private CusCheckbox cusCheckbox1;
        private CusColorCheck cusColorCheck1;
        private System.Windows.Forms.CheckBox checkBox1;
        private CusRadioButton cusRadioButton1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.CustomTabControl customTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}

