using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Inventor_Help_Examples_in_CSharp_Features_1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
