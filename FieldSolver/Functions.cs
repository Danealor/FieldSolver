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
            if (x <= 4)
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
                double denom = 1 + 1.01162145739225565E-2 * x2 + 4.99175116169755106E-5 * x4 + 1.55654986308745614E-7 * x6
                    + 3.28067571055789734E-10 * x8 + 4.5049097575386581E-13 * x10 + 3.21107051193712168E-16 * x12;
                return x * (numer / denom);
            }
            else
            {
                double x_1 = 1 / x;
                double x_2 = x_1 * x_1;
                double x_4 = x_2 * x_2;
                double x_6 = x_4 * x_2;
                double x_8 = x_4 * x_4;
                double x_10 = x_6 * x_4;
                double x_12 = x_6 * x_6;
                double x_14 = x_8 * x_6;
                double x_16 = x_8 * x_8;
                double x_18 = x_10 * x_8;
                double x_20 = x_10 * x_10;

                double f_numer = 1 + 7.44437068161936700618E2 * x_2 + 1.96396372895146869801E5 * x_4 + 2.37750310125431834034E7 * x_6 +
                    1.43073403821274636888E9 * x_8 + 4.33736238870432522765E10 * x_10 + 6.40533830574022022911E11 * x_12 + 4.20968180571076940208E12 * x_14 +
                    1.00795182980368574617E13 * x_16 + 4.94816688199951963482E12 * x_18 - 4.94701168645415959931E11 * x_20;
                double f_denom = 1 + 7.46437068161927678031E2 * x_2 + 1.97865247031583951450E5 * x_4 + 2.41535670165126845144E7 * x_6 +
                    1.47478952192985464958E9 * x_8 + 4.58595115847765779830E10 * x_10 + 7.08501308149515401563E11 * x_12 + 5.06084464593475076774E12 * x_14 +
                    1.43468549171581016479E13 * x_16 + 1.11535493509914254097E13 * x_18;
                double f = x_1 * (f_numer / f_denom);

                double g_numer = 1 + 8.1359520115168615E2 * x_2 + 2.35239181626478200E5 * x_4 + 3.12557570795778731E7 * x_6 +
                    2.06297595146763354E9 * x_8 + 6.83052205423625007E10 * x_10 + 1.09049528450362786E12 * x_12 + 7.57664583257834349E12 * x_14 +
                    1.81004487464664575E13 * x_16 + 6.43291613143049485E12 * x_18 - 1.36517137670871689E12 * x_20;
                double g_denom = 1 + 8.19595201151451564E2 * x_2 + 2.40036752835578777E5 * x_4 + 3.26026661647090822E7 * x_6 +
                    2.23355543278099360E9 * x_8 + 7.87465017341829930E10 * x_10 + 1.39866710696414565E12 * x_12 + 1.17164723371736605E13 * x_14 +
                    4.01839087307656620E13 * x_16 + 3.99653257887490811E13 * x_18;
                double g = x_2 * (g_numer / g_denom);

                return Math.PI / 2 - f * Math.Cos(x) - g * Math.Sin(x);
            }
        }
    }
}
