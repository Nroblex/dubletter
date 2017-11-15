using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Dubletter
{
    class Fil : Duplicates
    {
        public string filNamn { get; set; }
        public string md5Sum
        {
            get
            {
                using (var md5 = MD5.Create())
                {
                    using (var stream = File.OpenRead(fileName))
                    {
                        return Encoding.Default.GetString(md5.ComputeHash(stream));
                    }
                }
            }
        }
        public Fil(FileInfo fileInfo) 
        {
            this.fileName = fileInfo.FullName;
        }
    }
}
