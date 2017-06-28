using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace Autostart_Manager
{
    internal class Program
    {
        public static Options options = new Options();

        [STAThread]
        private static void Main(string[] args)
        {
            CommandLine.Parser.Default.ParseArguments(args, options);

            if (!options.silent)
            {
                Application.EnableVisualStyles();
                Application.Run(new Main());
            }
        }

        private void SaveStartItemList(List<StartItem> tuples)
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

        private List<StartItem> LoadStartItemList()
        {
            using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(Properties.Settings.Default.ProgramList)))
            {
                BinaryFormatter bf = new BinaryFormatter();
                return (List<StartItem>)bf.Deserialize(ms);
            }
        }
    }
}