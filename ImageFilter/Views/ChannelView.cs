using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImageFilter.Models;

namespace ImageFilter.Views
{
    public partial class ChannelView : UserControl
    {
        private ImageModel imageModel;

        public ChannelView()
        {
            InitializeComponent();
        }

        public void setVisibility(bool value)
        {
            this.Visible = value;
        }

        public bool getVisibility()
        {
            return this.Visible;
        }

        public void setChannelImages(Bitmap baseImage, Bitmap redChannel, Bitmap greenChannel, Bitmap blueChannel)
        {
            originalImage.Image = baseImage.Clone(
                                  new Rectangle(0, 0, baseImage.Width, baseImage.Height),
                                  System.Drawing.Imaging.PixelFormat.DontCare);
            originalImage.SizeMode = PictureBoxSizeMode.StretchImage;
            
            firstChannel.Image = redChannel.Clone(
                                  new Rectangle(0, 0, redChannel.Width, redChannel.Height),
                                  System.Drawing.Imaging.PixelFormat.DontCare);
            firstChannel.SizeMode = PictureBoxSizeMode.StretchImage;

            secondChannel.Image = greenChannel.Clone(
                                  new Rectangle(0, 0, greenChannel.Width, greenChannel.Height),
                                  System.Drawing.Imaging.PixelFormat.DontCare);
            secondChannel.SizeMode = PictureBoxSizeMode.StretchImage;

            thirdChannel.Image = blueChannel.Clone(
                                  new Rectangle(0, 0, blueChannel.Width, blueChannel.Height),
                                  System.Drawing.Imaging.PixelFormat.DontCare);
            thirdChannel.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public void setFilteredChannelImages(Bitmap filteredImage, Bitmap redChannel, Bitmap greenChannel, Bitmap blueChannel)
        {
            originalImage.Image = filteredImage.Clone(
                                  new Rectangle(0, 0, filteredImage.Width, filteredImage.Height),
                                  System.Drawing.Imaging.PixelFormat.DontCare);
            originalImage.SizeMode = PictureBoxSizeMode.StretchImage;

            firstChannel.Image = redChannel.Clone(
                                  new Rectangle(0, 0, redChannel.Width, redChannel.Height),
                                  System.Drawing.Imaging.PixelFormat.DontCare);
            firstChannel.SizeMode = PictureBoxSizeMode.StretchImage;

            secondChannel.Image = greenChannel.Clone(
                                  new Rectangle(0, 0, greenChannel.Width, greenChannel.Height),
                                  System.Drawing.Imaging.PixelFormat.DontCare);
            secondChannel.SizeMode = PictureBoxSizeMode.StretchImage;

            thirdChannel.Image = blueChannel.Clone(
                                  new Rectangle(0, 0, blueChannel.Width, blueChannel.Height),
                                  System.Drawing.Imaging.PixelFormat.DontCare);
            thirdChannel.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void originalImage_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
