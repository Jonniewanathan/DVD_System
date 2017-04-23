using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVDRentalsSystem.DVD
{
    public partial class frmDVDAnalysis : Form
    {
        private frmMenu menu;
        private ClsPrint print;

        public frmDVDAnalysis()
        {
            InitializeComponent();
        }

        public frmDVDAnalysis(frmMenu Menu)
        {
            InitializeComponent();
            this.menu = Menu;
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            print.PrintForm();
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            string dateFrom = String.Format("{0:dd-MMM-yy}", dtpDateFrom.Value);
            string dateTo = String.Format("{0:dd-MMM-yy}", dtpDateTo.Value);
            DataSet dvdSet = DVDs.getDVDAnalysis(dateFrom,dateTo);
            if (dvdSet.Tables[0].Rows.Count != 0)
            {
                grdDVDAnalysis.DataSource = dvdSet.Tables["ss"];
            }
            else
            {
                MessageBox.Show("Nothing to show from those Dates", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            print.printPreview();
        }

        private void frmDVDAnalysis_Load(object sender, EventArgs e)
        {
            print = new ClsPrint(grdDVDAnalysis, "DVD Analysis");
        }
    }
}
