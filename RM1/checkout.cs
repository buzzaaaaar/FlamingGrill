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
    public partial class check_out : Form
    {
        public check_out()
        {
            InitializeComponent();
        }


        private void btnPay_Click(object sender, EventArgs e)
        {
            this.Hide();
            exit exitForm = new exit();
            exitForm.Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmWelcome menuPOS = new frmWelcome();
            menuPOS.Show();
        }

        private async void btnCash_Click(object sender, EventArgs e)
        {
            lblCashPaymet.Visible = true;
            lblPaymentMethod.Visible = false;
            btnCash.Visible = false;
            btnCard.Visible = false;
            await Task.Delay(5000);

            this.Hide();
            frmCashPayment FormWelcome = new frmCashPayment();
            FormWelcome.Show();
        }

        private async void btnCard_Click(object sender, EventArgs e)
        {
            lblCardPayment.Visible = true;
            imgArrowDown.Visible = true;
            lblPaymentMethod.Visible = false;
            btnCash.Visible = false;
            btnCard.Visible = false;

            await Task.Delay(5000);

            this.Hide();
            exit FormWelcome = new exit();
            FormWelcome.Show();

        }

        private void btnDineIn_Click(object sender, EventArgs e)
        {
            lblOrderType.Visible = false;
            btnDineIn.Visible = false;
            btnTakeAway.Visible = false;
            lblPaymentMethod.Visible = true;
        }

        private void btnTakeAway_Click(object sender, EventArgs e)
        {
            lblOrderType.Visible = false;
            btnDineIn.Visible = false;
            btnTakeAway.Visible = false;
            lblPaymentMethod.Visible = true;
        }
    }
}
