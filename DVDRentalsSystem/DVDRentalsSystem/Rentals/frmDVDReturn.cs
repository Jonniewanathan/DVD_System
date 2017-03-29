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
    public partial class frmDVDReturn : Form
    {
        private frmMenu menu;
        private Boolean searchClick;
        private DateTime today = DateTime.Today;
        private String strdueDate;
        private DateTime dueDate;
        private string date;
        private int rentalId;
        private Rentals rental;
        private int daysOverDue;

        public frmDVDReturn()
        {
            InitializeComponent();
        }

        public frmDVDReturn(frmMenu Menu)
        {
            InitializeComponent();
            this.menu = Menu;
        }

        private void frmDVDReturn_Load(object sender, EventArgs e)
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "" || txtSearch.Text == " ")
            {
                MessageBox.Show("Please enter a valid DVDId", "Confirmation",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                searchClick = false;

                txtSearch.Focus();
            }
            else
            {
                searchClick = true;

                rental = new Rentals();

                DataTable dt = Rentals.getDVD(Convert.ToInt16(txtSearch.Text)).Tables["ss"];
                
                date = String.Format("{0:dd-MMM-yy}", today);

                try
                {
                    
                    DataRow drCurrent = dt.Rows[0];
                    
                    txtDVDId.Text = drCurrent["DVDId"].ToString();
                    txtTitle.Text = drCurrent["Title"].ToString();
                    cboGenre.SelectedIndex = (Convert.ToInt16(drCurrent["GenreId"]) - 1);
                    cboAgeRating.SelectedIndex = (Convert.ToInt16(drCurrent["AgeRatingId"]) - 1);
                    cboPriceCatagory.SelectedIndex = (Convert.ToInt16(drCurrent["RateId"]) - 1);
                    rental.setDVDId(Convert.ToInt16(txtDVDId.Text));
                    
                    DataTable dtR = rental.getRentals().Tables["ss"];
                    DataRow drRentals = dtR.Rows[0];

                    strdueDate = drRentals["DATEDUE"].ToString();
                    dueDate = Convert.ToDateTime(strdueDate);
                    rentalId = Convert.ToInt16(drRentals["RENTALSID"]);
                    TimeSpan overDue = today - dueDate;
                    daysOverDue = Convert.ToInt16(overDue.TotalDays);

                    

                    if (daysOverDue < 0)
                    {
                        txtAmount.Text = "00.00";
                        txtDaysOver.Text = "0";
                    }                
                    else if (daysOverDue == 0)
                    {
                        txtAmount.Text = "00.00";
                        txtDaysOver.Text = "0";
                    }
                    else
                    {
                        txtDaysOver.Text = daysOverDue.ToString();
                        decimal price = Rentals.getPrice(Convert.ToInt16(drCurrent["RateId"]));
                        price *= daysOverDue;

                        txtAmount.Text = price.ToString("00.00");
                    }

                    rental.setDateReturned(date);
                    
                    
                }
                catch (IndexOutOfRangeException f)
                {
                    MessageBox.Show("Please enter a valid DVDId", "Confirmation",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSearch.Focus();
                }
            }
        }

        public void clearData()
        {
            txtSearch.Text = "";
            txtDVDId.Text = "";
            txtTitle.Text = "";
            txtDaysOver.Text = "";
            txtAmount.Text = "";
            cboAgeRating.SelectedIndex = -1;
            cboGenre.SelectedIndex = -1;
            cboPriceCatagory.SelectedIndex = -1;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {

            rental.returnDVD();
            MessageBox.Show("DVD has been returned", "Confirmation",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtSearch.Focus();

            clearData();
        }
    }
}
