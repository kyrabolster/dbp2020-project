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
    public partial class Courses : Form
    {
        public Courses()
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
            LoadInstructors();
            LoadFirstCourse();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            UIUtilities.ClearControls(this.grpCourses.Controls);

            btnSave.Text = "Create";
            btnAdd.Enabled = false;
            btnDelete.Enabled = false;

            NavigationState(false);
        }
        private void Courses_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }
        #endregion

        #region Retrieves

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

        private void LoadInstructors()
        {
            string sqlInstructors = "SELECT InstructorID, LastName + ', ' + FirstName AS WholeName FROM Instructor ORDER BY LastName, FirstName";
            UIUtilities.BindComboBox(cmbInstructors, DataAccess.GetData(sqlInstructors), "WholeName", "InstructorId");
        }

        private void LoadCourseDetails()
        {
            //errProvider.Clear();

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
                        SELECT TOP(1) CourseId as LastCourseId FROM Course ORDER BY CourseId Desc
                    ) as LastCourseId,
                    (
                        SELECT TOP(1) InstructorId as LastInstructorId FROM Course ORDER BY CourseId Desc
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
                    txtCampus.Text = selectedCourse["Campus"].ToString();
                    cmbInstructors.SelectedValue = selectedCourse["InstructorId"];

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


    }
}
