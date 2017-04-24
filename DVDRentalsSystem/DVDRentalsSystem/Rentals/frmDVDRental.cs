using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVDRentalsSystem
{
    public partial class frmDVDRental : Form
    {
        private int customerID;  
        private ArrayList dvdArrayList = new ArrayList();
        private int[] dvdArray = new int[10];
        private decimal totalPrice;
        private frmMenu menu;
        private Boolean searchClick = false;
        private decimal price;

        public frmDVDRental()
        {
            InitializeComponent();
        }

        public frmDVDRental(frmMenu Menu)
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

        private void btnSearchCustomer_Click(object sender, EventArgs e)
        {

            grdCustomers.DataSource = Customers.getCustomers(txtSearchCustomer.Text).Tables["ss"];            

        }

        private void grdCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.grdCustomers.Rows[e.RowIndex];
            
            customerID = Convert.ToInt32(row.Cells[0].Value);
        }

        private void btnDVDidSearch_Click(object sender, EventArgs e)
        {
            if (txtSearchDVDId.Text == "" || txtSearchDVDId.Text == " ")
            {
                MessageBox.Show("Please enter a valid DVDId", "Confirmation",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                searchClick = false;

                txtSearchDVDId.Focus();
            }
            else
            {
                searchClick = true;

                DataTable dt = DVDs.getDVD(Convert.ToInt16(txtSearchDVDId.Text)).Tables["ss"];

                try
                {
                    DataRow drCurrent = dt.Rows[0];

                    txtDVDId.Text = drCurrent["DVDId"].ToString();
                    txtTitle.Text = drCurrent["Title"].ToString();
                    cboGenre.SelectedIndex = (Convert.ToInt16(drCurrent["GenreId"]) - 1);
                    cboAgeRating.SelectedIndex = (Convert.ToInt16(drCurrent["AgeRatingId"]) - 1);
                    cboPriceCatagory.SelectedIndex = (Convert.ToInt16(drCurrent["RateId"]) - 1);
                }
                catch (IndexOutOfRangeException f)
                {
                    MessageBox.Show("Please enter a valid DVDId", "Confirmation",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSearchDVDId.Focus();
                } 
            }

            
        }

        private void frmDVDRental_Load(object sender, EventArgs e)
        {
            dvdArrayList.Cast<int>();

            for (int i = 1; i <= 7; i++)
            {
                cboNumOfDays.Items.Add(i);
            }

            cboNumOfDays.SelectedIndex = 0;

            grdDVDBasket.Columns.Add("columnTitle", "Title");
            grdDVDBasket.Columns.Add("columnPrice", "Price");

            cboGenre.ValueMember = "Genre";
            cboGenre.DataSource = DVDs.getGenreList().Tables["ss"];

            cboAgeRating.ValueMember = "AgeRating";
            cboAgeRating.DataSource = DVDs.getAgeRatingList().Tables["ss"];

            cboPriceCatagory.ValueMember = "Description";
            cboPriceCatagory.DataSource = DVDs.getPriceCatagorys().Tables["ss"];
            clearData();
        }

        public void clearData()
        {
            txtSearchDVDId.Text = "";
            txtSearchCustomer.Text = "";
            txtDVDId.Text = "";
            txtTitle.Text = "";
            cboAgeRating.SelectedIndex = -1;
            cboGenre.SelectedIndex = -1;
            cboPriceCatagory.SelectedIndex = -1;
            cboNumOfDays.SelectedIndex = 0;
        }

        private void btnAddToBasket_Click(object sender, EventArgs e)
        {
            if (searchClick)
            {
                searchClick = false;
                            
                if (!linearSearch(Convert.ToInt16(txtDVDId.Text)))
                {
                   
                    int number = Convert.ToInt16(txtDVDId.Text);

                    price = Rentals.getPrice((cboPriceCatagory.SelectedIndex) + 1);
                    DataGridViewRow row = (DataGridViewRow)grdDVDBasket.Rows[0].Clone();
                    row.Cells[0].Value = txtTitle.Text;
                    row.Cells[1].Value = Math.Round(price, 2, MidpointRounding.ToEven);
                    dvdArrayList.Add(number);

                    grdDVDBasket.Rows.Add(row);
                    totalPrice += price;
                    int numOfDays = Convert.ToInt16(cboNumOfDays.Text);
                    txtTotalPrice.Text = (totalPrice * numOfDays).ToString("00.00");
                    clearData();
                }
                else
                {
                    MessageBox.Show("Please Select a Different DVD", "Confirmation",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSearchDVDId.Focus();
                }
            }
            else
            {
                MessageBox.Show("Please Select a DVD", "Confirmation",
                     MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSearchDVDId.Focus();
            }  
        }

        private void btnRent_Click(object sender, EventArgs e)
        {
            Rentals rental = new Rentals();
            DateTime today = DateTime.Now;
            DateTime dueDate = today.AddDays(Convert.ToInt16(cboNumOfDays.Text));
            string todayDate = String.Format("{0:dd-MMM-yy}", today);
            string dueDateDate = String.Format("{0:dd-MMM-yy}", dueDate);

            rental.setCost(totalPrice);
            rental.setCustomerId(customerID);
            rental.setDVDList(dvdArrayList);
            rental.setDateFrom(todayDate);
            rental.setDateDue(dueDateDate);

            rental.rentDVD();

            MessageBox.Show("DVDs have been Rented!", "Confirmation",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            grdDVDBasket.Rows.Clear();
        }

        public Boolean linearSearch(int dvdid)
        {
            Boolean result = false;

            for (int i = 0; i < dvdArrayList.Count; i++)
            {
                if (dvdArrayList.Contains(dvdid))
                {
                    return true;
                }
                
            }

            return result;
        }

        private void cboNumOfDays_SelectedIndexChanged(object sender, EventArgs e)
        {
            int numOfDays = Convert.ToInt16(cboNumOfDays.Text);
            txtTotalPrice.Text = (totalPrice * numOfDays).ToString("00.00");
        }
    }
}
