using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageFilter.Models
{
    class MeanRemoval7x7 : ConvolutionFilterBase
    {
        public override string FilterName
        {
            get { return "MeanRemoval7x7Filter"; }
        }

        private double factor = 1.0 / -35.0;
        public override double Factor
        {
            get { return factor; }
        }

        private double bias = 0.0;
        public override double Bias
        {
            get { return bias; }
        }

        private double[,] filterMatrix =
            new double[,] { { -1,-1, 0,-1,-1, 0,-1 },
                            { 0, -1,-1,-1,-1,-1,-1 },
                            { -1, -1,-1,-1,-1,-1, 0 },
                            { -1,-1,-1, 12, -1,-1,-1 },
                            { 0, -1,-1,-1,-1,-1,-1 },
                            { -1, -1,-1,-1,-1,-1, 0 },
                            { -1, 0,-1,-1, 0,-1,-1 },};

        public override double[,] FilterMatrix
        {
            get { return filterMatrix; }
        }
    }
}
