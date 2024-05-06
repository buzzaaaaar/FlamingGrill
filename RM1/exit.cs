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
    public partial class exit : Form
    {
        public exit()
        {
            InitializeComponent();
        }

        private async void exit_Load(object sender, EventArgs e)
        {
            await Task.Delay(5000);

            this.Hide();
            frmWelcome FormWelcome = new frmWelcome();
            FormWelcome.Show();
        }
    }
}
