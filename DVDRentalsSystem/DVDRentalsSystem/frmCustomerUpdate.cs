using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace DVDRentalsSystem
{
    public partial class frmCustomerUpdate : Form
    {
        frmMenu menu;

        public frmCustomerUpdate()
        {
            InitializeComponent();
        }

        public frmCustomerUpdate(frmMenu Menu)
        {
            InitializeComponent();
            this.menu = Menu;
        }

        private void frmCustomerUpdate_Load(object sender, EventArgs e)
        {
            cboCounty.ValueMember = "County";
            cboCounty.DataSource = Customers.getCountyList().Tables["ss"];

            cboCountry.ValueMember = "Country";
            cboCountry.DataSource = Customers.getCountryList().Tables["ss"];

            cboTitle.ValueMember = "Title";
            cboTitle.DataSource = Customers.getTitlesList().Tables["ss"];

            cboCountry.SelectedIndex = 85;

            txtCustomerId.Text = "0000";
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Customers customer = new Customers();

            DateTime dateOfBirth = dtpDOB.Value;
            DateTime today = DateTime.Now;

            int age = today.Year - dateOfBirth.Year;


            if (Validation.hasDigits(txtSurname.Text))
            {
                MessageBox.Show("Surname has Digits in it\n\nPlease Re-enter", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtSurname.Focus();
            }
            else if (Validation.textIsEmpty(txtSurname.Text))
            {
                MessageBox.Show("Surname field is empty \n\nPlease enter a surname", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtSurname.Focus();
            }
            else if (Validation.hasDigits(txtForename.Text))
            {
                MessageBox.Show("Forename has Digits in it\n\nPlease Re-enter", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtForename.Focus();
            }
            else if (age < 16)
            {
                MessageBox.Show("Age must be over 16\n\nPlease re-enter a date of birth", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

                dtpDOB.Focus();
            }
            else if (!Validation.isEmail(txtEmail.Text))
            {
                MessageBox.Show("Not an Email\n\nPlease enter a valid Email", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtEmail.Focus();
            }
            else if (!Validation.allDigits(txtPhone.Text))
            {
                MessageBox.Show("Phone has to be all Digits in it\n\nPlease Re-enter", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtPhone.Focus();
            }
            else if (Validation.textIsEmpty(txtTown.Text))
            {
                MessageBox.Show("Town field is empty \n\nPlease enter a Town", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtTown.Focus();
            }
            else if (Validation.hasDigits(txtTown.Text))
            {
                MessageBox.Show("Town has Digits in it\n\nPlease Re-enter", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtTown.Focus();
            }
            else if (Validation.textIsEmpty(txtAddress1.Text))
            {
                MessageBox.Show("Addreess1 field is empty \n\nPlease enter an Address1", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtAddress1.Focus();
            }
            else if (Validation.hasDigits(txtAddress2.Text))
            {
                MessageBox.Show("Addreess2 field contains digits\n\nPlease enter an Address2 without digits", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtAddress1.Focus();
            }
            else
            {
                customer.setAddress1(txtAddress1.Text);
                customer.setAddress2(txtAddress2.Text);
                customer.setCustomerId(Convert.ToInt32(txtCustomerId.Text));
                customer.setEmail(txtEmail.Text);
                customer.setSurname(txtSurname.Text);
                customer.setForename(txtForename.Text);
                customer.setTitleId((cboTitle.SelectedIndex) + 1);
                customer.setTown(txtTown.Text);
                customer.setPhoneNo(txtPhone.Text);
                customer.setStatus("A");
                customer.setCountryId((cboCountry.SelectedIndex) + 1);
                customer.setCountyId((cboCounty.SelectedIndex) + 1);
                customer.setDob(String.Format("{0:dd-MMM-yy}", dtpDOB.Value));

                try
                {
                    customer.updateCustomer(Convert.ToInt32(txtCustomerId.Text));
                    clearData();
                }
                catch (OracleException f)
                {
                    MessageBox.Show(f.ToString(), "Validation",MessageBoxButtons.OK, MessageBoxIcon.Information);

                    MessageBox.Show("Email already in system\n\nPlease enter a different Email", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtEmail.Focus();
                }
            }
        }

        private void clearData()
        {
            txtCustomerId.Text = "0000";
            txtAddress1.Text = "";
            txtAddress2.Text = "";
            txtEmail.Text = "";
            txtForename.Text = "";
            txtSurname.Text = "";
            txtPhone.Text = "";
            txtTown.Text = "";

            cboCountry.SelectedIndex = 85;
            cboCounty.SelectedIndex = 0;
            cboTitle.SelectedIndex = 0;

        }
    }
}
