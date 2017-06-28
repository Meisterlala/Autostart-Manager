using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Autostart_Manager
{
    internal static class Helper
    {
        public static List<StartItem> StartItemList = new List<StartItem>();

        static public void SaveStartItemList(List<StartItem> tuples)
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

        static public List<StartItem> LoadStartItemList()
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
    }
}