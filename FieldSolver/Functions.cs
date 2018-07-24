using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldSolver
{
    static class Functions
    {
        /// <summary>
        /// Calculates the sine integral of x using Padé approximants with a formula given by Rowe et al (2015).
        /// Accurate to better than 10^-16.
        /// </summary>
        public static double Si(double x)
        {
            // Note: use decimal (suffix 'm') if precision is lacking
            x = Math.Abs(x);
            if (x < 4)
            {
                double x2 = x * x;
                double x4 = x2 * x2;
                double x6 = x4 * x2;
                double x8 = x4 * x4;
                double x10 = x6 * x4;
                double x12 = x6 * x6;
                double x14 = x8 * x6;

                double numer = 1 - 4.54393409816329991E-2 * x2 + 1.15457225751016682E-3 * x4 - 1.41018536821330254E-5 * x6 
                    + 9.43280809438713025E-8 * x8 - 3.53201978997168357E-10 * x10 + 7.08240282274875911E-13 * x12 - 6.05338212010422477E-16 * x14;
                double denom = 1 + 1.01162145739225565E-2 * x2 + 4.99175116169755106E-5 * x4 + 1.55654986308745614E-7 * x6; //...
            }
            else
            {
                double x_2 = 1 / (x * x);
                double x_4 = x_2 * x_2;
                double x_6 = x_4 * x_2;
                double x_8 = x_4 * x_4;
                double x_10 = x_6 * x_4;
                double x_12 = x_6 * x_6;
                double x_14 = x_8 * x_6;
                double x_16 = x_8 * x_8;
                double x_18 = x_10 * x_8;
                double x_20 = x_10 * x_10;
            }
        }
    }
}
