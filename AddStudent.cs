using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem_
{
    public partial class AddStudent : Form
    {
        public AddStudent()
        {
            InitializeComponent();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure You want to Exit?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnrefersh_Click(object sender, EventArgs e)
        {
            txtSId.Clear();
            txtStuName.Clear();
            txtEntrollNo.Clear();
            txtdepartment.Clear();
            txtSemester.Clear();
            txtcontact.Clear();
            txtemail.Clear();
        }

      //  int SId;
        private void btnsaveInfo_Click(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(txtcontact.Text, @"^[0-9]{10}$"))
            {
                MessageBox.Show("The contact No Should be 10 digits", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (txtStuName.Text != "" &&
               txtEntrollNo.Text != "" &&
               txtdepartment.Text != "" &&
               txtSemester.Text != "" &&
               txtcontact.Text != "" &&
               txtemail.Text != "")
            {
                Int64 SId =Convert.ToInt64(txtSId.Text);
                String StudentName = txtStuName.Text;
                String EnrollNo = txtEntrollNo.Text;
                String Department = txtdepartment.Text;
                String Semester = txtSemester.Text;
                Int64 Contact = Convert.ToInt64(txtcontact.Text);
                String Email=txtemail.Text;
                

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = DESKTOP-5CSA9PG ; database=library_db ; integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                con.Open();
                cmd.CommandText = "insert into NewStudent (SId,StudentName,EnrollNo,Department,Semester,ContactNo,Email) values('" + SId + "','" + StudentName + "','" + EnrollNo + "','" + Department + "','" + Semester + "','" + Contact + "','" + Email + "')";
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Data Saved Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           
            

            else
            {
                MessageBox.Show("Empty Filed Not Allowed!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        

        private void txtcontact_Validating(object sender, CancelEventArgs e)
        {
            //Int32 contact = Convert.ToInt32(txtcontact.Text);

            //if (contact > 10)
            //{
            //    MessageBox.Show("The contact No Should be 10 digits","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            //}
            //else
            //{
            //    MessageBox.Show("The contact No Should be 10 digits", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //}
        }
    }
}
