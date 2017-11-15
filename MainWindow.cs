using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dubletter
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            ListFolders();
        }

        private void ListFolders()
        {
            TreeNode rootNode;
            DirectoryInfo info = new DirectoryInfo(@"c:\");
            if (info.Exists)
            {
                rootNode = new TreeNode(info.Name);
                rootNode.Tag = info;
                GetDirectories(info.GetDirectories(), rootNode);
                treeMain.Nodes.Add(rootNode);
            }


        }

        private void GetDirectories(DirectoryInfo[] subDirs, TreeNode nodToAddTo)
        {
            TreeNode aNode;
            DirectoryInfo[] subsubDirs;

            foreach (DirectoryInfo subDir in subDirs)
            {
                aNode = new TreeNode(subDir.Name, 0, 0);
                aNode.Tag = subDir;
                aNode.ImageKey = "folder";

                subsubDirs = subDir.GetDirectories();
                if (subsubDirs.Length > 0)
                {
                    GetDirectories(subsubDirs, aNode);
                }
            }
        }
    }
}
