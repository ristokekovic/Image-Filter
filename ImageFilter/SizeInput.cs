using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using ImageFilter.Controllers;

namespace ImageFilter
{
    public partial class SizeInput : MetroForm
    {
        private ImageController imageController;

        public SizeInput(ImageController ic)
        {
            InitializeComponent();
            imageController = ic;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Red_TextChanged(object sender, EventArgs e)
        {

        }

        private void OK_Click(object sender, EventArgs e)
        {
            int size = Int32.Parse(this.bufferSizeInput.Text);
            this.imageController.setBufferSize(size);
            this.Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
