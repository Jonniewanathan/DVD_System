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
        private DateTime today;

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
            //loading the combo boxes

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
            //populates the datagrid with the customers from the search
            grdCustomers.DataSource = Customers.getCustomers(txtSearch.Text).Tables["ss"];
        }

        private void grdCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
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
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
            Customers customer = new Customers();

            DateTime dateOfBirth = dtpDOB.Value;
            today = DateTime.Now;

            int age = today.Year - dateOfBirth.Year;

            //validation

            if (txtCustomerId.Text == "0000")
            {
                MessageBox.Show("Please select a customer to update", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (Validation.hasDigits(txtSurname.Text))
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
            else if (Validation.textIsEmpty(txtForename.Text))
            {
                MessageBox.Show("Forename field is empty \n\nPlease enter a forename", "Validation",
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
            else if (Validation.textIsEmpty(txtPhone.Text))
            {
                MessageBox.Show("Phone no. field is empty\n\nPlease enter a Phone Number", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtPhone.Focus();
            }
            else if (!Validation.allDigits(txtPhone.Text))
            {
                MessageBox.Show("Phone has to be all Digits in it\n\nPlease Re-enter", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtPhone.Focus();
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

                txtAddress2.Focus();
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
            else
            {
                customer.setAddress1(txtAddress1.Text.ToUpper());
                customer.setAddress2(txtAddress2.Text.ToUpper());
                customer.setCustomerId(Convert.ToInt32(txtCustomerId.Text));
                customer.setEmail(txtEmail.Text.ToLower());
                customer.setSurname(txtSurname.Text.ToUpper());
                customer.setForename(txtForename.Text.ToUpper());
                customer.setTitleId((cboTitle.SelectedIndex) + 1);
                customer.setTown(txtTown.Text.ToUpper());
                customer.setPhoneNo(txtPhone.Text.ToUpper());
                customer.setStatus("A");
                customer.setCountryId((cboCountry.SelectedIndex) + 1);
                customer.setCountyId((cboCounty.SelectedIndex) + 1);
                customer.setDob(String.Format("{0:dd-MMM-yy}", dtpDOB.Value));


                //checks if the email is already in the system
                try
                {
                    customer.updateCustomer(Convert.ToInt32(txtCustomerId.Text));

                    MessageBox.Show("Customer Updated!", "Updated!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

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

            dtpDOB.Text = today.ToString(); 

            cboCountry.SelectedIndex = 85;
            cboCounty.SelectedIndex = 0;
            cboTitle.SelectedIndex = 0;

        }
    }
}
