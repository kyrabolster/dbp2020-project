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
    public partial class ViewCourseStudents : Form
    {
        public ViewCourseStudents()
        {
            InitializeComponent();
        }

        private void ViewCourseStudents_Load(object sender, EventArgs e)
        {
            try
            {
                LoadCourses();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void LoadCourses()
        {
            string sqlCourses = "SELECT CourseID, CourseTitle FROM Course ORDER BY CourseTitle";
            UIUtilities.BindComboBox(cmbCourses, DataAccess.GetData(sqlCourses), "CourseTitle", "CourseID");
        }

        private void cmbCourses_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cmbCourses.SelectedIndex != 0)
                {
                    DataTable dt = DataAccess.GetData(
                            $@"SELECT Student.StudentID, Student.LastName + ', ' + Student.FirstName AS [Student Name],
	                                Student.Email
                                FROM Course
	                                INNER JOIN StudentCourse
		                                ON Course.CourseId = StudentCourse.CourseId
	                                INNER JOIN Student
		                                ON Student.StudentID = StudentCourse.StudentId
	                                WHERE Course.CourseID = {cmbCourses.SelectedValue}
	                                ORDER BY CourseTitle"
                        );

                    dgvStudents.DataSource = dt;

                    dgvStudents.ReadOnly = true;
                    dgvStudents.AutoResizeColumns();
                }
                else
                {
                    MessageBox.Show("Please select a course");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }
    }
}
