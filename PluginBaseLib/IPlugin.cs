using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginBaseLib
{
    public interface IPlugin
    {
        string Name { get; }
        void CompressFile(string sourceFile, string targetFile);
    }
}
