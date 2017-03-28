using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageFilter.Models
{
    public class RGBModel
    {
        private int r;
        private int g;
        private int b;

        public RGBModel()
        {
            r = g = b = 0;
        }

        public RGBModel(int r, int g, int b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
        }

        public int R
        {
            get
            {
                return this.r;
            }
            set
            {
                this.r = value;
            }
        }

        public int G
        {
            get
            {
                return this.g;
            }
            set
            {
                this.g = value;
            }
        }

        public int B
        {
            get
            {
                return this.b;
            }
            set
            {
                this.b = value;
            }
        }
    }
}
