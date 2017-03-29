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
    public partial class frmDVDRemove : Form
    {
        frmMenu menu;
        public frmDVDRemove()
        {
            InitializeComponent();
        }

        public frmDVDRemove(frmMenu Menu)
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

        private void btnSearch_Click(object sender, EventArgs e)
        {

            DataTable dt = DVDs.getDVD(Convert.ToInt16(txtSearch.Text)).Tables["ss"];

            try
            {
                DataRow drCurrent = dt.Rows[0];

                txtDVDId.Text = drCurrent["DVDId"].ToString();
                txtTitle.Text = drCurrent["Title"].ToString();
                cboGenre.SelectedIndex = (Convert.ToInt16(drCurrent["GenreId"])-1);
                cboAgeRating.SelectedIndex = (Convert.ToInt16(drCurrent["AgeRatingId"])-1);
                cboPriceCatagory.SelectedIndex = (Convert.ToInt16(drCurrent["RateId"])-1);
            }
            catch(IndexOutOfRangeException f)
            {
                MessageBox.Show("Please enter a valid DVDId", "Confirmation",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSearch.Focus();
            }
            
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            DVDs DVD = new DVDs();
            DVD.removeDVD(Convert.ToInt16(txtSearch.Text));

            MessageBox.Show("DVD " + txtDVDId.Text + " Removed!", "Confirmation",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            clearData();
        }
        public void clearData()
        {
            txtSearch.Text = "";
            txtDVDId.Text = "";
            txtTitle.Text = "";
            cboAgeRating.SelectedIndex = -1;
            cboGenre.SelectedIndex = -1;
            cboPriceCatagory.SelectedIndex = -1;
        }

        private void frmDVDRemove_Load(object sender, EventArgs e)
        {
            cboGenre.ValueMember = "Genre";
            cboGenre.DataSource = DVDs.getGenreList().Tables["ss"];

            cboAgeRating.ValueMember = "AgeRating";
            cboAgeRating.DataSource = DVDs.getAgeRatingList().Tables["ss"];

            cboPriceCatagory.ValueMember = "Description";
            cboPriceCatagory.DataSource = DVDs.getPriceCatagorys().Tables["ss"];

            clearData();
        }
    }
}
