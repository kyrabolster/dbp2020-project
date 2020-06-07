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
    public partial class HomeLanding : Form
    {
        public HomeLanding()
        {
            InitializeComponent();
        }

        private void HomeLanding_Load(object sender, EventArgs e)
        {
            SetStatusStrip("Welcome to StudentCourseHub!");
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            try
            {
                Form childForm = null;
                Button btn = (Button)sender;

                switch (btn.Tag)
                {
                    case "Courses":
                        childForm = new frmCourses() { MdiParent = MdiParent };
                        break;
                    case "Students":
                        childForm = new frmStudents() { MdiParent = MdiParent };
                        break;
                    case "Instructors":
                        childForm = new frmInstructors() { MdiParent = MdiParent };
                        break;
                    case "CourseSelect":
                        childForm = new frmCourseSelect() { MdiParent = MdiParent };
                        break;
                    case "Classlist":
                        childForm = new frmClasslist() { MdiParent = MdiParent };
                        break;
                }

                if (childForm != null)
                {
                    foreach (Form f in this.MdiChildren)
                    {
                        if (f.GetType() == childForm.GetType())
                        {
                            f.Activate();
                            return;
                        }
                    }
                }

                this.Close();
                childForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        #region Status Strip
        private void SetStatusStrip(string text)
        {
            ((MDIHome)this.MdiParent).StatusStipLabel.Text = text;
        }
        #endregion

    }
}
