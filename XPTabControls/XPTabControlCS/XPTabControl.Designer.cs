namespace VSControls
{
    partial class XPTabControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            if (this.fSysFont != System.IntPtr.Zero)
            {
                NativeMethods.DeleteObject(this.fSysFont);
                this.fSysFont = System.IntPtr.Zero;
            }
            fUpDown.ReleaseHandle();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // XPTabControl
            // 
            this.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.HotTrack = true;
            this.ResumeLayout(false);

        }

        #endregion
    }
}