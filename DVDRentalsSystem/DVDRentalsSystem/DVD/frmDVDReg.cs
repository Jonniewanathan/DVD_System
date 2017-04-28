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
using System.Collections;

namespace DVDRentalsSystem
{

    public partial class frmDVDReg : Form
    {
        private frmMenu menu;

        public frmDVDReg()
        {
            InitializeComponent();
        }
        public frmDVDReg(frmMenu Menu)
        {
            InitializeComponent();
            this.menu = Menu;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            //Validate data
            if(Validation.textIsEmpty(txtTitle.Text))
            {
                MessageBox.Show("No Title entered!\nPlease enter one", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtTitle.Focus();
            }

            else if (Validation.textIsEmpty(cboGenre.Text))
            {
                MessageBox.Show("No Genre Selected!\nPlease make a selection", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

                cboGenre.Focus();
            }

            else if(Validation.textIsEmpty(cboAgeRating.Text))
            {
                MessageBox.Show("No Age Rating Selected!\nPlease make a selection", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

                cboAgeRating.Focus();
            }

            else if (Validation.textIsEmpty(cboPriceCatagory.Text))
            {
                MessageBox.Show("No PriceCatagory Selected!\nPlease make a selection", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

                cboPriceCatagory.Focus();
            }
            else
            {
                //Instantiate DVD Object
                DVDs DVD = new DVDs();
            
                //Set DVD values
                DVD.setDvdId(Convert.ToInt32(txtDVDId.Text));
                DVD.setTitle(txtTitle.Text);
                DVD.setAgeRatingId((cboAgeRating.SelectedIndex)+1);
                DVD.setGenreId((cboGenre.SelectedIndex)+1);
                DVD.setPriceCatagoryId((cboPriceCatagory.SelectedIndex)+1);
                DVD.setStatus("A");


                //Insert DVD to Database
                DVD.regDVD();

                MessageBox.Show("DVD " + txtDVDId.Text + " Registered", "Confirmation",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                //ResetUi
                txtTitle.Text = "";
                cboAgeRating.SelectedIndex = -1;
                cboGenre.SelectedIndex = -1;
                cboPriceCatagory.SelectedIndex = -1;

                txtDVDId.Text = DVDs.nextDVDNo().ToString("0000");
                txtTitle.Focus();
            }

        }

        private void frmDVDReg_Load(object sender, EventArgs e)
        {
            //populates the combo boxes
            cboGenre.ValueMember = "Genre";
            cboGenre.DataSource = DVDs.getGenreList().Tables["ss"];

            cboAgeRating.ValueMember = "AgeRating";
            cboAgeRating.DataSource = DVDs.getAgeRatingList().Tables["ss"];

            cboPriceCatagory.ValueMember = "Description";
            cboPriceCatagory.DataSource = DVDs.getPriceCatagorys().Tables["ss"];

            //sets from elements back default
            clearData();

            txtDVDId.Text = DVDs.nextDVDNo().ToString("0000");
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

        //Sets the details back to defualt
        public void clearData()
        {
            txtDVDId.Text = "";
            txtTitle.Text = "";
            cboAgeRating.SelectedIndex = -1;
            cboGenre.SelectedIndex = -1;
            cboPriceCatagory.SelectedIndex = -1;
        }
    }
}
