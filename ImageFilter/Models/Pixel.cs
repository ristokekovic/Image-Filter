using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageFilter.Models
{
    class Pixel
    {
        public int x;
        public int y;
        public Color color;

        public Pixel()
        {
            x = 0;
            y = 0;
            color = new Color();
        }

        public Pixel(int x, int y, Color color)
        {
            this.x = x;
            this.y = y;
            this.color = color;
        }
    }
}
