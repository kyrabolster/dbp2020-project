namespace StudentCourseHub
{
    partial class HomeLanding
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCourses = new System.Windows.Forms.Button();
            this.btnStudents = new System.Windows.Forms.Button();
            this.btnInstructors = new System.Windows.Forms.Button();
            this.btnCourseSelect = new System.Windows.Forms.Button();
            this.btnClasslist = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCourses
            // 
            this.btnCourses.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnCourses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCourses.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCourses.ForeColor = System.Drawing.Color.White;
            this.btnCourses.Location = new System.Drawing.Point(430, 113);
            this.btnCourses.Name = "btnCourses";
            this.btnCourses.Size = new System.Drawing.Size(222, 113);
            this.btnCourses.TabIndex = 0;
            this.btnCourses.Tag = "Courses";
            this.btnCourses.Text = "Courses";
            this.btnCourses.UseVisualStyleBackColor = false;
            this.btnCourses.Click += new System.EventHandler(this.ShowNewForm);
            // 
            // btnStudents
            // 
            this.btnStudents.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnStudents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStudents.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStudents.ForeColor = System.Drawing.Color.White;
            this.btnStudents.Location = new System.Drawing.Point(430, 247);
            this.btnStudents.Name = "btnStudents";
            this.btnStudents.Size = new System.Drawing.Size(222, 113);
            this.btnStudents.TabIndex = 1;
            this.btnStudents.Tag = "Students";
            this.btnStudents.Text = "Students";
            this.btnStudents.UseVisualStyleBackColor = false;
            this.btnStudents.Click += new System.EventHandler(this.ShowNewForm);
            // 
            // btnInstructors
            // 
            this.btnInstructors.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(232)))), ((int)(((byte)(189)))));
            this.btnInstructors.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInstructors.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInstructors.ForeColor = System.Drawing.Color.White;
            this.btnInstructors.Location = new System.Drawing.Point(430, 381);
            this.btnInstructors.Name = "btnInstructors";
            this.btnInstructors.Size = new System.Drawing.Size(222, 113);
            this.btnInstructors.TabIndex = 2;
            this.btnInstructors.Tag = "Instructors";
            this.btnInstructors.Text = "Instructors";
            this.btnInstructors.UseVisualStyleBackColor = false;
            this.btnInstructors.Click += new System.EventHandler(this.ShowNewForm);
            // 
            // btnCourseSelect
            // 
            this.btnCourseSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(189)))), ((int)(((byte)(96)))));
            this.btnCourseSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCourseSelect.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCourseSelect.ForeColor = System.Drawing.Color.White;
            this.btnCourseSelect.Location = new System.Drawing.Point(130, 113);
            this.btnCourseSelect.Name = "btnCourseSelect";
            this.btnCourseSelect.Size = new System.Drawing.Size(276, 182);
            this.btnCourseSelect.TabIndex = 3;
            this.btnCourseSelect.Tag = "CourseSelect";
            this.btnCourseSelect.Text = "View Courses && Course Select";
            this.btnCourseSelect.UseVisualStyleBackColor = false;
            this.btnCourseSelect.Click += new System.EventHandler(this.ShowNewForm);
            // 
            // btnClasslist
            // 
            this.btnClasslist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(181)))), ((int)(((byte)(245)))));
            this.btnClasslist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClasslist.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClasslist.ForeColor = System.Drawing.Color.White;
            this.btnClasslist.Location = new System.Drawing.Point(130, 312);
            this.btnClasslist.Name = "btnClasslist";
            this.btnClasslist.Size = new System.Drawing.Size(276, 182);
            this.btnClasslist.TabIndex = 4;
            this.btnClasslist.Tag = "Classlist";
            this.btnClasslist.Text = "View && Edit Classlists";
            this.btnClasslist.UseVisualStyleBackColor = false;
            this.btnClasslist.Click += new System.EventHandler(this.ShowNewForm);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 24F);
            this.label1.Location = new System.Drawing.Point(199, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(386, 49);
            this.label1.TabIndex = 5;
            this.label1.Text = "StudentCourseHub";
            // 
            // HomeLanding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(800, 574);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClasslist);
            this.Controls.Add(this.btnCourseSelect);
            this.Controls.Add(this.btnInstructors);
            this.Controls.Add(this.btnStudents);
            this.Controls.Add(this.btnCourses);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "HomeLanding";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "Home";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCourses;
        private System.Windows.Forms.Button btnStudents;
        private System.Windows.Forms.Button btnInstructors;
        private System.Windows.Forms.Button btnCourseSelect;
        private System.Windows.Forms.Button btnClasslist;
        private System.Windows.Forms.Label label1;
    }
}