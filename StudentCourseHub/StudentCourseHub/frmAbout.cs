using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/* 
* Kyra Bolster
*  Database Programming - Final Project
*  June 7, 2020
*/

namespace StudentCourseHub
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {
            try
            {
                label2.Text = Application.ProductName;
                label3.Text = "Version" + Application.ProductVersion;
                label4.Text = Application.CompanyName;
                label5.Text = "StudentCourseHub is a platform for managing Courses, Students, Classlists, and Course Selection.";

                ((MDIHome)this.MdiParent).StatusStipLabel.Text = "About StudentCourseHub";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }

        }


    }
}
