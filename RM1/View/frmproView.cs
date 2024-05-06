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
    public partial class frmproView : SampleView
    {
        public frmproView()
        {
            InitializeComponent();
        }

        private void frmproView_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'rMDataSet5.products' table. You can move, or remove it, as needed.
            this.productsTableAdapter2.Fill(this.rMDataSet5.products);

            GetDate();
        }
        public void GetDate()
        {
            string qry = "SELECT pID, pName, pPrice, CategoryID, c.catName FROM products p INNER JOIN category c ON c.catID = p.CategoryID WHERE pName LIKE '%" + txtSearch.Text + "%'";
            ListBox lb = new ListBox();
            lb.Items.Add(dgvid);
            lb.Items.Add(dgvName);
            lb.Items.Add(dgvPrice);
            lb.Items.Add(dgvcatID);
            lb.Items.Add(dgvcatName);

            MainClass1.LoadData(qry, guna2DataGridView2, lb);
        }

        private void frmcatView_Load(object sender, EventArgs e)
        {
           
            GetDate();
        }
        public override void btnAdd_Click(object sender, EventArgs e)
        {
            frmproAdd frm = new frmproAdd();
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

        private void guna2DataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        private void guna2DataGridView2_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView2.CurrentCell.OwningColumn.Name == "dgvedit")
            {
                frmproAdd frm = new frmproAdd();
                frm.id = Convert.ToInt32(guna2DataGridView2.CurrentRow.Cells["dgvid"].Value);
                frm.cID = Convert.ToInt32(guna2DataGridView2.CurrentRow.Cells["dgvcatID"].Value);
                frm.ShowDialog();
                GetDate();
            }
            if (guna2DataGridView2.CurrentCell.OwningColumn.Name == "dgvdel")
            {


                int id = Convert.ToInt32(guna2DataGridView2.CurrentRow.Cells["dgvid"].Value);
                string qry = "Delete from products where pID = " + id + "";
                Hashtable ht = new Hashtable();
                MainClass1.SQL(qry, ht);

                MessageBox.Show("Deleted successfully");
                GetDate();
            }
        }
    }
}

