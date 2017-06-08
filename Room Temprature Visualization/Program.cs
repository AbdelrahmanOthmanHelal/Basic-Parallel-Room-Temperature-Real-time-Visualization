using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Room_Temprature_Visualization
{
    static class Program
    {
        public static Main MainForm = new Main();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();   
            //Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }
}
