using Tao.OpenGl;
using Tao.Platform.Windows;

namespace Room_Temprature_Visualization
{
    // This will be needed to change the color mode in a nice way.    
    public enum colorMappingMode { Discrete, Continuous };

    public enum ParallelizationMode { CPP, CSharp}

    public enum CalculationMode { Sequential, Parallel }

    // This class will contain any helper function 

    static class Helpers
    {
        // A function to Initialize the simpleOpenGL Control ..
        static public void InitGraphics()
        {
            Visualizer.MainOpenGLControl.InitializeContexts();
   
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            // We need to make it like a panel, start from the top left corner .. 
            Glu.gluOrtho2D(0, Visualizer.MainOpenGLControl.Width, Visualizer.MainOpenGLControl.Height, 0);
            // Clearing the color to white .. 
            Gl.glClearColor(1, 1, 1, 1);
            Gl.glClear( Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
        }
    }
}
