using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
namespace Dubletter
{
    public partial class frmMain : Form
    {
        private FolderBrowserDialog _browseFolder = null;
        private string pathToStartDir = null;

        private Thread _workerThread = null;


        private bool isMatchOnName = false;

        public delegate void dlgSetFileName(string FileName, string fileSizeAsString);

        private delegate void dlgSetDuplicateCountText(int duplicates, int totalFilesSearched);
        private delegate void dlgSetDirNameSearched(string dirName);


        private Search _searcherObject = null;

        delegate void dlgSetLabelText(Label l, string t);

        private BackgroundWorker _bgWorker;

        public event dlgSetFileName OnSetFileName;
        private event dlgSetDuplicateCountText OnSetDuplicateCount;
        private event dlgSetDirNameSearched OnSetDirName;


        public frmMain()
        {

            InitializeComponent();
            optFileName.Checked = true;
            OnSetFileName += frmMain_OnSetFileName;
            //OnSetDuplicateCount += frmMain_OnSetDuplicateCount;
            OnSetDirName += frmMain_OnSetDirName;

            

        }

        private void setLabelText(Label lb, string text)
        {
            if (lb.InvokeRequired)
            {
                dlgSetLabelText d = new dlgSetLabelText(setLabelText);
                lb.Invoke(d, new object[] { lb, text });
            }
            else
            {
                lb.Text = text;
            }
        }
        private void setDirLabelSearchText(string dirName)
        {
            if (lblDirSearch.InvokeRequired)
            {
                dlgSetDirNameSearched d = new dlgSetDirNameSearched(setDirLabelSearchText);
                lblDirSearch.Invoke(d, new object[] { dirName });
            }
            else
                lblDirSearch.Text = dirName;
        }

        private void setDuplicateCountText(int duplicates, int totalCount)
        {
            if (lblFileSearch.InvokeRequired)
            {
                dlgSetDuplicateCountText d = new dlgSetDuplicateCountText(setDuplicateCountText);
                lblFileSearch.Invoke(d, new object[] { duplicates, totalCount });
            }
            else
            {
                lblFileSearch.Text = String.Format("Sökte genom {0}, filer och fann {1} dubletter", totalCount.ToString(), duplicates.ToString());
                btnMove.Enabled = true;
            }
        }

        private void addItemToListView(string fileName, string fileSizeAsString)
        {
            if (lstDublett.InvokeRequired)
            {
                dlgSetFileName d = new dlgSetFileName(addItemToListView);
                lstDublett.Invoke(d, new object[] { fileName, fileSizeAsString });
            }
            else
            {
                lstDublett.CheckBoxes = true;
                ListViewItem addedItem = lstDublett.Items.Add(new ListViewItem(fileName));
                addedItem.SubItems.Add(fileSizeAsString);
            }
        }

        public void frmMain_OnSetDirName(string dirName)
        {
            setDirLabelSearchText(string.Format("Söker igenom: {0}", dirName));
        }

        public void frmMain_OnSetDuplicateCount(int count, int totalFilesSearched)
        {
            if (count == 0)
                MessageBox.Show(String.Format("Av {0} kunde inga dubletter hittas", totalFilesSearched.ToString()));
            else
            {
                setDuplicateCountText(count, totalFilesSearched);
            }
        }


        public void frmMain_OnSetFileName(string FileName, string fileSizeAsString)
        {
            addItemToListView(FileName, fileSizeAsString);
        }



        private void btnStartDir_Click(object sender, EventArgs e)
        {

            _browseFolder = new FolderBrowserDialog();
            _browseFolder.ShowNewFolderButton = false;

            if (_browseFolder.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pathToStartDir = _browseFolder.SelectedPath;
            }
            else
            {
                pathToStartDir = null;
            }

            if (null != pathToStartDir)
            {
                lblStartDir.Text = "Startkatalog: " + pathToStartDir;
                btnStartDuplicates.Enabled = true;
            }
            else
            {
                btnStartDuplicates.Enabled = false;
            }

        }

        private void btnStartDuplicates_Click(object sender, EventArgs e)
        {

            SearchEngine engine = new SearchEngine(@"c:\temp\");
            engine.Search(false);

            //lstDublett.Items.Clear();

            //_workerThread = new Thread(new ParameterizedThreadStart(performSearch));
            //_workerThread.Start();

        }

        private void performSearch(object t)
        {
            _searcherObject = new Search(pathToStartDir, isMatchOnName);
            _searcherObject.PerformSearch(this);
        }

        private void optFileName_CheckedChanged(object sender, EventArgs e)
        {
            isMatchOnName = optFileName.Checked ? true : false;
        }

        private void btnMove_Click(object sender, EventArgs e)
        {
            List<Duplicates> selectedToMove = new List<Duplicates>(lstDublett.CheckedItems.Count);

            DialogResult dlgAnswer = (MessageBox.Show("ALLA markerade FLYTTAS till den katalog du anger, filnamnen numreras\nBekräfta att du vill fortsätta\nAlla filer hamnar i samma katalog", "Bekräfta", MessageBoxButtons.OKCancel));
            if (dlgAnswer == DialogResult.OK)
            {
                _browseFolder.ShowNewFolderButton = true;

                if (_browseFolder.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Cursor.Current = Cursors.WaitCursor;

                    //kolla om _searcherObject.getDuplicates är matchade mot ibockade

                    foreach (ListViewItem itemChecked in lstDublett.CheckedItems)
                    {
                        FileInfo f = new FileInfo(itemChecked.Text);
                        selectedToMove.Add(new Duplicates { fileName = f.Name, filePath = f.FullName, fileSize = f.Length, fileCreateDate = f.CreationTime });
                        f = null;
                    }
                    //FixFiles fixer = new FixFiles(_browseFolder.SelectedPath, _searcherObject.getDuplicates);
                    FixFiles fixer = new FixFiles(_browseFolder.SelectedPath, selectedToMove);

                    fixer.DoFix();
                    Cursor.Current = Cursors.Arrow;
                }

                MessageBox.Show(string.Format("Flyttade {0} filer till mappen {1}", selectedToMove.Count.ToString(), _browseFolder.SelectedPath));
                lstDublett.Clear();
                btnMove.Enabled = false;

            }
        }

        private void btnEnterStartPath_Click(object sender, EventArgs e)
        {
            StartPathForm frmStartPath = new StartPathForm();
            frmStartPath.OnSetPath += frmStartPath_OnSetPath;


            frmStartPath.Show();


        }

        void frmStartPath_OnSetPath(string path)
        {
            pathToStartDir = path;
            lblStartDir.Text = path;
            btnStartDuplicates.Enabled = true;
        }

        
        
    }
}
