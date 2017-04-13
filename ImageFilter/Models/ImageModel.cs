using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageFilter.Models
{
    public class ImageModel
    {
        private int width;
        private int height;
        private Bitmap image;
        private Bitmap filteredImage;
        private CIEModel[,] CIEimage;
        private Bitmap downsampledImage;

        public ImageModel()
        {
            image = null;
            filteredImage = null;
            width = 0;
            height = 0;
        }

        public void setImage(String path)
        {
            image = new Bitmap(Bitmap.FromFile(path));
            width = image.Width;
            height = image.Height;
        }

        public void setImageFromBitmap(Bitmap bmp)
        {
            image = bmp.Clone(
                                  new Rectangle(0, 0, bmp.Width, bmp.Height),
                                  System.Drawing.Imaging.PixelFormat.DontCare);
        }

        public void setFilteredImage(Bitmap image)
        {
            filteredImage = image.Clone(
                                  new Rectangle(0, 0, image.Width, image.Height),
                                  System.Drawing.Imaging.PixelFormat.DontCare);
        }

        public void setCIEImage(CIEModel[,] matrix)
        {
            CIEimage = matrix;
        }

        public Bitmap getBaseImage()
        {
            return image;
        }

        public Bitmap getFilteredImage()
        {
            return filteredImage;
        }

        public CIEModel[,] getCIEImage()
        {
            return CIEimage;
        }

        public int getWidth()
        {
            return width;
        }

        public int getHeight()
        {
            return height;
        }

        public void setDownsampledImage(Bitmap image)
        {
            this.downsampledImage = image;
        }

        public Bitmap getDownsampledImage()
        {
            return this.downsampledImage;
        }


    }
}
