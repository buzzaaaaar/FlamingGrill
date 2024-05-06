using Guna.UI2.WinForms;
using RM1.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RM1.View
{
    public partial class frmcatView : SampleView
    {
        public frmcatView()
        {
            InitializeComponent();
        }
        public void GetDate()
        {
            string qry = "select * from category where catName like '%" + txtSearch.Text + "%' ";
            ListBox lb = new ListBox();
            lb.Items.Add(dgvid);
            lb.Items.Add(dgvName);

            MainClass1.LoadData(qry, guna2DataGridView1,lb);
        }

        private void frmcatView_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'rMDataSet.category' table. You can move, or remove it, as needed.
            this.categoryTableAdapter.Fill(this.rMDataSet.category);
            GetDate();
        }
        public override void btnAdd_Click(object sender, EventArgs e)
        {
            frmcatAdd frm = new frmcatAdd();
            frm.ShowDialog();
            GetDate();
        }


        public override void txtSearch_TextChanged(object sender, EventArgs e)
        {
            GetDate();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvedit")
            {
                frmcatAdd frm = new frmcatAdd();
                frm.id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);
                frm.txtName.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvName"].Value);
                frm.ShowDialog();
                GetDate();
            }
            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvdel")
            {


                int id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);
                string qry = "Delete from category where catID = " + id + "";
                Hashtable ht = new Hashtable();
                MainClass1.SQL(qry,ht);

                MessageBox.Show("Deleted successfully");
                GetDate();
            }

        }
    }
}
