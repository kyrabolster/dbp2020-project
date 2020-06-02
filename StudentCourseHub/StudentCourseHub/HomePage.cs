using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentCourseHub
{
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            Splash mySplash = new Splash();
            Login myLogin = new Login();

            mySplash.ShowDialog();

            if (mySplash.DialogResult != DialogResult.OK)
            {
                this.Close();
            }
            else
            {
                myLogin.ShowDialog();
            }

            if (myLogin.DialogResult == DialogResult.OK)
            {
                this.Show();
            }
            else
            {
                this.Close();
            }
        }

        private void coursesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Courses resultsForm = new Courses();
            resultsForm.Show();
        }
    }
}
