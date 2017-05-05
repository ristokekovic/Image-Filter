using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using ImageFilter;

namespace ImageFilter.Views
{
    public partial class BaseView : UserControl
    {

        PropertyInfo imageRectangleProperty = typeof(PictureBox).GetProperty("ImageRectangle", BindingFlags.GetProperty | BindingFlags.NonPublic | BindingFlags.Instance);

        DisplayForm mainForm;

        Image image;

        int width;
        int height;


        public BaseView()
        {
            InitializeComponent();
        }

        public void setMainForm(DisplayForm form)
        {
            this.mainForm = form;
        }

        public void setBaseImage(String path)
        {
            image = Image.FromFile(path);
            width = image.Width;
            height = image.Height;
            this.baseImage.Image = image;
            this.baseImage.Visible = true;
            this.baseImage.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public void setBaseImageFromBitmap(Bitmap bmp)
        {
            this.baseImage.Image = bmp.Clone(
                                    new Rectangle(0, 0, bmp.Width, bmp.Height),
                                   System.Drawing.Imaging.PixelFormat.DontCare);
        }

        public void setVisibility(bool value)
        {
            this.Visible = value;
        }

        public bool getVisibility()
        {
            return this.Visible;
        }

        private void baseImage_Click(object sender, EventArgs e)
        {
            if (baseImage.Image != null)
            {
                /*MouseEventArgs me = (MouseEventArgs)e;

                Bitmap original = (Bitmap)baseImage.Image;

                Color? color = null;
                switch (baseImage.SizeMode)
                {
                    case PictureBoxSizeMode.Normal:
                    case PictureBoxSizeMode.AutoSize:
                        {
                            color = original.GetPixel(me.X, me.Y);
                            break;
                        }
                    case PictureBoxSizeMode.CenterImage:
                    case PictureBoxSizeMode.StretchImage:
                    case PictureBoxSizeMode.Zoom:
                        {
                            Rectangle rectangle = (Rectangle)imageRectangleProperty.GetValue(baseImage, null);
                            if (rectangle.Contains(me.Location))
                            {
                                using (Bitmap copy = new Bitmap(baseImage.ClientSize.Width, baseImage.ClientSize.Height))
                                {
                                    using (Graphics g = Graphics.FromImage(copy))
                                    {
                                        g.DrawImage(baseImage.Image, rectangle);

                                        Color c = copy.GetPixel(me.X, me.Y);

                                        this.mainForm.floodFilter(c, me.X, me.Y);
                                    }
                                }
                            }
                            break;
                        }


                        Color c = copy.GetPixel(me.X, me.Y);

                        this.mainForm.floodFilter(c, me.X, me.Y);
                }

                if (!color.HasValue)
                {
                    //User clicked somewhere there is no image
                }
                else
                {
                    //use color.Value
                }*/

                MouseEventArgs me = (MouseEventArgs)e;

                Bitmap img = (Bitmap)baseImage.Image;
                float stretch_X = img.Width / (float)width;
                float stretch_Y = img.Height / (float)height;
                Color color = img.GetPixel((int)(me.X * stretch_X), (int)(me.Y * stretch_Y));

                this.mainForm.floodFilter(color, (int)(me.X * stretch_X), (int)(me.Y * stretch_Y));

            }
        }
    }
}
