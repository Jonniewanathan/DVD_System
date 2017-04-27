namespace DVDRentalsSystem
{
    partial class frmDVDRental
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuBack = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSearchCustomer = new System.Windows.Forms.Button();
            this.txtSearchCustomer = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.grdCustomers = new System.Windows.Forms.DataGridView();
            this.btnDVDidSearch = new System.Windows.Forms.Button();
            this.txtSearchDVDId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpDVDUpdate = new System.Windows.Forms.GroupBox();
            this.txtDVDId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAddToBasket = new System.Windows.Forms.Button();
            this.cboPriceCatagory = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboAgeRating = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboGenre = new System.Windows.Forms.ComboBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.grdDVDBasket = new System.Windows.Forms.DataGridView();
            this.btnRent = new System.Windows.Forms.Button();
            this.txtTotalPrice = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cboNumOfDays = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCustomerID = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCustomers)).BeginInit();
            this.grpDVDUpdate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDVDBasket)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuBack,
            this.mnuExit});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1228, 24);
            this.menuStrip1.TabIndex = 11;
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
            // btnSearchCustomer
            // 
            this.btnSearchCustomer.Location = new System.Drawing.Point(295, 27);
            this.btnSearchCustomer.Name = "btnSearchCustomer";
            this.btnSearchCustomer.Size = new System.Drawing.Size(75, 23);
            this.btnSearchCustomer.TabIndex = 72;
            this.btnSearchCustomer.Text = "Search";
            this.btnSearchCustomer.UseVisualStyleBackColor = true;
            this.btnSearchCustomer.Click += new System.EventHandler(this.btnSearchCustomer_Click);
            // 
            // txtSearchCustomer
            // 
            this.txtSearchCustomer.Location = new System.Drawing.Point(77, 31);
            this.txtSearchCustomer.Name = "txtSearchCustomer";
            this.txtSearchCustomer.Size = new System.Drawing.Size(200, 20);
            this.txtSearchCustomer.TabIndex = 71;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(15, 39);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 13);
            this.label12.TabIndex = 70;
            this.label12.Text = "Surname";
            // 
            // grdCustomers
            // 
            this.grdCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdCustomers.Location = new System.Drawing.Point(12, 68);
            this.grdCustomers.Name = "grdCustomers";
            this.grdCustomers.Size = new System.Drawing.Size(468, 199);
            this.grdCustomers.TabIndex = 69;
            this.grdCustomers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdCustomers_CellClick);
            // 
            // btnDVDidSearch
            // 
            this.btnDVDidSearch.Location = new System.Drawing.Point(656, 28);
            this.btnDVDidSearch.Name = "btnDVDidSearch";
            this.btnDVDidSearch.Size = new System.Drawing.Size(75, 23);
            this.btnDVDidSearch.TabIndex = 78;
            this.btnDVDidSearch.Text = "Search";
            this.btnDVDidSearch.UseVisualStyleBackColor = true;
            this.btnDVDidSearch.Click += new System.EventHandler(this.btnDVDidSearch_Click);
            // 
            // txtSearchDVDId
            // 
            this.txtSearchDVDId.Location = new System.Drawing.Point(546, 31);
            this.txtSearchDVDId.Name = "txtSearchDVDId";
            this.txtSearchDVDId.Size = new System.Drawing.Size(100, 20);
            this.txtSearchDVDId.TabIndex = 77;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(501, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 80;
            this.label1.Text = "DVDId";
            // 
            // grpDVDUpdate
            // 
            this.grpDVDUpdate.Controls.Add(this.txtDVDId);
            this.grpDVDUpdate.Controls.Add(this.label4);
            this.grpDVDUpdate.Controls.Add(this.btnAddToBasket);
            this.grpDVDUpdate.Controls.Add(this.cboPriceCatagory);
            this.grpDVDUpdate.Controls.Add(this.label3);
            this.grpDVDUpdate.Controls.Add(this.cboAgeRating);
            this.grpDVDUpdate.Controls.Add(this.label2);
            this.grpDVDUpdate.Controls.Add(this.cboGenre);
            this.grpDVDUpdate.Controls.Add(this.txtTitle);
            this.grpDVDUpdate.Controls.Add(this.label6);
            this.grpDVDUpdate.Controls.Add(this.lblTitle);
            this.grpDVDUpdate.Location = new System.Drawing.Point(515, 68);
            this.grpDVDUpdate.Name = "grpDVDUpdate";
            this.grpDVDUpdate.Size = new System.Drawing.Size(273, 199);
            this.grpDVDUpdate.TabIndex = 79;
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
            // btnAddToBasket
            // 
            this.btnAddToBasket.Location = new System.Drawing.Point(99, 168);
            this.btnAddToBasket.Name = "btnAddToBasket";
            this.btnAddToBasket.Size = new System.Drawing.Size(75, 23);
            this.btnAddToBasket.TabIndex = 7;
            this.btnAddToBasket.Text = "Add";
            this.btnAddToBasket.UseVisualStyleBackColor = true;
            this.btnAddToBasket.Click += new System.EventHandler(this.btnAddToBasket_Click);
            // 
            // cboPriceCatagory
            // 
            this.cboPriceCatagory.Enabled = false;
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
            this.cboAgeRating.Enabled = false;
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
            this.cboGenre.Enabled = false;
            this.cboGenre.FormattingEnabled = true;
            this.cboGenre.Location = new System.Drawing.Point(99, 80);
            this.cboGenre.Name = "cboGenre";
            this.cboGenre.Size = new System.Drawing.Size(121, 21);
            this.cboGenre.TabIndex = 4;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(99, 54);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.ReadOnly = true;
            this.txtTitle.Size = new System.Drawing.Size(121, 20);
            this.txtTitle.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Genre";
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
            // grdDVDBasket
            // 
            this.grdDVDBasket.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDVDBasket.Location = new System.Drawing.Point(819, 68);
            this.grdDVDBasket.Name = "grdDVDBasket";
            this.grdDVDBasket.Size = new System.Drawing.Size(368, 199);
            this.grdDVDBasket.TabIndex = 81;
            // 
            // btnRent
            // 
            this.btnRent.Location = new System.Drawing.Point(1141, 340);
            this.btnRent.Name = "btnRent";
            this.btnRent.Size = new System.Drawing.Size(75, 23);
            this.btnRent.TabIndex = 82;
            this.btnRent.Text = "Rent";
            this.btnRent.UseVisualStyleBackColor = true;
            this.btnRent.Click += new System.EventHandler(this.btnRent_Click);
            // 
            // txtTotalPrice
            // 
            this.txtTotalPrice.Location = new System.Drawing.Point(856, 272);
            this.txtTotalPrice.Name = "txtTotalPrice";
            this.txtTotalPrice.ReadOnly = true;
            this.txtTotalPrice.Size = new System.Drawing.Size(109, 20);
            this.txtTotalPrice.TabIndex = 83;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(819, 279);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 84;
            this.label5.Text = "Total";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(972, 278);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 13);
            this.label7.TabIndex = 85;
            this.label7.Text = "Number of days";
            // 
            // cboNumOfDays
            // 
            this.cboNumOfDays.FormattingEnabled = true;
            this.cboNumOfDays.Location = new System.Drawing.Point(1060, 274);
            this.cboNumOfDays.Name = "cboNumOfDays";
            this.cboNumOfDays.Size = new System.Drawing.Size(121, 21);
            this.cboNumOfDays.TabIndex = 86;
            this.cboNumOfDays.SelectedIndexChanged += new System.EventHandler(this.cboNumOfDays_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 288);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 87;
            this.label8.Text = "Customer ID";
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.Location = new System.Drawing.Point(104, 279);
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.Size = new System.Drawing.Size(100, 20);
            this.txtCustomerID.TabIndex = 88;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 314);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 13);
            this.label9.TabIndex = 89;
            this.label9.Text = "Customer Name";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(104, 311);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(139, 20);
            this.txtCustomerName.TabIndex = 90;
            // 
            // frmDVDRental
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1228, 387);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtCustomerID);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cboNumOfDays);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTotalPrice);
            this.Controls.Add(this.btnRent);
            this.Controls.Add(this.grdDVDBasket);
            this.Controls.Add(this.btnDVDidSearch);
            this.Controls.Add(this.txtSearchDVDId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grpDVDUpdate);
            this.Controls.Add(this.btnSearchCustomer);
            this.Controls.Add(this.txtSearchCustomer);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.grdCustomers);
            this.Controls.Add(this.menuStrip1);
            this.Name = "frmDVDRental";
            this.Text = "Rent DVDs";
            this.Load += new System.EventHandler(this.frmDVDRental_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCustomers)).EndInit();
            this.grpDVDUpdate.ResumeLayout(false);
            this.grpDVDUpdate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDVDBasket)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuBack;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.Button btnSearchCustomer;
        private System.Windows.Forms.TextBox txtSearchCustomer;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView grdCustomers;
        private System.Windows.Forms.Button btnDVDidSearch;
        private System.Windows.Forms.TextBox txtSearchDVDId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpDVDUpdate;
        private System.Windows.Forms.TextBox txtDVDId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAddToBasket;
        private System.Windows.Forms.ComboBox cboPriceCatagory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboAgeRating;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboGenre;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView grdDVDBasket;
        private System.Windows.Forms.Button btnRent;
        private System.Windows.Forms.TextBox txtTotalPrice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboNumOfDays;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCustomerID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCustomerName;
    }
}