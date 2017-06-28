using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Autostart_Manager
{
    [Serializable]
    public class StartItem
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string Commandline { get; set; }
        public string WorkingDirectory { get; set; }
        public Status CurrentStatus { get; set; }
        public Image DisplayedImage { get; set; }
        public Guid GUID { get; }
        public bool KeepAlive { get; set; }

        public StartItem()
        {
            GUID = Guid.NewGuid();
            WorkingDirectory = "";
            Commandline = "";
            CurrentStatus = Status.stopped;
            DisplayedImage = Properties.Resources.DefaultImage;

            Helper.StartItemList.Add(this);
        }
    }
}