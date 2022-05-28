using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PluginBaseLib;

namespace PluginLib
{
    public class ZipPlugin:IPlugin
    {
        public string Name
        {
            get { return "ZipPlugin"; }
        }

        public void CompressFile(string sourceFile, string targetFile)
        {
            string fullTargetPath = targetFile + ".zip";
            ZipFile.CreateFromDirectory(sourceFile, fullTargetPath);
        }
    }
}
