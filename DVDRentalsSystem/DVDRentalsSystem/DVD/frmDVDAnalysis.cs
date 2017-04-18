using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVDRentalsSystem.DVD
{
    public partial class frmDVDAnalysis : Form
    {
        private frmMenu menu;

        public frmDVDAnalysis()
        {
            InitializeComponent();
        }

        public frmDVDAnalysis(frmMenu Menu)
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

        private void frmDVDAnalysis_Load(object sender, EventArgs e)
        {
            grdDVDAnalysis.DataSource = DVDs.getDVDAnalysis().Tables["ss"];
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }
    }
}
