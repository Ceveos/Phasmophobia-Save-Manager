using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phasmophobia_Save_Manager
{
    public static class Constants
    {
        public const string SaveDirectory = @"%USERPROFILE%\AppData\LocalLow\Kinetic Games\Phasmophobia";
        public const string SaveFileName = @"saveData.txt";
        public const string BackupFileName = @"Phasmophobia-Backup.dat";
        public const string TempFileName = @"Temp.dat";
        public const string SaveFilePassword = "CHANGE ME TO YOUR OWN RANDOM STRING";
    }
}
