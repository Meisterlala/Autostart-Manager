using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

namespace Autostart_Manager
{
    internal class Options
    {
        [Option('s', "silent", DefaultValue = false, HelpText = "Don't display the interface")]
        public bool silent { get; set; }
    }
}