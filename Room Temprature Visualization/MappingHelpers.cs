using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Room_Temprature_Visualization
{
    class MappingHelpers
    {
        // An array to hold the color names .. 
        static string[] colorTableNames = { "Blue", "Cyan", "LimeGreen", "Yellow", "Red" };
        // An array to hold the color values .. 
        static string[] colorTableValues = { "0,0,255", "0,255,255", "50,205,50", "255,255,0", "255,0,0" };

        static public double[] LookUpTableValueToColor(int N, double S, double Smin, double Smax)
        {
            string colorResult;
            // Regulate the borders .. 
            if (S < Smin)
            {
                colorResult = colorTableValues[0];
            }

            else if (S >= Smax)
            {
                colorResult = colorTableValues[N - 1];
            }

            else
            {
                double dummy1 = (S - Smin) * N;
                double dummy2 = (Smax - Smin);
                colorResult = colorTableValues[Convert.ToInt32(Math.Floor(dummy1 / dummy2))];
            }

            string[] result = colorResult.Split(',');
            return new double[] { Convert.ToInt32(result[0]), Convert.ToInt32(result[1]), Convert.ToInt32(result[2]) };

        }
        static public double[] TransferFunctionValueToColor(double N, double S, double Smin, double Smax)
        {
            if (S >= Smin && S <= Smax && Smin != Smax)
            {
                double DeltaS = (Smax - Smin) / (N - 1);
                double Ds = (S - Smin) / DeltaS;

                double i = Math.Floor(Ds);

                double alpha = Ds - i;

                string[] Ci = null;
                string[] CiP1 = null;

                if (i != N - 1)
                {
                    Ci = colorTableValues[(int)i].Split(',');
                    CiP1 = colorTableValues[(int)i + 1].Split(',');
                }

                else
                {
                    Ci = colorTableValues[(int)i].Split(',');
                    CiP1 = colorTableValues[(int)i].Split(',');
                }

                double[] FinalColor = {
                Convert.ToDouble(Ci[0]) + alpha * (Convert.ToDouble(CiP1[0]) - Convert.ToDouble(Ci[0])),
                Convert.ToDouble(Ci[1]) + alpha * (Convert.ToDouble(CiP1[1]) - Convert.ToDouble(Ci[1])),
                Convert.ToDouble(Ci[2]) + alpha * (Convert.ToDouble(CiP1[2]) - Convert.ToDouble(Ci[2]))
            };

                return new double[] { FinalColor[0], FinalColor[1], FinalColor[2] };
            }

            else
            {
                return null;
            }
        }
    }
}
