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
    }
}
