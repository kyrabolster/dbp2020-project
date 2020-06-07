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
    public partial class HomeLanding : Form
    {
        public HomeLanding()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
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

    }
}
