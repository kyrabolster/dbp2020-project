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
    public partial class ViewStudentCourses : Form
    {
        public ViewStudentCourses()
        {
            InitializeComponent();
        }
        private void ViewStudentCourses_Load(object sender, EventArgs e)
        {
            try
            {
                LoadStudents();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void LoadStudents()
        {
            string sqlStudents = "SELECT StudentID, LastName + ', ' + FirstName AS [StudentName] FROM Student ORDER BY LastName, FirstName";
            UIUtilities.BindComboBox(cmbStudents, DataAccess.GetData(sqlStudents), "StudentName", "StudentID");
        }

        private void cmbStudents_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cmbStudents.SelectedIndex != 0)
                {
                    DataTable dt = DataAccess.GetData(
                            $@"SELECT Course.CourseId, CourseTitle, Instructor.LastName + ', ' + Instructor.FirstName AS [Instructor], Campus
                                FROM Course
	                                INNER JOIN StudentCourse
		                                ON Course.CourseId = StudentCourse.CourseId
	                                INNER JOIN Student
		                                ON Student.StudentID = StudentCourse.StudentId
				                    INNER JOIN Instructor
					                    ON Instructor.InstructorId = Course.InstructorId
	                                WHERE Student.StudentId = {cmbStudents.SelectedValue}
	                                ORDER BY CourseTitle"
                        );

                    dgvCourses.DataSource = dt;

                    dgvCourses.ReadOnly = true;
                    dgvCourses.AutoResizeColumns();
                }
                else
                {
                    MessageBox.Show("Please select a student");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }
    }
}
