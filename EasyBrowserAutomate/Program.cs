using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace EasyBrowserAutomation
{
    static class Program
    {
        public static Form1 fmain;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            fmain = new Form1();
            Application.Run(fmain);
        }
    }
}
