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
    public partial class frmCustomerRemove : Form
    {
        private frmMenu menu;

        public frmCustomerRemove()
        {
            InitializeComponent();
        }

        public frmCustomerRemove(frmMenu Menu)
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

        //populates the grid view with the customer records
        private void btnSearch_Click(object sender, EventArgs e)
        {
            grdCustomers.DataSource = Customers.getCustomers(txtSearch.Text).Tables["ss"];
        }

        //populates the form with the data from the row selected on the datagrid
        private void grdCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.grdCustomers.Rows[e.RowIndex];

            int customerId = Convert.ToInt32(row.Cells[0].Value);

            txtCustomerId.Text = customerId.ToString("0000");
            cboTitle.Text = row.Cells[1].Value.ToString();
            txtForename.Text = row.Cells[2].Value.ToString();
            txtSurname.Text = row.Cells[3].Value.ToString();
            dtpDOB.Text = row.Cells[4].Value.ToString();
            txtEmail.Text = row.Cells[5].Value.ToString();
            txtPhone.Text = row.Cells[6].Value.ToString();
            txtAddress1.Text = row.Cells[7].Value.ToString();
            txtAddress2.Text = row.Cells[8].Value.ToString();
            txtTown.Text = row.Cells[9].Value.ToString();
            cboCounty.Text = row.Cells[10].Value.ToString();
            cboCountry.Text = row.Cells[11].Value.ToString();
        }

        //calls the methos to remove the specified customer
        private void btnRemove_Click(object sender, EventArgs e)
        {
            Customers customer = new Customers();

            MessageBox.Show(txtForename.Text.TrimEnd() + " " + txtSurname.Text.TrimEnd() + " has been de-Registered", "Customer Removed",
                     MessageBoxButtons.OK, MessageBoxIcon.Information);

            customer.removeCustomer(Convert.ToInt16(txtCustomerId.Text));
       
        }
    }
}
