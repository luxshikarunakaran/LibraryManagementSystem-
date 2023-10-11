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
    public partial class ViewBook : Form
    {
        public ViewBook()
        {
            InitializeComponent();
        }

        private void ViewBook_Load(object sender, EventArgs e)
        {
            panel2.Visible=false;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = DESKTOP-5CSA9PG ; database=library_db ; integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from NewBook";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds=new DataSet();
            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];

        }

        int BId;
        Int64 rowid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                BId = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
              //  MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            panel2.Visible = true;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = DESKTOP-5CSA9PG ; database=library_db ; integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from NewBook where BId='"+BId+"'";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);


            rowid = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());

            txtbookname1.Text = ds.Tables[0].Rows[0][1].ToString();
            txtauthorname1.Text=ds.Tables[0].Rows[0][2].ToString();
            txtpublication1.Text = ds.Tables[0].Rows[0][3].ToString();
            txtPDate.Text= ds.Tables[0].Rows[0][4].ToString();
            txtprice1.Text = ds.Tables[0].Rows[0][5].ToString();
            txtquantity1.Text = ds.Tables[0].Rows[0][6].ToString();

        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            //    panel2.Visible = false;
            if (MessageBox.Show("Are You sure you want to close", "Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }
         
        }

        private void txtbookname2_TextChanged(object sender, EventArgs e)
        {
            if (txtbookname2.Text != "")
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = DESKTOP-5CSA9PG ; database=library_db ; integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from NewBook where BookName LIKE '"+txtbookname2.Text+ "%'";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = DESKTOP-5CSA9PG ; database=library_db ; integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from NewBook";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void btnreferesh_Click(object sender, EventArgs e)
        {
            txtbookname2.Clear();
            txtbookname1.Clear();
            txtauthorname1.Clear();
            txtpublication1.Clear();
            txtPDate.Clear();
            txtprice1.Clear();
            txtquantity1.Clear();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Data will be Updated. Confirm?","Success",MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.OK)
            {
                String BookName = txtbookname1.Text;
                String Author = txtauthorname1.Text;
                String Publication = txtpublication1.Text;
                String PubDate = txtPDate.Text;
                Int64 Price = Convert.ToInt64(txtprice1.Text);
                Int64 Quantity = Convert.ToInt64(txtquantity1.Text);

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = DESKTOP-5CSA9PG ; database=library_db ; integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "update NewBook set BookName='" + BookName + "', Author='" + Author + "',Publication='" + Publication + "',PubDate='" + PubDate + "',Price='" + Price + "',Quantity='" + Quantity + "' where BId='" + rowid + "'";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
            }
            

        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data will be Deleted. Confirm?", "Confirmation Dialog", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = DESKTOP-5CSA9PG ; database=library_db ; integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "delete from NewBook where BId='" + rowid + "'";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
            }
        
        }
    }
}
