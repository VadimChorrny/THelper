using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace THelper
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
            loading first = new loading();
            DateTime end = DateTime.Now + TimeSpan.FromSeconds(1.2);
            first.Show();
            while(end > DateTime.Now)
            {
                Application.DoEvents();
            }

            first.Close();
            first.Dispose();
            Application.Run(new Form1());
        }
    }
}
