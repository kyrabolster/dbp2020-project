namespace StudentCourseHub
{
    partial class Courses
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
            this.components = new System.ComponentModel.Container();
            this.grpCourses = new System.Windows.Forms.GroupBox();
            this.cmbInstructors = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCourseId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCourseTitle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.errProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.cmbCampus = new System.Windows.Forms.ComboBox();
            this.grpCourses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // grpCourses
            // 
            this.grpCourses.Controls.Add(this.cmbCampus);
            this.grpCourses.Controls.Add(this.cmbInstructors);
            this.grpCourses.Controls.Add(this.label6);
            this.grpCourses.Controls.Add(this.label5);
            this.grpCourses.Controls.Add(this.txtCourseId);
            this.grpCourses.Controls.Add(this.label1);
            this.grpCourses.Controls.Add(this.btnCancel);
            this.grpCourses.Controls.Add(this.btnLast);
            this.grpCourses.Controls.Add(this.btnAdd);
            this.grpCourses.Controls.Add(this.btnDelete);
            this.grpCourses.Controls.Add(this.btnFirst);
            this.grpCourses.Controls.Add(this.btnSave);
            this.grpCourses.Controls.Add(this.btnPrevious);
            this.grpCourses.Controls.Add(this.btnNext);
            this.grpCourses.Controls.Add(this.txtDescription);
            this.grpCourses.Controls.Add(this.label3);
            this.grpCourses.Controls.Add(this.txtCourseTitle);
            this.grpCourses.Controls.Add(this.label2);
            this.grpCourses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grpCourses.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpCourses.Location = new System.Drawing.Point(38, 26);
            this.grpCourses.Margin = new System.Windows.Forms.Padding(4);
            this.grpCourses.Name = "grpCourses";
            this.grpCourses.Padding = new System.Windows.Forms.Padding(4);
            this.grpCourses.Size = new System.Drawing.Size(574, 540);
            this.grpCourses.TabIndex = 9;
            this.grpCourses.TabStop = false;
            this.grpCourses.Text = "Course Information";
            // 
            // cmbInstructors
            // 
            this.cmbInstructors.FormattingEnabled = true;
            this.cmbInstructors.Location = new System.Drawing.Point(65, 341);
            this.cmbInstructors.Name = "cmbInstructors";
            this.cmbInstructors.Size = new System.Drawing.Size(446, 28);
            this.cmbInstructors.TabIndex = 32;
            this.cmbInstructors.Tag = "Instructor";
            this.cmbInstructors.Validating += new System.ComponentModel.CancelEventHandler(this.cmb_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(62, 311);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 20);
            this.label6.TabIndex = 31;
            this.label6.Text = "Instructor:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(62, 250);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 20);
            this.label5.TabIndex = 29;
            this.label5.Text = "Campus:";
            // 
            // txtCourseId
            // 
            this.txtCourseId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCourseId.Location = new System.Drawing.Point(65, 50);
            this.txtCourseId.Margin = new System.Windows.Forms.Padding(4);
            this.txtCourseId.Name = "txtCourseId";
            this.txtCourseId.ReadOnly = true;
            this.txtCourseId.Size = new System.Drawing.Size(447, 23);
            this.txtCourseId.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 20);
            this.label1.TabIndex = 27;
            this.label1.Text = "Course Id:";
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(404, 444);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(108, 58);
            this.btnCancel.TabIndex = 26;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnLast
            // 
            this.btnLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLast.Location = new System.Drawing.Point(404, 384);
            this.btnLast.Margin = new System.Windows.Forms.Padding(4);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(108, 53);
            this.btnLast.TabIndex = 22;
            this.btnLast.Text = "Last";
            this.btnLast.UseVisualStyleBackColor = true;
            this.btnLast.Click += new System.EventHandler(this.Navigation_Handler);
            // 
            // btnAdd
            // 
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(56, 444);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(108, 58);
            this.btnAdd.TabIndex = 23;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(172, 444);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(108, 58);
            this.btnDelete.TabIndex = 24;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFirst.Location = new System.Drawing.Point(56, 384);
            this.btnFirst.Margin = new System.Windows.Forms.Padding(4);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(108, 53);
            this.btnFirst.TabIndex = 21;
            this.btnFirst.Text = "First";
            this.btnFirst.UseVisualStyleBackColor = true;
            this.btnFirst.Click += new System.EventHandler(this.Navigation_Handler);
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(288, 444);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(108, 58);
            this.btnSave.TabIndex = 25;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevious.Location = new System.Drawing.Point(172, 384);
            this.btnPrevious.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(108, 53);
            this.btnPrevious.TabIndex = 20;
            this.btnPrevious.Text = "Previous";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.Navigation_Handler);
            // 
            // btnNext
            // 
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Location = new System.Drawing.Point(288, 384);
            this.btnNext.Margin = new System.Windows.Forms.Padding(4);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(108, 53);
            this.btnNext.TabIndex = 19;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.Navigation_Handler);
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(65, 163);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(447, 67);
            this.txtDescription.TabIndex = 3;
            this.txtDescription.Tag = "Description";
            this.txtDescription.Validating += new System.ComponentModel.CancelEventHandler(this.txt_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 139);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Description:";
            // 
            // txtCourseTitle
            // 
            this.txtCourseTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCourseTitle.Location = new System.Drawing.Point(65, 103);
            this.txtCourseTitle.Margin = new System.Windows.Forms.Padding(4);
            this.txtCourseTitle.Name = "txtCourseTitle";
            this.txtCourseTitle.Size = new System.Drawing.Size(447, 23);
            this.txtCourseTitle.TabIndex = 1;
            this.txtCourseTitle.Tag = "CourseTitle";
            this.txtCourseTitle.Validating += new System.ComponentModel.CancelEventHandler(this.txt_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 79);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Couse Title:";
            // 
            // errProvider
            // 
            this.errProvider.ContainerControl = this;
            // 
            // cmbCampus
            // 
            this.cmbCampus.FormattingEnabled = true;
            this.cmbCampus.Location = new System.Drawing.Point(65, 273);
            this.cmbCampus.Name = "cmbCampus";
            this.cmbCampus.Size = new System.Drawing.Size(446, 28);
            this.cmbCampus.TabIndex = 33;
            this.cmbCampus.Tag = "Campus";
            this.cmbCampus.Validating += new System.ComponentModel.CancelEventHandler(this.cmb_Validating);
            // 
            // Courses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 605);
            this.Controls.Add(this.grpCourses);
            this.Name = "Courses";
            this.Text = " ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Courses_FormClosing);
            this.Load += new System.EventHandler(this.Courses_Load);
            this.grpCourses.ResumeLayout(false);
            this.grpCourses.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpCourses;
        private System.Windows.Forms.TextBox txtCourseId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCourseTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbInstructors;
        private System.Windows.Forms.ErrorProvider errProvider;
        private System.Windows.Forms.ComboBox cmbCampus;
    }
}