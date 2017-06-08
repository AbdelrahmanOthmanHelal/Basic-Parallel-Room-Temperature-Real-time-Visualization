using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using Tao.Platform.Windows;
using System.Runtime.InteropServices;

namespace Room_Temprature_Visualization
{
    class Visualizer
    {
        // Importing the DLL file..
        [DllImport(@"CalculateAveragesCppAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void CalculateAveragesCPP(double[] cellTemps, double[] cellTempsBackup, int[] cellTypes, int[] cellTypesBackup, int ColsCount, int RowsCount, int numThreads, int[] rowIntersect, int[] colIntersect);

        // This is the calculation mode .. a user input 
        public static CalculationMode mainCalculationMode = CalculationMode.Parallel;

        // This is the desired language mode .. a user input (C# is for both seq and parallel, c++ for only parallel)
        public static ParallelizationMode mainParallizationMode = ParallelizationMode.CSharp;

        // This is a waiting period for the thread ...
        static public int tickTime = 0; // default value

        // This is the number of threads .. for C# or C++
        static public int numberOfThreads = 1; // Default value

        // The openGL Tao's control ..
        static public SimpleOpenGlControl MainOpenGLControl;
        // A table to hold all cell types, this is a table to add types dynamically during the run time
        static public Hashtable cellTypes;
        //A global array of cells for the panel ..
        static public Cell[,] panelCells;

        // The cell values after the computation
        static public Cell[,] panelCellsBackup;
        
        static public ThreadStart MasterCalculationThreadStart;
        static public Thread MasterCalculationThread;

        static public void InitializePanel(double sMax, double sMin, double temprature = 50)
        {
            //Forming the 2D array of cells to be ready for computations .. 
            int RowsCount = MainOpenGLControl.Height / Cell.length, ColsCount = MainOpenGLControl.Width / Cell.length;
    
            panelCells = new Cell[RowsCount, ColsCount];
            
            Cell.cellColoringMode = colorMappingMode.Continuous; // default
            Cell.sMin = sMin;
            Cell.sMax = sMax;

            for (int i = 0; i < RowsCount; i++)
            {
                for (int j = 0; j < ColsCount; j++)
                {
                    panelCells[i, j] = new Cell();
                    panelCells[i, j].cellType = "Tr"; // all cells are normal by default
                    panelCells[i, j].computeColor(); // mapping the temprature to a color value

                    // Storing the coords
                    panelCells[i, j].xCoord = j * Cell.length; 
                    panelCells[i, j].yCoord = i * Cell.length;
                }
            }
        }

        static private void calculateAveragesSequential(int[] rowIntersect, int[]colIntersect, int rowCount, int colsCount)
        {
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < colsCount; j++)
                { 
                    int tempRowValue, tempColValue;
                    double temp = panelCells[i, j].temprature, numberOfCells = 1;

                    if (panelCells[i, j].cellType == "Tr")
                    {
                        for (int k = 0; k < 8; k++)
                        {
                            tempRowValue = i + rowIntersect[k];
                            tempColValue = j + colIntersect[k];
                            if (tempRowValue >= 0 && tempRowValue < rowCount && tempColValue >= 0 && tempColValue < colsCount)
                            {
                                if (panelCells[tempRowValue, tempColValue].cellType != "B")
                                {
                                    temp += panelCells[tempRowValue, tempColValue].temprature;
                                    numberOfCells++;
                                }
                            }
                        }
                        panelCellsBackup[i, j].computeColor(temp / numberOfCells);
                        Thread.Sleep(tickTime);
                    }
                }
            }
        }

        static void calculateAveragesParallelCSharp(int[] rowIntersect, int[] colIntersect, int RowsCount, int ColsCount)
        {
            Parallel.For(0, RowsCount, new ParallelOptions { MaxDegreeOfParallelism = numberOfThreads }, i =>
            {
                Parallel.For(0, ColsCount, j =>
                {
                    int tempRowValue, tempColValue;
                    double temp = panelCells[i, j].temprature, numberOfCells = 1;

                    if (panelCells[i, j].cellType == "Tr")
                    {
                        for (int k = 0; k < 8; k++)
                        {
                            tempRowValue = i + rowIntersect[k];
                            tempColValue = j + colIntersect[k];
                            if (tempRowValue >= 0 && tempRowValue < RowsCount && tempColValue >= 0 && tempColValue < ColsCount)
                            {
                                if (panelCells[tempRowValue, tempColValue].cellType != "B")
                                {
                                    temp += panelCells[tempRowValue, tempColValue].temprature;
                                    numberOfCells++;
                                }
                            }
                        }
                        panelCellsBackup[i, j].computeColor(temp / numberOfCells);
                        Thread.Sleep(tickTime);
                    }
                });
            });
        }

        static void calculateAveragesParallelCppPre(int[] rowIntersect, int[] colIntersect, int RowsCount, int ColsCount)
        {
            double[] cellTemps = new double[ColsCount * RowsCount], cellTempsBackup = new double[ColsCount * RowsCount];
            int[] cellTypes = new int[RowsCount * ColsCount], cellTypesBackup = new int[ RowsCount * ColsCount];

            for (int i = 0; i < RowsCount; i ++){
                for (int j = 0; j < ColsCount; j++)
                {
                    cellTemps[(i * ColsCount) + j] = panelCells[i, j].temprature;
                    cellTempsBackup[(i * ColsCount) + j] = panelCellsBackup[i, j].temprature;

                    if (panelCells[i, j].cellType == "Tr")
                    {
                        cellTypes[(i * ColsCount) + j] = -1;
                    }

                    if (panelCells[i,j].cellType == "B")
                    {
                        cellTypes[(i * ColsCount) + j] = -2;
                    }

                    if (panelCellsBackup[i, j].cellType == "Tr")
                    {
                        cellTypesBackup[(i * ColsCount) + j] = -1;
                    }

                    if (panelCellsBackup[i, j].cellType == "B")
                    {
                        cellTypesBackup[(i * ColsCount) + j] = -2;
                    }
                }
            }

            CalculateAveragesCPP(cellTemps, cellTempsBackup, cellTypes, cellTypesBackup, ColsCount, RowsCount, numberOfThreads, rowIntersect, colIntersect);

            for (int i = 0; i < RowsCount; i++)
            {
                for (int j = 0; j < ColsCount; j++)
                {
                    if (panelCells[i,j].cellType == "Tr")
                    {
                        double temp = cellTempsBackup[(i * ColsCount) + j];
                        panelCells[i, j].computeColor(temp);
                    }
                }
            }
        }

        static public void CalculateAverages()
        {
            int[] rowIntersect = { -1, -1, -1, 0, 0, 1, 1, 1 };
            int[] colIntersect = { -1, 0, 1, -1, 1, -1, 0, 1 };
            int RowsCount = MainOpenGLControl.Height / Cell.length, ColsCount = MainOpenGLControl.Width / Cell.length;

            panelCellsBackup = new Cell[RowsCount, ColsCount];

            // We want to change in the main array beacuse it's used in the invalidating function
            // Just ot avoid shallow copies, copy cell by cell.
            for (int l = 0; l < RowsCount; l++)
                for (int m = 0; m < ColsCount; m++)
                    panelCellsBackup[l, m] = panelCells[l, m];

            while (true)
            {
                switch (mainCalculationMode)
                {
                    case CalculationMode.Sequential:
                        calculateAveragesSequential(rowIntersect, colIntersect, RowsCount, ColsCount);
                        break;

                    case CalculationMode.Parallel:
                        if (Visualizer.mainParallizationMode == ParallelizationMode.CSharp)
                            calculateAveragesParallelCSharp(rowIntersect, colIntersect, RowsCount, ColsCount);
                        
                        else if (Visualizer.mainParallizationMode == ParallelizationMode.CPP)
                        {
                            calculateAveragesParallelCppPre(rowIntersect, colIntersect, RowsCount, ColsCount);
                        }
                        break;
                }

                MainOpenGLControl.Invalidate();

                // Replacing the old values with the new ones ..
                for (int l = 0; l < RowsCount; l++)
                    for (int m = 0; m < ColsCount; m++)
                        panelCells[l, m] = panelCellsBackup[l, m];
            }
        }
    }
}
