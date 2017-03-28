using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImageFilter.Controllers;
using ModernUISample.metro;

namespace ImageFilter
{
    public partial class DisplayForm : MetroFramework.Forms.MetroForm
    {
        private ImageController imageController;
        private Bitmap tmp;

        public DisplayForm()
        {
            InitializeComponent();
            imageController = new ImageController(baseView, channelView);

            if (MetroUI.DesignMode == false)
            {
                MetroUI.Style.PropertyChanged += Style_PropertyChanged;
                MetroUI.Style.DarkStyle = false;
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

        private void fileButton_Click(object sender, EventArgs e)
        {
           
        }

        private void eXITAPPLICATIONToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void loadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Create a new OpenFileDialog and display it.
            String name;
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Image Files(*.jpeg;*.bmp;*.png;*.jpg)|*.jpeg;*.bmp;*.png;*.jpg";
            if (file.ShowDialog() == DialogResult.OK)
            {
                name = file.FileName;
                imageController.setImage(name);
            }

            int[] properties = imageController.returnImageProperties();

            toolStripStatusLabel1.Text = "Image Properties - Resolution: " + properties[0] + " x " + properties[1] + " Width: " + properties[0] + " Height: " + properties[1];
        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            imageController.saveImage();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void channelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.baseView.setVisibility(false);
            this.channelView.setVisibility(true);
            imageController.setChannelImages();
        }

        private void colorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ColorInput dlg = new ColorInput();
            dlg.red = dlg.green = dlg.blue = 0;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                imageController.applyColorFilter(dlg.red, dlg.green, dlg.blue);
            }
        }

        private void invertToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            imageController.applyMeanRemoval();
        }

        private void invertToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            imageController.applyInvertFilter();
        }
    }
}
