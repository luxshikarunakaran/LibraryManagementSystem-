using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem_
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to Exit?","Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
           
        }

        private void addNewBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddBooks abs = new AddBooks();
            abs.ShowDialog();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Close the Application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }

        }

        private void viewBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewBook VB = new ViewBook();
            VB.ShowDialog();
        }

        private void addStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStudent AS = new AddStudent();
            AS.ShowDialog();
        }

        private void viewStudentInFoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewStudent VSS = new ViewStudent();
            VSS.ShowDialog();
        }

        private void issueBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IssuueBook IS = new IssuueBook();
            IS.ShowDialog();
        }

        private void returnBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReturnBook1 RB = new ReturnBook1();
            RB.ShowDialog();
        }

        private void completeBookDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompleteBookDetails CBD = new CompleteBookDetails();
            CBD.ShowDialog();
        }
    }
}
