using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RM1.Model
{
    public partial class frmWelcome : Form
    {
        public frmWelcome()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            menuPOS menuPOS = new menuPOS();
            menuPOS.Show();
        }
        private int clickCount = 0;
        private void pictureBox1_Click(object sender, EventArgs e)
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
}
