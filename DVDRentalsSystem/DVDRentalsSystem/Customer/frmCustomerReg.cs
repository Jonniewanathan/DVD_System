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
    public partial class frmCustomerReg : Form
    {
        private frmMenu menu;

        public frmCustomerReg()
        {
            InitializeComponent();
        }

        public frmCustomerReg(frmMenu Menu)
        {
            InitializeComponent();
            this.menu = Menu;
        }

        private void frmCustomerReg_Load(object sender, EventArgs e)
        {
            cboCounty.ValueMember = "County";
            cboCounty.DataSource = Customers.getCountyList().Tables["ss"];

            cboCountry.ValueMember = "Country";
            cboCountry.DataSource = Customers.getCountryList().Tables["ss"];

            cboTitle.ValueMember = "Title";
            cboTitle.DataSource = Customers.getTitlesList().Tables["ss"];

            cboCountry.SelectedIndex = 85;

            txtCustomerId.Text = Customers.nextCustNo().ToString("0000");
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Customers customer = new Customers();

            DateTime dateOfBirth = dtpDOB.Value;
            DateTime today = DateTime.Now;

            int age = today.Year - dateOfBirth.Year;
            

            if(Validation.hasDigits(txtSurname.Text))
            {
                MessageBox.Show("Surname has Digits in it\n\nPlease Re-enter", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtSurname.Focus();
            }
            else if(Validation.textIsEmpty(txtSurname.Text))
            {
                MessageBox.Show("Surname field is empty \n\nPlease enter a surname", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtSurname.Focus();
            }
            else if(Validation.hasDigits(txtForename.Text))
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
            else if(Validation.hasDigits(txtTown.Text))
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
                customer.setCustomerId(Convert.ToInt16(txtCustomerId.Text));
                customer.setEmail(txtEmail.Text);
                customer.setSurname(txtSurname.Text);
                customer.setForename(txtForename.Text);
                customer.setTitleId((cboTitle.SelectedIndex)+1);
                customer.setTown(txtTown.Text);
                customer.setPhoneNo(txtPhone.Text);
                customer.setStatus("A");
                customer.setCountryId((cboCountry.SelectedIndex)+1);
                customer.setCountyId((cboCounty.SelectedIndex)+1);
                customer.setDob(String.Format("{0:dd-MMM-yy}", dtpDOB.Value));

                try
                {
                    customer.regCustomer();
                    MessageBox.Show(txtForename.Text + " " + txtSurname.Text + " has been registered to the system", "Registered",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clearData();
                }
                catch(OracleException f)
                {
                    MessageBox.Show(f.ToString(), "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    MessageBox.Show("Email already in system\n\nPlease enter a different Email", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtEmail.Focus();
                }               
            }
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

        private void clearData()
        {
            txtCustomerId.Text = Customers.nextCustNo().ToString("0000");
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
