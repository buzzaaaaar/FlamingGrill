﻿using System;
using System.CodeDom.Compiler;
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
using System.Xml.Linq;

namespace RM1.Model
{
    public partial class frmproAdd : SampleAdd
    {
        public frmproAdd()
        {
            InitializeComponent();
        }
        public int id = 0;
        public int cID = 0;

        

        private void frmproAdd_Load(object sender, EventArgs e)
        {
            string qry = "select catID 'id',catName 'name' from category  ";
            MainClass1.CBFill(qry,cbCat);

            if (cID > 0)
            {
                cbCat.SelectedValue = cID;
            }

            if (id > 0)
            {
                ForUpdateLoadData();
            }
        }
        string filePath;
        Byte[]imageByteArray;
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images(.jpg, .png)|* .png; *.jpg";
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                filePath = ofd.FileName;
                txtImage.Image = new Bitmap(filePath);
            }

        }
        public override void btnSave_Click(object sender, EventArgs e)
        {
            string qry = "";
            if (id == 0)
            {
                qry = "insert into products values(@Name ,@price,@cat,@img)";
            }
            else
            {
                qry = "update products set pName =@Name, pPrice = @price, CategoryID =@cat,pImage=@img where pID =@id";
            }

            Image temp = new Bitmap(txtImage.Image);
            MemoryStream ms = new MemoryStream();
            temp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            imageByteArray = ms.ToArray();

            Hashtable ht = new Hashtable();
            ht.Add("@id", id);
            ht.Add("@Name", txtName.Text);
            ht.Add("@price",txtPrice.Text);
            ht.Add("@cat",Convert.ToInt32(cbCat.SelectedValue));
            ht.Add("@img", imageByteArray);

            if (MainClass1.SQL(qry, ht) > 0)
            {
                MessageBox.Show("Saved Successfully..");
                id = 0;
                cID = 0;    
                txtName.Text = "";
                txtPrice.Text = "";
                cbCat.SelectedIndex = 0;
                cbCat.SelectedIndex = 0;
                txtImage.Image = RM1.Properties.Resources.product_29;
                txtName.Focus();
            }
        }

        private void ForUpdateLoadData() 
        {
            string qry = @"select * from products where pid = " + id + "";
            SqlCommand cmd = new SqlCommand(qry, MainClass1.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if(dt.Rows.Count > 0)
            {
                txtName.Text = dt.Rows[0]["pName"].ToString();
                txtPrice.Text = dt.Rows[0]["pPrice"].ToString();

                Byte[] imageArray = (byte[])(dt.Rows[0]["pImage"]);
                byte[] imageByteArray = imageArray;
                txtImage.Image = Image.FromStream(new MemoryStream(imageArray));
            }
        }
    }
}
