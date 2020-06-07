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
        /// <summary>
        /// Form Load and Setup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Courses_Load(object sender, EventArgs e)
        {
            try
            {
                LoadCampuses();
                LoadInstructors();
                LoadFirstCourse();
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
        /// Change form display to add a course
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                SetStatusStrip("Press 'Create' to add your course...");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        /// <summary>
        /// Delete course button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this course from the database?" +
                    "\r\nAll enrolled students will be removed from the course.", "Are you sure?", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    DeleteCourse();
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
        /// Create course button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateChildren(ValidationConstraints.Enabled))
                {
                    CreateCourse();
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
                LoadCourseDetails();
                btnAdd.Enabled = true;
                btnAdd.Enabled = true;
                btnDelete.Enabled = true;
                btnSave.Enabled = true;

                NavigationState(true);
                NextPreviousButtonManagement();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }


        private void Courses_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }

        #endregion

        #region Retrieves

        /// <summary>
        /// Load campuses to combobox
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
        }

        /// <summary>
        /// Load instructors to combobox
        /// </summary>
        private void LoadInstructors()
        {
            string sqlInstructors = "SELECT InstructorID, LastName + ', ' + FirstName AS WholeName FROM Instructor ORDER BY LastName, FirstName";
            UIUtilities.BindComboBox(cmbInstructors, DataAccess.GetData(sqlInstructors), "WholeName", "InstructorId");
        }

        /// <summary>
        /// Load and display first course
        /// </summary>
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

        /// <summary>
        /// Load and dispay course details
        /// </summary>
        private void LoadCourseDetails()
        {
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

                    SetStatusStrip($"Viewing course id: {currentCourseId}");
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

        /// <summary>
        /// Insert course into database
        /// </summary>
        private void CreateCourse()
        {
            string courseTitle = txtCourseTitle.Text;
            string description = txtDescription.Text;
            string campus = cmbCampus.SelectedItem.ToString();

            int instructorId = Convert.ToInt32(cmbInstructors.SelectedValue);


            string sqlInsertCourse = $@"INSERT INTO Course (CourseTitle, Description, Campus, InstructorId) 
                                                VALUES('{courseTitle}', '{description}', '{campus}', {instructorId})";

            int rowsAffected = DataAccess.ExecuteNonQuery(sqlInsertCourse);

            if (rowsAffected == 1)
            {
                SetStatusStrip("Creating...");
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

        /// <summary>
        /// Update course in the database
        /// </summary>
        private void UpdateCourse()
        {
            string courseId = txtCourseId.Text;
            string courseTitle = txtCourseTitle.Text;
            string description = txtDescription.Text;
            string campus = cmbCampus.SelectedItem.ToString();

            int instructorId = Convert.ToInt32(cmbInstructors.SelectedValue);

            string sqlUpdateCourse = $@"UPDATE Course
                                        SET CourseTitle = '{courseTitle}', Description = '{description}', 
                                            Campus = '{campus}', InstructorId = '{instructorId}'
                                        WHERE CourseId = {courseId}";

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

        /// <summary>
        /// Delete course from database
        /// </summary>
        private void DeleteCourse()
        {
            int courseId = Convert.ToInt32(txtCourseId.Text);

            string sqlDeleteFK = $@"DELETE FROM StudentCourseHub.dbo.StudentCourse WHERE CourseId = {courseId}";
            DataAccess.ExecuteNonQuery(sqlDeleteFK);

            string sqlDeleteCourse = $@"DELETE FROM StudentCourseHub.dbo.Course WHERE CourseId = {courseId}";

            int rowsAffected = DataAccess.ExecuteNonQuery(sqlDeleteCourse);

            if (rowsAffected == 1)
            {
                SetStatusStrip("Deleting...");
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

        /// <summary>
        /// Manage next and previous button state
        /// </summary>
        private void NextPreviousButtonManagement()
        {
            btnPrevious.Enabled = previousCourseId != null;
            btnNext.Enabled = nextCourseId != null;
        }

        /// <summary>
        /// Manage navigation between courses
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
        /// Validates that all required comboboxes have a selected value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmb_Validating(object sender, CancelEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }


        }

        /// <summary>
        /// Validates that all required fields are not empty and do not exceed the length required by the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
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
                else if ((string)txt.Tag == "Description" && txtDescription.Text.Length > 255)
                {
                    errMsg = $"The course description cannot exceed 255 characters in length.";
                    failedValidation = true;
                }
                else if ((string)txt.Tag == "CourseTitle" && txtCourseTitle.Text.Length > 30)
                {
                    errMsg = $"The course title cannot exceed 30 characters in length.";
                    failedValidation = true;
                }

                e.Cancel = failedValidation;

                errProvider.SetError(txt, errMsg);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }

        }
        #endregion

    }
}
