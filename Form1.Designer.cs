namespace Dubletter
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStartDir = new System.Windows.Forms.Button();
            this.lblStartDir = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.optFileSize = new System.Windows.Forms.RadioButton();
            this.optFileName = new System.Windows.Forms.RadioButton();
            this.btnStartDuplicates = new System.Windows.Forms.Button();
            this.lstDublett = new System.Windows.Forms.ListView();
            this.colDublett = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblFileSearch = new System.Windows.Forms.Label();
            this.lblDirSearch = new System.Windows.Forms.Label();
            this.btnMove = new System.Windows.Forms.Button();
            this.btnEnterStartPath = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStartDir
            // 
            this.btnStartDir.Location = new System.Drawing.Point(66, 12);
            this.btnStartDir.Name = "btnStartDir";
            this.btnStartDir.Size = new System.Drawing.Size(195, 26);
            this.btnStartDir.TabIndex = 0;
            this.btnStartDir.Text = "Klicka här för att ange startkatalog!";
            this.btnStartDir.UseVisualStyleBackColor = true;
            this.btnStartDir.Click += new System.EventHandler(this.btnStartDir_Click);
            // 
            // lblStartDir
            // 
            this.lblStartDir.AutoSize = true;
            this.lblStartDir.Location = new System.Drawing.Point(69, 55);
            this.lblStartDir.Name = "lblStartDir";
            this.lblStartDir.Size = new System.Drawing.Size(67, 13);
            this.lblStartDir.TabIndex = 1;
            this.lblStartDir.Text = "Startkatalog:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.optFileSize);
            this.groupBox1.Controls.Add(this.optFileName);
            this.groupBox1.Location = new System.Drawing.Point(66, 89);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(419, 54);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Inställningar";
            // 
            // optFileSize
            // 
            this.optFileSize.AutoSize = true;
            this.optFileSize.Location = new System.Drawing.Point(156, 20);
            this.optFileSize.Name = "optFileSize";
            this.optFileSize.Size = new System.Drawing.Size(240, 17);
            this.optFileSize.TabIndex = 1;
            this.optFileSize.TabStop = true;
            this.optFileSize.Text = "Matcha filnamn och filstorlek (exakt samma fil)";
            this.optFileSize.UseVisualStyleBackColor = true;
            // 
            // optFileName
            // 
            this.optFileName.AutoSize = true;
            this.optFileName.Location = new System.Drawing.Point(6, 19);
            this.optFileName.Name = "optFileName";
            this.optFileName.Size = new System.Drawing.Size(121, 17);
            this.optFileName.TabIndex = 0;
            this.optFileName.TabStop = true;
            this.optFileName.Text = "Matcha bara filnamn";
            this.optFileName.UseVisualStyleBackColor = true;
            this.optFileName.CheckedChanged += new System.EventHandler(this.optFileName_CheckedChanged);
            // 
            // btnStartDuplicates
            // 
            this.btnStartDuplicates.Enabled = false;
            this.btnStartDuplicates.Location = new System.Drawing.Point(66, 161);
            this.btnStartDuplicates.Name = "btnStartDuplicates";
            this.btnStartDuplicates.Size = new System.Drawing.Size(419, 33);
            this.btnStartDuplicates.TabIndex = 3;
            this.btnStartDuplicates.Text = "Starta sökning av dubletter";
            this.btnStartDuplicates.UseVisualStyleBackColor = true;
            this.btnStartDuplicates.Click += new System.EventHandler(this.btnStartDuplicates_Click);
            // 
            // lstDublett
            // 
            this.lstDublett.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstDublett.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDublett,
            this.colSize});
            this.lstDublett.FullRowSelect = true;
            this.lstDublett.GridLines = true;
            this.lstDublett.Location = new System.Drawing.Point(12, 243);
            this.lstDublett.Name = "lstDublett";
            this.lstDublett.Size = new System.Drawing.Size(530, 347);
            this.lstDublett.TabIndex = 4;
            this.lstDublett.UseCompatibleStateImageBehavior = false;
            this.lstDublett.View = System.Windows.Forms.View.Details;
            // 
            // colDublett
            // 
            this.colDublett.Text = "Dublett";
            this.colDublett.Width = 424;
            // 
            // colSize
            // 
            this.colSize.Text = "Storlek";
            this.colSize.Width = 90;
            // 
            // lblFileSearch
            // 
            this.lblFileSearch.AutoSize = true;
            this.lblFileSearch.Location = new System.Drawing.Point(12, 227);
            this.lblFileSearch.Name = "lblFileSearch";
            this.lblFileSearch.Size = new System.Drawing.Size(50, 13);
            this.lblFileSearch.TabIndex = 5;
            this.lblFileSearch.Text = "Dubletter";
            // 
            // lblDirSearch
            // 
            this.lblDirSearch.AutoSize = true;
            this.lblDirSearch.Location = new System.Drawing.Point(12, 593);
            this.lblDirSearch.Name = "lblDirSearch";
            this.lblDirSearch.Size = new System.Drawing.Size(35, 13);
            this.lblDirSearch.TabIndex = 6;
            this.lblDirSearch.Text = "label1";
            // 
            // btnMove
            // 
            this.btnMove.Enabled = false;
            this.btnMove.Location = new System.Drawing.Point(66, 620);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(419, 28);
            this.btnMove.TabIndex = 7;
            this.btnMove.Text = "Flytta Samtliga filer till samma mapp";
            this.btnMove.UseVisualStyleBackColor = true;
            this.btnMove.Click += new System.EventHandler(this.btnMove_Click);
            // 
            // btnEnterStartPath
            // 
            this.btnEnterStartPath.Location = new System.Drawing.Point(267, 12);
            this.btnEnterStartPath.Name = "btnEnterStartPath";
            this.btnEnterStartPath.Size = new System.Drawing.Size(202, 26);
            this.btnEnterStartPath.TabIndex = 8;
            this.btnEnterStartPath.Text = "Ange katalog genom att skriva in den";
            this.btnEnterStartPath.UseVisualStyleBackColor = true;
            this.btnEnterStartPath.Click += new System.EventHandler(this.btnEnterStartPath_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 669);
            this.Controls.Add(this.btnEnterStartPath);
            this.Controls.Add(this.btnMove);
            this.Controls.Add(this.lblDirSearch);
            this.Controls.Add(this.lblFileSearch);
            this.Controls.Add(this.lstDublett);
            this.Controls.Add(this.btnStartDuplicates);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblStartDir);
            this.Controls.Add(this.btnStartDir);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hitta dubletter";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartDir;
        private System.Windows.Forms.Label lblStartDir;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton optFileSize;
        private System.Windows.Forms.RadioButton optFileName;
        private System.Windows.Forms.Button btnStartDuplicates;
        private System.Windows.Forms.ListView lstDublett;
        private System.Windows.Forms.Label lblFileSearch;
        private System.Windows.Forms.ColumnHeader colDublett;
        private System.Windows.Forms.ColumnHeader colSize;
        private System.Windows.Forms.Label lblDirSearch;
        private System.Windows.Forms.Button btnMove;
        private System.Windows.Forms.Button btnEnterStartPath;
    }
}

