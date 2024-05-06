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
    public partial class FAQ : Form
    {
        public FAQ()
        {
            InitializeComponent();
        }
        public void AddControls(Form f)
        {
            CenterPanel.Controls.Clear();
            f.Dock = DockStyle.Fill;
            f.TopLevel = false;
            CenterPanel.Controls.Add(f);
            f.Show();
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            AddControls(new frmNeedHelp());
            btnNeedHelp.Checked = true;
            btnMenuItems.Checked = false;
            btnCancel.Checked = false;
            btnInfo.Checked = false;
            btnSeInfo.Checked = false;
            btnFeedback.Checked = false;
        }
        private void btnMenuItems_Click(object sender, EventArgs e)
        {
            AddControls(new frmMenuItems());
            btnNeedHelp.Checked = false;
            btnMenuItems.Checked = true;
            btnCancel.Checked = false;
            btnInfo.Checked = false;
            btnSeInfo.Checked = false;
            btnFeedback.Checked = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            AddControls(new frmCancelOrder());
            btnNeedHelp.Checked = false;
            btnMenuItems.Checked = false;
            btnCancel.Checked = true;
            btnInfo.Checked = false;
            btnSeInfo.Checked = false;
            btnFeedback.Checked = false;
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            AddControls(new frmInfo());
            btnNeedHelp.Checked = false;
            btnMenuItems.Checked = false;
            btnCancel.Checked = false;
            btnInfo.Checked = true;
            btnSeInfo.Checked = false;
            btnFeedback.Checked = false;
        }

        private void btnSeInfo_Click(object sender, EventArgs e)
        {
            AddControls(new frmSeInfo());
            btnNeedHelp.Checked = false;
            btnMenuItems.Checked = false;
            btnCancel.Checked = false;
            btnInfo.Checked = false;
            btnSeInfo.Checked = true;
            btnFeedback.Checked = false;
        }

        private void btnFeedback_Click(object sender, EventArgs e)
        {
            AddControls(new frmFeedback());
            btnNeedHelp.Checked = false;
            btnMenuItems.Checked = false;
            btnCancel.Checked = false;
            btnInfo.Checked = false;
            btnSeInfo.Checked = false;
            btnFeedback.Checked = true;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            menuPOS menuPOS = new menuPOS();
            menuPOS.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            menuPOS menuPOS = new menuPOS();
            menuPOS.Show();
        }
    }
}
