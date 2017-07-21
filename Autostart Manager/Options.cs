using CommandLine;

namespace Autostart_Manager
{
    internal class Options
    {
        #region Properties

        [Option('m', "minimzed", DefaultValue = false, HelpText = "Start Minimized")]
        public bool Minimzed { get; set; }

        #endregion Properties
    }
}