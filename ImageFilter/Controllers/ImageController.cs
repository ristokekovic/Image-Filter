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
using System.IO;

namespace ImageFilter.Controllers
{
    public class ImageController
    {
        private ImageModel imageModel;
        private BaseView baseView;
        private ChannelView channelView;
        private HistogramView histogramView;
        

        private int[] redArray;
        private int[] greenArray;
        private int[] blueArray;

        private int[] redHistogramArray;
        private int[] greenHistogramArray;
        private int[] blueHistogramArray;

        private int size;
        private ImageBuffer undoBuffer;
        private ImageBuffer redoBuffer;

        private Color pickedColor;

        public ImageController(BaseView bv, ChannelView cv, HistogramView hv)
        {
            imageModel = new ImageModel();
            baseView = bv;
            channelView = cv;
            channelView.setImageModel(this.imageModel);
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

        public void setPickedColor(Color c)
        {
            this.pickedColor = c;
        }

        public Color getPickedColor()
        {
            return pickedColor;
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
                dialog.Filter = "BMP|*.bmp|JPG|*.jpg;*.jpeg|PNG|*.png|RIKI|*.riki";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    String ext = Path.GetExtension(dialog.FileName);
                    if(ext == ".riki")
                    {
                        if (imageModel.getDownsampledImage() == null)
                        {
                            MessageBox.Show("You did not choose an appropriate downsampled image. Please do that before saving into this file format");
                            return;
                        }
                        else
                        {
                            this.storeCustomFormat(imageModel.getDownsampledImage(), dialog.FileName);
                        }

                    }
                    image.Save(dialog.FileName, ImageFormat.Jpeg);
                }
            }

            this.redoBuffer.clearBuffer();
        }

        public void storeCustomFormat(Bitmap image, string name)
        {
            byte[] array = new byte[(imageModel.getHeight() / 2 * imageModel.getWidth() / 2) * 3];

            int counter = 0;

            for (int y = 0; y < imageModel.getHeight(); y += 2)
                for (int x = 0; x < imageModel.getWidth(); x += 2)
                {
                    array[counter++] = image.GetPixel(x, y).R;
                    array[counter++] = image.GetPixel(x, y).G;
                    array[counter++] = image.GetPixel(x, y).B;
                }

            uint originalDataSize = (uint)(imageModel.getHeight() / 2 * imageModel.getWidth() / 2) * 3;
            byte[] compressedData = new byte[originalDataSize * (101 / 100) + 384];

            int compressedDataSize = CompressionController.Compress(array, compressedData, originalDataSize);

            this.saveToCustomFormat(name, compressedDataSize, compressedData, image);

            MessageBox.Show("Compression done!");
        }

        public void loadCustomFormat(string name)
        {
            int width = 0;
            int height = 0;
            byte[] compressedData = this.loadFromCustomFormat(name, width, height);
            uint originalDataSize = (uint)(height / 2 * width / 2) * 3;
            byte[] decompressedData = new byte[originalDataSize];
            uint compressedDataSize = originalDataSize * (101 / 100) + 384;

            CompressionController.Decompress(compressedData, decompressedData, (uint)compressedDataSize, originalDataSize);

            int counter = 0;
            Bitmap bmp = new Bitmap(width, height);
            Color c;

            for (int y = 0; y < height; y += 2)
                for (int x = 0; x < width; x += 2)
                {
                    c = Color.FromArgb(decompressedData[counter++], decompressedData[counter++], decompressedData[counter++]);
                    bmp.SetPixel(x, y, c);
                    bmp.SetPixel(x + 1, y, c);
                    bmp.SetPixel(x, y + 1, c);
                    bmp.SetPixel(x + 1, y + 1, c);
                }

            imageModel.setImageFromBitmap(bmp);
            imageModel.setCIEImage(setCIEImage(bmp));
            RGBModel[,] rgbImage = convertToRGB(imageModel.getCIEImage());
            histogramView.setBaseImage(imageModel.getFilteredImage());
            baseView.setBaseImageFromBitmap(imageModel.getBaseImage());
            channelView.setFilteredChannelImages(bmp, setRedChannel(rgbImage), setGreenChannel(rgbImage), setBlueChannel(rgbImage));
            undoBuffer.clearBuffer();
            redoBuffer.clearBuffer();

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

        public void applyZoneHistogramFilter(int n, int k)
        {
            int[] filteredRed = FilterController.HistogramZoneFilter(this.redHistogramArray, this.redArray, imageModel.getWidth() * imageModel.getHeight(), n, k);
            int[] filteredGreen = FilterController.HistogramZoneFilter(this.greenHistogramArray, this.greenArray, imageModel.getWidth() * imageModel.getHeight(), n, k);
            int[] filteredBlue = FilterController.HistogramZoneFilter(this.blueHistogramArray, this.blueArray, imageModel.getWidth() * imageModel.getHeight(), n, k);

            Bitmap image;
            if (imageModel.getFilteredImage() != null)
                image = imageModel.getFilteredImage();
            else
                image = imageModel.getBaseImage();

            this.undoBuffer.push(image);

            Bitmap bmp = new Bitmap(imageModel.getWidth(),imageModel.getHeight());
            Color tmpColor;

            for (int x = 0; x < imageModel.getWidth(); x++)
            {
                for (int y = 0; y < imageModel.getHeight(); y++)
                {
                    tmpColor = Color.FromArgb(filteredRed[x * imageModel.getHeight() + y], filteredGreen[x * imageModel.getHeight() + y], filteredBlue[x * imageModel.getHeight() + y]);
                    bmp.SetPixel(x, y, tmpColor);
                    this.redArray[x * imageModel.getHeight() + y] = filteredRed[x * imageModel.getHeight() + y];
                    this.greenArray[x * imageModel.getHeight() + y] = filteredGreen[x * imageModel.getHeight() + y];
                    this.blueArray[x * imageModel.getHeight() + y] = filteredBlue[x * imageModel.getHeight() + y];
                }
            }

            imageModel.setFilteredImage(bmp);
            baseView.setBaseImageFromBitmap(bmp);
            imageModel.setCIEImage(setCIEImage(bmp));
            RGBModel[,] rgbImage = convertToRGB(imageModel.getCIEImage());
            histogramView.setBaseImage(imageModel.getFilteredImage());

            histogramView.setRedHistogramChannel(redArray, imageModel.getHeight() * imageModel.getWidth());
            histogramView.setGreenHistogramChannel(greenArray, imageModel.getHeight() * imageModel.getWidth());
            histogramView.setBlueHistogramChannel(blueArray, imageModel.getHeight() * imageModel.getWidth());

            channelView.setFilteredChannelImages(bmp, setRedChannel(rgbImage), setGreenChannel(rgbImage), setBlueChannel(rgbImage));
        }

        public Bitmap setRedChannel(RGBModel[,] image)
        {
            Bitmap bmp = new Bitmap(imageModel.getWidth(), imageModel.getHeight());
            redArray = new int[imageModel.getWidth() * imageModel.getHeight()];

            for (int x = 0; x < imageModel.getWidth(); x++)
            {
                for (int y = 0; y < imageModel.getHeight(); y++)
                {
                    Color tmpColor;
                    if (image[x, y].R >= 0)
                    {
                        tmpColor = Color.FromArgb(image[x, y].R, 0, 0);
                        redArray[x * imageModel.getHeight() + y] = image[x, y].R;
                    }
                    else
                    {
                        tmpColor = Color.FromArgb(0, 0, 0);
                        redArray[x * imageModel.getHeight() + y] = 0;
                    }
                    bmp.SetPixel(x, y, tmpColor);
                }
            }

            redHistogramArray = histogramView.setRedHistogramChannel(redArray, imageModel.getHeight() * imageModel.getWidth());

            return bmp;
        }

        public Bitmap setGreenChannel(RGBModel[,] image)
        {
            Bitmap bmp = new Bitmap(imageModel.getWidth(), imageModel.getHeight());
            greenArray = new int[imageModel.getWidth() * imageModel.getHeight()];

            for (int x = 0; x < imageModel.getWidth(); x++)
            {
                for (int y = 0; y < imageModel.getHeight(); y++)
                {
                    Color tmpColor;
                    if (image[x, y].G >= 0)
                    {
                        tmpColor = Color.FromArgb(0, image[x, y].G, 0);
                        greenArray[x * imageModel.getHeight() + y] = image[x, y].G;
                    }
                    else
                    {
                        tmpColor = Color.FromArgb(0, 0, 0);
                        greenArray[x * imageModel.getHeight() + y] = 0;
                    }
                    bmp.SetPixel(x, y, tmpColor);
                }
            }

            greenHistogramArray = histogramView.setGreenHistogramChannel(greenArray, imageModel.getHeight() * imageModel.getWidth());

            return bmp;

        }

        public Bitmap setBlueChannel(RGBModel[,] image)
        {
            Bitmap bmp = new Bitmap(imageModel.getWidth(), imageModel.getHeight());
            blueArray = new int[imageModel.getWidth() * imageModel.getHeight()];

            for (int x = 0; x < imageModel.getWidth(); x++)
            {
                for (int y = 0; y < imageModel.getHeight(); y++)
                {
                    Color tmpColor;
                    if (image[x, y].B >= 0)
                    {
                        tmpColor = Color.FromArgb(0, 0, image[x, y].B);
                        blueArray[x * imageModel.getHeight() + y] = image[x, y].B;
                    }
                    else
                    {
                        tmpColor = Color.FromArgb(0, 0, 0);
                        blueArray[x * imageModel.getHeight() + y] = 0;
                    }
                    bmp.SetPixel(x, y, tmpColor);
                }
            }

            blueHistogramArray = histogramView.setBlueHistogramChannel(blueArray, imageModel.getHeight() * imageModel.getWidth());

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

        public void downsampleAllChannels()
        {
            Bitmap image;
            if (imageModel.getFilteredImage() != null)
                image = imageModel.getFilteredImage();
            else
                image = imageModel.getBaseImage();

            channelView.setChannelImages(image, this.downsampleChannel(this.convertToRGB(imageModel.getCIEImage()), "red"),
                                                this.downsampleChannel(this.convertToRGB(imageModel.getCIEImage()), "green"),
                                                this.downsampleChannel(this.convertToRGB(imageModel.getCIEImage()), "blue"));
        }

        public Bitmap downsampleChannel(RGBModel[,] image, string channel)
        {
            Bitmap bmp = new Bitmap(imageModel.getWidth(), imageModel.getHeight());
            RGBModel firstPixel;
            RGBModel secondPixel;
            RGBModel thirdPixel;
            RGBModel fourthPixel;

            int averageRed;
            int averageGreen;
            int averageBlue;

            for (int y = 0; y < imageModel.getHeight(); y++)
                for (int x = 0; x < imageModel.getWidth(); x++)
                {
                    if (image[x, y].R < 0)
                        image[x, y].R = 0;

                    if (image[x, y].G < 0)
                        image[x, y].G = 0;

                    if (image[x, y].B < 0)
                        image[x, y].B = 0;
                }

            for (int y = 0; y < imageModel.getHeight(); y+=2)
                for (int x = 0; x < imageModel.getWidth(); x+=2)
                {
                    

                    switch(channel)
                    {
                        case "red":
                            firstPixel = image[x, y];
                            secondPixel = image[x + 1, y];
                            thirdPixel = image[x, y + 1];
                            fourthPixel = image[x + 1, y + 1];
                            averageGreen = (firstPixel.G + secondPixel.G + thirdPixel.G + fourthPixel.G) / 4;
                            averageBlue=(firstPixel.B + secondPixel.B + thirdPixel.B + fourthPixel.B) / 4;
                            if (averageGreen < 0)
                                averageGreen = 0;
                            if (averageBlue < 0)
                                averageBlue = 0;
                            bmp.SetPixel(x, y, Color.FromArgb(image[x, y].R, averageGreen, averageBlue));
                            bmp.SetPixel(x + 1, y, Color.FromArgb(image[x + 1, y].R, averageGreen, averageBlue));
                            bmp.SetPixel(x, y + 1, Color.FromArgb(image[x, y + 1].R, averageGreen, averageBlue));
                            bmp.SetPixel(x + 1, y + 1, Color.FromArgb(image[x + 1, y + 1].R, averageGreen, averageBlue));
                            break;
                        case "green":
                            firstPixel = image[x, y];
                            secondPixel = image[x + 1, y];
                            thirdPixel = image[x, y + 1];
                            fourthPixel = image[x + 1, y + 1];
                            averageRed = (firstPixel.R + secondPixel.R + thirdPixel.R + fourthPixel.R) / 4;
                            averageBlue = (firstPixel.B + secondPixel.B + thirdPixel.B + fourthPixel.B) / 4;
                            if (averageRed < 0)
                                averageRed = 0;
                            if (averageBlue < 0)
                                averageBlue = 0;
                            bmp.SetPixel(x, y, Color.FromArgb(averageRed, image[x,y].G, averageBlue));
                            bmp.SetPixel(x + 1, y, Color.FromArgb(averageRed, image[x+1, y].G, averageBlue));
                            bmp.SetPixel(x, y + 1, Color.FromArgb(averageRed, image[x, y+1].G, averageBlue));
                            bmp.SetPixel(x + 1, y + 1, Color.FromArgb(averageRed, image[x+1, y+1].G, averageBlue));
                            break;
                        case "blue":
                            firstPixel = image[x, y];
                            secondPixel = image[x + 1, y];
                            thirdPixel = image[x, y + 1];
                            fourthPixel = image[x + 1, y + 1];
                            averageRed = (firstPixel.R + secondPixel.R + thirdPixel.R + fourthPixel.R) / 4;
                            averageGreen = (firstPixel.G + secondPixel.G + thirdPixel.G + fourthPixel.G) / 4;
                            if (averageRed < 0)
                                averageRed = 0;
                            if (averageGreen < 0)
                                averageGreen = 0;
                            bmp.SetPixel(x, y, Color.FromArgb(averageRed, averageGreen, image[x, y].R));
                            bmp.SetPixel(x + 1, y, Color.FromArgb(averageRed, averageGreen, image[x + 1, y].B));
                            bmp.SetPixel(x, y + 1, Color.FromArgb(averageRed, averageGreen, image[x, y + 1].B));
                            bmp.SetPixel(x + 1, y + 1, Color.FromArgb(averageRed, averageGreen, image[x + 1, y + 1].B));
                            break;
                    }
                }

            return bmp;
        }

        public void saveToCustomFormat(string file, int size, byte[] array, Bitmap bitmap)
        {
            //PPM File Format
            //Header contains:
            //P3 means that this is a RGB color image in ASCII
            //Next two values are width and height of the image in pixels
            //The last number is the maximum value each color can take
            
            //After this minimal header, raw RGB data follows

            //Use a streamwriter to write the text part of the encoding
            var writer = new StreamWriter(file);
            writer.Write("P6" + "\n");
            writer.Write(bitmap.Width + " " + bitmap.Height + "\n");
            writer.Write("255" + "\n");
            writer.Close();
            //Switch to a binary writer to write the data
            var writerB = new BinaryWriter(new FileStream(file, FileMode.Append));

            for(int i = 0; i < size; i++)
            {
                writerB.Write(array[i]);
            }
            writerB.Close();
        }

        public byte[] loadFromCustomFormat(string file, int width, int height)
        {
            var reader = new BinaryReader(new FileStream(file, FileMode.Open));
            if (reader.ReadChar() != 'P' || reader.ReadChar() != '6')
                return null;
            reader.ReadChar(); //Eat newline
            string widths = "", heights = "";
            char temp;
            while ((temp = reader.ReadChar()) != ' ')
                widths += temp;
            while ((temp = reader.ReadChar()) >= '0' && temp <= '9')
                heights += temp;
            if (reader.ReadChar() != '2' || reader.ReadChar() != '5' || reader.ReadChar() != '5')
                return null;
            reader.ReadChar(); //Eat the last newline
            width = int.Parse(widths);
            height = int.Parse(heights);

            //Read in the pixels
            byte[] array = new byte[(width / 2 * height / 2) * 3];
            for (int i = 0; i < (width / 2 * height / 2) * 3; i++)
                array[i] = reader.ReadByte();

            return array;
        }

        public double Sim(Color first, Color second)
        {
            return Math.Sqrt(Math.Pow((first.R - second.R),2) + Math.Pow((first.G - second.G),2) + Math.Pow((first.B - second.B), 2));
        }

        public Bitmap floodfill(Color ci, Bitmap image, int x, int y, Color Y, int S)
        {
            //Bitmap result = new Bitmap(image.Width, image.Height);
            Stack<Pixel> pixels = new Stack<Pixel>();
            int ctr = 0;

            pixels.Push(new Pixel(x, y, ci));

            while (pixels.Count > 0)
            {

                if (ctr > 5000000)
                    break;

                Pixel popped = pixels.Pop();

                if (popped.x == 2 || popped.y == 2 || popped.x == image.Width || popped.y == image.Height)
                    continue;

                if (Sim(popped.color, Y) <= S && Sim(ci, Y) != 0.0)
                {
                    ctr++;
                    image.SetPixel(popped.x, popped.y, Y);

                    pixels.Push(new Pixel(popped.x - 1, popped.y, image.GetPixel(x - 1, y)));
                    pixels.Push(new Pixel(popped.x - 1, popped.y - 1, image.GetPixel(x - 1, y - 1)));
                    pixels.Push(new Pixel(popped.x - 1, popped.y + 1, image.GetPixel(x - 1, y + 1)));
                    
                    pixels.Push(new Pixel(popped.x, popped.y - 1, image.GetPixel(x, y - 1)));
                    pixels.Push(new Pixel(popped.x, popped.y + 1, image.GetPixel(x, y + 1)));
                    
                    
                    pixels.Push(new Pixel(popped.x + 1, popped.y - 1, image.GetPixel(x + 1, y - 1)));
                    pixels.Push(new Pixel(popped.x + 1, popped.y, image.GetPixel(x + 1, y)));
                    pixels.Push(new Pixel(popped.x + 1, popped.y + 1, image.GetPixel(x + 1, y + 1)));
                }
                else if(Sim(ci,Y) != 0.0)
                {
                    pixels.Push(new Pixel(popped.x - 1, popped.y, image.GetPixel(x - 1, y)));
                    pixels.Push(new Pixel(popped.x - 1, popped.y - 1, image.GetPixel(x - 1, y - 1)));
                    pixels.Push(new Pixel(popped.x - 1, popped.y + 1, image.GetPixel(x - 1, y + 1)));

                    pixels.Push(new Pixel(popped.x, popped.y - 1, image.GetPixel(x, y - 1)));
                    pixels.Push(new Pixel(popped.x, popped.y + 1, image.GetPixel(x, y + 1)));


                    pixels.Push(new Pixel(popped.x + 1, popped.y - 1, image.GetPixel(x + 1, y - 1)));
                    pixels.Push(new Pixel(popped.x + 1, popped.y, image.GetPixel(x + 1, y)));
                    pixels.Push(new Pixel(popped.x + 1, popped.y + 1, image.GetPixel(x + 1, y + 1)));
                }
            }

            return image;
        }

        public void checkIfSimilar(Color Y, Point T, Bitmap b, int S, int numberOfSteps)
        {
            if (T.X == 2 || T.Y == 2 || T.X == b.Width || T.Y == b.Height)
                return;

            if (numberOfSteps > 3000)
                return;

            /*if(numberOfSteps == 250)
                MessageBox.Show("250");

            if (numberOfSteps == 500)
                MessageBox.Show("500");

            if (numberOfSteps == 750)
                MessageBox.Show("750");

            if (numberOfSteps == 2999)
                MessageBox.Show("2999");*/

            Color ci = b.GetPixel(T.X - 1, T.Y);
            if(Sim(ci, Y) <= S && Sim(ci, Y) != 0.0)
            {
                b.SetPixel(T.X - 1, T.Y, pickedColor);
                numberOfSteps++;
                checkIfSimilar(Y, new Point(T.X - 1, T.Y), b, S, numberOfSteps);
            }
            ci = b.GetPixel(T.X - 1, T.Y - 1);
            if (Sim(ci, Y) <= S && Sim(ci, Y) != 0.0)
            {
                b.SetPixel(T.X - 1, T.Y - 1, pickedColor);
                numberOfSteps++;
                checkIfSimilar(Y, new Point(T.X - 1, T.Y - 1), b, S, numberOfSteps);
            }
            ci = b.GetPixel(T.X - 1, T.Y + 1);
            if (Sim(ci, Y) <= S && Sim(ci, Y) != 0.0)
            {
                b.SetPixel(T.X - 1, T.Y + 1, pickedColor);
                numberOfSteps++;
                checkIfSimilar(Y, new Point(T.X - 1, T.Y + 1), b, S, numberOfSteps);
            }
            ci = b.GetPixel(T.X, T.Y - 1);
            if (Sim(ci, Y) <= S && Sim(ci, Y) != 0.0)
            {
                b.SetPixel(T.X, T.Y - 1, pickedColor);
                numberOfSteps++;
                checkIfSimilar(Y, new Point(T.X, T.Y - 1), b, S, numberOfSteps);
            }
            ci = b.GetPixel(T.X, T.Y + 1);
            if (Sim(ci, Y) <= S && Sim(ci, Y) != 0.0)
            {
                b.SetPixel(T.X, T.Y + 1, pickedColor);
                numberOfSteps++;
                checkIfSimilar(Y, new Point(T.X, T.Y + 1), b, S, numberOfSteps);
            }
            ci = b.GetPixel(T.X + 1, T.Y);
            if (Sim(ci, Y) <= S && Sim(ci, Y) != 0.0)
            {
                b.SetPixel(T.X + 1, T.Y, pickedColor);
                numberOfSteps++;
                checkIfSimilar(Y, new Point(T.X + 1, T.Y), b, S, numberOfSteps);
            }
            ci = b.GetPixel(T.X + 1, T.Y - 1);
            if (Sim(ci, Y) <= S && Sim(ci, Y) != 0.0)
            {
                b.SetPixel(T.X + 1, T.Y - 1, pickedColor);
                numberOfSteps++;
                checkIfSimilar(Y, new Point(T.X + 1, T.Y - 1), b, S, numberOfSteps);
            }
            ci = b.GetPixel(T.X + 1, T.Y + 1);
            if (Sim(ci, Y) <= S && Sim(ci, Y) != 0.0)
            {
                b.SetPixel(T.X + 1, T.Y + 1, pickedColor);
                numberOfSteps++;
                checkIfSimilar(Y, new Point(T.X + 1, T.Y + 1), b, S, numberOfSteps);
            }

            return;
        }

        public void applyFloodFilter(Color c, int x, int y)
        {
            Bitmap image;
            if (imageModel.getFilteredImage() != null)
                image = imageModel.getFilteredImage();
            else
                image = imageModel.getBaseImage();

            this.undoBuffer.push(image);

            image.SetPixel(x, y, pickedColor);

            int treshold = 0;

            Parameter dlg = new Parameter();
            dlg.nValue = 0;

            if (DialogResult.OK == dlg.ShowDialog())
                treshold = dlg.nValue;

            //checkIfSimilar(c, new Point(x, y), image, treshold, 0);
            image = floodfill(c, image, x, y, pickedColor, treshold);

            imageModel.setFilteredImage(image);
            baseView.setBaseImageFromBitmap(image);
            imageModel.setCIEImage(setCIEImage(image));
            RGBModel[,] rgbImage = convertToRGB(imageModel.getCIEImage());
            histogramView.setBaseImage(imageModel.getFilteredImage());
            channelView.setFilteredChannelImages(image, setRedChannel(rgbImage), setGreenChannel(rgbImage), setBlueChannel(rgbImage));

        }

    }
}
