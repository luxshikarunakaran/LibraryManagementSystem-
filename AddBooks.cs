using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem_
{
    public partial class AddBooks : Form
    {
        public AddBooks()
        {
            InitializeComponent();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (txtbId.Text != "" &&
                txtbookname.Text != "" &&
                 txtauthorname.Text != "" &&
                 txtpublication.Text != "" &&
                 txtprice.Text != "" &&
                 txtquantity.Text != "")
            {


                Int64 BId = Convert.ToInt64(txtbId.Text);
                String BookName = txtbookname.Text;
                String Author = txtauthorname.Text;
                String Publication = txtpublication.Text;
                String PubDate = dateTimePickerpurchaseDate.Text;
                Int64 Price = Convert.ToInt64(txtprice.Text);
                Int64 Quantity = Convert.ToInt64(txtquantity.Text);

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = DESKTOP-5CSA9PG ; database=library_db ; integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                con.Open();
                cmd.CommandText = "insert into NewBook (BId,BookName,Author,Publication,PubDate,Price,Quantity) values('" + BId + "','" + BookName + "','" + Author + "','" + Publication + "','" + PubDate + "','" + Price + "','" + Quantity + "')";
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Data Saved Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtbookname.Clear();
                txtauthorname.Clear();
                txtpublication.Clear();
                dateTimePickerpurchaseDate.Value = DateTime.Today;
                txtprice.Clear();
                txtquantity.Clear();
            }
            else
            {
                MessageBox.Show("Empty Filed Not Allowed!","Warning",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Your unsaved Datas will Delete", "Are you sure?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
