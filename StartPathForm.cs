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
    public partial class StartPathForm : Form
    {

        

        public  delegate void dlgOnSetPath(string path);
        public event dlgOnSetPath OnSetPath;

        public StartPathForm()
        {
            InitializeComponent();
            txtPath.Focus();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string path = txtPath.Text;

            if (Directory.Exists(path))
            {
                OnSetPath(path);
                this.Close();
            }
            else
            {
                MessageBox.Show(String.Format("Katalogen du angav {0} finns inte!", path));
                return;
            }

        }




    }
}
