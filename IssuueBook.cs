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
    public partial class IssuueBook : Form
    {
        public IssuueBook()
        {
            InitializeComponent();
        }

        private void IssuueBook_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = DESKTOP-5CSA9PG ; database=library_db ; integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();

            cmd=new SqlCommand("select BookName from NewBook",con);
            SqlDataReader sdr=cmd.ExecuteReader();

          
            while(sdr.Read())
            {
                for(int i=0;i<sdr.FieldCount;i++)
                {
                    cmbBookName.Items.Add(sdr.GetString(i));
                }
            }
            sdr.Close();
            con.Close();
        }


        int count;
        private void btnSearchStudent_Click(object sender, EventArgs e)
        {
            if (txtenterenrollno.Text != "")
            {
                String EId=txtenterenrollno.Text;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = DESKTOP-5CSA9PG ; database=library_db ; integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from NewStudent where EnrollNo='" + EId + "'";
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet ds= new DataSet();
                DA.Fill(ds);


                //-------------------------------------------------------------------------------

                // Code to count how many books has been issued on this enrollment number


                cmd.CommandText = "select count(EnrollNo) from IRBook where EnrollNo='" + EId + "' and BookReturnDate is null";
                SqlDataAdapter DA1 = new SqlDataAdapter(cmd);
                DataSet ds1 = new DataSet();
                DA1.Fill(ds1);

                count = int.Parse(ds1.Tables[0].Rows[0][0].ToString());





                //------------------------------------------------------------------------------


                if (ds.Tables[0].Rows.Count != 0)
                {
                    txtSId.Text= ds.Tables[0].Rows[0][0].ToString();
                    txtStuname.Text= ds.Tables[0].Rows[0][1].ToString();
                    txtdepartment.Text = ds.Tables[0].Rows[0][3].ToString();
                    txtSemester.Text = ds.Tables[0].Rows[0][4].ToString();
                    txtcontact.Text = ds.Tables[0].Rows[0][5].ToString();
                    txtemail.Text = ds.Tables[0].Rows[0][6].ToString();
                }
                else
                {
                    txtSId.Clear();
                    txtStuname.Clear();
                    txtdepartment.Clear();
                    txtSemester.Clear();
                    txtcontact.Clear();
                    txtemail.Clear();

                    MessageBox.Show("Invalid Enroll No","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }

        private void btnissueBook_Click(object sender, EventArgs e)
        {
            if (txtStuname.Text != "")
            {
                if(cmbBookName.SelectedIndex != -1 && count<=2)
                {
                    int SId=Convert.ToInt32(txtSId.Text);
                    String EnrollNo=txtenterenrollno.Text;  
                    String StudentName = txtStuname.Text;
                    String Department=txtdepartment.Text;
                    String Semester=txtSemester.Text;
                    Int64 ContactNo=Int64.Parse(txtcontact.Text);
                    String Email = txtemail.Text;
                    String BookName = cmbBookName.Text;
                    String BookIssueDate=dateTimePickerIssueDate.Text;
                  


                    String EId = txtenterenrollno.Text;
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = "data source = DESKTOP-5CSA9PG ; database=library_db ; integrated security=True";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    con.Open();

                    cmd.CommandText = "insert into IRBook (SId,EnrollNo,StudentName,Department,Semester,ContactNo,Email,BookName,BookIssueDate) values (" + SId + ",'" + EnrollNo + "','" + StudentName + "','"+ Department + "','" + Semester + "',"+ ContactNo + ",'"+ Email + "','"+ BookName + "','"+ BookIssueDate + "')";
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Book Issued", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Select Book, OR Maximum number of Book has been ISSUED ", "No Book selected", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                MessageBox.Show("Enter Valid Enrollement No", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void txtenterenrollno_TextChanged(object sender, EventArgs e)
        {
            if (txtenterenrollno.Text == "")
            {
                txtStuname.Clear();
                txtdepartment.Clear();
                txtSemester.Clear();
                txtcontact.Clear();
                txtemail.Clear();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtenterenrollno.Clear();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You sure you want to close", "Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }

        }

      
    }
}
