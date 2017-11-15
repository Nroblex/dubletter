using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Dubletter
{
    public class Duplicates
    {
        FileInfo finfo;
        public string fileName { get; set; }
        public string filePath { get; set; }
        public long fileSize { get; set; }
        public DateTime fileCreateDate { get; set; }

    }

}
