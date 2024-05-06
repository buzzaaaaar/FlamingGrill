using RM1.Model;
using RM1.View;
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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        public  void AddControls(Form f)
        {
            CenterPanel.Controls.Clear();
            f.Dock = DockStyle.Fill;
            f.TopLevel = false;
            CenterPanel.Controls.Add(f);
            f.Show();


        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            AddControls(new frmcatView());
            
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            AddControls(new frmproView());
        }
        private int clickCount;
        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            {
                clickCount++;
                if (clickCount == 3)
                {
                    clickCount = 0;
                    frmOpen form1 = new frmOpen();
                    form1.Show();
                    this.Hide();
                }
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            frmWelcome form1 = new frmWelcome();
            form1.Show();
            this.Hide();
        }
    }
}
