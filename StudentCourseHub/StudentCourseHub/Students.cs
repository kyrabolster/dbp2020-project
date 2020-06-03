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
    public partial class Students : Form
    {
        public Students()
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
        private void Students_Load(object sender, EventArgs e)
        {
            try
            {
                LoadFirstStudent();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                UIUtilities.ClearControls(this.grpStudents.Controls);

                btnSave.Text = "Create";
                btnAdd.Enabled = false;
                btnDelete.Enabled = false;

                NavigationState(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this student record from the database?", "Are you sure?", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                DeleteStudent();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateChildren(ValidationConstraints.Enabled))
                {
                    CreateStudent();
                }
            }
            // add more sqlExceptions throughout
            catch (SqlException ex)
            {
                MessageBox.Show("Something is wrong with the data or database!", ex.GetType().ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            LoadStudentDetails();
            btnAdd.Enabled = true;
            btnAdd.Enabled = true;
            btnDelete.Enabled = true;

            NavigationState(true);
            NextPreviousButtonManagement();
        }

        private void Students_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }

        #endregion

        #region Retrieves
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

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
        private void CreateStudent()
        {
            string firstName = txtFirstName.Text;
            string middleName = txtMiddleName.Text;
            string lastName = txtLastName.Text;
            string address = txtAddress.Text;
            string email = txtEmail.Text;
            string phone = txtPhone.Text;



            // Enforce business rules


            string sqlInsertStudent = $@"INSERT INTO Student (FirstName, MiddleName, LastName, Address, Phone, Email) 
                                                VALUES('{firstName}', '{middleName}', '{lastName}', '{address}', '{email}', '{phone}')";

            // how do you know if false data? eg description > 255 char ??

            int rowsAffected = DataAccess.ExecuteNonQuery(sqlInsertStudent);

            if (rowsAffected == 1)
            {
                MessageBox.Show("Student created.");
                btnAdd.Enabled = true;
                btnDelete.Enabled = true;
                LoadFirstStudent();
            }
            else
            {
                MessageBox.Show("The database did not report the correct number of rows affected.");
            }
        }

        private void DeleteStudent()
        {
            int studentId = Convert.ToInt32(txtStudentId.Text);

            string sqlDeleteStudent = $@"DELETE FROM StudentCourseHub.dbo.Student WHERE StudentId = {studentId}";

            int rowsAffected = DataAccess.ExecuteNonQuery(sqlDeleteStudent);

            if (rowsAffected == 1)
            {
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

        private void NextPreviousButtonManagement()
        {
            btnPrevious.Enabled = previousStudentId != null;
            btnNext.Enabled = nextStudentId != null;
        }

        private void Navigation_Handler(object sender, EventArgs e)
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

        private void NavigationState(bool enableState)
        {
            btnFirst.Enabled = enableState;
            btnLast.Enabled = enableState;
            btnNext.Enabled = enableState;
            btnPrevious.Enabled = enableState;
        }

        #endregion

        // add status strip

        #region Validation

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

            e.Cancel = failedValidation;

            errProvider.SetError(txt, errMsg);
        }

        #endregion
    }
}
