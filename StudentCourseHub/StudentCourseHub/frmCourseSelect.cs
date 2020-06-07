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
        /// <summary>
        /// Load and setup Course Selection form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CourseSelect_Load(object sender, EventArgs e)
        {
            try
            {
                LoadCampuses();
                LoadInstructors();
                LoadStudents();
                LoadCourses();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Something is wrong with the data or database!", ex.GetType().ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        /// <summary>
        /// Select student from students combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                    SetStatusStrip("");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Something is wrong with the data or database!", ex.GetType().ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        /// <summary>
        /// Select course from courses the selected student is enrolled in
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvCourses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
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
            catch (SqlException ex)
            {
                MessageBox.Show("Something is wrong with the data or database!", ex.GetType().ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }

        }

        /// <summary>
        /// Select course from list of all courses in the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvCourseSelect_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
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
            catch (SqlException ex)
            {
                MessageBox.Show("Something is wrong with the data or database!", ex.GetType().ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }

        }

        /// <summary>
        /// Drop course for selected student
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDrop_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbStudents.SelectedIndex == 0)
                {
                    MessageBox.Show("Please select a student.");
                    return;
                }

                if (txtCourseId.Text == "")
                {
                    MessageBox.Show("Please select a course to drop.");
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
                        SetStatusStrip("Dropping course...");
                        MessageBox.Show("Course dropped.");
                        LoadYourCourses();
                    }
                    else
                    {
                        MessageBox.Show("The database did not report the correct number of rows affected.");
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Something is wrong with the data or database!", ex.GetType().ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        /// <summary>
        /// Enroll selected student in course
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnroll_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbStudents.SelectedIndex == 0)
                {
                    MessageBox.Show("Please select a student.");
                    return;
                }

                if (txtCourseId2.Text == "")
                {
                    MessageBox.Show("Please select a course to enroll.");
                    return;
                }

                int courseId = Convert.ToInt32(txtCourseId2.Text);
                int studentId = Convert.ToInt32(cmbStudents.SelectedValue);

                int courseCount = Convert.ToInt32(DataAccess.GetValue(
                                                    $"SELECT COUNT(StudentId) FROM StudentCourse WHERE StudentId = {studentId}"));

                if (courseCount == 7)
                {
                    MessageBox.Show("Students cannot be enrolled in more than 7 courses.");
                    return;
                }

                string sqlEnroll = $@"INSERT INTO StudentCourse (StudentId, CourseId) VALUES({studentId}, {courseId})";

                int rowsAffected = DataAccess.ExecuteNonQuery(sqlEnroll);

                if (rowsAffected == 1)
                {
                    SetStatusStrip("Enrolling...");
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
        /// <summary>
        /// Load student combobox
        /// </summary>
        private void LoadStudents()
        {
            string sqlStudents = "SELECT StudentID, LastName + ', ' + FirstName AS [StudentName] FROM Student ORDER BY LastName, FirstName";
            UIUtilities.BindComboBox(cmbStudents, DataAccess.GetData(sqlStudents), "StudentName", "StudentID");

            SetStatusStrip("");
        }

        /// <summary>
        /// Load campus combobox
        /// </summary>
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

        /// <summary>
        /// Load Instructor combobox
        /// </summary>
        private void LoadInstructors()
        {
            string sqlInstructors = "SELECT InstructorID, LastName + ', ' + FirstName AS WholeName FROM Instructor ORDER BY LastName, FirstName";
            UIUtilities.BindComboBox(cmbInstructors, DataAccess.GetData(sqlInstructors), "WholeName", "InstructorId");
            UIUtilities.BindComboBox(cmbInstructors2, DataAccess.GetData(sqlInstructors), "WholeName", "InstructorId");
        }

        /// <summary>
        /// Load courses the selected student is enrolled in
        /// </summary>
        private void LoadYourCourses()
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

            dgvYourCourses.DataSource = dt;
            dgvYourCourses.ReadOnly = true;
            dgvYourCourses.AutoResizeColumns();
            dgvYourCourses.CurrentCell.Selected = false;
            dgvCourseSelect.CurrentCell.Selected = false;

            SetStatusStrip($"Course selection for student id: {cmbStudents.SelectedValue}");
        }

        /// <summary>
        /// Load all courses in the database
        /// </summary>
        private void LoadCourses()
        {
            DataTable dt = DataAccess.GetData(
                    $@"SELECT DISTINCT Course.CourseId, CourseTitle, Instructor.LastName + ', ' + Instructor.FirstName AS [Instructor], Campus
                                FROM Course
				                    INNER JOIN Instructor
					                    ON Instructor.InstructorId = Course.InstructorId
	                                ORDER BY CourseTitle"
                );

            dgvCourseSelect.DataSource = dt;
            dgvCourseSelect.ReadOnly = true;
            dgvCourseSelect.AutoResizeColumns();
        }

        #endregion

        /// <summary>
        /// Set MDI parent status strip
        /// </summary>
        /// <param name="text"></param>
        #region Status Strip
        private void SetStatusStrip(string text)
        {
            ((MDIHome)this.MdiParent).StatusStipLabel.Text = text;
        }
        #endregion

    }
}
