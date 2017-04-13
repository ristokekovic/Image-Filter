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

        private Color oldFirstChannelColor;
        private Color oldSecondChannelColor;
        private Color oldThirdChannelColor;

        public ChannelView()
        {
            InitializeComponent();
        }

        public void setImageModel(ImageModel im)
        {
            this.imageModel = im;
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

        public void setRedChannel(Bitmap image, Bitmap redChannel)
        {
            originalImage.Image = image.Clone(
                                  new Rectangle(0, 0, image.Width, image.Height),
                                  System.Drawing.Imaging.PixelFormat.DontCare);
            originalImage.SizeMode = PictureBoxSizeMode.StretchImage;

            firstChannel.Image = redChannel.Clone(
                                  new Rectangle(0, 0, redChannel.Width, redChannel.Height),
                                  System.Drawing.Imaging.PixelFormat.DontCare);
            firstChannel.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public void setGreenChannel(Bitmap image, Bitmap greenChannel)
        {
            originalImage.Image = image.Clone(
                                  new Rectangle(0, 0, image.Width, image.Height),
                                  System.Drawing.Imaging.PixelFormat.DontCare);
            originalImage.SizeMode = PictureBoxSizeMode.StretchImage;

            secondChannel.Image = greenChannel.Clone(
                                  new Rectangle(0, 0, greenChannel.Width, greenChannel.Height),
                                  System.Drawing.Imaging.PixelFormat.DontCare);
            secondChannel.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public void setBlueChannel(Bitmap image, Bitmap blueChannel)
        {
            originalImage.Image = image.Clone(
                                  new Rectangle(0, 0, image.Width, image.Height),
                                  System.Drawing.Imaging.PixelFormat.DontCare);
            originalImage.SizeMode = PictureBoxSizeMode.StretchImage;

            thirdChannel.Image = blueChannel.Clone(
                                  new Rectangle(0, 0, blueChannel.Width, blueChannel.Height),
                                  System.Drawing.Imaging.PixelFormat.DontCare);
            thirdChannel.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void originalImage_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void firstChannel_Click(object sender, EventArgs e)
        {
            this.imageModel.setDownsampledImage((Bitmap) this.firstChannel.Image);
            this.firstChannel.BorderStyle = BorderStyle.None;
            firstChannel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.firstChannel.Padding = new System.Windows.Forms.Padding(5);
            this.oldFirstChannelColor = firstChannel.BackColor;
            firstChannel.BackColor = Color.Red;
            this.secondChannel.Padding = new System.Windows.Forms.Padding(0);
            this.thirdChannel.Padding = new System.Windows.Forms.Padding(0);
            if (this.oldSecondChannelColor != null)
                this.secondChannel.BackColor = this.oldSecondChannelColor;
            if (this.oldThirdChannelColor != null)
                this.thirdChannel.BackColor = this.oldThirdChannelColor;
        }

        private void secondChannel_Click(object sender, EventArgs e)
        {
            this.imageModel.setDownsampledImage((Bitmap)this.secondChannel.Image);
            this.secondChannel.BorderStyle = BorderStyle.None;
            secondChannel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.secondChannel.Padding = new System.Windows.Forms.Padding(5);
            this.oldSecondChannelColor = secondChannel.BackColor;
            secondChannel.BackColor = Color.Red;
            this.firstChannel.Padding = new System.Windows.Forms.Padding(0);
            this.thirdChannel.Padding = new System.Windows.Forms.Padding(0);
            if (this.oldFirstChannelColor != null)
                this.firstChannel.BackColor = this.oldFirstChannelColor;
            if (this.oldThirdChannelColor != null)
                this.thirdChannel.BackColor = this.oldThirdChannelColor;
        }

        private void thirdChannel_Click(object sender, EventArgs e)
        {
            this.imageModel.setDownsampledImage((Bitmap)this.thirdChannel.Image);
            this.thirdChannel.BorderStyle = BorderStyle.None;
            thirdChannel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.thirdChannel.Padding = new System.Windows.Forms.Padding(5);
            this.oldThirdChannelColor = thirdChannel.BackColor;
            thirdChannel.BackColor = Color.Red;
            this.firstChannel.Padding = new System.Windows.Forms.Padding(0);
            this.secondChannel.Padding = new System.Windows.Forms.Padding(0);
            if (this.oldFirstChannelColor != null)
                this.firstChannel.BackColor = this.oldFirstChannelColor;
            if (this.oldSecondChannelColor != null)
                this.secondChannel.BackColor = this.oldSecondChannelColor;
        }
    }
}
