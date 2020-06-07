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
    public partial class frmCourses : Form
    {
        public frmCourses()
        {
            InitializeComponent();
        }

        #region Globals

        int currentCourseId = 0;
        int firstCourseId = 0;
        int lastCourseId = 0;
        int? previousCourseId;
        int? nextCourseId;

        int currentInstructorId = 0;
        int firstInstructorId = 0;
        int lastInstructorId = 0;
        int? previousInstructorId;
        int? nextInstructorId;

        #endregion

        #region Events
        private void Courses_Load(object sender, EventArgs e)
        {
            try
            {
                LoadCampuses();
                LoadInstructors();
                LoadFirstCourse();
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
                UIUtilities.ClearControls(this.grpCourses.Controls);

                btnCreate.Enabled = true;
                btnAdd.Enabled = false;
                btnDelete.Enabled = false;
                btnSave.Enabled = false;


                NavigationState(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this course from the database?", "Are you sure?", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                DeleteCourse();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateChildren(ValidationConstraints.Enabled))
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to modify this course in the database?", "Are you sure?", MessageBoxButtons.YesNo);

                    if (dialogResult == DialogResult.Yes)
                    {
                        UpdateCourse();
                    }
                    else
                    {
                        LoadCourseDetails();
                    }
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

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateChildren(ValidationConstraints.Enabled))
                {
                    CreateCourse();
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
            LoadCourseDetails();
            btnAdd.Enabled = true;
            btnAdd.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = true;

            NavigationState(true);
            NextPreviousButtonManagement();
        }


        private void Courses_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }

        #endregion

        #region Retrieves

        private void LoadCampuses()
        {
            cmbCampus.Items.Add("");
            cmbCampus.Items.Add("Fredericton");
            cmbCampus.Items.Add("Miramichi");
            cmbCampus.Items.Add("Moncton");
            cmbCampus.Items.Add("Saint John");
            cmbCampus.Items.Add("St. Andrews");
            cmbCampus.Items.Add("Woodstock");
        }
        private void LoadInstructors()
        {
            string sqlInstructors = "SELECT InstructorID, LastName + ', ' + FirstName AS WholeName FROM Instructor ORDER BY LastName, FirstName";
            UIUtilities.BindComboBox(cmbInstructors, DataAccess.GetData(sqlInstructors), "WholeName", "InstructorId");
        }

        private void LoadFirstCourse()
        {
            try
            {
                DataTable firstCourse = DataAccess.GetData("SELECT TOP (1) CourseId, InstructorId FROM Course ORDER BY CourseTitle");

                if (firstCourse.Rows.Count > 0)
                {
                    currentCourseId = Convert.ToInt32(firstCourse.Rows[0]["CourseId"]);
                    currentInstructorId = Convert.ToInt32(firstCourse.Rows[0]["InstructorId"]);

                    firstCourseId = currentCourseId;
                    firstInstructorId = currentInstructorId;

                    LoadCourseDetails();
                    NextPreviousButtonManagement();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void LoadCourseDetails()
        {
            //necessary?
            errProvider.Clear();

            string[] sqlStatements = new string[]
            {
                $"SELECT * FROM Course WHERE CourseId = {currentCourseId} AND InstructorId = {currentInstructorId}",
                $@"
                SELECT 
                    (
                        SELECT TOP(1) CourseId as FirstCourseId FROM Course ORDER BY CourseTitle
                    ) as FirstCourseId,
                    (
                        SELECT TOP(1) InstructorId as FirstInstructorId FROM Course ORDER BY CourseTitle
                    ) as FirstInstructorId,
                    q.PreviousCourseId,
                    q.PreviousInstructorId,
                    q.NextCourseId,
                    q.NextInstructorId,
                    (
                        SELECT TOP(1) CourseId as LastCourseId FROM Course ORDER BY CourseTitle Desc
                    ) as LastCourseId,
                    (
                        SELECT TOP(1) InstructorId as LastInstructorId FROM Course ORDER BY CourseTitle Desc
                    ) as LastInstructorId
                    FROM
                    (
                        SELECT CourseId, InstructorId,
	                    LEAD(CourseId) OVER(ORDER BY CourseTitle) AS NextCourseId,
	                    LEAD(InstructorId) OVER(ORDER BY CourseTitle) AS NextInstructorId,  
	                    LAG(CourseId) OVER(ORDER BY CourseTitle) AS PreviousCourseId,
	                    LAG(InstructorId) OVER(ORDER BY CourseTitle) AS PreviousInstructorId,
                        ROW_NUMBER() OVER(ORDER BY CourseTitle) AS 'RowNumber'
                        FROM Course
                    ) AS q
                    WHERE q.CourseId = {currentCourseId} AND q.InstructorId = {currentInstructorId}
                    ORDER BY q.CourseId, q.InstructorId"
            };

            try
            {
                DataSet ds = new DataSet();
                ds = DataAccess.GetData(sqlStatements);

                if (ds.Tables[0].Rows.Count == 1)
                {
                    DataRow selectedCourse = ds.Tables[0].Rows[0];

                    txtCourseId.Text = selectedCourse["CourseId"].ToString();
                    txtCourseTitle.Text = selectedCourse["CourseTitle"].ToString();
                    txtDescription.Text = selectedCourse["Description"].ToString();
                    cmbInstructors.SelectedValue = selectedCourse["InstructorId"];
                    cmbCampus.SelectedItem = selectedCourse["Campus"].ToString();

                    firstCourseId = Convert.ToInt32(ds.Tables[1].Rows[0]["FirstCourseId"]);
                    previousCourseId = ds.Tables[1].Rows[0]["PreviousCourseId"] != DBNull.Value ? Convert.ToInt32(ds.Tables["Table1"].Rows[0]["PreviousCourseId"]) : (int?)null;
                    nextCourseId = ds.Tables[1].Rows[0]["NextCourseId"] != DBNull.Value ? Convert.ToInt32(ds.Tables["Table1"].Rows[0]["NextCourseId"]) : (int?)null;
                    lastCourseId = Convert.ToInt32(ds.Tables[1].Rows[0]["LastCourseId"]);

                    firstInstructorId = Convert.ToInt32(ds.Tables[1].Rows[0]["FirstInstructorId"]);
                    previousInstructorId = ds.Tables[1].Rows[0]["PreviousInstructorId"] != DBNull.Value ? Convert.ToInt32(ds.Tables["Table1"].Rows[0]["PreviousInstructorId"]) : (int?)null;
                    nextInstructorId = ds.Tables[1].Rows[0]["NextInstructorId"] != DBNull.Value ? Convert.ToInt32(ds.Tables["Table1"].Rows[0]["NextInstructorId"]) : (int?)null;
                    lastInstructorId = Convert.ToInt32(ds.Tables[1].Rows[0]["LastInstructorId"]);
                }
                else
                {
                    MessageBox.Show("The course no longer exists");
                    LoadFirstCourse();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        #endregion

        #region NonQuery
        private void CreateCourse()
        {
            string courseTitle = txtCourseTitle.Text;
            string description = txtDescription.Text;
            string campus = cmbCampus.SelectedItem.ToString();

            int instructorId = Convert.ToInt32(cmbInstructors.SelectedValue);


            // Enforce business rules

            string sqlInsertCourse = $@"INSERT INTO Course (CourseTitle, Description, Campus, InstructorId) 
                                                VALUES('{courseTitle}', '{description}', '{campus}', {instructorId})";

            // how do you know if false data? eg description > 255 char ??

            int rowsAffected = DataAccess.ExecuteNonQuery(sqlInsertCourse);

            if (rowsAffected == 1)
            {
                MessageBox.Show("Course created.");
                btnAdd.Enabled = true;
                btnDelete.Enabled = true;
                btnCreate.Enabled = false;
                btnSave.Enabled = true;
                LoadFirstCourse();
            }
            else
            {
                MessageBox.Show("The database did not report the correct number of rows affected.");
            }
        }

        private void UpdateCourse()
        {
            string courseId = txtCourseId.Text;
            string courseTitle = txtCourseTitle.Text;
            string description = txtDescription.Text;
            string campus = cmbCampus.SelectedItem.ToString();

            int instructorId = Convert.ToInt32(cmbInstructors.SelectedValue);


            // Enforce business rules

            string sqlUpdateCourse = $@"UPDATE Course
                                        SET CourseTitle = '{courseTitle}', Description = '{description}', 
                                            Campus = '{campus}', InstructorId = '{instructorId}'
                                        WHERE CourseId = {courseId}";

            // how do you know if false data? eg description > 255 char ??

            int rowsAffected = DataAccess.ExecuteNonQuery(sqlUpdateCourse);

            if (rowsAffected == 1)
            {
                MessageBox.Show("Course updated.");
                btnAdd.Enabled = true;
                btnDelete.Enabled = true;

            }
            else
            {
                MessageBox.Show("The database did not report the correct number of rows affected.");
            }
        }


        private void DeleteCourse()
        {
            int courseId = Convert.ToInt32(txtCourseId.Text);

            string sqlDeleteCourse = $@"DELETE FROM StudentCourseHub.dbo.Course WHERE CourseId = {courseId}";

            int rowsAffected = DataAccess.ExecuteNonQuery(sqlDeleteCourse);

            if (rowsAffected == 1)
            {
                MessageBox.Show("Course deleted.");
                btnAdd.Enabled = true;
                btnDelete.Enabled = true;
                LoadFirstCourse();
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
            btnPrevious.Enabled = previousCourseId != null;
            btnNext.Enabled = nextCourseId != null;
        }

        private void Navigation_Handler(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            switch (b.Name)
            {
                case "btnFirst":
                    currentCourseId = firstCourseId;
                    currentInstructorId = firstInstructorId;
                    break;
                case "btnLast":
                    currentCourseId = lastCourseId;
                    currentInstructorId = lastInstructorId;
                    break;
                case "btnPrevious":
                    currentCourseId = previousCourseId.Value;
                    currentInstructorId = previousInstructorId.Value;
                    break;
                case "btnNext":
                    currentCourseId = nextCourseId.Value;
                    currentInstructorId = nextInstructorId.Value;
                    break;
            }

            LoadCourseDetails();
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

        #region Status

        // add status strip to mdi 

        //private void SetStatusStrip(string text, Color foreColor)
        //{
        //    toolStripStatusLabel1.Text = text;
        //    toolStripStatusLabel1.ForeColor = foreColor;
        //}

        #endregion

        #region Validation

        private void cmb_Validating(object sender, CancelEventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            string cmbName = cmb.Tag.ToString();

            string errMsg = null;
            bool failedValidation = false;

            if (cmb.SelectedIndex == -1 || cmb.SelectedIndex == 0)
            {
                errMsg = $"{cmbName} is required";
                failedValidation = true;
            }

            e.Cancel = failedValidation;
            errProvider.SetError(cmb, errMsg);
        }

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
