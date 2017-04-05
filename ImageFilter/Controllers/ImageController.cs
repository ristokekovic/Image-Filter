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
    public class ImageController
    {
        private ImageModel imageModel;
        private BaseView baseView;
        private ChannelView channelView;
        private HistogramView histogramView;

        private int size;
        private ImageBuffer undoBuffer;
        private ImageBuffer redoBuffer;

        public ImageController(BaseView bv, ChannelView cv, HistogramView hv)
        {
            imageModel = new ImageModel();
            baseView = bv;
            channelView = cv;
            histogramView = hv;
            undoBuffer = new ImageBuffer();
            redoBuffer = new ImageBuffer();
        }

        public void setBufferSize(int size)
        {
            this.size = size;
            undoBuffer.setSize(this.size);
            redoBuffer.setSize(this.size);
        }

        public void setImage(String path)
        {
            imageModel.setImage(path);
            CIEModel[,] matrix = setCIEImage(imageModel.getBaseImage());
            imageModel.setCIEImage(matrix);
            baseView.setBaseImage(path);
            histogramView.setBaseImage(imageModel.getBaseImage());
            this.redoBuffer.clearBuffer();
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
            if (image == null)
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

            this.redoBuffer.clearBuffer();
        }

        public Bitmap getCurrentImage()
        {
            if (imageModel.getFilteredImage() != null)
                return imageModel.getFilteredImage();
            else
                return imageModel.getBaseImage();
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
            int[] array = new int[imageModel.getWidth() * imageModel.getHeight()];

            for (int x = 0; x < imageModel.getWidth(); x++)
            {
                for (int y = 0; y < imageModel.getHeight(); y++)
                {
                    Color tmpColor;
                    if (image[x, y].R >= 0)
                    {
                        tmpColor = Color.FromArgb(image[x, y].R, 0, 0);
                        array[x * imageModel.getHeight() + y] = image[x, y].R;
                    }
                    else
                    {
                        tmpColor = Color.FromArgb(0, 0, 0);
                        array[x * imageModel.getHeight() + y] = 0;
                    }
                    bmp.SetPixel(x, y, tmpColor);
                }
            }

            histogramView.setRedHistogramChannel(array, imageModel.getHeight() * imageModel.getWidth());

            return bmp;
        }

        public Bitmap setGreenChannel(RGBModel[,] image)
        {
            Bitmap bmp = new Bitmap(imageModel.getWidth(), imageModel.getHeight());
            int[] array = new int[imageModel.getWidth() * imageModel.getHeight()];

            for (int x = 0; x < imageModel.getWidth(); x++)
            {
                for (int y = 0; y < imageModel.getHeight(); y++)
                {
                    Color tmpColor;
                    if (image[x, y].G >= 0)
                    {
                        tmpColor = Color.FromArgb(0, image[x, y].G, 0);
                        array[x * imageModel.getHeight() + y] = image[x, y].G;
                    }
                    else
                    {
                        tmpColor = Color.FromArgb(0, 0, 0);
                        array[x * imageModel.getHeight() + y] = 0;
                    }
                    bmp.SetPixel(x, y, tmpColor);
                }
            }

            histogramView.setGreenHistogramChannel(array, imageModel.getHeight() * imageModel.getWidth());

            return bmp;

        }

        public Bitmap setBlueChannel(RGBModel[,] image)
        {
            Bitmap bmp = new Bitmap(imageModel.getWidth(), imageModel.getHeight());
            int[] array = new int[imageModel.getWidth() * imageModel.getHeight()];

            for (int x = 0; x < imageModel.getWidth(); x++)
            {
                for (int y = 0; y < imageModel.getHeight(); y++)
                {
                    Color tmpColor;
                    if (image[x, y].B >= 0)
                    {
                        tmpColor = Color.FromArgb(0, 0, image[x, y].B);
                        array[x * imageModel.getHeight() + y] = image[x, y].B;
                    }
                    else
                    {
                        tmpColor = Color.FromArgb(0, 0, 0);
                        array[x * imageModel.getHeight() + y] = 0;
                    }
                    bmp.SetPixel(x, y, tmpColor);
                }
            }

            histogramView.setBlueHistogramChannel(array, imageModel.getHeight() * imageModel.getWidth());

            return bmp;

        }

        public void setChannelImages()
        {
            Bitmap image;
            if (imageModel.getFilteredImage() != null)
                image = imageModel.getFilteredImage();
            else
                image = imageModel.getBaseImage();
            RGBModel[,] rgbImage = convertToRGB(imageModel.getCIEImage());
            histogramView.setBaseImage(imageModel.getBaseImage());
            this.channelView.setChannelImages(image, setRedChannel(rgbImage), setGreenChannel(rgbImage), setBlueChannel(rgbImage));
        }

        public void applyColorFilter(int red, int green, int blue)
        {
            Bitmap image;
            if (imageModel.getFilteredImage() != null)
                image = imageModel.getFilteredImage();
            else
                image = imageModel.getBaseImage();

            this.undoBuffer.push(image);

            if (FilterController.Color(image, red, green, blue))
            {
                imageModel.setFilteredImage(image);
                baseView.setBaseImageFromBitmap(image);
                imageModel.setCIEImage(setCIEImage(image));
                RGBModel[,] rgbImage = convertToRGB(imageModel.getCIEImage());
                histogramView.setBaseImage(imageModel.getFilteredImage());
                if (red != 0 && green == 0 && blue == 0)
                    channelView.setRedChannel(image, setRedChannel(rgbImage));
                else if (green != 0 && red == 0 && blue == 0)
                    channelView.setGreenChannel(image, setGreenChannel(rgbImage));
                else if (blue != 0 && red == 0 && green == 0)
                    channelView.setBlueChannel(image, setBlueChannel(rgbImage));
                else
                    channelView.setFilteredChannelImages(image, setRedChannel(rgbImage), setGreenChannel(rgbImage), setBlueChannel(rgbImage));
            }
            else
                throw new Exception();

            this.redoBuffer.clearBuffer();
        }

        public void applyInvertFilter()
        {
            Bitmap image;
            if (imageModel.getFilteredImage() != null)
                image = imageModel.getFilteredImage();
            else
                image = imageModel.getBaseImage();

            this.undoBuffer.push(image);

            if (FilterController.Invert(image))
            {
                imageModel.setFilteredImage(image);
                baseView.setBaseImageFromBitmap(image);
                imageModel.setCIEImage(setCIEImage(image));
                RGBModel[,] rgbImage = convertToRGB(imageModel.getCIEImage());
                histogramView.setBaseImage(imageModel.getFilteredImage());
                channelView.setFilteredChannelImages(image, setRedChannel(rgbImage), setGreenChannel(rgbImage), setBlueChannel(rgbImage));
            }
            else
                throw new Exception();

            this.redoBuffer.clearBuffer();
        }

        public void applyMeanRemoval(int type)
        {
            Bitmap image;
            if (imageModel.getFilteredImage() != null)
                image = imageModel.getFilteredImage();
            else
                image = imageModel.getBaseImage();

            this.undoBuffer.push(image);

            switch (type)
            {
                case 1:
                    
                    MeanRemoval3x3 mr3 = new MeanRemoval3x3();
                    image = FilterController.ConvolutionFilter(image, mr3);
                    break;
                case 2:
                    MeanRemoval5x5 mr5 = new MeanRemoval5x5();
                    image = FilterController.ConvolutionFilter(image, mr5);
                    break;
                case 3:
                    MeanRemoval7x7 mr7 = new MeanRemoval7x7();
                    image = FilterController.ConvolutionFilter(image, mr7);
                    break;
            }

            imageModel.setFilteredImage(image);
            baseView.setBaseImageFromBitmap(image);
            imageModel.setCIEImage(setCIEImage(image));
            RGBModel[,] rgbImage = convertToRGB(imageModel.getCIEImage());
            histogramView.setBaseImage(imageModel.getFilteredImage());
            channelView.setFilteredChannelImages(image, setRedChannel(rgbImage), setGreenChannel(rgbImage), setBlueChannel(rgbImage));
        
            this.redoBuffer.clearBuffer();
        }

        public void meanRemovalComparison()
        {
            Bitmap image = imageModel.getBaseImage();

            MeanRemoval3x3 mr3 = new MeanRemoval3x3();
            MeanRemoval5x5 mr5 = new MeanRemoval5x5();
            MeanRemoval7x7 mr7 = new MeanRemoval7x7();

            Bitmap convImage3 = FilterController.ConvolutionFilter(image, mr3);
            Bitmap convImage5 = FilterController.ConvolutionFilter(image, mr5);
            Bitmap convImage7 = FilterController.ConvolutionFilter(image, mr7);

            channelView.setChannelImages(image, convImage3, convImage5, convImage7);
        }

        public void applyEdgeDetectionHomogenity()
        {
            Parameter dlg = new Parameter();
            dlg.nValue = 0;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                Bitmap image;
                if (imageModel.getFilteredImage() != null)
                    image = imageModel.getFilteredImage();
                else
                    image = imageModel.getBaseImage();

                this.undoBuffer.push(image);

                if (FilterController.EdgeDetectHomogenity(image, (byte)dlg.nValue))
                {
                    imageModel.setFilteredImage(image);
                    baseView.setBaseImageFromBitmap(image);
                    imageModel.setCIEImage(setCIEImage(image));
                    RGBModel[,] rgbImage = convertToRGB(imageModel.getCIEImage());
                    histogramView.setBaseImage(imageModel.getFilteredImage());
                    channelView.setFilteredChannelImages(image, setRedChannel(rgbImage), setGreenChannel(rgbImage), setBlueChannel(rgbImage));
                }
                else
                    throw new Exception();

                this.redoBuffer.clearBuffer();

            }
        }

        public void applyTimeWarpFilter()
        {

            Parameter dlg = new Parameter();
            dlg.nValue = 0;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                Bitmap image;
                if (imageModel.getFilteredImage() != null)
                    image = imageModel.getFilteredImage();
                else
                    image = imageModel.getBaseImage();

                this.undoBuffer.push(image);
                if (FilterController.TimeWarp(image, (byte)dlg.nValue, false))
                {
                    imageModel.setFilteredImage(image);
                    baseView.setBaseImageFromBitmap(image);
                    imageModel.setCIEImage(setCIEImage(image));
                    RGBModel[,] rgbImage = convertToRGB(imageModel.getCIEImage());
                    histogramView.setBaseImage(imageModel.getFilteredImage());
                    channelView.setFilteredChannelImages(image, setRedChannel(rgbImage), setGreenChannel(rgbImage), setBlueChannel(rgbImage));
                }
                else
                    throw new Exception();

                this.redoBuffer.clearBuffer();
            }
        }

        public void undo()
        {
            if(!this.undoBuffer.isEmpty())
            {
                this.redoBuffer.push(this.imageModel.getFilteredImage());
                Bitmap bmp = this.undoBuffer.pop();
                this.imageModel.setFilteredImage(bmp);
                baseView.setBaseImageFromBitmap(bmp);
                imageModel.setCIEImage(setCIEImage(bmp));
                RGBModel[,] rgbImage = convertToRGB(imageModel.getCIEImage());
                histogramView.setBaseImage(imageModel.getFilteredImage());
                channelView.setFilteredChannelImages(bmp, setRedChannel(rgbImage), setGreenChannel(rgbImage), setBlueChannel(rgbImage));
            }
        }

        public void redo()
        {
            if(!this.redoBuffer.isEmpty())
            {
                this.undoBuffer.push(this.imageModel.getFilteredImage());
                Bitmap bmp = this.redoBuffer.pop();
                this.imageModel.setFilteredImage(bmp);
                baseView.setBaseImageFromBitmap(bmp);
                imageModel.setCIEImage(setCIEImage(bmp));
                RGBModel[,] rgbImage = convertToRGB(imageModel.getCIEImage());
                histogramView.setBaseImage(imageModel.getFilteredImage());
                channelView.setFilteredChannelImages(bmp, setRedChannel(rgbImage), setGreenChannel(rgbImage), setBlueChannel(rgbImage));
            }
        }
    }
}
