using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RM1
{
    public partial class frmOpen : Form
    {
        public frmOpen()
        {
            InitializeComponent();
        }

        private void btnPassOne_Click(object sender, EventArgs e)
        {
            txtPassword.Text += "1";
        }

        private void btnPassTwo_Click(object sender, EventArgs e)
        {
            txtPassword.Text += "2";
        }

        private void btnPassThree_Click(object sender, EventArgs e)
        {
            txtPassword.Text += "3";
        }

        private void btnPassFour_Click(object sender, EventArgs e)
        {
            txtPassword.Text += "4";
        }

        private void btnPassFive_Click(object sender, EventArgs e)
        {
            txtPassword.Text += "5";
        }

        private void btnPassSix_Click(object sender, EventArgs e)
        {
            txtPassword.Text += "6";
        }

        private void btnPassSeven_Click(object sender, EventArgs e)
        {
            txtPassword.Text += "7";
        }

        private void btnPassEig_Click(object sender, EventArgs e)
        {
            txtPassword.Text += "8";
        }

        private void btnPassNine_Click(object sender, EventArgs e)
        {
            txtPassword.Text += "9";
        }

        private void btnPassZero_Click(object sender, EventArgs e)
        {
            txtPassword.Text += "0";
        }

        private void btnPassClear_Click(object sender, EventArgs e)
        {
            txtPassword.Text = "";
        }

        private void btnPassDone_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == "1234")
            {
                this.Hide();
                frmMain mainForm = new frmMain();
                mainForm.Show();
            }
        }
    }
}
