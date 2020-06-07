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

/* 
* Kyra Bolster
*  Database Programming - Final Project
*  June 7, 2020
*/

namespace StudentCourseHub
{
    public partial class frmCourseSelect : Form
    {
        public frmCourseSelect()
        {
            InitializeComponent();
        }

        #region Events
        private void ViewStudentCourses_Load(object sender, EventArgs e)
        {
            try
            {
                LoadCampuses();
                LoadInstructors();
                LoadStudents();
                LoadCourses();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void cmbStudents_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cmbStudents.SelectedIndex != 0)
                {
                    LoadYourCourses();
                }
                else
                {
                    UIUtilities.ClearControls(grpYourCourses.Controls);
                    dgvYourCourses.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void dgvCourses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int CourseId = Convert.ToInt32(dgvYourCourses.CurrentRow.Cells[0].Value);

            string sql = $@"SELECT CourseId, CourseTitle, [Description], Campus, Course.InstructorId, 
                                   Instructor.LastName + ', ' + Instructor.LastName AS Instructor 
                            FROM Course 
                                INNER JOIN Instructor
	                                ON Course.InstructorId = Instructor.InstructorId
                            WHERE CourseID = {CourseId}";

            DataTable dt = DataAccess.GetData(sql);

            if (dt.Rows.Count > 0)
            {
                txtCourseId.Text = dt.Rows[0]["CourseId"].ToString();
                txtCourseTitle.Text = dt.Rows[0]["CourseTitle"].ToString();
                txtDescription.Text = dt.Rows[0]["Description"].ToString();
                cmbCampus.SelectedItem = dt.Rows[0]["Campus"].ToString();
                cmbInstructors.SelectedValue = dt.Rows[0]["InstructorId"].ToString();

            }
        }

        private void dgvCourseSelect_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int CourseId = Convert.ToInt32(dgvCourseSelect.CurrentRow.Cells[0].Value);

            string sql = $@"SELECT CourseId, CourseTitle, [Description], Campus, Course.InstructorId, 
                                   Instructor.LastName + ', ' + Instructor.LastName AS Instructor 
                            FROM Course 
                                INNER JOIN Instructor
	                                ON Course.InstructorId = Instructor.InstructorId
                            WHERE CourseID = {CourseId}";

            DataTable dt = DataAccess.GetData(sql);

            if (dt.Rows.Count > 0)
            {
                txtCourseId2.Text = dt.Rows[0]["CourseId"].ToString();
                txtCourseTitle2.Text = dt.Rows[0]["CourseTitle"].ToString();
                txtDescription2.Text = dt.Rows[0]["Description"].ToString();
                cmbCampus2.SelectedItem = dt.Rows[0]["Campus"].ToString();
                cmbInstructors2.SelectedValue = dt.Rows[0]["InstructorId"].ToString();

            }
        }

        private void btnDrop_Click(object sender, EventArgs e)
        {
            if (cmbStudents.SelectedIndex == 0)
            {
                MessageBox.Show("Please select a student.");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to drop this course?", "Are you sure?", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {

                int courseId = Convert.ToInt32(txtCourseId.Text);
                int studentId = Convert.ToInt32(cmbStudents.SelectedValue);

                string sqlDropCourse = $@"DELETE FROM StudentCourse
	                                        WHERE StudentId = {studentId} AND CourseId = {courseId};";

                int rowsAffected = DataAccess.ExecuteNonQuery(sqlDropCourse);

                if (rowsAffected == 1)
                {
                    MessageBox.Show("Course dropped.");
                    LoadYourCourses();

                }
                else
                {
                    MessageBox.Show("The database did not report the correct number of rows affected.");
                }
            }
        }

        private void btnEnroll_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbStudents.SelectedIndex == 0)
                {
                    MessageBox.Show("Please select a student.");
                    return;
                }

                int courseId = Convert.ToInt32(txtCourseId2.Text);
                int studentId = Convert.ToInt32(cmbStudents.SelectedValue);

                string sqlEnroll = $@"INSERT INTO StudentCourse (StudentId, CourseId) VALUES({studentId}, {courseId})";

                int rowsAffected = DataAccess.ExecuteNonQuery(sqlEnroll);

                if (rowsAffected == 1)
                {
                    MessageBox.Show("Course enrollement successful.");
                    LoadYourCourses();

                }
                else
                {
                    MessageBox.Show("The database did not report the correct number of rows affected.");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("This student is already enrolled in the selected course.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }

        }

        #endregion

        #region Retrieves
        private void LoadStudents()
        {
            string sqlStudents = "SELECT StudentID, LastName + ', ' + FirstName AS [StudentName] FROM Student ORDER BY LastName, FirstName";
            UIUtilities.BindComboBox(cmbStudents, DataAccess.GetData(sqlStudents), "StudentName", "StudentID");
        }

        private void LoadCampuses()
        {
            cmbCampus.Items.Add("");
            cmbCampus.Items.Add("Fredericton");
            cmbCampus.Items.Add("Miramichi");
            cmbCampus.Items.Add("Moncton");
            cmbCampus.Items.Add("Saint John");
            cmbCampus.Items.Add("St. Andrews");
            cmbCampus.Items.Add("Woodstock");

            cmbCampus2.Items.Add("");
            cmbCampus2.Items.Add("Fredericton");
            cmbCampus2.Items.Add("Miramichi");
            cmbCampus2.Items.Add("Moncton");
            cmbCampus2.Items.Add("Saint John");
            cmbCampus2.Items.Add("St. Andrews");
            cmbCampus2.Items.Add("Woodstock");
        }
        private void LoadInstructors()
        {
            string sqlInstructors = "SELECT InstructorID, LastName + ', ' + FirstName AS WholeName FROM Instructor ORDER BY LastName, FirstName";
            UIUtilities.BindComboBox(cmbInstructors, DataAccess.GetData(sqlInstructors), "WholeName", "InstructorId");
            UIUtilities.BindComboBox(cmbInstructors2, DataAccess.GetData(sqlInstructors), "WholeName", "InstructorId");
        }

        private void LoadCourses()
        {
            DataTable dt = DataAccess.GetData(
                    $@"SELECT DISTINCT Course.CourseId, CourseTitle, Instructor.LastName + ', ' + Instructor.FirstName AS [Instructor], Campus
                                FROM Course
	                                INNER JOIN StudentCourse
		                                ON Course.CourseId = StudentCourse.CourseId
				                    INNER JOIN Instructor
					                    ON Instructor.InstructorId = Course.InstructorId
	                                ORDER BY CourseTitle"
                );

            dgvCourseSelect.DataSource = dt;

            dgvCourseSelect.ReadOnly = true;
            dgvCourseSelect.AutoResizeColumns();
        }

        private void LoadYourCourses()
        {
            int studentId = Convert.ToInt32(cmbStudents.SelectedValue);

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

            dgvYourCourses.DataSource = dt;

            dgvYourCourses.ReadOnly = true;
            dgvYourCourses.AutoResizeColumns();
        }





        #endregion


    }
}
