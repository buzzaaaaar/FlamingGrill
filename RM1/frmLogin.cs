using RM1.Model;
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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(MainClass1.IsValidUser(txtUser.Text,txtPass.Text)==false)
            {
                MessageBox.Show("invalid Username or Password");
                return;
            }
            else
            {
                this.Hide();
                frmMain frm = new frmMain();
                frm.Show();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {

            this.Hide();
            frmWelcome frm = new frmWelcome();
            frm.Show();

        }
    }
}
