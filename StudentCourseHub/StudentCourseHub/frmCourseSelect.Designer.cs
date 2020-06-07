namespace StudentCourseHub
{
    partial class frmCourseSelect
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
            this.dgvYourCourses = new System.Windows.Forms.DataGridView();
            this.cmbStudents = new System.Windows.Forms.ComboBox();
            this.cmbCampus = new System.Windows.Forms.ComboBox();
            this.cmbInstructors = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCourseId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCourseTitle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDrop = new System.Windows.Forms.Button();
            this.btnEnroll = new System.Windows.Forms.Button();
            this.grpCourseSelect = new System.Windows.Forms.GroupBox();
            this.cmbCampus2 = new System.Windows.Forms.ComboBox();
            this.cmbInstructors2 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCourseId2 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDescription2 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCourseTitle2 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dgvCourseSelect = new System.Windows.Forms.DataGridView();
            this.grpYourCourses = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvYourCourses)).BeginInit();
            this.grpCourseSelect.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourseSelect)).BeginInit();
            this.grpYourCourses.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvYourCourses
            // 
            this.dgvYourCourses.AllowUserToAddRows = false;
            this.dgvYourCourses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvYourCourses.Location = new System.Drawing.Point(8, 39);
            this.dgvYourCourses.Name = "dgvYourCourses";
            this.dgvYourCourses.RowHeadersWidth = 51;
            this.dgvYourCourses.RowTemplate.Height = 24;
            this.dgvYourCourses.Size = new System.Drawing.Size(621, 274);
            this.dgvYourCourses.TabIndex = 3;
            this.dgvYourCourses.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCourses_CellClick);
            // 
            // cmbStudents
            // 
            this.cmbStudents.FormattingEnabled = true;
            this.cmbStudents.Location = new System.Drawing.Point(23, 12);
            this.cmbStudents.Name = "cmbStudents";
            this.cmbStudents.Size = new System.Drawing.Size(285, 24);
            this.cmbStudents.TabIndex = 2;
            this.cmbStudents.SelectionChangeCommitted += new System.EventHandler(this.cmbStudents_SelectionChangeCommitted);
            // 
            // cmbCampus
            // 
            this.cmbCampus.FormattingEnabled = true;
            this.cmbCampus.Location = new System.Drawing.Point(751, 173);
            this.cmbCampus.Name = "cmbCampus";
            this.cmbCampus.Size = new System.Drawing.Size(350, 24);
            this.cmbCampus.TabIndex = 43;
            this.cmbCampus.Tag = "Campus";
            // 
            // cmbInstructors
            // 
            this.cmbInstructors.FormattingEnabled = true;
            this.cmbInstructors.Location = new System.Drawing.Point(751, 204);
            this.cmbInstructors.Name = "cmbInstructors";
            this.cmbInstructors.Size = new System.Drawing.Size(350, 24);
            this.cmbInstructors.TabIndex = 42;
            this.cmbInstructors.Tag = "Instructor";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(661, 204);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 17);
            this.label6.TabIndex = 41;
            this.label6.Text = "Instructor:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(669, 173);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 17);
            this.label5.TabIndex = 40;
            this.label5.Text = "Campus:";
            // 
            // txtCourseId
            // 
            this.txtCourseId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCourseId.Location = new System.Drawing.Point(751, 39);
            this.txtCourseId.Margin = new System.Windows.Forms.Padding(4);
            this.txtCourseId.Name = "txtCourseId";
            this.txtCourseId.ReadOnly = true;
            this.txtCourseId.Size = new System.Drawing.Size(350, 23);
            this.txtCourseId.TabIndex = 39;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(660, 39);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 38;
            this.label1.Text = "Course Id:";
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(751, 99);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(350, 67);
            this.txtDescription.TabIndex = 37;
            this.txtDescription.Tag = "Description";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(649, 99);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 17);
            this.label3.TabIndex = 36;
            this.label3.Text = "Description:";
            // 
            // txtCourseTitle
            // 
            this.txtCourseTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCourseTitle.Location = new System.Drawing.Point(751, 69);
            this.txtCourseTitle.Margin = new System.Windows.Forms.Padding(4);
            this.txtCourseTitle.Name = "txtCourseTitle";
            this.txtCourseTitle.ReadOnly = true;
            this.txtCourseTitle.Size = new System.Drawing.Size(350, 23);
            this.txtCourseTitle.TabIndex = 35;
            this.txtCourseTitle.Tag = "CourseTitle";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(649, 69);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 17);
            this.label2.TabIndex = 34;
            this.label2.Text = "Couse Title:";
            // 
            // btnDrop
            // 
            this.btnDrop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDrop.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDrop.Location = new System.Drawing.Point(826, 255);
            this.btnDrop.Margin = new System.Windows.Forms.Padding(4);
            this.btnDrop.Name = "btnDrop";
            this.btnDrop.Size = new System.Drawing.Size(204, 58);
            this.btnDrop.TabIndex = 44;
            this.btnDrop.Text = "Drop Course";
            this.btnDrop.UseVisualStyleBackColor = true;
            this.btnDrop.Click += new System.EventHandler(this.btnDrop_Click);
            // 
            // btnEnroll
            // 
            this.btnEnroll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnroll.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnroll.Location = new System.Drawing.Point(826, 250);
            this.btnEnroll.Margin = new System.Windows.Forms.Padding(4);
            this.btnEnroll.Name = "btnEnroll";
            this.btnEnroll.Size = new System.Drawing.Size(204, 58);
            this.btnEnroll.TabIndex = 45;
            this.btnEnroll.Text = "Enroll in Course";
            this.btnEnroll.UseVisualStyleBackColor = true;
            this.btnEnroll.Click += new System.EventHandler(this.btnEnroll_Click);
            // 
            // grpCourseSelect
            // 
            this.grpCourseSelect.Controls.Add(this.cmbCampus2);
            this.grpCourseSelect.Controls.Add(this.cmbInstructors2);
            this.grpCourseSelect.Controls.Add(this.label4);
            this.grpCourseSelect.Controls.Add(this.label7);
            this.grpCourseSelect.Controls.Add(this.txtCourseId2);
            this.grpCourseSelect.Controls.Add(this.label8);
            this.grpCourseSelect.Controls.Add(this.txtDescription2);
            this.grpCourseSelect.Controls.Add(this.label9);
            this.grpCourseSelect.Controls.Add(this.txtCourseTitle2);
            this.grpCourseSelect.Controls.Add(this.label10);
            this.grpCourseSelect.Controls.Add(this.btnEnroll);
            this.grpCourseSelect.Controls.Add(this.dgvCourseSelect);
            this.grpCourseSelect.Location = new System.Drawing.Point(23, 410);
            this.grpCourseSelect.Name = "grpCourseSelect";
            this.grpCourseSelect.Size = new System.Drawing.Size(1143, 328);
            this.grpCourseSelect.TabIndex = 46;
            this.grpCourseSelect.TabStop = false;
            this.grpCourseSelect.Text = "Course Selection";
            // 
            // cmbCampus2
            // 
            this.cmbCampus2.FormattingEnabled = true;
            this.cmbCampus2.Location = new System.Drawing.Point(751, 170);
            this.cmbCampus2.Name = "cmbCampus2";
            this.cmbCampus2.Size = new System.Drawing.Size(349, 24);
            this.cmbCampus2.TabIndex = 55;
            this.cmbCampus2.Tag = "Campus";
            // 
            // cmbInstructors2
            // 
            this.cmbInstructors2.FormattingEnabled = true;
            this.cmbInstructors2.Location = new System.Drawing.Point(751, 200);
            this.cmbInstructors2.Name = "cmbInstructors2";
            this.cmbInstructors2.Size = new System.Drawing.Size(348, 24);
            this.cmbInstructors2.TabIndex = 54;
            this.cmbInstructors2.Tag = "Instructor";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(658, 200);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 17);
            this.label4.TabIndex = 53;
            this.label4.Text = "Instructor:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(666, 170);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 17);
            this.label7.TabIndex = 52;
            this.label7.Text = "Campus:";
            // 
            // txtCourseId2
            // 
            this.txtCourseId2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCourseId2.Location = new System.Drawing.Point(751, 34);
            this.txtCourseId2.Margin = new System.Windows.Forms.Padding(4);
            this.txtCourseId2.Name = "txtCourseId2";
            this.txtCourseId2.ReadOnly = true;
            this.txtCourseId2.Size = new System.Drawing.Size(350, 23);
            this.txtCourseId2.TabIndex = 51;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(657, 34);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 17);
            this.label8.TabIndex = 50;
            this.label8.Text = "Course Id:";
            // 
            // txtDescription2
            // 
            this.txtDescription2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription2.Location = new System.Drawing.Point(751, 96);
            this.txtDescription2.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescription2.Multiline = true;
            this.txtDescription2.Name = "txtDescription2";
            this.txtDescription2.ReadOnly = true;
            this.txtDescription2.Size = new System.Drawing.Size(350, 67);
            this.txtDescription2.TabIndex = 49;
            this.txtDescription2.Tag = "Description";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(646, 96);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 17);
            this.label9.TabIndex = 48;
            this.label9.Text = "Description:";
            // 
            // txtCourseTitle2
            // 
            this.txtCourseTitle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCourseTitle2.Location = new System.Drawing.Point(751, 65);
            this.txtCourseTitle2.Margin = new System.Windows.Forms.Padding(4);
            this.txtCourseTitle2.Name = "txtCourseTitle2";
            this.txtCourseTitle2.ReadOnly = true;
            this.txtCourseTitle2.Size = new System.Drawing.Size(349, 23);
            this.txtCourseTitle2.TabIndex = 47;
            this.txtCourseTitle2.Tag = "CourseTitle";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(646, 65);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 17);
            this.label10.TabIndex = 46;
            this.label10.Text = "Couse Title:";
            // 
            // dgvCourseSelect
            // 
            this.dgvCourseSelect.AllowUserToAddRows = false;
            this.dgvCourseSelect.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCourseSelect.Location = new System.Drawing.Point(8, 34);
            this.dgvCourseSelect.Name = "dgvCourseSelect";
            this.dgvCourseSelect.RowHeadersWidth = 51;
            this.dgvCourseSelect.RowTemplate.Height = 24;
            this.dgvCourseSelect.Size = new System.Drawing.Size(621, 274);
            this.dgvCourseSelect.TabIndex = 4;
            this.dgvCourseSelect.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCourseSelect_CellClick);
            // 
            // grpYourCourses
            // 
            this.grpYourCourses.Controls.Add(this.btnDrop);
            this.grpYourCourses.Controls.Add(this.cmbCampus);
            this.grpYourCourses.Controls.Add(this.cmbInstructors);
            this.grpYourCourses.Controls.Add(this.label6);
            this.grpYourCourses.Controls.Add(this.label5);
            this.grpYourCourses.Controls.Add(this.txtCourseId);
            this.grpYourCourses.Controls.Add(this.label1);
            this.grpYourCourses.Controls.Add(this.txtDescription);
            this.grpYourCourses.Controls.Add(this.label3);
            this.grpYourCourses.Controls.Add(this.txtCourseTitle);
            this.grpYourCourses.Controls.Add(this.label2);
            this.grpYourCourses.Controls.Add(this.dgvYourCourses);
            this.grpYourCourses.Location = new System.Drawing.Point(23, 61);
            this.grpYourCourses.Name = "grpYourCourses";
            this.grpYourCourses.Size = new System.Drawing.Size(1143, 332);
            this.grpYourCourses.TabIndex = 47;
            this.grpYourCourses.TabStop = false;
            this.grpYourCourses.Text = "Student\'s Course List";
            // 
            // frmCourseSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1193, 750);
            this.Controls.Add(this.grpYourCourses);
            this.Controls.Add(this.cmbStudents);
            this.Controls.Add(this.grpCourseSelect);
            this.Name = "frmCourseSelect";
            this.Text = "StudentCourses";
            this.Load += new System.EventHandler(this.ViewStudentCourses_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvYourCourses)).EndInit();
            this.grpCourseSelect.ResumeLayout(false);
            this.grpCourseSelect.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourseSelect)).EndInit();
            this.grpYourCourses.ResumeLayout(false);
            this.grpYourCourses.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvYourCourses;
        private System.Windows.Forms.ComboBox cmbStudents;
        private System.Windows.Forms.ComboBox cmbCampus;
        private System.Windows.Forms.ComboBox cmbInstructors;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCourseId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCourseTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDrop;
        private System.Windows.Forms.Button btnEnroll;
        private System.Windows.Forms.GroupBox grpCourseSelect;
        private System.Windows.Forms.DataGridView dgvCourseSelect;
        private System.Windows.Forms.GroupBox grpYourCourses;
        private System.Windows.Forms.ComboBox cmbCampus2;
        private System.Windows.Forms.ComboBox cmbInstructors2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCourseId2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDescription2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCourseTitle2;
        private System.Windows.Forms.Label label10;
    }
}