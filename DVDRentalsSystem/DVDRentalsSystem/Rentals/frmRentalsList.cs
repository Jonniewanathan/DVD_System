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
    public partial class frmRentalsList : Form
    {
        private frmMenu menu;
        private ClsPrint print;

        public frmRentalsList()
        {
            InitializeComponent();
        }

        public frmRentalsList(frmMenu Menu)
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

        private void btnLoad_Click(object sender, EventArgs e)
        {
            string date = String.Format("{0:dd-MMM-yy}", dtpDate.Value);

            grdRentalsList.DataSource = Rentals.getDailyRentalsList(date).Tables["ss"];
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            print.PrintForm();
        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            print.printPreview();
        }

        private void frmRentalsList_Load(object sender, EventArgs e)
        {
            print = new ClsPrint(grdRentalsList,"Daily Rental List");
        }
    }
}
