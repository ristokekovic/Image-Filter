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
using System.IO;

namespace ImageFilter
{
   

    public partial class DisplayForm : MetroFramework.Forms.MetroForm
    {
        private ImageController imageController;
        private AudioController audioController;
        private Bitmap tmp;

        public DisplayForm()
        {
            InitializeComponent();
            this.baseView.setMainForm(this);
            imageController = new ImageController(baseView, channelView, histogramView);
            audioController = new AudioController();

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
            file.Filter = "Image Files(*.jpeg;*.bmp;*.png;*.jpg;*.riki)|*.jpeg;*.bmp;*.png;*.jpg;*.riki";
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

        private void zoneFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HistogramFilterInput dlg = new HistogramFilterInput();
            if (DialogResult.OK == dlg.ShowDialog())
            {
                imageController.applyZoneHistogramFilter(dlg.getN(), dlg.getK());
            }
        }

        private void downsampleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.imageController.downsampleAllChannels();
            this.channelView.Visible = true;           
        }

        private void channelSubtractionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.audioController.ModifyChannels();
        }

        private void colorPickerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if(DialogResult.OK == cd.ShowDialog())
            {
                imageController.setPickedColor(cd.Color);
            }
        }

        private void floodFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (DialogResult.OK == cd.ShowDialog())
            {
                imageController.setPickedColor(cd.Color);
            }
            toolStripStatusLabel1.Text = "Please click on a pixel that you wish to change";
        }

        public void floodFilter(Color c, int x, int y)
        {
            imageController.applyFloodFilter(c, x, y);
        }

        private void playAudioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            audioController.PlayStream();
        }
    }
}
