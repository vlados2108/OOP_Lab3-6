using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PluginBaseLib;

namespace PluginLib
{
    public class GZipPlugin:IPlugin
    {
        public string Name
        {
            get { return "GZipPlugin"; }
        }

        public void CompressFile(string sourceFile, string targetFile)
        {
            string fullPath = sourceFile + ".json";
            string fullTargetPath = targetFile + ".gz";
            FileStream copyFile = File.Open(fullPath,FileMode.Open);
            FileStream compressedFile = File.Create(fullTargetPath);
            var compressor = new GZipStream(compressedFile, CompressionMode.Compress);
            copyFile.CopyTo(compressor);
            copyFile.Close();
            compressedFile.Close();
        }
    }
}
