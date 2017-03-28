using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageFilter.Views;
using ImageFilter.Models;
using System.Windows.Forms;
using System.Drawing.Imaging;
using ImageFilter.Views;

namespace ImageFilter.Controllers
{
    class ImageController
    {
        private ImageModel imageModel;
        private BaseView baseView;
        private ChannelView channelView;

        public ImageController(BaseView bv, ChannelView cv)
        {
            imageModel = new ImageModel();
            baseView = bv;
            channelView = cv;
        }

        public void setImage(String path)
        {
            imageModel.setImage(path);
            CIEModel[,] matrix = setCIEImage(imageModel.getBaseImage());
            imageModel.setCIEImage(matrix);
            baseView.setBaseImage(path);
        }

        public int[] returnImageProperties()
        {
            int[] array = new int[2];
            array[0] = imageModel.getWidth();
            array[1] = imageModel.getHeight();

            return array;
        }

        public void saveImage()
        {
            Bitmap image = imageModel.getFilteredImage();
            if(image == null)
            {
                MessageBox.Show("No filter was applied to base image");
            }
            else
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "BMP|*.bmp|JPG|*.jpg;*.jpeg|PNG|*.png";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    image.Save(dialog.FileName, ImageFormat.Jpeg);
                }
            }
        }

        public CIEModel[,] setCIEImage(Bitmap image)
        {
            CIEModel[,] CIEImage = new CIEModel[image.Width, image.Height];
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    // Get the color of a pixel within myBitmap.
                    Color pixelColor = image.GetPixel(x, y);
                    int r = (int)pixelColor.R;
                    int g = (int)pixelColor.G;
                    int b = (int)pixelColor.B;
                    CIEImage[x, y] = CIEController.RGBtoXYZ(r, g, b);
                }
            }

            return CIEImage;
        }

        public RGBModel[,] convertToRGB(CIEModel[,] matrix)
        {
            RGBModel[,] RGBImage = new RGBModel[imageModel.getWidth(), imageModel.getHeight()];
            for (int x = 0; x < imageModel.getWidth(); x++)
            {
                for (int y = 0; y < imageModel.getHeight(); y++)
                {
                    // Get the color of a pixel within myBitmap.
                    RGBImage[x, y] = CIEController.XYZtoRGB(matrix[x, y].X, matrix[x, y].Y, matrix[x, y].Z);
                }
            }

            return RGBImage;
        }

        public Bitmap setRedChannel(RGBModel[,] image)
        {
            Bitmap bmp = new Bitmap(imageModel.getWidth(), imageModel.getHeight());

            for (int x = 0; x < imageModel.getWidth(); x++)
            {
                for (int y = 0; y < imageModel.getHeight(); y++)
                {
                    Color tmpColor;
                    if (image[x, y].R >= 0)
                        tmpColor = Color.FromArgb(image[x, y].R, 0, 0);
                    else
                        tmpColor = Color.FromArgb(0, 0, 0);
                    bmp.SetPixel(x, y, tmpColor);
                }
            }

            return bmp;
        }

        public Bitmap setGreenChannel(RGBModel[,] image)
        {
            Bitmap bmp = new Bitmap(imageModel.getWidth(), imageModel.getHeight());

            for (int x = 0; x < imageModel.getWidth(); x++)
            {
                for (int y = 0; y < imageModel.getHeight(); y++)
                {
                    Color tmpColor;
                    if (image[x, y].G >= 0)
                        tmpColor = Color.FromArgb(0, image[x, y].G, 0);
                    else
                        tmpColor = Color.FromArgb(0, 0, 0);
                    bmp.SetPixel(x, y, tmpColor);
                }
            }

            return bmp;

        }

        public Bitmap setBlueChannel(RGBModel[,] image)
        {
            Bitmap bmp = new Bitmap(imageModel.getWidth(), imageModel.getHeight());

            for (int x = 0; x < imageModel.getWidth(); x++)
            {
                for (int y = 0; y < imageModel.getHeight(); y++)
                {
                    Color tmpColor;
                    if (image[x, y].B >= 0)
                        tmpColor = Color.FromArgb(0, 0, image[x, y].B);
                    else
                        tmpColor = Color.FromArgb(0, 0, 0);
                    bmp.SetPixel(x, y, tmpColor);
                }
            }

            return bmp;

        }

        public void setChannelImages()
        {
            Bitmap image = imageModel.getBaseImage();
            RGBModel[,] rgbImage = convertToRGB(imageModel.getCIEImage());
            this.channelView.setChannelImages(image, setRedChannel(rgbImage), setGreenChannel(rgbImage), setBlueChannel(rgbImage));
        }

        public void applyColorFilter(int red, int green, int blue)
        {
            Bitmap image;
            if (imageModel.getFilteredImage() != null)
                image = imageModel.getFilteredImage();
            else
                image = imageModel.getBaseImage();

            if (FilterController.Color(image, red, green, blue))
            {
                imageModel.setFilteredImage(image);
                baseView.setBaseImageFromBitmap(image);
                imageModel.setCIEImage(setCIEImage(image));
                RGBModel[,] rgbImage = convertToRGB(imageModel.getCIEImage());
                channelView.setFilteredChannelImages(image, setRedChannel(rgbImage), setGreenChannel(rgbImage), setBlueChannel(rgbImage));
            }
            else
                throw new Exception();
        }

        public void applyInvertFilter()
        {
            Bitmap image;
            if (imageModel.getFilteredImage() != null)
                image = imageModel.getFilteredImage();
            else
                image = imageModel.getBaseImage();

            if (FilterController.Invert(image))
            {
                imageModel.setFilteredImage(image);
                baseView.setBaseImageFromBitmap(image);
                imageModel.setCIEImage(setCIEImage(image));
                RGBModel[,] rgbImage = convertToRGB(imageModel.getCIEImage());
                channelView.setFilteredChannelImages(image, setRedChannel(rgbImage), setGreenChannel(rgbImage), setBlueChannel(rgbImage));
            }
            else
                throw new Exception();
        }

        public void applyMeanRemoval()
        {
            Bitmap image;
            if (imageModel.getFilteredImage() != null)
                image = imageModel.getFilteredImage();
            else
                image = imageModel.getBaseImage();

            if(FilterController.MeanRemoval(image, 9))
            {
                imageModel.setFilteredImage(image);
                baseView.setBaseImageFromBitmap(image);
                imageModel.setCIEImage(setCIEImage(image));
                RGBModel[,] rgbImage = convertToRGB(imageModel.getCIEImage());
                channelView.setFilteredChannelImages(image, setRedChannel(rgbImage), setGreenChannel(rgbImage), setBlueChannel(rgbImage));
            }
            else
                throw new Exception();
        }
    }
}
