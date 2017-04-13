using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;

namespace ImageFilter
{
    public partial class HistogramFilterInput : MetroFramework.Forms.MetroForm
    {
        public HistogramFilterInput()
        {
            InitializeComponent();

            OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public int getN()
        {
            return Convert.ToInt32(this.n.Text);
        }

        public int getK()
        {
            return Convert.ToInt32(this.k.Text);
        }

    }
}
