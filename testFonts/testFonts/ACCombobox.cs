using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace testFonts
{
    public partial class ACComboBox : System.Windows.Forms.ComboBox
    {
        private bool autoComplete;
        [DefaultValue(true),
        Description("Auto-completes text if a match is found in the items collection."), Category("Behavior")]
        public bool AutoComplete
        {
            get { return autoComplete; }
            set { autoComplete = value; }
        }


        public ACComboBox()
        {
            // This call is required by the Windows.Forms Form Designer.
            // Add any initialization after the InitComponent call
            this.autoComplete = true;
            this.KeyPress += new KeyPressEventHandler(this.OnKeyPress);
        }

        public ACComboBox(IContainer container)
        {
            container.Add(this);
            this.autoComplete = true;
            this.KeyPress += new KeyPressEventHandler(this.OnKeyPress);
        }
        private void OnKeyPress(object sender, KeyPressEventArgs e)
        {
            if (autoComplete)
            {
                ACComboBox acComboBox = (ACComboBox)sender;
                if (!e.KeyChar.Equals((char)8))
                {
                    SearchItems(acComboBox, ref e);
                }
                else
                    e.Handled = false;
            }
            else
                e.Handled = false;
        }
        /// <summary>
        /// Searches the combo box item list for a match and selects it.
        /// If no match is found, then selected index defaults to -1.
        /// </summary>
        ///<param name="&quot;acComboBox&quot;" />
        ///<param name="&quot;e&quot;" />
        private void SearchItems(ACComboBox acComboBox, ref KeyPressEventArgs e)
        {
            int selectionStart = acComboBox.SelectionStart;
            int selectionLength = acComboBox.SelectionLength;
            int selectionEnd = selectionStart + selectionLength;
            int index;
            StringBuilder sb = new StringBuilder();
            sb.Append(acComboBox.Text.Substring(0, selectionStart))
                .Append(e.KeyChar.ToString())
                .Append(acComboBox.Text.Substring(selectionEnd));
            index = acComboBox.FindString(sb.ToString());
            if (index == -1)
                e.Handled = false;
            else
            {
                acComboBox.SelectedIndex = index;
                acComboBox.Select(selectionStart + 1, acComboBox.Text.Length - (selectionStart + 1));
                e.Handled = true;
            }
        }
    }
}
