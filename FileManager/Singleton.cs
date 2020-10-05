using Phasmophobia_Save_Manager.Configuration;
using Phasmophobia_Save_Manager.FileManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phasmophobia_Save_Manager
{
    public sealed class Singleton
    {
        public Config config;
        public SaveFileManager saveFileManager;

        private static readonly Lazy<Singleton>
            lazy =
            new Lazy<Singleton>
                (() => new Singleton());

        public static Singleton Instance { get { return lazy.Value; } }

        private Singleton()
        {
        }
    }
}


