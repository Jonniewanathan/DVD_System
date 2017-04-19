using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVDRentalsSystem.DVD;

namespace DVDRentalsSystem
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void mnuDVDReg_Click(object sender, EventArgs e)
        {
            frmDVDReg DVDReg = new frmDVDReg(this);
            DVDReg.Show();
            this.Hide();
        }

        private void mnuDVDUpdate_Click(object sender, EventArgs e)
        {
            frmDVDupdate DVDupdate = new frmDVDupdate(this);
            DVDupdate.Show();
            this.Hide();
        }

        private void mnuDVDRemove_Click(object sender, EventArgs e)
        {
            frmDVDRemove DVDremove = new frmDVDRemove(this);
            DVDremove.Show();
            this.Hide();
        }

        private void mnuDVDList_Click(object sender, EventArgs e)
        {
            frmDVDlist DVDList = new frmDVDlist(this);
            DVDList.Show();
            this.Hide();
        }

        private void registerCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomerReg CustomerReg = new frmCustomerReg(this);
            CustomerReg.Show();
            this.Hide();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {

        }

        private void mnuCustomerUpdate_Click(object sender, EventArgs e)
        {
            frmCustomerUpdate CustomerUpdate = new frmCustomerUpdate(this);
            CustomerUpdate.Show();
            this.Hide();
        }

        private void removeCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomerRemove customerRemove = new frmCustomerRemove(this);
            customerRemove.Show();
            this.Hide();
        }

        private void mnuDVDRental_Click(object sender, EventArgs e)
        {
            frmDVDRental dvdRental = new frmDVDRental(this);
            dvdRental.Show();
            this.Hide();
        }

        private void returnDVDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDVDReturn dvdReturn = new frmDVDReturn(this);
            dvdReturn.Show();
            this.Hide();
        }

        private void listCustomerRentalsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomerRentals customerRentals = new frmCustomerRentals(this);
            customerRentals.Show();
            this.Hide();
        }

        private void analysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDVDAnalysis dvdAnalysis = new frmDVDAnalysis(this);
            dvdAnalysis.Show();
            this.Hide();
        }

        private void rentalListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRentalsList rentalsList = new frmRentalsList(this);
            rentalsList.Show();
            this.Hide();
        }
    }
}
