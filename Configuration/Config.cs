using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phasmophobia_Save_Manager.Configuration
{
    public struct Config
    {
        public string BackupLocation;

        public Config(string backupLocation)
        {
            this.BackupLocation = backupLocation;
        }
    }
}
