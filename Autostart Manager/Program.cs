using System;
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
            Helper.StartItemList = Helper.LoadStartItemList();

            if (!options.silent)
            {
                Application.EnableVisualStyles();
                Application.Run(new Main());
            }
        }
    }
}