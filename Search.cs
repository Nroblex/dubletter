using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dubletter
{
    public class Search
    {
        private string _initDirPath = null;
        private bool _isMatchOnNames = false;
        private DirectoryInfo _initDir = null;

        private List<Duplicates> _fileDuplicates = new List<Duplicates>();
        private List<Fil> _filesList = new List<Fil>();
        private List<KeyValuePair<string, long>> fileInfoList = new List<KeyValuePair<string, long>>();

        private frmMain _objMain = null;

        public Search(string initDir, bool isJustMatchOnNames)
        {
            _initDirPath = initDir;
            _isMatchOnNames = isJustMatchOnNames;
        }

        
        public List<Duplicates> getDuplicates
        {
            get
            {
                return _fileDuplicates;
            }
        }

        public void PerformSearch(frmMain objMain)
        {
            _initDir = new DirectoryInfo(_initDirPath);
            _objMain = objMain;

            DirectoryInfo[] subDirs = _initDir.GetDirectories("*", SearchOption.AllDirectories);

            SearchFolderForDuplicates(_initDir);
            //Loopa igenom alla bibliotek.
            //foreach (DirectoryInfo dirInf in _initDir.GetDirectories("*", SearchOption.AllDirectories))
            foreach(DirectoryInfo dirInf in subDirs )
            {
                //Alla filer i just detta bibliotek.
                _objMain.frmMain_OnSetDirName(dirInf.FullName);
                SearchFolderForDuplicates(dirInf);

            }

            ReportDuplicates();

        }

        private void SearchFolderForDuplicates(DirectoryInfo dirInf)
        {
            try
            {
                FileInfo[] finfo = dirInf.GetFiles();


                foreach (FileInfo f in finfo)
                {
                    //om filnamnet redan finns i listan...
                    if (_filesList.Count != 0)
                    {
                        Fil alreadyExists = null;
                        if (_isMatchOnNames)
                        {
                            alreadyExists = _filesList.FirstOrDefault(p => p.fileName == f.Name);
                        }
                        else
                        {
                            alreadyExists = _filesList.FirstOrDefault(p => (p.fileName == f.Name && p.fileSize == f.Length));
                        }

                        int filePathCount = _fileDuplicates.Count(p => p.filePath == f.FullName);
                        int fileNameCount = _fileDuplicates.Count(p => p.fileName == f.Name);

                        if (alreadyExists != null && filePathCount == 0)
                        {
                            if (fileNameCount == 0)
                            {
                                _fileDuplicates.Add(
                                    new Duplicates
                                    {
                                        fileName = alreadyExists.fileName,
                                        fileCreateDate = alreadyExists.fileCreateDate,
                                        fileSize = alreadyExists.fileSize,
                                        filePath = alreadyExists.filePath
                                    });
                            }
                            _fileDuplicates.Add(
                                new Duplicates
                                {
                                    fileName = f.Name,
                                    fileCreateDate = f.CreationTime,
                                    filePath = f.FullName,
                                    fileSize = f.Length
                                });
                        }

                        _filesList.Add(new Fil { fileName = f.Name, filePath = f.FullName, fileSize = f.Length, fileCreateDate = f.CreationTime });
                        
                    }
                    else
                    {
                        _filesList.Add(new Fil { fileName = f.Name, filePath = f.FullName, fileSize = f.Length, fileCreateDate = f.CreationTime });
                    }

                }

                if (_fileDuplicates.Count > 0)
                {
                    _fileDuplicates = _fileDuplicates.OrderBy(p => p.fileName).ToList();
                }

            }
            catch (Exception ep)
            {

            }
        }

        private void ReportDuplicates()
        {
            if (_fileDuplicates.Count > 0)
            {
                foreach (Duplicates dup in _fileDuplicates)
                {
                    _objMain.frmMain_OnSetFileName(dup.filePath, dup.fileSize.ToString());
                }

                _objMain.frmMain_OnSetDuplicateCount(_fileDuplicates.Count, _filesList.Count);
            }
            else
            {
                _objMain.frmMain_OnSetDuplicateCount(0, _filesList.Count);
            }
        }


    }
}
