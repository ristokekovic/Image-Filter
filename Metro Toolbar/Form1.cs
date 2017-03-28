using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ModernUISample.metro;

namespace ModernUISample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            if (MetroUI.DesignMode == false)
            {
                MetroUI.Style.PropertyChanged += Style_PropertyChanged;
                MetroUI.Style.DarkStyle = true;
            }
        }

        

        void Style_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "DarkStyle")
            {
                BackColor = MetroUI.Style.BackColor;
                Refresh();
            }
        }

        /// <summary>
        /// Switch the current Style...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pshSwitchStyle_Click(object sender, EventArgs e)
        {
            MetroUI.Style.DarkStyle = !(MetroUI.Style.DarkStyle);
        }

        /// <summary>
        /// close the app
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void eXITAPPLICATIONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// painting the title area (only for demonstration)
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Pen pen = new Pen(MetroUI.Style.AccentColor))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
            }

            using (SolidBrush brush = new SolidBrush(MetroUI.Style.AccentColor))
            {
                e.Graphics.DrawString(Text.ToUpper(), MetroUI.Style.LightFont, brush, 10, 8);
            }
        }

        /// <summary>
        /// support form moving whereever the user clicks inside the form (only for demonstration)
        /// </summary>
        /// <param name="msg"></param>
        protected override void WndProc(ref Message msg)
        {
            if (msg.Msg == 0x84) // WM_NCHITTEST
                msg.Result = (IntPtr)0x02;  // HTCAPTION
            else
                base.WndProc(ref msg);
        }

    }
}
