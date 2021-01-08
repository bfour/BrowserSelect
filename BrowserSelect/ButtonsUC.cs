using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BrowserSelect
{
    public partial class ButtonsUC : UserControl
    {

        public Form callingForm;
        public ButtonsUC(Form callingForm)
        {
            this.callingForm = callingForm;
            InitializeComponent();
            add_button("About", show_about, 0);
            add_button("Settings", show_setting, 1);

            // http://www.telerik.com/blogs/winforms-scaling-at-large-dpi-settings-is-it-even-possible-
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        }

        private void show_setting(object sender, EventArgs e)
        {
            new frm_settings(this.callingForm).ShowDialog();
        }

        private void show_about(object sender, EventArgs e)
        {
            new frm_About().ShowDialog();
        }

        private List<VButton> vbtn = new List<VButton>();
        private void add_button(string text, EventHandler evt, int index)
        {
            // code for vertical buttons on the right, they are custom controls
            // without support for form designer, so we initiate them in code
            var btn = new VButton();
            btn.Anchor = AnchorStyles.Right;
            btn.Width = 20;
            btn.Height = 22;
            btn.Top = index * 26;
            //btn.Left = this.Width - 35;
            //btn.Left = btn_help.Right - btn.Width;
            Controls.Add(btn);
            btn.Click += evt;

            btn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            if (text.Equals("About"))
                btn.BackgroundImage = global::BrowserSelect.Properties.Resources.information_outline;
            else if (text.Equals("Settings"))
                btn.BackgroundImage = global::BrowserSelect.Properties.Resources.cog_outline;
            else
                btn.Text = text;
            btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            btn.Cursor = System.Windows.Forms.Cursors.Hand;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            //btn.Location = new System.Drawing.Point(97, 155);
            btn.Size = new System.Drawing.Size(25, 25);
            btn.TabIndex = 0;
            btn.UseVisualStyleBackColor = true;

            vbtn.Add(btn);
        }
    }
}
