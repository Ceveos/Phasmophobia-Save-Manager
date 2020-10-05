using Phasmophobia_Save_Manager.Configuration;
using Phasmophobia_Save_Manager.FileManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phasmophobia_Save_Manager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Singleton singleton = Singleton.Instance;
            singleton.config = new Config(Constants.SaveDirectory);
            singleton.saveFileManager = new SaveFileManager(singleton.config);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }
}
