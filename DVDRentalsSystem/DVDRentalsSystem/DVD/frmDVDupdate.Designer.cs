namespace DVDRentalsSystem
{
    partial class frmDVDupdate
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
            this.grpDVDUpdate = new System.Windows.Forms.GroupBox();
            this.txtDVDId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.cboPriceCatagory = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboAgeRating = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboGenre = new System.Windows.Forms.ComboBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.grdDVD = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuBack = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.grpDVDUpdate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDVD)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpDVDUpdate
            // 
            this.grpDVDUpdate.Controls.Add(this.txtDVDId);
            this.grpDVDUpdate.Controls.Add(this.label4);
            this.grpDVDUpdate.Controls.Add(this.btnUpdate);
            this.grpDVDUpdate.Controls.Add(this.cboPriceCatagory);
            this.grpDVDUpdate.Controls.Add(this.label3);
            this.grpDVDUpdate.Controls.Add(this.cboAgeRating);
            this.grpDVDUpdate.Controls.Add(this.label2);
            this.grpDVDUpdate.Controls.Add(this.cboGenre);
            this.grpDVDUpdate.Controls.Add(this.txtTitle);
            this.grpDVDUpdate.Controls.Add(this.label1);
            this.grpDVDUpdate.Controls.Add(this.lblTitle);
            this.grpDVDUpdate.Location = new System.Drawing.Point(12, 73);
            this.grpDVDUpdate.Name = "grpDVDUpdate";
            this.grpDVDUpdate.Size = new System.Drawing.Size(273, 223);
            this.grpDVDUpdate.TabIndex = 4;
            this.grpDVDUpdate.TabStop = false;
            this.grpDVDUpdate.Text = "Update DVD";
            // 
            // txtDVDId
            // 
            this.txtDVDId.Location = new System.Drawing.Point(99, 21);
            this.txtDVDId.Name = "txtDVDId";
            this.txtDVDId.ReadOnly = true;
            this.txtDVDId.Size = new System.Drawing.Size(121, 20);
            this.txtDVDId.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "DVDId";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(99, 180);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 7;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // cboPriceCatagory
            // 
            this.cboPriceCatagory.FormattingEnabled = true;
            this.cboPriceCatagory.Location = new System.Drawing.Point(99, 141);
            this.cboPriceCatagory.Name = "cboPriceCatagory";
            this.cboPriceCatagory.Size = new System.Drawing.Size(121, 21);
            this.cboPriceCatagory.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Price Catagory";
            // 
            // cboAgeRating
            // 
            this.cboAgeRating.FormattingEnabled = true;
            this.cboAgeRating.Location = new System.Drawing.Point(99, 109);
            this.cboAgeRating.Name = "cboAgeRating";
            this.cboAgeRating.Size = new System.Drawing.Size(121, 21);
            this.cboAgeRating.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Age Rating";
            // 
            // cboGenre
            // 
            this.cboGenre.FormattingEnabled = true;
            this.cboGenre.Location = new System.Drawing.Point(99, 80);
            this.cboGenre.Name = "cboGenre";
            this.cboGenre.Size = new System.Drawing.Size(121, 21);
            this.cboGenre.TabIndex = 4;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(99, 54);
            this.txtTitle.MaxLength = 35;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(121, 20);
            this.txtTitle.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Genre";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(17, 60);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(27, 13);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Title";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Title";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(43, 36);
            this.txtSearch.MaxLength = 35;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(100, 20);
            this.txtSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(153, 33);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // grdDVD
            // 
            this.grdDVD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDVD.Location = new System.Drawing.Point(291, 33);
            this.grdDVD.Name = "grdDVD";
            this.grdDVD.Size = new System.Drawing.Size(653, 263);
            this.grdDVD.TabIndex = 8;
            this.grdDVD.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdDVD_CellClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuBack,
            this.mnuExit});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(956, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuBack
            // 
            this.mnuBack.Name = "mnuBack";
            this.mnuBack.Size = new System.Drawing.Size(44, 20);
            this.mnuBack.Text = "Back";
            this.mnuBack.Click += new System.EventHandler(this.mnuBack_Click);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(37, 20);
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // frmDVDupdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 307);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.grdDVD);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.grpDVDUpdate);
            this.Name = "frmDVDupdate";
            this.Text = "Update DVD";
            this.Load += new System.EventHandler(this.frmDVDupdate_Load);
            this.grpDVDUpdate.ResumeLayout(false);
            this.grpDVDUpdate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDVD)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpDVDUpdate;
        private System.Windows.Forms.TextBox txtDVDId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ComboBox cboPriceCatagory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboAgeRating;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboGenre;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView grdDVD;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuBack;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
    }
}