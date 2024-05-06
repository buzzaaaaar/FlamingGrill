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

namespace RM1.Model
{
    public partial class frmcatAdd : SampleAdd
    {
        public frmcatAdd()
        {
            InitializeComponent();
        }

        public int id = 0;

        public override void btnSave_Click(object sender, EventArgs e)
        {
            string qry = "";
            if (id == 0)
            {
                qry = "insert into category values(@Name)";
            }
            else
            {
                qry = "update category set catName =@Name where catID =@id";
            }
            Hashtable ht = new Hashtable();
            ht.Add("@id",id );
            ht.Add("@Name",txtName.Text);

            if (MainClass1.SQL(qry, ht) > 0)
            {
                MessageBox.Show("Saved Successfully..");
                id = 0;
                txtName.Text = ""; 
                txtName.Focus();
            }
        }
    }
}
