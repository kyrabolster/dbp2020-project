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
    public partial class frmClasslist : Form
    {
        public frmClasslist()
        {
            InitializeComponent();
        }

        #region Events
        private void ViewCourseStudents_Load(object sender, EventArgs e)
        {
            try
            {
                LoadCourses();
                LoadClasslist();
                LoadStudentList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void cmbCourses_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                LoadClasslist();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void dgvStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int StudentId = Convert.ToInt32(dgvClasslist.CurrentRow.Cells[0].Value);

            string sql = $@"SELECT * FROM Student
                            WHERE StudentID = {StudentId}";

            DataTable dt = DataAccess.GetData(sql);

            if (dt.Rows.Count > 0)
            {
                txtStudentId.Text = dt.Rows[0]["StudentId"].ToString();
                txtStudentName.Text = dt.Rows[0]["FirstName"].ToString() + " " + dt.Rows[0]["MiddleName"].ToString()
                                       + " " + dt.Rows[0]["LastName"].ToString();
                txtEmail.Text = dt.Rows[0]["Email"].ToString();
                txtPhone.Text = dt.Rows[0]["Phone"].ToString();
                txtAddress.Text = dt.Rows[0]["Address"].ToString();

            }
        }

        private void dgvAllStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int StudentId = Convert.ToInt32(dgvAllStudents.CurrentRow.Cells[0].Value);

            string sql = $@"SELECT * FROM Student WHERE StudentID = {StudentId}";

            DataTable dt = DataAccess.GetData(sql);

            if (dt.Rows.Count > 0)
            {
                txtStudentId2.Text = dt.Rows[0]["StudentId"].ToString();
                txtStudentName2.Text = dt.Rows[0]["FirstName"].ToString() + " " + dt.Rows[0]["MiddleName"].ToString()
                                       + " " + dt.Rows[0]["LastName"].ToString();
                txtEmail2.Text = dt.Rows[0]["Email"].ToString();
                txtPhone2.Text = dt.Rows[0]["Phone"].ToString();
                txtAddress2.Text = dt.Rows[0]["Address"].ToString();

            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (cmbCourses.SelectedIndex == 0)
            {
                MessageBox.Show("Please select a course.");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Are you sure you want remove this student from the course?", "Are you sure?", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {

                int studentId = Convert.ToInt32(txtStudentId.Text);
                int courseId = Convert.ToInt32(cmbCourses.SelectedValue);

                string sqlDropStudent = $@"DELETE FROM StudentCourse
	                                        WHERE StudentId = {studentId} AND CourseId = {courseId};";

                int rowsAffected = DataAccess.ExecuteNonQuery(sqlDropStudent);

                if (rowsAffected == 1)
                {
                    MessageBox.Show("Student removed from class.");
                    LoadClasslist();

                }
                else
                {
                    MessageBox.Show("The database did not report the correct number of rows affected.");
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbCourses.SelectedIndex == 0)
                {
                    MessageBox.Show("Please select a course.");
                    return;
                }

                int courseId = Convert.ToInt32(cmbCourses.SelectedValue);
                int studentId = Convert.ToInt32(txtStudentId2.Text);

                string sqlEnroll = $@"INSERT INTO StudentCourse (StudentId, CourseId) VALUES({studentId}, {courseId})";

                int rowsAffected = DataAccess.ExecuteNonQuery(sqlEnroll);

                if (rowsAffected == 1)
                {
                    MessageBox.Show("Student successfully added to classlist.");
                    LoadClasslist();

                }
                else
                {
                    MessageBox.Show("The database did not report the correct number of rows affected.");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("This student is already a member of the classlist.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        #endregion

        #region Retrieves
        private void LoadCourses()
        {
            string sqlCourses = "SELECT CourseID, CourseTitle FROM Course ORDER BY CourseTitle";
            UIUtilities.BindComboBox(cmbCourses, DataAccess.GetData(sqlCourses), "CourseTitle", "CourseID");
        }

        private void LoadClasslist()
        {
            if (cmbCourses.SelectedIndex != 0)
            {
                DataTable dt = DataAccess.GetData(
                        $@"SELECT Student.StudentID, Student.LastName + ', ' + Student.FirstName AS [Student Name], Student.Email
                                 FROM Student
	                                INNER JOIN StudentCourse
		                                ON Student.StudentID = StudentCourse.StudentID
	                                INNER JOIN Course
		                                ON Course.CourseId = StudentCourse.CourseId
	                                WHERE Course.CourseID = {cmbCourses.SelectedValue}
	                                ORDER BY LastName, FirstName"
                    );

                dgvClasslist.DataSource = dt;

                dgvClasslist.ReadOnly = true;
                dgvClasslist.AutoResizeColumns();
            }
            else
            {
                UIUtilities.ClearControls(grpClasslist.Controls);
                dgvClasslist.DataSource = null;
            }
        }

        private void LoadStudentList()
        {
            DataTable dt = DataAccess.GetData(
                    $@"SELECT DISTINCT Student.StudentID, Student.LastName, Student.FirstName, 
                                        Student.LastName + ', ' + Student.FirstName AS [Student Name], Student.Email
                                 FROM Student
	                                INNER JOIN StudentCourse
		                                ON Student.StudentId = StudentCourse.StudentId
	                                ORDER BY LastName"
                );

            dgvAllStudents.DataSource = dt;

            dgvAllStudents.ReadOnly = true;
            dgvAllStudents.AutoResizeColumns();
        }

        #endregion


    }
}
