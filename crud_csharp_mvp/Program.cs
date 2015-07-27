using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace crud_csharp_mvp {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// -abrenicamarkjoshua@gmail.com
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(loginForm.getInstance());
        }
    }
}
