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
            /*chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Maximum = 255;
            chart2.ChartAreas[0].AxisY.Minimum = 0;
            chart2.ChartAreas[0].AxisY.Maximum = 255;
            chart3.ChartAreas[0].AxisY.Minimum = 0;
            chart3.ChartAreas[0].AxisY.Maximum = 255;
            chart4.ChartAreas[0].AxisY.Minimum = 0;
            chart4.ChartAreas[0].AxisY.Maximum = 255;*/
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

        public void setRedHistogramChannel(int[] array, int size)
        {
            int[] frequency = new int[256];

            for (int i = 0; i < 256; i++)
                frequency[i] = 0;

            for(int i = 0; i < size; i++)
            {
                frequency[array[i]]++;
            }

            for(int i=0; i< size;i++)
            {
                redChart.Series["Red"].Points.AddXY(array[i], frequency[array[i]]);
            }
        }

        public void setGreenHistogramChannel(int[] array, int size)
        {
            int[] frequency = new int[256];

            for (int i = 0; i < 256; i++)
                frequency[i] = 0;

            for (int i = 0; i < size; i++)
            {
                frequency[array[i]]++;
            }

            for (int i = 0; i < size; i++)
            {
                greenChart.Series["Green"].Points.AddXY(array[i], frequency[array[i]]);
            }
        }

        public void setBlueHistogramChannel(int[] array, int size)
        {
            int[] frequency = new int[256];

            for (int i = 0; i < 256; i++)
                frequency[i] = 0;

            for (int i = 0; i < size; i++)
            {
                frequency[array[i]]++;
            }

            for (int i = 0; i < size; i++)
            {
                blueChart.Series["Blue"].Points.AddXY(array[i], frequency[array[i]]);
            }
        }
    }
}
