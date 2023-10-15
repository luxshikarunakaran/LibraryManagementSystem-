using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem_
{
    public partial class ReturnBook1 : Form
    {
        public ReturnBook1()
        {
            InitializeComponent();
        }

     
        private void btnSearchStudent_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = DESKTOP-5CSA9PG ; database=library_db ; integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from IRBook where EnrollNo = '"+txtEnterEnrollNo.Text+"' and BookReturnDate IS NULL";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count != 0)
            {
                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                MessageBox.Show("Invalid ID or No Book Issued","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnreturn_Click(object sender, EventArgs e)
        {
           

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = DESKTOP-5CSA9PG ; database=library_db ; integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();

            cmd.CommandText = "update IRBook set BookReturnDate='" + dateTimePickerReturnDate.Text + "' where EnrollNo='"+txtEnterEnrollNo.Text+"' and SId="+rowid+"";
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Return Succesful.","Sucess",MessageBoxButtons.OK,MessageBoxIcon.Information);

            ReturnBook1_Load(this, null);

        }


        private void ReturnBook1_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
            txtEnterEnrollNo.Clear();
        }



        String BookName;
        String BookIssueDate;
        Int64 rowid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            panel2.Visible = true;

            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                rowid = Int64.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                BookName = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                BookIssueDate = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                //  MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }

            txtBookName.Text=BookName;
            txtIssueDate.Text=BookIssueDate;

       }

       

        private void txtEnterEnrollNo_TextChanged(object sender, EventArgs e)
        {
            if (txtEnterEnrollNo.Text != "")
            {
                panel2.Visible=false;
                dataGridView1.DataSource = null;
            }
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            txtEnterEnrollNo.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You sure you want to Exit", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }

        }

        private void btncancel_Click(object sender, EventArgs e)
        {
           
            panel2.Visible = false;
        }
    }
}
