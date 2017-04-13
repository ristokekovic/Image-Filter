using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageFilter.Models
{
    class ImageBuffer
    {
        private Bitmap[] buffer;
        private int size;
        private int currentNoOfElements;

        public ImageBuffer()
        {
            this.size = 0;
            this.currentNoOfElements = 0;
        }

        public void setSize(int size)
        {
            this.size = size;
            buffer = new Bitmap[size];
        }

        public bool isEmpty()
        {
            if (this.buffer == null)
            {
                this.size = 10;
                this.currentNoOfElements = 0;
                buffer = new Bitmap[size];
            }

            return this.currentNoOfElements == 0;
        }

        public bool isFull()
        {
            if (this.buffer == null)
            {
                this.size = 10;
                this.currentNoOfElements = 0;
                buffer = new Bitmap[size];
            }

            return this.currentNoOfElements == this.size;
        }

        public void clearBuffer()
        {
            this.size = 10;
            buffer = new Bitmap[size];
            this.currentNoOfElements = 0;
        }

        public void push(Bitmap bmp)
        {
            if(this.buffer == null)
            {
                this.size = 10;
                this.currentNoOfElements = 0;
                buffer = new Bitmap[size];
            }

            if (!this.isFull())
            {
                this.buffer[currentNoOfElements] = bmp.Clone(
                                  new Rectangle(0, 0, bmp.Width, bmp.Height),
                                  System.Drawing.Imaging.PixelFormat.DontCare);
                this.currentNoOfElements++;
            }
            else
            {
                this.removeFirst();
                this.buffer[currentNoOfElements] = bmp.Clone(
                                  new Rectangle(0, 0, bmp.Width, bmp.Height),
                                  System.Drawing.Imaging.PixelFormat.DontCare);
                this.currentNoOfElements++;
            }
        }

        public Bitmap pop()
        {
            if (this.buffer == null)
            {
                this.size = 10;
                this.currentNoOfElements = 0;
                buffer = new Bitmap[size];
            }

            if (!this.isEmpty())
            {
                Bitmap bmp = this.buffer[currentNoOfElements - 1].Clone(
                                  new Rectangle(0, 0, this.buffer[currentNoOfElements - 1].Width, this.buffer[currentNoOfElements - 1].Height),
                                  System.Drawing.Imaging.PixelFormat.DontCare);
                this.currentNoOfElements--;
                return bmp;
            }
            else return null;

        }

        public Bitmap removeFirst()
        {
            if (this.buffer == null)
            {
                this.size = 10;
                this.currentNoOfElements = 0;
                buffer = new Bitmap[size];
            }

            if (!this.isEmpty())
            {
                Bitmap bmp = this.buffer[0];
                if (this.currentNoOfElements == 1)
                    currentNoOfElements--;
                else
                {
                    for (int i = 0; i < currentNoOfElements; i++)
                        this.buffer[i] = this.buffer[i + 1];
                    currentNoOfElements--;
                }

                return bmp;
            }
            else return null;
        }
    }
}
