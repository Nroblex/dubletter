using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dubletter
{
    public class SearchEngine
    {
        private string _inPath = null;
        DirectoryInfo _dirInfo = null;
        private Dictionary<Duplicates, Fil> duplic = new Dictionary<Duplicates, Fil>();
        private HashSet<KeyValuePair<string, long>> haschFiles = new HashSet<KeyValuePair<string, long>>();

        private List<Duplicates> duplicates = new List<Duplicates>();

        public SearchEngine(string inPath)
        {
            _inPath = inPath;
            _dirInfo = new DirectoryInfo(_inPath);
        }

        //Letar efter dubletter.
        public void Search(bool IsMatchExactSize)
        {
            string search = "RSMPConnectorlog.txt.";
            try
            {
                FileInfo[] actualFiles = _dirInfo.GetFiles("*", SearchOption.AllDirectories);
                //FileInfo myFile = actualFiles.OrderByDescending(f => f.LastAccessTime).Where(p => p.Name == search);
                //IEnumerable<FileInfo> finfos = actualFiles.OrderByDescending(f => f.LastAccessTime).Select(l => l.Nam

                bool isContains = search.Contains("Connector");

                var result = from v in actualFiles.OrderByDescending(f => f.LastAccessTime)
                             where v.Name.Contains(search)
                             select v.Name;

                FileInfo finf = actualFiles.OrderByDescending(f => f.LastAccessTime).Where(p => p.Name.Contains(search)).FirstOrDefault();

                //foreach (FileInfo f in finf)
                //{
                //    string fnamn = f.Name;
                //    DateTime dtAccessed = f.LastWriteTime;
                //}
                //FileInfo myFile = actualFiles.FirstOrDefault(p => p.Name == search);

                var duplicateNames = actualFiles.GroupBy(file => file.Name)
                    .Where(group => group.Count() > 1);

                foreach (var group in duplicateNames)
                {
                    foreach (var fil in group)
                    {
                        //var previousRecord = null;
                        KeyValuePair<string, long> fileDuplicate = new KeyValuePair<string, long>(fil.Name, fil.Length);
                        if (haschFiles.Contains(fileDuplicate))
                        {
                            duplicates.Add(new Duplicates { fileName = fil.Name, filePath = fil.FullName, fileCreateDate = fil.CreationTime, fileSize = fil.Length });
                            //duplicates.Add(new Duplicates { fileName = previousRecord.Name, filePath = fil.FullName, fileCreateDate = fil.CreationTime, fileSize = fil.Length });
                        }
                        else
                        {
                            haschFiles.Add(fileDuplicate);
                        }

                        //previousRecord = fil;
                    }

                }
            } catch(Exception e)
            {
                
            }
            

            
        }



    }
}
