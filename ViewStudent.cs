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
    public partial class ViewStudent : Form
    {
        public ViewStudent()
        {
            InitializeComponent();
        }

      

        private void btnreferesh_Click(object sender, EventArgs e)
        {
            txtStuName1.Clear();
            txtenrollNo.Clear();
            txtEntrollNo1.Clear();
            txtdepartment1.Clear();
            txtSemester1.Clear();
            txtcontact1.Clear();
            txtemail1.Clear();
        }

        private void txtenrollNo_TextChanged(object sender, EventArgs e)
        {
            if (txtenrollNo.Text != "")
            {
                lblview.Visible = false;
                Image image = Image.FromFile("C:\\Users\\Lux\\Pictures\\Liberay Management System\\search1.gif");
                pictureBox1.Image = image;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = DESKTOP-5CSA9PG ; database=library_db ; integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from NewStudent where EnrollNo LIKE '" + txtenrollNo.Text + "%'";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView11.DataSource = ds.Tables[0];
            }
            else
            {
                lblview.Visible = true;
                Image image = Image.FromFile("C:\\Users\\Lux\\Pictures\\Liberay Management System\\search.gif");
                pictureBox1.Image = image;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = DESKTOP-5CSA9PG ; database=library_db ; integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from NewStudent";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView11.DataSource = ds.Tables[0];
            }
        }

        private void ViewStudent_Load(object sender, EventArgs e)
        {
            panel21.Visible = false;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = DESKTOP-5CSA9PG ; database=library_db ; integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from NewStudent";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView11.DataSource = ds.Tables[0];
        }

       
        private void btnupdate1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data will be Updated. Confirm?", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
               // Int64 SId = Convert.ToInt64(txtSId.Text);
                String StudentName = txtStuName1.Text;
                String EnrollNo = txtEntrollNo1.Text;
                String Department = txtdepartment1.Text;
                String Semester = txtSemester1.Text;
                Int64 Contact = Convert.ToInt64(txtcontact1.Text);
                String Email = txtemail1.Text;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = DESKTOP-5CSA9PG ; database=library_db ; integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "update NewStudent set StudentName='" + StudentName + "', EnrollNo='" +EnrollNo+ "',Department='" + Department + "',Semester='" + Semester + "',ContactNo='" + Contact + "',Email='" + Email + "' where SId='" + rowid + "'";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                ViewStudent_Load(this, null);
            }
        }


        int SId;
        Int64 rowid;
        private void dataGridView11_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView11.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                SId = int.Parse(dataGridView11.Rows[e.RowIndex].Cells[0].Value.ToString());
                //  MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            panel21.Visible = true;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = DESKTOP-5CSA9PG ; database=library_db ; integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from NewStudent where SId='" + SId + "'";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);


            rowid = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());

            txtStuName1.Text = ds.Tables[0].Rows[0][1].ToString();
            txtEntrollNo1.Text = ds.Tables[0].Rows[0][2].ToString();
            txtdepartment1.Text = ds.Tables[0].Rows[0][3].ToString();
            txtSemester1.Text = ds.Tables[0].Rows[0][4].ToString();
            txtcontact1.Text = ds.Tables[0].Rows[0][5].ToString();
            txtemail1.Text = ds.Tables[0].Rows[0][6].ToString();
        }


        private void btndelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data will be Deleted? Confirm?.", "Confirmation Dialog", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = DESKTOP-5CSA9PG ; database=library_db ; integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "delete from NewStudent where SId='" + rowid + "'";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                ViewStudent_Load(this, null);

            }


        }

        private void btncancel1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You sure you want to close", "Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }

        }
    }
}
