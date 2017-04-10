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
    public partial class frmDVDupdate : Form
    {
        frmMenu menu;
        public frmDVDupdate()
        {
            InitializeComponent();
        }

        public frmDVDupdate(frmMenu Menu)
        {
            InitializeComponent();
            this.menu = Menu;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            grdDVD.DataSource = DVDs.getDVDs(txtSearch.Text.ToUpper()).Tables["ss"];
        }
		
		//This is the method to put the items from the datagrid to the text boxes
		
        private void grdDVD_CellClick(object sender, DataGridViewCellEventArgs e)
        {          
            DataGridViewRow row = this.grdDVD.Rows[e.RowIndex];

            int dvdid = Convert.ToInt32(row.Cells[0].Value);

            txtDVDId.Text = dvdid.ToString("0000");

            txtTitle.Text = row.Cells[1].Value.ToString().Trim();
            cboAgeRating.SelectedIndex = (Convert.ToInt16(row.Cells[6].Value.ToString())-1);
            cboGenre.SelectedIndex = (Convert.ToInt16(row.Cells[7].Value.ToString())-1);
            cboPriceCatagory.SelectedIndex = (Convert.ToInt16(row.Cells[8].Value.ToString())-1);
        }

        private void frmDVDupdate_Load(object sender, EventArgs e)
        {
            cboGenre.ValueMember = "Genre";
            cboGenre.DataSource = DVDs.getGenreList().Tables["ss"];

            cboAgeRating.ValueMember = "AgeRating";
            cboAgeRating.DataSource = DVDs.getAgeRatingList().Tables["ss"];

            cboPriceCatagory.ValueMember = "Description";
            cboPriceCatagory.DataSource = DVDs.getPriceCatagorys().Tables["ss"];

            clearData();
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Validate Data
            if (Validation.textIsEmpty(txtTitle.Text))
            {
                MessageBox.Show("No Title entered!\nPlease enter one", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
   
            else if (Validation.textIsEmpty(cboGenre.Text))
            {
                MessageBox.Show("No Genre Selected!\nPlease make a selection", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else if (Validation.textIsEmpty(cboAgeRating.Text))
            {
                MessageBox.Show("No Age Rating Selected!\nPlease make a selection", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else if (Validation.textIsEmpty(cboPriceCatagory.Text))
            {
                MessageBox.Show("No PriceCatagory Selected!\nPlease make a selection", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                DVDs DVD = new DVDs();

                DVD.setTitle(txtTitle.Text.ToUpper());
                DVD.setAgeRatingId((cboAgeRating.SelectedIndex)+1);
                DVD.setGenreId((cboGenre.SelectedIndex)+1);
                DVD.setPriceCatagoryId((cboPriceCatagory.SelectedIndex)+1);
                DVD.setDvdId(Convert.ToInt16(txtDVDId.Text));


                DVD.updateDVD();

                MessageBox.Show("DVD " + txtDVDId.Text + " Updated!", "Confirmation",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                clearData();
            }
                        
        }
        public void clearData()
        {
            txtSearch.Text = "";
            txtDVDId.Text = "";
            txtTitle.Text = "";
            cboAgeRating.SelectedIndex = -1;
            cboGenre.SelectedIndex = -1;
            cboPriceCatagory.SelectedIndex = -1;
            grdDVD.DataSource = null;
        }
    }
}
