using Phasmophobia_Save_Manager.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phasmophobia_Save_Manager.FileManager
{
    public class SaveFileManager
    {
        private Config config;
        private FileSystemWatcher saveFileSystemWatcher;

        public event EventHandler<string> OnSaveFileEvent;


        public SaveFileManager(Config config)
        {
            this.config = config;
            this.saveFileSystemWatcher = new FileSystemWatcher();
            saveFileSystemWatcher.Path = Environment.ExpandEnvironmentVariables(Constants.SaveDirectory);
            saveFileSystemWatcher.Filter = "saveData.txt";
            saveFileSystemWatcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.CreationTime;
            saveFileSystemWatcher.Changed += onSaveFileChanged;
            saveFileSystemWatcher.Created += onSaveFileChanged;
        }

        private void onSaveFileChanged(object sender, FileSystemEventArgs e)
        {
            BackupSaveFile();
        }

        public void BackupSaveFile()
        {
            try
            {
                DateTime now = DateTime.Now;
                string saveFilePath = $"{Environment.ExpandEnvironmentVariables(Constants.SaveDirectory)}\\{Constants.SaveFileName}";
                string backupFilePath = $"{Environment.ExpandEnvironmentVariables(config.BackupLocation)}\\Phasmophobia Save Backup ({now.ToString("yyyy-dd-M HH-mm-ss")}).txt";
                File.Copy(saveFilePath, backupFilePath, true);
                OnSaveFileEvent(this, $"Saved file at {now.ToString("yyyy-dd-M HH-mm-ss")}");
            } catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error copying save file!");
            }
        }

        public void RestoreSaveFile(string fileName)
        {
            // 
        }

        public void MonitorSaveFile()
        {
            saveFileSystemWatcher.EnableRaisingEvents = true;
        }

        public void StopMonitoringSaveFile()
        {
            saveFileSystemWatcher.EnableRaisingEvents = false;
        }
    }
}
