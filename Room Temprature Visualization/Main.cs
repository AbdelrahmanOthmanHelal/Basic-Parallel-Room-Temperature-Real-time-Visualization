using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Collections;
using System.Threading;
using Tao.OpenGl;
using System.Threading.Tasks;

namespace Room_Temprature_Visualization
{
    public partial class Main : Form
    {
        // Initalizing the color key panel ..
        public void InitializeColorMapperPanel(colorMappingMode mode)
        {
            Graphics colorKeyPanelDrawer = ColorKeyPanel.CreateGraphics();
            switch (mode)
            {
                case colorMappingMode.Discrete:
                    colorKeyPanelDrawer.FillRectangle(Brushes.Blue, new Rectangle(0, 0, 50, 50));
                    colorKeyPanelDrawer.FillRectangle(Brushes.Cyan, new Rectangle(50, 0, 50, 50));
                    colorKeyPanelDrawer.FillRectangle(Brushes.LimeGreen, new Rectangle(100, 0, 50, 50));
                    colorKeyPanelDrawer.FillRectangle(Brushes.Yellow, new Rectangle(150, 0, 50, 50));
                    colorKeyPanelDrawer.FillRectangle(Brushes.Red, new Rectangle(200, 0, 50, 50));
                    break;

                case colorMappingMode.Continuous:
                    Brush[] MainBrushes = new Brush[5];
                    MainBrushes[0] = new LinearGradientBrush(new Rectangle(0, 0, 60, 500), Color.Blue, Color.Cyan, LinearGradientMode.Horizontal);
                    MainBrushes[1] = new LinearGradientBrush(new Rectangle(59, 0, 60, 500), Color.Cyan, Color.LimeGreen, LinearGradientMode.Horizontal);
                    MainBrushes[2] = new LinearGradientBrush(new Rectangle(119, 0, 60, 500), Color.LimeGreen, Color.Yellow, LinearGradientMode.Horizontal);
                    MainBrushes[3] = new LinearGradientBrush(new Rectangle(179, 0, 60, 500), Color.Yellow, Color.Red, LinearGradientMode.Horizontal);

                    colorKeyPanelDrawer.FillRectangle(MainBrushes[0], 0.0f, 0.0f, 60.0f, 500.0f);
                    colorKeyPanelDrawer.FillRectangle(MainBrushes[1], 60.0f, 0.0f, 60.0f, 500.0f);
                    colorKeyPanelDrawer.FillRectangle(MainBrushes[2], 120.0f, 0.0f, 60.0f, 500.0f);
                    colorKeyPanelDrawer.FillRectangle(MainBrushes[3], 180.0f, 0.0f, 60.0f, 500.0f);
                    break;
            }
        }

        private void initOpenGLControlComponent()
        {
            // This will dynamically add the openGLControl to the form ..
            this.groupBox1.Controls.Add(Visualizer.MainOpenGLControl);
            Visualizer.MainOpenGLControl.AutoCheckErrors = false;
            Visualizer.MainOpenGLControl.AutoFinish = false;
            Visualizer.MainOpenGLControl.AutoMakeCurrent = true;
            Visualizer.MainOpenGLControl.AutoSwapBuffers = true;
            Visualizer.MainOpenGLControl.BackColor = System.Drawing.Color.Black;
            Visualizer.MainOpenGLControl.ForeColor = System.Drawing.Color.Black;
            Visualizer.MainOpenGLControl.ColorBits = ((byte)(32));
            Visualizer.MainOpenGLControl.DepthBits = ((byte)(16));
            Visualizer.MainOpenGLControl.Location = new System.Drawing.Point(14, 21);
            Visualizer.MainOpenGLControl.Name = "MainOpenGLControl";
            Visualizer.MainOpenGLControl.Size = new System.Drawing.Size(600, 400);
            Visualizer.MainOpenGLControl.StencilBits = ((byte)(0));
            Visualizer.MainOpenGLControl.TabIndex = 0;
            // Adding the event handlers .. 
            Visualizer.MainOpenGLControl.Paint += new System.Windows.Forms.PaintEventHandler(this.MainOpenGLWindow_Paint);
            Visualizer.MainOpenGLControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mainPanel_MouseMove);
            Visualizer.MainOpenGLControl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mainPanel_MouseClickLeft);
            Visualizer.MainOpenGLControl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mainPanel_MouseClickRight);
        }

        public Main()
        {
            Visualizer.MainOpenGLControl = new Tao.Platform.Windows.SimpleOpenGlControl();
            InitializeComponent();
            initOpenGLControlComponent();
            // Initlizing the OpenGL Control ..
            Helpers.InitGraphics();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Cell.sMin = Convert.ToDouble(MinColorMap.Text);
            Cell.sMax = Convert.ToDouble(MaxColorMap.Text);

            // Add the static requirement sources to the hashtable
            Visualizer.cellTypes = new Hashtable();
            Visualizer.cellTypes.Add("Tr", (Cell.sMax + Cell.sMin) / 2); // Normal Cell
            Visualizer.cellTypes.Add("Th", Cell.sMax); // Hot source 
            Visualizer.cellTypes.Add("Tc", Cell.sMin); // Cold Source
            Visualizer.cellTypes.Add("Tw", (Cell.sMax + Cell.sMin) / 2); // Window
            Visualizer.cellTypes.Add("B", null); // Block .. It has no temprature 

            cellTypesLabels.Text = "Tr -> Normal Cell\n";
            cellTypesLabels.Text += "Th -> Hot Source\n";
            cellTypesLabels.Text += "Tc -> Cold Source\n";
            cellTypesLabels.Text += "Tw -> Window\n";
            cellTypesLabels.Text += "B -> Block\n";

            foreach (string sourceTypeName in Visualizer.cellTypes.Keys)
            {
                cellTypesCombo.Items.Add(sourceTypeName);
            }

            Cell.length = Convert.ToInt32(CellSizeUpDown.Value);
            Visualizer.InitializePanel(Cell.sMax, Cell.sMin);
            cellTypesCombo.SelectedIndex = 1;
        }


        private void DiscreteColorCheck_CheckedChanged(object sender, EventArgs e)
        {
            Cell.cellColoringMode = colorMappingMode.Discrete;
            InitializeColorMapperPanel(Cell.cellColoringMode);
        }

        private void ContinuousColorCheck_CheckedChanged(object sender, EventArgs e)
        {
            Cell.cellColoringMode = colorMappingMode.Continuous;
            InitializeColorMapperPanel(Cell.cellColoringMode);
        }

        private void mainPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (e.X >= 0 && e.Y >= 0 && e.X < (Visualizer.MainOpenGLControl.Width / Cell.length) * Cell.length && e.Y < (Visualizer.MainOpenGLControl.Height / Cell.length) * Cell.length)
                {
                    int xPos = e.X / Cell.length, yPos = e.Y / Cell.length;
                    Visualizer.panelCells[yPos, xPos].cellType = cellTypesCombo.Items[cellTypesCombo.SelectedIndex].ToString();
                    Visualizer.panelCells[yPos, xPos].computeColor();
                    Visualizer.MainOpenGLControl.Invalidate(new Rectangle(Visualizer.panelCells[yPos, xPos].xCoord, Visualizer.panelCells[yPos, xPos].yCoord, Cell.length, Cell.length));
                }
            }
        }

        private void mainPanel_MouseClickLeft(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (e.X >= 0 && e.Y >= 0 && e.X < (Visualizer.MainOpenGLControl.Width / Cell.length) * Cell.length && e.Y < (Visualizer.MainOpenGLControl.Height / Cell.length) * Cell.length)
                {
                    int xPos = e.X / Cell.length, yPos = e.Y / Cell.length;
                    Visualizer.panelCells[yPos, xPos].cellType = cellTypesCombo.Items[cellTypesCombo.SelectedIndex].ToString();
                    Visualizer.panelCells[yPos, xPos].computeColor();
                    Visualizer.MainOpenGLControl.Invalidate(new Rectangle(Visualizer.panelCells[yPos, xPos].xCoord, Visualizer.panelCells[yPos, xPos].yCoord, Cell.length, Cell.length));
                }
            }
        }

        private void mainPanel_MouseClickRight(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.X >= 0 && e.Y >= 0 && e.X < (Visualizer.MainOpenGLControl.Width / Cell.length) * Cell.length && e.Y < (Visualizer.MainOpenGLControl.Height / Cell.length) * Cell.length)
                {
                    int xPos = e.X / Cell.length, yPos = e.Y / Cell.length;
                    ToolTip valueToolTip = new ToolTip();
                    IWin32Window win = this;
                    valueToolTip.Show(Visualizer.panelCells[yPos, xPos].temprature.ToString(), win, e.X + 10, e.Y + 35, 1000);
                }
            }
        }

        private void CellSizeUpdate_Click(object sender, EventArgs e)
        {
            StartVisualizationButton.Enabled = true;
            StopVisualizationButton.Enabled = false;
            // If i was updating the size in the runtime -> abort the thread 
            if (Visualizer.MasterCalculationThread != null)
            {
                if (Visualizer.MasterCalculationThread.ThreadState == ThreadState.Suspended)
                    Visualizer.MasterCalculationThread.Resume();
                Visualizer.MasterCalculationThread.Abort();
            }

            Graphics manipulator = Visualizer.MainOpenGLControl.CreateGraphics();
            manipulator.Clear(Color.White);
            Cell.length = Convert.ToInt32(CellSizeUpDown.Value);

            Visualizer.InitializePanel(Cell.sMax, Cell.sMin);
            Visualizer.MainOpenGLControl.Invalidate();
        }

        private void AddCell_Click(object sender, EventArgs e)
        {
            Visualizer.cellTypes.Add(cellName.Text, Convert.ToDouble(cellValue.Text));
            cellTypesLabels.Text += cellName.Text + " -> " + cellLabel.Text + "\n";
            cellTypesCombo.Items.Add(cellName.Text);
        }

        private void ColorKeyPanel_Paint_1(object sender, PaintEventArgs e)
        {
            InitializeColorMapperPanel(Cell.cellColoringMode);
        }

        private void UpdateColorMappingLimits_Click(object sender, EventArgs e)
        {
            double oldMinValue = Cell.sMin, oldMaxValue = Cell.sMax; 

            Cell.sMin = Convert.ToDouble(MinColorMap.Text);
            Cell.sMax = Convert.ToDouble(MaxColorMap.Text);

            // Update the values of the hashtable cells
            Visualizer.cellTypes["Tr"] = (Cell.sMax + Cell.sMin) / 2; // Normal Cell
            Visualizer.cellTypes["Th"] = Cell.sMax; // Hot source 
            Visualizer.cellTypes["Tc"] = Cell.sMin; // Cold Source
            Visualizer.cellTypes["Tw"] = (Cell.sMax + Cell.sMin) / 2; // Window
            
            int RowsCount = Visualizer.MainOpenGLControl.Height / Cell.length, ColsCount = Visualizer.MainOpenGLControl.Width / Cell.length;

            if (Visualizer.MasterCalculationThread != null)
                Visualizer.MasterCalculationThread.Suspend();
            for (int i = 0; i < RowsCount; i++)
            {
                for (int j = 0; j < ColsCount; j++)
                {
                    if (Visualizer.panelCells[i, j].cellType == "Tr")
                    {
                        double ratio = (Visualizer.panelCells[i, j].temprature - oldMinValue) / (oldMaxValue - oldMinValue);
                        Visualizer.panelCells[i, j].computeColor((ratio * (Cell.sMax - Cell.sMin)) + Cell.sMin);
                    }

                    else
                    {
                        foreach (string cellType in Visualizer.cellTypes.Keys)
                        {
                            if (Visualizer.panelCells[i, j].cellType == cellType)
                            {
                                if (cellType != "B")
                                    Visualizer.panelCells[i, j].computeColor(Convert.ToDouble(Visualizer.cellTypes[cellType]));
                            }
                        }
                    }
                }   
            }

            if (Visualizer.MasterCalculationThread != null)
                Visualizer.MasterCalculationThread.Resume();

            //// If i was updating the size in the runtime -> abort the thread 
            //if (Visualizer.MasterCalculationThread != null)
            //{
            //    if (Visualizer.MasterCalculationThread.ThreadState == ThreadState.Suspended)
            //        Visualizer.MasterCalculationThread.Resume();

            //    Visualizer.MasterCalculationThread.Abort();
            //}

            //StopVisualizationButton.Enabled = false;
            //StartVisualizationButton.Enabled = true;

            //Graphics manipulator = Visualizer.MainOpenGLControl.CreateGraphics();
            //manipulator.Clear(Color.White);
            //Visualizer.InitializePanel(Cell.sMax, Cell.sMin);
            Visualizer.MainOpenGLControl.Invalidate();
        }

        private void StartVisualization_Click(object sender, EventArgs e)
        {
            if (Visualizer.MasterCalculationThread == null || Visualizer.MasterCalculationThread.ThreadState == ThreadState.Aborted)
            {
                int RowsCount = Visualizer.MainOpenGLControl.Height / Cell.length, ColsCount = Visualizer.MainOpenGLControl.Width / Cell.length;

                if (SequentialRadio.Checked)
                    Visualizer.mainCalculationMode = CalculationMode.Sequential;

                Visualizer.tickTime = Convert.ToInt32(numberOfTicks.Text);
                Visualizer.numberOfThreads = Convert.ToInt32(numberOfThreads.Text);
                Visualizer.MasterCalculationThreadStart = new ThreadStart(Visualizer.CalculateAverages);
                Visualizer.MasterCalculationThread = new Thread(Visualizer.MasterCalculationThreadStart);
                Visualizer.MasterCalculationThread.Start();
                StartVisualizationButton.Text = "Resume";
                StartVisualizationButton.Enabled = false;
            }

            else
            {
                Visualizer.MasterCalculationThread.Resume();
            }
            StartVisualizationButton.Enabled = false;
            StopVisualizationButton.Enabled = true;
            Visualizer.tickTime = Convert.ToInt32(numberOfTicks.Text);
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Closing the thread on closing.
            if (Visualizer.MasterCalculationThread != null)
            {
                if (Visualizer.MasterCalculationThread.ThreadState == ThreadState.Suspended)
                    Visualizer.MasterCalculationThread.Resume();

                Visualizer.MasterCalculationThread.Abort();
            }
        }

        private void MainOpenGLWindow_Paint(object sender, PaintEventArgs e)
        {
            //Forming the 2D array of cells to be ready for computations .. 
            int RowsCount = Visualizer.MainOpenGLControl.Height / Cell.length, ColsCount = Visualizer.MainOpenGLControl.Width / Cell.length;

            for (int i = 0; i < RowsCount; i++)
            {
                for (int j = 0; j < ColsCount; j++)
                {
                    double[][] coords = new double[4][];

                    coords[0] = new double[] { Visualizer.panelCells[i, j].xCoord, Visualizer.panelCells[i, j].yCoord };
                    coords[1] = new double[] { Visualizer.panelCells[i, j].xCoord + Cell.length, Visualizer.panelCells[i, j].yCoord };
                    coords[2] = new double[] { Visualizer.panelCells[i, j].xCoord + Cell.length, Visualizer.panelCells[i, j].yCoord + Cell.length };
                    coords[3] = new double[] { Visualizer.panelCells[i, j].xCoord, Visualizer.panelCells[i, j].yCoord + Cell.length };

                    Gl.glBegin(Gl.GL_QUADS);
                    for (int k = 0; k < 4; k++)
                    {
                        if (Visualizer.panelCells[i, j].color != null)
                        {
                            Gl.glColor3d(Visualizer.panelCells[i, j].color[0] / 255.0f, Visualizer.panelCells[i, j].color[1] / 255.0f, Visualizer.panelCells[i, j].color[2] / 255.0f);
                            Gl.glVertex2dv(coords[k]);
                        }
                    }
                    Gl.glEnd();

                    if (Visualizer.panelCells[i, j].cellType == "Tw")
                    {
                        // Drawing the window border .. 
                        Gl.glBegin(Gl.GL_LINE_STRIP);
                        Gl.glColor3d((double)109/255, (double)74/255, (double)45/255);

                        // Top right X, Y
                        Gl.glVertex2d(Visualizer.panelCells[i, j].xCoord + Cell.length, Visualizer.panelCells[i, j].yCoord);
                        // Top Left 
                        Gl.glVertex2d(Visualizer.panelCells[i, j].xCoord, Visualizer.panelCells[i, j].yCoord);
                        // Bottom Left 
                        Gl.glVertex2d(Visualizer.panelCells[i, j].xCoord, Visualizer.panelCells[i, j].yCoord + Cell.length);
                        // Bottom Right X, Y
                        Gl.glVertex2d(Visualizer.panelCells[i, j].xCoord + Cell.length, Visualizer.panelCells[i, j].yCoord + Cell.length);
                        // Top right X, Y
                        Gl.glVertex2d(Visualizer.panelCells[i, j].xCoord + Cell.length, Visualizer.panelCells[i, j].yCoord);
                        Gl.glEnd();
                    }
                }
            }
        }

        private void stopVisualization_Click(object sender, EventArgs e)
        {
            if (Visualizer.MasterCalculationThread != null)
            {
                Visualizer.MasterCalculationThread.Suspend();
                StartVisualizationButton.Enabled = true;
                StopVisualizationButton.Enabled = false;
            }
        }

        private void CSharpRadio_CheckedChanged(object sender, EventArgs e)
        {
            Visualizer.mainCalculationMode = CalculationMode.Parallel;
            Visualizer.mainParallizationMode = ParallelizationMode.CSharp;
        }

        private void CPlusRadio_CheckedChanged(object sender, EventArgs e)
        {
            Visualizer.mainCalculationMode = CalculationMode.Parallel;
            Visualizer.mainParallizationMode = ParallelizationMode.CPP;
        }

        private void SequentialRadio_CheckedChanged(object sender, EventArgs e)
        {
            Visualizer.mainCalculationMode = CalculationMode.Sequential;
        }
    }
}