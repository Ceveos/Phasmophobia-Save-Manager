using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phasmophobia_Save_Manager
{
    public partial class Main : Form
    {
        private Singleton singleton;
        public Main()
        {
            InitializeComponent();
            singleton = Singleton.Instance;
            singleton.saveFileManager.OnSaveFileEvent += SaveFileManager_OnSaveFileEvent;
        }

        private void SaveFileManager_OnSaveFileEvent(object sender, string newStatus)
        {
            UpdateStatus(newStatus);
            btStart.Enabled = !singleton.saveFileManager.isMonitoring;
            btStop.Enabled = singleton.saveFileManager.isMonitoring;
        }

        private void btOpenSaveDirectory_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", Environment.ExpandEnvironmentVariables(Constants.SaveDirectory));
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            
            btStart.Enabled = false;
            singleton.saveFileManager.PerformSaveFileCheck(); // Immediately backup save file
            singleton.saveFileManager.MonitorSaveFile(); // Monitor for changes
            btStop.Enabled = true;
        }

        private void btStop_Click(object sender, EventArgs e)
        {
            btStop.Enabled = false;
            singleton.saveFileManager.StopMonitoringSaveFile();
            btStart.Enabled = true;
        }

        private void Main_Load(object sender, EventArgs e)
        {
        }

        private void UpdateStatus(string status)
        {
            if (lbStatus.InvokeRequired)
            {
                lbStatus.BeginInvoke((MethodInvoker)delegate () { lbStatus.Text = status; });
            }
            else
            {
                lbStatus.Text = status;
            }
        }
    }
}
