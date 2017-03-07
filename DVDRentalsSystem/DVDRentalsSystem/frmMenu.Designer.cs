namespace DVDRentalsSystem
{
    partial class frmMenu
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
            this.mnuStrip = new System.Windows.Forms.MenuStrip();
            this.dVDAdministrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDVDReg = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDVDRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDVDUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDVDList = new System.Windows.Forms.ToolStripMenuItem();
            this.customerAdministrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registerCustomerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblName = new System.Windows.Forms.Label();
            this.mnuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuStrip
            // 
            this.mnuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dVDAdministrationToolStripMenuItem,
            this.customerAdministrationToolStripMenuItem});
            this.mnuStrip.Location = new System.Drawing.Point(0, 0);
            this.mnuStrip.Name = "mnuStrip";
            this.mnuStrip.Size = new System.Drawing.Size(547, 24);
            this.mnuStrip.TabIndex = 0;
            this.mnuStrip.Text = "menuStrip1";
            // 
            // dVDAdministrationToolStripMenuItem
            // 
            this.dVDAdministrationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDVDReg,
            this.mnuDVDRemove,
            this.mnuDVDUpdate,
            this.mnuDVDList});
            this.dVDAdministrationToolStripMenuItem.Name = "dVDAdministrationToolStripMenuItem";
            this.dVDAdministrationToolStripMenuItem.Size = new System.Drawing.Size(124, 20);
            this.dVDAdministrationToolStripMenuItem.Text = "DVD Administration";
            // 
            // mnuDVDReg
            // 
            this.mnuDVDReg.Name = "mnuDVDReg";
            this.mnuDVDReg.Size = new System.Drawing.Size(143, 22);
            this.mnuDVDReg.Text = "Register DVD";
            this.mnuDVDReg.Click += new System.EventHandler(this.mnuDVDReg_Click);
            // 
            // mnuDVDRemove
            // 
            this.mnuDVDRemove.Name = "mnuDVDRemove";
            this.mnuDVDRemove.Size = new System.Drawing.Size(143, 22);
            this.mnuDVDRemove.Text = "Remove DVD";
            this.mnuDVDRemove.Click += new System.EventHandler(this.mnuDVDRemove_Click);
            // 
            // mnuDVDUpdate
            // 
            this.mnuDVDUpdate.Name = "mnuDVDUpdate";
            this.mnuDVDUpdate.Size = new System.Drawing.Size(143, 22);
            this.mnuDVDUpdate.Text = "Update DVD";
            this.mnuDVDUpdate.Click += new System.EventHandler(this.mnuDVDUpdate_Click);
            // 
            // mnuDVDList
            // 
            this.mnuDVDList.Name = "mnuDVDList";
            this.mnuDVDList.Size = new System.Drawing.Size(143, 22);
            this.mnuDVDList.Text = "List DVDs";
            this.mnuDVDList.Click += new System.EventHandler(this.mnuDVDList_Click);
            // 
            // customerAdministrationToolStripMenuItem
            // 
            this.customerAdministrationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registerCustomerToolStripMenuItem});
            this.customerAdministrationToolStripMenuItem.Name = "customerAdministrationToolStripMenuItem";
            this.customerAdministrationToolStripMenuItem.Size = new System.Drawing.Size(153, 20);
            this.customerAdministrationToolStripMenuItem.Text = "Customer Administration";
            // 
            // registerCustomerToolStripMenuItem
            // 
            this.registerCustomerToolStripMenuItem.Name = "registerCustomerToolStripMenuItem";
            this.registerCustomerToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.registerCustomerToolStripMenuItem.Text = "Register Customer";
            this.registerCustomerToolStripMenuItem.Click += new System.EventHandler(this.registerCustomerToolStripMenuItem_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(198, 126);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(133, 25);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "DVD System";
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 325);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.mnuStrip);
            this.MainMenuStrip = this.mnuStrip;
            this.Name = "frmMenu";
            this.Text = "DVD Rental  Sysem";
            this.mnuStrip.ResumeLayout(false);
            this.mnuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuStrip;
        private System.Windows.Forms.ToolStripMenuItem dVDAdministrationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuDVDReg;
        private System.Windows.Forms.ToolStripMenuItem mnuDVDRemove;
        private System.Windows.Forms.ToolStripMenuItem mnuDVDUpdate;
        private System.Windows.Forms.ToolStripMenuItem mnuDVDList;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.ToolStripMenuItem customerAdministrationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registerCustomerToolStripMenuItem;
    }
}

