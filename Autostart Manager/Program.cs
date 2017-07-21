using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using System.Globalization;

namespace Autostart_Manager
{
    internal class Program
    {
        #region Fields

        public static Options options = new Options();
        private const int SecondsToSleep = 2;
        private static Thread loopThread;
        private static Main MainUI;
        private static Thread MainUITthread = new Thread(StartMainUI);

        #endregion Fields

        #region Methods

        public static bool ProcessIsRunning(StartItem si)
        {
            var processes = GetProcessFromStartItem(si);
            return (processes.Length != 0) ? true : false;
        }

        public static void RunProcess(StartItem SI)
        {
            var newPro = new Process();
            var si = newPro.StartInfo;
            si.Arguments = SI.Commandline;
            si.FileName = SI.Path;
            try
            {
                newPro.Start();
            }
            catch (Exception)
            {
            }
        }

        internal static void StopProcess(StartItem si)
        {
            var processes = GetProcessFromStartItem(si);
            foreach (Process pc in processes)
            {
                pc.Kill();
            }
        }

        private static Process[] GetProcessFromStartItem(StartItem si)
        {
            Process[] pname = new Process[0];
            int indexSlash = si.Path.LastIndexOf("\\", StringComparison.Ordinal);
            indexSlash = (indexSlash == -1) ? 0 : indexSlash;
            int indexDot = si.Path.LastIndexOf(".");
            indexDot = (indexDot == -1) ? 0 : indexDot;
            string exeName;
            try
            {
                exeName = si.Path.Substring(indexSlash + 1, indexDot - indexSlash - 1);
                //    exeName = si.Path.Substring(indexSlash + 1);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Debug.WriteLine(si.Path + Autostart_Manager.Properties.Resources.Program_GetProcessFromStartItem_Slash + indexSlash + " Dot:" + indexDot);
                return pname;
            }

            pname = Process.GetProcessesByName(exeName);
            return pname;
        }

        [STAThread]
        private static void Main(string[] args)
        {
            CommandLine.Parser.Default.ParseArguments(args, options);

            Helper.StartItemList = Helper.LoadStartItemList();

            MainUITthread.Name = "Main UI";
            MainUITthread.SetApartmentState(ApartmentState.STA);
            MainUITthread.Start();

            StartProcesses();

            ThreadInitilize();
            ThreadStart();
        }

        private static void StartMainUI()
        {
            MainUI = new Main();
            Application.EnableVisualStyles();
            if (Program.options.Minimzed)
            {
                MainUI.WindowState = FormWindowState.Minimized;
                MainUI.Hide();
            }
            else
            {
                MainUI.WindowState = FormWindowState.Normal;
                MainUI.Show();
            }
            Application.Run();
        }

        private static void StartProcesses()
        {
            foreach (StartItem si in Helper.StartItemList)
            {
                if (!ProcessIsRunning(si))
                {
                    RunProcess(si);
                }
            }
        }

        private static void ThreadInitilize()
        {
            loopThread = new Thread(ThreadWorking);
            loopThread.SetApartmentState(ApartmentState.STA);
        }

        private static void ThreadStart()
        {
            Thread.Sleep(TimeSpan.FromSeconds(5));
            loopThread.Start();
        }

        private static void ThreadWorking()
        {
            while (true)
            {
                var StartList = Helper.StartItemList;
                foreach (StartItem item in StartList)
                {
                    //Check the status, if the process is running
                    item.CurrentStatus = (ProcessIsRunning(item)) ? Status.running : Status.stopped;

                    //Start the process if it should be kept alive
                    if (item.KeepAlive == true && item.CurrentStatus == Status.stopped)
                        RunProcess(item);
                }

                // Update the ListView
                MainUI.UpdateListViewFull();

                //Sleep
                Thread.Sleep(SecondsToSleep * 1000);
            }
        }

        #endregion Methods
    }
}