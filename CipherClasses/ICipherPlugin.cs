using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.CipherClasses
{
    public interface ICipherPlugin
    {
        public string Name { get; }

        ICryptoTransform GetEncryptTransform();
        ICryptoTransform GetDecryptTransform();
    }
}
