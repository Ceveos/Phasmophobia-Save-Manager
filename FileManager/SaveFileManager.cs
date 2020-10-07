using Newtonsoft.Json.Linq;
using Phasmophobia_Save_Manager.Configuration;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Phasmophobia_Save_Manager.FileManager
{
    public class SaveFileManager
    {
        private Config config;
        private FileSystemWatcher saveFileSystemWatcher;

        public event EventHandler<string> OnSaveFileEvent;
        public event EventHandler OnJsonUpdated;

        public bool isMonitoring = false;
        public JObject saveFileData;

        public SaveFileManager(Config config)
        {
            this.config = config;
            this.saveFileSystemWatcher = new FileSystemWatcher();
            saveFileSystemWatcher.Path = Environment.ExpandEnvironmentVariables(Constants.SaveDirectory);
            saveFileSystemWatcher.Filter = Constants.SaveFileName;
            saveFileSystemWatcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.CreationTime;
            saveFileSystemWatcher.Changed += onSaveFileChanged;
            saveFileSystemWatcher.Created += onSaveFileChanged;
        }

        private void onSaveFileChanged(object sender, FileSystemEventArgs e)
        {
            PerformSaveFileCheck();
        }

        public void PerformSaveFileCheck()
        {
            GetSaveFileJson();
            if (IsSaveFileCorrupt())
            {
                OnSaveFileEvent(this, "Save file is corrupt!");
                StopMonitoringSaveFile(); 
                MessageBox.Show("Save file corrupt", "Save file is found to be corrupted! Backing up will stop");
            } else
            {
                OnSaveFileEvent(this, "Save file is good, backing up");
                BackupSaveFile();
            }
        }

        public dynamic GetSaveFileJson()
        {
            string data;
            try
            {
                // Create backup (to avoid read/write issues with another process)
                BackupSaveFile(Constants.TempFileName);
                string tempFilePath = Path.Combine(Application.StartupPath, Constants.TempFileName);

                data = File.ReadAllText(tempFilePath);
                StringBuilder text = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    text.Append((char)(data[i] ^ Constants.SaveFilePassword[i % Constants.SaveFilePassword.Length]));
                }

                try
                {
                    saveFileData = JObject.Parse(text.ToString());
                }
                catch (Exception)
                {
                    saveFileData = null;
                }
                return saveFileData;
            } catch (Exception)
            {
                OnSaveFileEvent(this, "Error reading save file");
                return null;
            }
        }

        public bool IsSaveFileCorrupt()
        {
            // Check initial data
            // JSON is set up in the following sections:
            // - StringData
            // - IntData
            // - FloatData
            // - BoolData
            //
            // We will ensure that all types have appropriate values (i.e. no nulls)
            bool isCorrupt = false;

            if (saveFileData == null) { return true;  }
            
            foreach (JProperty section in saveFileData.Properties())
            {
                if (!SaveFileComponents.SectionsToCheck.ContainsKey(section.Name))
                {
                    // We don't know what this section is. Continue
                    continue;
                }

                SectionInfo sectionInfo = SaveFileComponents.SectionsToCheck[section.Name];
                foreach (JObject item in section.Value)
                {
                    string key = (string)item["Key"];
                    JValue value = (JValue)item["Value"];

                    JTokenType valueType = value.Type;
                    if (valueType != sectionInfo.SectionType)
                    {
                        isCorrupt = true;
                        break;
                    }
                }

                if (isCorrupt) break;
            }

            return isCorrupt;
        }

        public void BackupSaveFile(string name = Constants.BackupFileName)
        {
            try
            {
                string saveFilePath = $"{Environment.ExpandEnvironmentVariables(Constants.SaveDirectory)}\\{Constants.SaveFileName}";
                string backupFilePath = Path.Combine(Application.StartupPath, name);
                File.Copy(saveFilePath, backupFilePath, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error copying save file!");
            }
        }

        public void RestoreSaveFile()
        {
            try
            {
                string saveFilePath = Path.Combine(Application.StartupPath, "phasmophobia-backup.dat");
                string backupFilePath = $"{Environment.ExpandEnvironmentVariables(Constants.SaveDirectory)}\\{Constants.SaveFileName}";
                File.Copy(saveFilePath, backupFilePath, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error overwriting Phasmophobia save file!");
            }
        }

        public void MonitorSaveFile()
        {
            saveFileSystemWatcher.EnableRaisingEvents = true;
            isMonitoring = true;
        }

        public void StopMonitoringSaveFile()
        {
            saveFileSystemWatcher.EnableRaisingEvents = false;
            isMonitoring = false;
        }
        public static object GetPropValue(object target, string propName)
        {
            return target.GetType().GetProperty(propName).GetValue(target, null);
        }
    }
}
