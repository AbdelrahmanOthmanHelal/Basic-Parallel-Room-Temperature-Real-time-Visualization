using System;
using ColorMapper;

namespace Room_Temprature_Visualization
{
    class Cell
    {
        public int xCoord, yCoord;
        public double[] color;
        public static double sMin, sMax;
        public static int length = 0;
        public static colorMappingMode cellColoringMode;
        public string cellType;
        public double temprature;

        public void computeColor()
        {
            if (Visualizer.cellTypes[cellType] == null)
            {
                color = new double[] { 0, 0, 0 };
            }
            else
            {
                //If it's a discrete mode 
                switch (cellColoringMode)
                {
                    case colorMappingMode.Discrete:
                        color = MappingHelpers.LookUpTableValueToColor(5, Convert.ToDouble(Visualizer.cellTypes[cellType]), sMin, sMax);
                        break;

                    case colorMappingMode.Continuous:
                        color = MappingHelpers.TransferFunctionValueToColor(5, Convert.ToDouble(Visualizer.cellTypes[cellType]), sMin, sMax);
                        break;
                }
            }
            this.temprature = Convert.ToDouble(Visualizer.cellTypes[cellType]);
        }

        public void computeColor(double temprature)
        {
            this.temprature = temprature;
            switch (cellColoringMode)
            {
                case colorMappingMode.Discrete:
                    color = MappingHelpers.LookUpTableValueToColor(5, temprature, sMin, sMax);
                    break;

                case colorMappingMode.Continuous:
                    color = MappingHelpers.TransferFunctionValueToColor(5, temprature, sMin, sMax);
                    break;
            }
        }
    }
}
