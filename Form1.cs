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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
        private void txtusername_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtusername.Text == "Username")
            {
                txtusername.Clear();
            }
        }

        private void txtpassword_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtpassword.Text == "Password")
            {
                txtpassword.Clear();
                txtpassword.PasswordChar= '*';  
            }
        }

        private void pictureBoxYoutube_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/");
        }

        private void pictureBoxInstagram_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.instagram.com/");
        }

        private void pictureBoxfacebook_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://web.facebook.com/?_rdc=1&_rdr");
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = DESKTOP-5CSA9PG ; database=library_db ; integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from LoginnTable where Username = '" + txtusername.Text + "' and Password='" + txtpassword.Text + "'";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count != 0)
            {
                this.Hide();
                Dashboard dsa = new Dashboard();
                dsa.Show();
            }
            else
            {
                MessageBox.Show("Wrong Username or Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }

        private void btnsignup_Click(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection();
            //con.ConnectionString = "data source = DESKTOP-5CSA9PG ; database=library_db ; integrated security=True";
            //SqlCommand cmd = new SqlCommand();
            //cmd.Connection = con;

            //SqlDataReader dr=new SqlDataReader();
            
            //dr = cmd.ExecuteReader();


            //if (txtpassword.Text != string.Empty ||  txtusername.Text != string.Empty)
            //    {
            //        if (txtpassword.Text == txtpassword.Text)
            //        {
            //            cmd = new SqlCommand("select * from LoginnTable where Username='" + txtusername.Text + "'", con);
            //            dr = cmd.ExecuteReader();
            //            if (dr.Read())
            //            {
            //                dr.Close();
            //                MessageBox.Show("Username Already exist please try another ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            }
            //            else
            //            {
            //                dr.Close();
            //                cmd = new SqlCommand("insert into LoginTable values(@Username,@Password)", con);
            //                cmd.Parameters.AddWithValue("Username", txtusername.Text);
            //                cmd.Parameters.AddWithValue("Password", txtpassword.Text);
            //                cmd.ExecuteNonQuery();
            //                MessageBox.Show("Your Account is created . Please login now.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            }
            //        }
            //        else
            //        {
            //            MessageBox.Show("Please enter password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("Please enter value in all field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //} 
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You sure you want to Exit", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
