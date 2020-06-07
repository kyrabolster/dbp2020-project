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
    public partial class frmStudents : Form
    {
        public frmStudents()
        {
            InitializeComponent();
        }

        #region Globals

        int currentStudentId = 0;
        int firstStudentId = 0;
        int lastStudentId = 0;
        int? previousStudentId;
        int? nextStudentId;

        #endregion

        #region Events
        /// <summary>
        /// Load and setup Students form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Students_Load(object sender, EventArgs e)
        {
            try
            {
                LoadFirstStudent();
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
        /// Change form display to add a student
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                UIUtilities.ClearControls(this.grpStudents.Controls);

                btnCreate.Enabled = true;
                btnAdd.Enabled = false;
                btnDelete.Enabled = false;
                btnSave.Enabled = false;

                NavigationState(false);
                SetStatusStrip("Press 'Create' to add student...");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        /// <summary>
        /// Delete student button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this student record from the database?" +
                    "\r\nThey will be removed from all classlists.", "Are you sure?", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    DeleteStudent();
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
        /// Create student button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateChildren(ValidationConstraints.Enabled))
                {
                    CreateStudent();
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
        /// Save changes button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateChildren(ValidationConstraints.Enabled))
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to modify this student record in the database?",
                                                                "Are you sure?", MessageBoxButtons.YesNo);

                    if (dialogResult == DialogResult.Yes)
                    {
                        UpdateStudent();
                    }
                    else
                    {
                        LoadStudentDetails();
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
        /// Cancel actions and reset form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                LoadStudentDetails();
                btnAdd.Enabled = true;
                btnAdd.Enabled = true;
                btnDelete.Enabled = true;
                btnSave.Enabled = true;

                NavigationState(true);
                NextPreviousButtonManagement();
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

        private void Students_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }

        #endregion

        #region Retrieves
        /// <summary>
        /// Load first student
        /// </summary>
        private void LoadFirstStudent()
        {
            try
            {
                DataTable firstStudent = DataAccess.GetData("SELECT TOP (1) StudentId FROM Student ORDER BY LastName, FirstName");

                if (firstStudent.Rows.Count > 0)
                {
                    currentStudentId = Convert.ToInt32(firstStudent.Rows[0]["StudentId"]);

                    firstStudentId = currentStudentId;

                    LoadStudentDetails();
                    NextPreviousButtonManagement();
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
        /// Load and display student details
        /// </summary>
        private void LoadStudentDetails()
        {
            errProvider.Clear();

            string[] sqlStatements = new string[]
            {
                $"SELECT * FROM Student WHERE StudentId = {currentStudentId}",
                $@"
                SELECT 
                    (
                        SELECT TOP(1) StudentId as FirstStudentId FROM Student ORDER BY LastName, FirstName
                    ) as FirstStudentId,
                    q.PreviousStudentId,
                    q.NextStudentId,
                    (
                        SELECT TOP(1) StudentId as LastStudentId FROM Student ORDER BY LastName Desc, FirstName Desc
                    ) as LastStudentId
                    FROM
                    (
                        SELECT StudentId,
	                    LEAD(StudentId) OVER(ORDER BY LastName, FirstName) AS NextStudentId,
	                    LAG(StudentId) OVER(ORDER BY LastName, FirstName) AS PreviousStudentId,
                        ROW_NUMBER() OVER(ORDER BY LastName, FirstName) AS 'RowNumber'
                        FROM Student
                    ) AS q
                    WHERE q.StudentId = {currentStudentId}
                    ORDER BY q.StudentId"
            };

            try
            {
                DataSet ds = new DataSet();
                ds = DataAccess.GetData(sqlStatements);

                if (ds.Tables[0].Rows.Count == 1)
                {
                    DataRow selectedStudent = ds.Tables[0].Rows[0];

                    txtStudentId.Text = selectedStudent["StudentId"].ToString();
                    txtFirstName.Text = selectedStudent["FirstName"].ToString();
                    txtMiddleName.Text = selectedStudent["MiddleName"].ToString();
                    txtLastName.Text = selectedStudent["LastName"].ToString();
                    txtEmail.Text = selectedStudent["Email"].ToString();
                    txtPhone.Text = selectedStudent["Phone"].ToString();
                    txtAddress.Text = selectedStudent["Address"].ToString();


                    firstStudentId = Convert.ToInt32(ds.Tables[1].Rows[0]["FirstStudentId"]);
                    previousStudentId = ds.Tables[1].Rows[0]["PreviousStudentId"] != DBNull.Value ? Convert.ToInt32(ds.Tables["Table1"].Rows[0]["PreviousStudentId"]) : (int?)null;
                    nextStudentId = ds.Tables[1].Rows[0]["NextStudentId"] != DBNull.Value ? Convert.ToInt32(ds.Tables["Table1"].Rows[0]["NextStudentId"]) : (int?)null;
                    lastStudentId = Convert.ToInt32(ds.Tables[1].Rows[0]["LastStudentId"]);

                    SetStatusStrip($"Viewing student id: {currentStudentId}");
                }
                else
                {
                    MessageBox.Show("The student no longer exists");
                    LoadFirstStudent();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        #endregion

        #region NonQuery
        /// <summary>
        /// Insert student into database
        /// </summary>
        private void CreateStudent()
        {
            string firstName = txtFirstName.Text;
            string middleName = txtMiddleName.Text;
            string lastName = txtLastName.Text;
            string address = txtAddress.Text;
            string email = txtEmail.Text;
            string phone = txtPhone.Text;

            string sqlInsertStudent = $@"INSERT INTO Student (FirstName, MiddleName, LastName, Address, Phone, Email) 
                                                VALUES('{firstName}', '{middleName}', '{lastName}', '{address}', '{email}', '{phone}')";

            int rowsAffected = DataAccess.ExecuteNonQuery(sqlInsertStudent);

            if (rowsAffected == 1)
            {
                SetStatusStrip("Creating...");
                MessageBox.Show("Student created.");
                btnAdd.Enabled = true;
                btnDelete.Enabled = true;
                btnCreate.Enabled = false;
                btnSave.Enabled = true;
                LoadFirstStudent();
            }
            else
            {
                MessageBox.Show("The database did not report the correct number of rows affected.");
            }
        }

        /// <summary>
        /// Update student in the database
        /// </summary>
        private void UpdateStudent()
        {
            string studentId = txtStudentId.Text;
            string firstName = txtFirstName.Text;
            string middleName = txtMiddleName.Text;
            string lastName = txtLastName.Text;
            string address = txtAddress.Text;
            string email = txtEmail.Text;
            string phone = txtPhone.Text;

            string sqlUpdateStudent = $@"UPDATE Student
                                        SET FirstName = '{firstName}', MiddleName = '{middleName}', LastName = '{lastName}', 
                                            Address = '{address}', Email = '{email}', Phone = '{phone}'
                                        WHERE StudentId = {studentId}";

            int rowsAffected = DataAccess.ExecuteNonQuery(sqlUpdateStudent);

            if (rowsAffected == 1)
            {
                MessageBox.Show("Student record updated.");
                btnAdd.Enabled = true;
                btnDelete.Enabled = true;
            }
            else
            {
                MessageBox.Show("The database did not report the correct number of rows affected.");
            }
        }

        /// <summary>
        /// Delete student from the database
        /// </summary>
        private void DeleteStudent()
        {
            int studentId = Convert.ToInt32(txtStudentId.Text);

            string sqlDeleteFK = $@"DELETE FROM StudentCourseHub.dbo.StudentCourse WHERE StudentId = {studentId}";
            DataAccess.ExecuteNonQuery(sqlDeleteFK);

            string sqlDeleteStudent = $@"DELETE FROM StudentCourseHub.dbo.Student WHERE StudentId = {studentId}";

            int rowsAffected = DataAccess.ExecuteNonQuery(sqlDeleteStudent);

            if (rowsAffected == 1)
            {
                SetStatusStrip("Deleting...");
                MessageBox.Show("Student deleted.");
                btnAdd.Enabled = true;
                btnDelete.Enabled = true;
                LoadFirstStudent();
            }
            else
            {
                MessageBox.Show("The database did not report the correct number of rows affected.");
            }
        }

        #endregion

        #region Navigation
        /// <summary>
        /// Manage next and previous button state
        /// </summary>
        private void NextPreviousButtonManagement()
        {
            btnPrevious.Enabled = previousStudentId != null;
            btnNext.Enabled = nextStudentId != null;
        }

        /// <summary>
        /// Manage navigation between students
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Navigation_Handler(object sender, EventArgs e)
        {
            try
            {
                Button b = (Button)sender;

                switch (b.Name)
                {
                    case "btnFirst":
                        currentStudentId = firstStudentId;
                        break;
                    case "btnLast":
                        currentStudentId = lastStudentId;
                        break;
                    case "btnPrevious":
                        currentStudentId = previousStudentId.Value;
                        break;
                    case "btnNext":
                        currentStudentId = nextStudentId.Value;
                        break;
                }

                LoadStudentDetails();
                NextPreviousButtonManagement();
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
        /// Manage navigation buttons state
        /// </summary>
        /// <param name="enableState"></param>
        private void NavigationState(bool enableState)
        {
            btnFirst.Enabled = enableState;
            btnLast.Enabled = enableState;
            btnNext.Enabled = enableState;
            btnPrevious.Enabled = enableState;
        }

        #endregion

        #region Status

        /// <summary>
        /// Set MDI parent status strip
        /// </summary>
        /// <param name="text"></param>
        private void SetStatusStrip(string text)
        {
            ((MDIHome)this.MdiParent).StatusStipLabel.Text = text;
        }

        #endregion

        #region Validation

        /// <summary>
        /// Validates that all required fields are not empty and do not exceed the length required by the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            string txtBoxName = txt.Tag.ToString();
            string errMsg = null;
            bool failedValidation = false;

            if (txt.Text == string.Empty)
            {
                errMsg = $"{txtBoxName} is required";
                failedValidation = true;
            }
            else if (
                        ((string)txt.Tag == "StudentName" && txtFirstName.Text.Length > 30) ||
                        ((string)txt.Tag == "MiddleName" && txtMiddleName.Text.Length > 30) ||
                        ((string)txt.Tag == "LastName" && txtLastName.Text.Length > 30)
                    )
            {
                errMsg = $"Name cannot exceed 30 characters in length.";
                failedValidation = true;
            }
            else if ((string)txt.Tag == "Email" && txtEmail.Text.Length > 30)
            {
                errMsg = $"Email cannot exceed 30 characters in length.";
                failedValidation = true;
            }
            else if ((string)txt.Tag == "Address" && txtEmail.Text.Length > 250)
            {
                errMsg = $"Address cannot exceed 250 characters in length.";
                failedValidation = true;
            }
            e.Cancel = failedValidation;

            errProvider.SetError(txt, errMsg);
        }

        #endregion
    }
}
