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
    public partial class frmCustomerRentals : Form
    {
        private frmMenu menu;

        public frmCustomerRentals()
        {
            InitializeComponent();
        }

        public frmCustomerRentals(frmMenu Menu)
        {
            InitializeComponent();
            this.menu = Menu;
        }

        private void frmCustomerRentals_Load(object sender, EventArgs e)
        {

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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            grdCustomers.DataSource = Customers.getCustomers(txtSearch.Text).Tables["ss"];
        }

        private void grdCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.grdCustomers.Rows[e.RowIndex];

            int customerId = Convert.ToInt32(row.Cells[0].Value);

            txtCustomerId.Text = customerId.ToString("0000").Trim();
            cboTitle.Text = row.Cells[1].Value.ToString().Trim();
            txtForename.Text = row.Cells[2].Value.ToString().Trim();
            txtSurname.Text = row.Cells[3].Value.ToString().Trim();
            dtpDOB.Text = row.Cells[4].Value.ToString().Trim();
            txtEmail.Text = row.Cells[5].Value.ToString().Trim();
            txtPhone.Text = row.Cells[6].Value.ToString().Trim();
            txtAddress1.Text = row.Cells[7].Value.ToString().Trim();
            txtAddress2.Text = row.Cells[8].Value.ToString().Trim();
            txtTown.Text = row.Cells[9].Value.ToString().Trim();
            cboCounty.Text = row.Cells[10].Value.ToString().Trim();
            cboCountry.Text = row.Cells[11].Value.ToString().Trim();

            grdCustomerInfo.DataSource = Customers.getCustomerRentals(customerId).Tables["ss"];


        }
    }
}
