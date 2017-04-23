using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVDRentalsSystem
{
    public partial class frmDVDlist : Form
    {
        frmMenu menu;
        private ClsPrint print;

        public frmDVDlist()
        {
            InitializeComponent();
        }

        public frmDVDlist(frmMenu Menu)
        {
            InitializeComponent();
            this.menu = Menu;
        }

        private void frmDVDlist_Load(object sender, EventArgs e)
        {
            grdDVDList.DataSource = DVDs.getDVDs("","").Tables["ss"];
            
            //Adding fields to the the filterBy combobox
            cboFilterBy.Items.Add("All");
            cboFilterBy.Items.Add("Available");
            cboFilterBy.Items.Add("Rented/Unavailable");
            cboFilterBy.Items.Add("De-Registered");

            //Adding fields to the OrderBy combobox
            cboOrderBy.Items.Add("DVD ID");
            cboOrderBy.Items.Add("Title");

            print = new ClsPrint(grdDVDList, "DVD List");

        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuBack_Click(object sender, EventArgs e)
        {
            this.Close();
            menu.Show();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            string orderBy;
            string filterBy;

            if(cboFilterBy.Text == "All")
            {
                filterBy = "";
            }
            else if (cboFilterBy.Text == "Available")
            {
                filterBy = "A";
            }
            else if (cboFilterBy.Text == "Rented/Unavailable")
            {
                filterBy = "U";
            }
            else if (cboFilterBy.Text == "De-Registered")
            {
                filterBy = "R";
            }
            else
            {
                filterBy = "";
            }
            if(cboOrderBy.Text == "DVD ID")
            {
                orderBy = "ORDER BY DVDID";
            }
            else if (cboOrderBy.Text == "Title")
            {
                orderBy = "ORDER BY Title";
            }
            else
            {
                orderBy = ""; 
            }

            grdDVDList.DataSource = DVDs.getDVDs(orderBy, filterBy).Tables["ss"];
            print = new ClsPrint(grdDVDList,"DVD List");
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            print.PrintForm();
        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            print.printPreview();
        }
    }
}
