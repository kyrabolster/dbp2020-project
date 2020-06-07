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
    public partial class frmInstructors : Form
    {
        public frmInstructors()
        {
            InitializeComponent();
        }

        #region Globals

        int currentInstructorId = 0;
        int firstInstructorId = 0;
        int lastInstructorId = 0;
        int? previousInstructorId;
        int? nextInstructorId;
        #endregion

        #region Events

        /// <summary>
        /// Load and setup Instructors form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Instructors_Load(object sender, EventArgs e)
        {
            try
            {
                LoadFirstInstructor();
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


        private void Instructors_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }

        #endregion

        #region Retrieves
        /// <summary>
        /// Load first instructor
        /// </summary>
        private void LoadFirstInstructor()
        {
            try
            {
                DataTable firstInstructor = DataAccess.GetData("SELECT TOP (1) InstructorId FROM Instructor ORDER BY LastName, FirstName");

                if (firstInstructor.Rows.Count > 0)
                {
                    currentInstructorId = Convert.ToInt32(firstInstructor.Rows[0]["InstructorId"]);

                    firstInstructorId = currentInstructorId;

                    LoadInstructorDetails();
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
        /// Load and display instructor details
        /// </summary>
        private void LoadInstructorDetails()
        {

            string[] sqlStatements = new string[]
            {
                $"SELECT * FROM Instructor WHERE InstructorId = {currentInstructorId}",
                $@"
                SELECT 
                    (
                        SELECT TOP(1) InstructorId as FirstInstructorId FROM Instructor ORDER BY LastName, FirstName
                    ) as FirstInstructorId,
                    q.PreviousInstructorId,
                    q.NextInstructorId,
                    (
                        SELECT TOP(1) InstructorId as LastInstructorId FROM Instructor ORDER BY LastName Desc, FirstName Desc
                    ) as LastInstructorId
                    FROM
                    (
                        SELECT InstructorId,
	                    LEAD(InstructorId) OVER(ORDER BY LastName, FirstName) AS NextInstructorId,
	                    LAG(InstructorId) OVER(ORDER BY LastName, FirstName) AS PreviousInstructorId,
                        ROW_NUMBER() OVER(ORDER BY LastName, FirstName) AS 'RowNumber'
                        FROM Instructor
                    ) AS q
                    WHERE q.InstructorId = {currentInstructorId}
                    ORDER BY q.InstructorId"
            };

            try
            {
                DataSet ds = new DataSet();
                ds = DataAccess.GetData(sqlStatements);

                if (ds.Tables[0].Rows.Count == 1)
                {
                    DataRow selectedInstructor = ds.Tables[0].Rows[0];

                    txtInstructorId.Text = selectedInstructor["InstructorId"].ToString();
                    txtInstructorName.Text = selectedInstructor["LastName"].ToString() + ", " + selectedInstructor["FirstName"].ToString();
                    txtEmail.Text = selectedInstructor["Email"].ToString();
                    txtPhone.Text = selectedInstructor["Phone"].ToString();

                    firstInstructorId = Convert.ToInt32(ds.Tables[1].Rows[0]["FirstInstructorId"]);
                    previousInstructorId = ds.Tables[1].Rows[0]["PreviousInstructorId"] != DBNull.Value ? Convert.ToInt32(ds.Tables["Table1"].Rows[0]["PreviousInstructorId"]) : (int?)null;
                    nextInstructorId = ds.Tables[1].Rows[0]["NextInstructorId"] != DBNull.Value ? Convert.ToInt32(ds.Tables["Table1"].Rows[0]["NextInstructorId"]) : (int?)null;
                    lastInstructorId = Convert.ToInt32(ds.Tables[1].Rows[0]["LastInstructorId"]);

                    SetStatusStrip($"Viewing instructor id: {currentInstructorId}");
                }
                else
                {
                    MessageBox.Show("The instructor no longer exists");
                    LoadFirstInstructor();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        #endregion

        #region Navigation

        /// <summary>
        /// Manage button state
        /// </summary>
        private void NextPreviousButtonManagement()
        {
            btnPrevious.Enabled = previousInstructorId != null;
            btnNext.Enabled = nextInstructorId != null;
        }

        /// <summary>
        /// Manage navigation
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
                        currentInstructorId = firstInstructorId;
                        break;
                    case "btnLast":
                        currentInstructorId = lastInstructorId;
                        break;
                    case "btnPrevious":
                        currentInstructorId = previousInstructorId.Value;
                        break;
                    case "btnNext":
                        currentInstructorId = nextInstructorId.Value;
                        break;
                }

                LoadInstructorDetails();
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

    }
}
