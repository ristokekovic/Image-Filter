using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageFilter.Views
{
    public partial class BaseView : UserControl
    {
        public BaseView()
        {
            InitializeComponent();
        }

        public void setBaseImage(String path)
        {
            Image image = Image.FromFile(path);
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
    }
}
