using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageFilter.Models
{
    class ImageModel
    {
        private int width;
        private int height;
        private Bitmap image;
        private Bitmap filteredImage;
        private CIEModel[,] CIEimage;

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

        public void setFilteredImage(Bitmap image)
        {
            filteredImage = image;
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



    }
}
