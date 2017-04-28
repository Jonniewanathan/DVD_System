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
        private ArrayList prices = new ArrayList();
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
            //Populate gridview with customers
            grdCustomers.DataSource = Customers.getCustomers(txtSearchCustomer.Text).Tables["ss"];            

        }

        private void grdCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            //Stores the customerId for use later
            DataGridViewRow row = this.grdCustomers.Rows[e.RowIndex];
            
            customerID = Convert.ToInt32(row.Cells[0].Value);

            txtCustomerID.Text = customerID.ToString("0000");
            txtCustomerName.Text = row.Cells[2].Value.ToString().TrimEnd() + " " + row.Cells[3].Value.ToString().TrimEnd();
        }

        private void btnDVDidSearch_Click(object sender, EventArgs e)
        {

            //checks if a customer is selected
            if (customerID != 0)
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
            else
            {
                MessageBox.Show("Please select a Customer", "Confirmation",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSearchDVDId.Focus();
            }

            

            
        }

        private void frmDVDRental_Load(object sender, EventArgs e)
        {
            //casts the array list to an int
            dvdArrayList.Cast<int>();

            //populates the combo box with numbers 1 to 7
            for (int i = 1; i <= 7; i++)
            {
                cboNumOfDays.Items.Add(i);
            }

            
            cboNumOfDays.SelectedIndex = 0;
            grdDVDBasket.Columns.Add("columnDVDId", "DVDId");
            grdDVDBasket.Columns.Add("columnTitle", "Title");
            grdDVDBasket.Columns.Add("columnPrice", "Price");

            //Populate the combo boxes
            cboGenre.ValueMember = "Genre";
            cboGenre.DataSource = DVDs.getGenreList().Tables["ss"];

            cboAgeRating.ValueMember = "AgeRating";
            cboAgeRating.DataSource = DVDs.getAgeRatingList().Tables["ss"];

            cboPriceCatagory.ValueMember = "Description";
            cboPriceCatagory.DataSource = DVDs.getPriceCatagorys().Tables["ss"];

            //Resets elements back to default
            clearData();
        }

        //Resets form elements back to default
        public void clearData()
        {
            txtSearchDVDId.Text = "";
            txtSearchCustomer.Text = "";
            txtDVDId.Text = "";
            txtTitle.Text = "";
            cboAgeRating.SelectedIndex = -1;
            cboGenre.SelectedIndex = -1;
            cboPriceCatagory.SelectedIndex = -1;
        }

        private void btnAddToBasket_Click(object sender, EventArgs e)
        {
            //checks if a dvd has been selected
            if (searchClick)
            {
                searchClick = false;
                 
                //checking if a dvd has already been added to the basket           
                if (!linearSearch(Convert.ToInt16(txtDVDId.Text)))
                {
                    int number = Convert.ToInt16(txtDVDId.Text);

                    price = Rentals.getPrice((cboPriceCatagory.SelectedIndex) + 1);
                    DataGridViewRow row = (DataGridViewRow)grdDVDBasket.Rows[0].Clone();
                    row.Cells[0].Value = txtDVDId.Text;
                    row.Cells[1].Value = txtTitle.Text;
                    row.Cells[2].Value = Math.Round(price, 2, MidpointRounding.ToEven);
                    dvdArrayList.Add(number);

                    grdDVDBasket.Rows.Add(row);
                    prices.Add(price);
                    
                    int numOfDays = Convert.ToInt16(cboNumOfDays.Text);
                    //Getting the total price
                    txtTotalPrice.Text = (totalPriceCalc(prices)*numOfDays).ToString("00.00");
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
            //checks if dvds are in the baskets
            if (dvdArrayList.Count != 0)
            {
                Rentals rental = new Rentals();
                DateTime today = DateTime.Now;
                DateTime dueDate = today.AddDays(Convert.ToInt16(cboNumOfDays.Text));
                string todayDate = String.Format("{0:dd-MMM-yy}", today);
                string dueDateDate = String.Format("{0:dd-MMM-yy}", dueDate);

                //sets all the attributes for the rental
                rental.setCost(totalPrice);
                rental.setCustomerId(customerID);
                rental.setDVDList(dvdArrayList);
                rental.setDateFrom(todayDate);
                rental.setDateDue(dueDateDate);

                rental.rentDVD();

                MessageBox.Show("DVDs have been Rented!", "Confirmation",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                grdDVDBasket.Rows.Clear();
                cboNumOfDays.SelectedIndex = 0;
                txtTotalPrice.Text = "";
                clearData();
            }
            else
            {
                MessageBox.Show("No DVDs in basket please add a DVD", "Confirmation",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //Searches through the arraylist for a specific DVDid
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

        //checks for the number of days being changed
        private void cboNumOfDays_SelectedIndexChanged(object sender, EventArgs e)
        {
            int numOfDays = Convert.ToInt16(cboNumOfDays.Text);

            //Updates the total price
            txtTotalPrice.Text = (totalPriceCalc(prices) * numOfDays).ToString("00.00");
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            //checks if a row is selected to remove
            if (grdDVDBasket.SelectedRows.Count > 0)
            {
                dvdArrayList.RemoveAt(grdDVDBasket.SelectedRows[0].Index);
                prices.RemoveAt(grdDVDBasket.SelectedRows[0].Index);
                grdDVDBasket.Rows.RemoveAt(grdDVDBasket.SelectedRows[0].Index);
                int numOfDays = Convert.ToInt16(cboNumOfDays.Text);
                txtTotalPrice.Text = (totalPriceCalc(prices) * numOfDays).ToString("00.00");
            }
            else
            {
                MessageBox.Show("Please select a Item in the basket to remove", "Confirmation",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            
        }

        //Calculates the total price using the Arraylist
        private decimal totalPriceCalc(ArrayList prices)
        {
            decimal total = 0;

            foreach (decimal price in prices)
            {
                total += price;
            }

            return total;
        }
    }
}
