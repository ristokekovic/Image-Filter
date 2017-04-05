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
            imageController = new ImageController(baseView, channelView, histogramView);

            baseView.Dock = DockStyle.Bottom;
            baseView.Anchor = AnchorStyles.Bottom & AnchorStyles.Left;

            channelView.Dock = DockStyle.Bottom;
            channelView.Anchor = AnchorStyles.Bottom & AnchorStyles.Left;

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
            this.channelView.setVisibility(true);
            this.showHistogram.Visible = true;
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
        }

        private void invertToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            imageController.applyInvertFilter();
        }

        private void fIltersToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SizeInput si = new SizeInput(this.imageController);
            si.Show();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.imageController.undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.imageController.redo();
        }

        private void histogramChannelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.baseView.setVisibility(false);
            this.channelView.setVisibility(false);
            this.histogramView.setVisibility(true);
        }

        private void showHistogram_CheckedChanged(object sender, EventArgs e)
        {
            this.histogramView.setVisibility(this.showHistogram.Checked);
            this.histogramView.setBaseImage(imageController.getCurrentImage());
        }

        private void metroMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        public void hideCheckbox()
        {
            this.showHistogram.Visible = false;
        }

        private void homogenityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            imageController.applyEdgeDetectionHomogenity();
        }

        private void timeWarpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            imageController.applyTimeWarpFilter();
        }

        private void x3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            imageController.applyMeanRemoval(1);
        }

        private void x5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            imageController.applyMeanRemoval(2);
        }

        private void x7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            imageController.applyMeanRemoval(3);
        }

        private void comparisonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            imageController.meanRemovalComparison();
            channelView.setVisibility(true);
        }
    }
}
