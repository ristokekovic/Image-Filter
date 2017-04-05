using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageFilter.Models
{
    public abstract class ConvolutionFilterBase
    {
        public abstract string FilterName
        {
            get;
        }

        public abstract double Factor
        {
            get;
        }

        public abstract double Bias
        {
            get;
        }

        public abstract double[,] FilterMatrix
        {
            get;
        }
    }
}
