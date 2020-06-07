using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentCourseHub
{
    public partial class MDIHome : Form
    {

        public MDIHome()
        {
            InitializeComponent();
        }

        private void MDIHome_Load(object sender, EventArgs e)
        {
            //Splash mySplash = new Splash();
            //Login myLogin = new Login();

            //mySplash.ShowDialog();

            //if (mySplash.DialogResult != DialogResult.OK)
            //{
            //    this.Close();
            //}
            //else
            //{
            //    myLogin.ShowDialog();
            //}

            //if (myLogin.DialogResult == DialogResult.OK)
            //{
            //    this.Show();
            //}
            //else
            //{
            //    this.Close();
            //}

            Form childForm = new HomeLanding();
            childForm.MdiParent = this;
            childForm.Show();

            foreach (Control control in this.Controls)
            {
                MdiClient client = control as MdiClient;
                if (!(client == null))
                {
                    client.BackColor = Color.White;
                    break;
                }
            }
        }

        private void ShowNewForm(object sender, EventArgs e)
        {

            Form childForm = null;
            ToolStripMenuItem m = (ToolStripMenuItem)sender;

            switch (m.Tag)
            {
                case "Home":
                    foreach (Form c in this.MdiChildren)
                        c.Close();
                    childForm = new HomeLanding();
                    break;
                case "Courses":
                    childForm = new frmCourses();
                    break;
                case "Students":
                    childForm = new frmStudents();
                    break;
                case "Instructors":
                    childForm = new frmInstructors();
                    break;
                case "CourseSelect":
                    childForm = new frmCourseSelect();
                    break;
                case "Classlist":
                    childForm = new frmClasslist();
                    break;
            }

            if (childForm != null)
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.GetType() == childForm.GetType())
                    {
                        f.Activate();
                        return;
                    }
                }
            }

            // close landing page
            foreach (Form c in this.MdiChildren)
            {
                if ((string)c.Tag == "Home")
                    c.Close();
            }

            childForm.MdiParent = this;
            childForm.Show();


        }


        // boilerplate

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }


    }
}
