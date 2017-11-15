using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dubletter
{
    class FixFiles
    {
        //frmMain _objMain = null;
        List<Duplicates> _duplicates = null;
        
        private string _outDirectory = null;
        private int fixCounter = 0;

        
        public FixFiles(string outDirectory , List<Duplicates> duplicates)
        {
          //  _objMain = oMain;
            _outDirectory = outDirectory;
            _duplicates = duplicates;
        }

        public void DoFix()
        {
            if (!Directory.Exists(_outDirectory))
            {
                Directory.CreateDirectory(_outDirectory);
            }

            foreach (Duplicates duplicate in _duplicates)
            {
                if (File.Exists(Path.Combine(_outDirectory, duplicate.fileName)))
                {
                    string newFilename = string.Format("{0}_{1}", fixCounter++.ToString(), duplicate.fileName);
                    File.Move(duplicate.filePath, Path.Combine(_outDirectory, newFilename));
                }
                else
                {
                    File.Move(duplicate.filePath, Path.Combine(_outDirectory, duplicate.fileName));
                }
            }
        }
    }
}
