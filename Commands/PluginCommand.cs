using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PluginLib;
using PluginBaseLib;

namespace WpfApp1.Commands
{
    public class PluginCommand:ICommand
    {
        IPlugin plugin;

        public PluginCommand(IPlugin plugin) => this.plugin = plugin;

        public void Execute()
        {
            plugin.CompressFile("Data","Result");
        }
    }
}
