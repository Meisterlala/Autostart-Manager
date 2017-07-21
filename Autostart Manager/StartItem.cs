using System;
using System.Drawing;

namespace Autostart_Manager
{
    [Serializable]
    public class StartItem
    {
        #region Constructors

        public StartItem()
        {
            GUID = Guid.NewGuid();
            Commandline = "";
            Name = "";
            Path = "";
            KeepAlive = false;
            CurrentStatus = Status.stopped;
            DisplayedImage = Properties.Resources.DefaultImage;

            Helper.StartItemList.Add(this);
        }

        #endregion Constructors

        #region Properties

        public string Commandline { get; set; }
        public Status CurrentStatus { get; set; }
        public Image DisplayedImage { get; set; }
        public Guid GUID { get; }
        public bool KeepAlive { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }

        #endregion Properties
    }
}