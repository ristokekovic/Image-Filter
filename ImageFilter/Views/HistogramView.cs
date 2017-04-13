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
    public partial class HistogramView : UserControl
    {
        public HistogramView()
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

        public void setBaseImage(Bitmap image)
        {
            this.baseImage.Image = image.Clone(
                                  new Rectangle(0, 0, image.Width, image.Height),
                                  System.Drawing.Imaging.PixelFormat.DontCare);
            baseImage.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public int[] setRedHistogramChannel(int[] array, int size)
        {
            redChart.Series["Red"].Points.Clear();

            int[] frequency = new int[256];

            for (int i = 0; i < 256; i++)
                frequency[i] = 0;

            for(int i = 0; i < size; i++)
            {
                frequency[array[i]]++;
            }

            for(int i=0; i< 255;i++)
            {
                redChart.Series["Red"].Points.AddXY(i, frequency[i]);
            }

            return frequency;
        }

        public void setRedHistogramChannelFromFrequency(int[] array, int[] frequency, int size)
        {
            for (int i = 0; i < size; i++)
            {
                redChart.Series["Red"].Points.AddXY(array[i], frequency[array[i]]);
            }
        }

        public int[] setGreenHistogramChannel(int[] array, int size)
        {
            greenChart.Series["Green"].Points.Clear();

            int[] frequency = new int[256];

            for (int i = 0; i < 256; i++)
                frequency[i] = 0;

            for (int i = 0; i < size; i++)
            {
                frequency[array[i]]++;
            }

            for (int i = 0; i < 255; i++)
            {
                greenChart.Series["Green"].Points.AddXY(i, frequency[i]);
            }

            return frequency;
        }

        public void setGreenHistogramChannelFromFrequency(int[] array, int[] frequency, int size)
        {
            for (int i = 0; i < size; i++)
            {
                greenChart.Series["Green"].Points.AddXY(array[i], frequency[array[i]]);
            }
        }

        public int[] setBlueHistogramChannel(int[] array, int size)
        {
            blueChart.Series["Blue"].Points.Clear();
            int[] frequency = new int[256];

            for (int i = 0; i < 256; i++)
                frequency[i] = 0;

            for (int i = 0; i < size; i++)
            {
                frequency[array[i]]++;
            }

            for (int i = 0; i < 255; i++)
            {
                blueChart.Series["Blue"].Points.AddXY(i, frequency[i]);
            }

            return frequency;
        }

        public void setBlueHistogramChannelFromFrequency(int[] array, int[] frequency, int size)
        {
            for (int i = 0; i < size; i++)
            {
                blueChart.Series["Blue"].Points.AddXY(array[i], frequency[array[i]]);
            }
        }

        public void setFilteredChannels(int[] redHistogramArray, int[] greenHistogramArray, int[] blueHistogramArray)
        {
            redChart.Series["Red"].Points.Clear();
            greenChart.Series["Green"].Points.Clear();
            blueChart.Series["Blue"].Points.Clear();

            for (int i = 0; i < 255; i++)
            {
                redChart.Series["Red"].Points.AddXY(i, redHistogramArray[i]);
            }

            for (int i = 0; i < 255; i++)
            {
                greenChart.Series["Green"].Points.AddXY(i, greenHistogramArray[i]);
            }

            for (int i = 0; i < 255; i++)
            {
                blueChart.Series["Blue"].Points.AddXY(i, blueHistogramArray[i]);
            }
        }
    }
}
