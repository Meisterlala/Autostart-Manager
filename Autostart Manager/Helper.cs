using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Autostart_Manager
{
    internal static class Helper
    {
        #region Fields

        public static List<StartItem> StartItemList = new List<StartItem>();

        #endregion Fields

        #region Methods

        public static Image GetImageFromPath(string path)
        {
            Image result;

            try
            {
                var icon = Icon.ExtractAssociatedIcon(path);
                result = icon.ToBitmap();
            }
            catch (Exception)
            {
                result = Properties.Resources.DefaultImage;
            }

            return result;
        }

        public static List<StartItem> LoadStartItemList()
        {
            if (Properties.Settings.Default.ProgramList == null || Properties.Settings.Default.ProgramList == "")
            {
                return new List<StartItem>();
            }

            using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(Properties.Settings.Default.ProgramList)))
            {
                BinaryFormatter bf = new BinaryFormatter();
                return (List<StartItem>)bf.Deserialize(ms);
            }
        }

        public static void SaveStartItemList(List<StartItem> tuples)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(ms, tuples);
                ms.Position = 0;
                byte[] buffer = new byte[(int)ms.Length];
                ms.Read(buffer, 0, buffer.Length);
                Properties.Settings.Default.ProgramList = Convert.ToBase64String(buffer);
                Properties.Settings.Default.Save();
            }
        }

        public static StartItem StartItemFromGUID(StartItem passed)
        {
            foreach (StartItem si in StartItemList)
            {
                if (si.GUID == passed.GUID)
                {
                    return si;
                }
            }

            throw new Exception(Autostart_Manager.Properties.Resources.Helper_StartItemFromGUID_CouldNotFindStartItemFromGUID);
        }

        public static void UpdateStartItemListStatus(List<StartItem> SIList)
        {
            foreach (StartItem newSI in SIList)
            {
                foreach (StartItem oldSI in StartItemList)
                {
                    if (newSI.GUID == oldSI.GUID)
                    {
                        oldSI.CurrentStatus = newSI.CurrentStatus;
                    }
                }
            }
        }

        #endregion Methods
    }
}