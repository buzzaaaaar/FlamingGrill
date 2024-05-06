using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RM1.Model
{
    public partial class menuPOS : Form
    {
        public menuPOS()
        {
            InitializeComponent();
        }
        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmOpen frm = new frmOpen();
            frm.Show();
        }

        private void menuPOS_Load(object sender, EventArgs e)
        {
            guna2DataGridView2.BorderStyle = BorderStyle.FixedSingle;
            AddCategory();

            ProductPanel.Controls.Clear();
            LoadProducts();
        }

        private void AddCategory()
        {
            string qry = "select * from category ";
            SqlCommand cmd = new SqlCommand(qry,MainClass1.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            CategoryPanel.Controls.Clear();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Guna.UI2.WinForms.Guna2Button b = new Guna.UI2.WinForms.Guna2Button();
                    b.FillColor = Color.FromArgb(50, 55, 89);
                    b.Size = new Size(197, 45);
                    b.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
                    b.Text = row["catName"].ToString();

                    b.Click += new EventHandler(_Click);

                    CategoryPanel.Controls.Add(b);
                }
            }
        }

        private void _Click(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2Button b = (Guna.UI2.WinForms.Guna2Button)sender;
            foreach(var item in ProductPanel.Controls)
            {
                var pro = (ucPro)item;
                pro.Visible = pro.PCetagory.ToLower().Contains(b.Text.Trim().ToLower());
            }
        }

        private void AddItems(string id, string name, string cat, string price, Image pimage)
        {
            var w = new ucPro()
            {
                PName = name,
                PPrice = price,
                PCetagory = cat,
                PImage = pimage,
                id = Convert.ToInt32(id)

            };

            ProductPanel.Controls.Add(w);

            w.onSelect += (ss, ee) =>
            {
                var wdg = (ucPro)ss;

                foreach (DataGridViewRow item in guna2DataGridView2.Rows)
                {
                    if (Convert.ToInt32(item.Cells["dgvid"].Value) == wdg.id)
                    {
                        item.Cells["dgvQty"].Value = int.Parse(item.Cells["dgvQty"].Value.ToString())+1;
                        item.Cells["dgvAmount"].Value = int.Parse(item.Cells["dgvQty"].Value.ToString()) *
                                                           double.Parse(item.Cells["dgvPrice"].Value.ToString());
                        return;
                    }

                   

                }
                guna2DataGridView2.Rows.Add(new object[] { 0, wdg.id, wdg.PName, 1, wdg.PPrice, wdg.PPrice });
                GetTotal();
            };
           
        }

        private void LoadProducts()
        {
            string qry = "select * from products INNER JOIN category  ON catID = CategoryID";
            SqlCommand cmd = new SqlCommand(qry, MainClass1.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach (DataRow item in dt.Rows)
            {
                Byte[] imagearray = (byte[])item["pImage"];
                byte[] imagebytearray = imagearray;

                AddItems(item["pID"].ToString(), item["pName"].ToString(), item["catName"].ToString(),
                                                  item["pPrice"].ToString(),Image.FromStream(new MemoryStream(imagearray)));
            }
        }

        private void guna2DataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            int count = 0;

            foreach(DataGridViewRow row in guna2DataGridView2.Rows)
            {
                count++;
                row.Cells[0].Value = count;
            }
        }

        private void GetTotal()
        {
            double tot = 0;
            lblTotal.Text = "";
            foreach(DataGridViewRow item in guna2DataGridView2.Rows)
            {
                tot += double.Parse(item.Cells["dgvAmount"].Value.ToString());

            }
            lblTotal.Text = tot.ToString("N2");

        }

        private void guna2DataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == guna2DataGridView2.Columns["dgvdel"].Index && e.RowIndex >= 0)
            {
                DataGridViewRow row = guna2DataGridView2.Rows[e.RowIndex];
                guna2DataGridView2.Rows.Remove(row);
                GetTotal();
            }
        }

        private void ProductPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            this.Hide();
            check_out checkoutForm = new check_out();
            checkoutForm.Show();
            Random rnd = new Random();
            int randomNumber = rnd.Next(10, 100);
            checkoutForm.lblCheckTotal.Text = lblTotal.Text;
            checkoutForm.label3.Text = randomNumber.ToString();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FAQ frm = new FAQ();
            frm.Show();
        }
    }
}
