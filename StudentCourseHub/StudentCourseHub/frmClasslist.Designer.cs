namespace StudentCourseHub
{
    partial class frmClasslist
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
            this.cmbCourses = new System.Windows.Forms.ComboBox();
            this.dgvClasslist = new System.Windows.Forms.DataGridView();
            this.grpClasslist = new System.Windows.Forms.GroupBox();
            this.txtStudentId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtStudentName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.grpAddToClasslist = new System.Windows.Forms.GroupBox();
            this.txtStudentId2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPhone2 = new System.Windows.Forms.TextBox();
            this.txtAddress2 = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtStudentName2 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtEmail2 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dgvAllStudents = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClasslist)).BeginInit();
            this.grpClasslist.SuspendLayout();
            this.grpAddToClasslist.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllStudents)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbCourses
            // 
            this.cmbCourses.FormattingEnabled = true;
            this.cmbCourses.Location = new System.Drawing.Point(39, 21);
            this.cmbCourses.Name = "cmbCourses";
            this.cmbCourses.Size = new System.Drawing.Size(285, 24);
            this.cmbCourses.TabIndex = 0;
            this.cmbCourses.SelectionChangeCommitted += new System.EventHandler(this.cmbCourses_SelectionChangeCommitted);
            // 
            // dgvClasslist
            // 
            this.dgvClasslist.AllowUserToAddRows = false;
            this.dgvClasslist.BackgroundColor = System.Drawing.Color.White;
            this.dgvClasslist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClasslist.Location = new System.Drawing.Point(13, 23);
            this.dgvClasslist.Name = "dgvClasslist";
            this.dgvClasslist.RowHeadersWidth = 51;
            this.dgvClasslist.RowTemplate.Height = 24;
            this.dgvClasslist.Size = new System.Drawing.Size(762, 274);
            this.dgvClasslist.TabIndex = 1;
            this.dgvClasslist.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStudents_CellClick);
            // 
            // grpClasslist
            // 
            this.grpClasslist.BackColor = System.Drawing.Color.White;
            this.grpClasslist.Controls.Add(this.txtStudentId);
            this.grpClasslist.Controls.Add(this.label4);
            this.grpClasslist.Controls.Add(this.txtPhone);
            this.grpClasslist.Controls.Add(this.txtAddress);
            this.grpClasslist.Controls.Add(this.btnRemove);
            this.grpClasslist.Controls.Add(this.label5);
            this.grpClasslist.Controls.Add(this.txtStudentName);
            this.grpClasslist.Controls.Add(this.label1);
            this.grpClasslist.Controls.Add(this.label3);
            this.grpClasslist.Controls.Add(this.txtEmail);
            this.grpClasslist.Controls.Add(this.label2);
            this.grpClasslist.Controls.Add(this.dgvClasslist);
            this.grpClasslist.Location = new System.Drawing.Point(26, 64);
            this.grpClasslist.Name = "grpClasslist";
            this.grpClasslist.Size = new System.Drawing.Size(1138, 328);
            this.grpClasslist.TabIndex = 2;
            this.grpClasslist.TabStop = false;
            this.grpClasslist.Text = "Classlist";
            // 
            // txtStudentId
            // 
            this.txtStudentId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStudentId.Location = new System.Drawing.Point(880, 50);
            this.txtStudentId.Margin = new System.Windows.Forms.Padding(4);
            this.txtStudentId.Name = "txtStudentId";
            this.txtStudentId.ReadOnly = true;
            this.txtStudentId.Size = new System.Drawing.Size(234, 23);
            this.txtStudentId.TabIndex = 59;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(796, 50);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 17);
            this.label4.TabIndex = 58;
            this.label4.Text = "Student Id:";
            // 
            // txtPhone
            // 
            this.txtPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhone.Location = new System.Drawing.Point(880, 141);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(4);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.ReadOnly = true;
            this.txtPhone.Size = new System.Drawing.Size(234, 23);
            this.txtPhone.TabIndex = 57;
            this.txtPhone.Tag = "CourseTitle";
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(880, 171);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(4);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ReadOnly = true;
            this.txtAddress.Size = new System.Drawing.Size(234, 23);
            this.txtAddress.TabIndex = 56;
            // 
            // btnRemove
            // 
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.Location = new System.Drawing.Point(898, 219);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(204, 58);
            this.btnRemove.TabIndex = 55;
            this.btnRemove.Text = "Remove From Classlist";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(808, 171);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 17);
            this.label5.TabIndex = 51;
            this.label5.Text = "Address:";
            // 
            // txtStudentName
            // 
            this.txtStudentName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStudentName.Location = new System.Drawing.Point(880, 81);
            this.txtStudentName.Margin = new System.Windows.Forms.Padding(4);
            this.txtStudentName.Name = "txtStudentName";
            this.txtStudentName.ReadOnly = true;
            this.txtStudentName.Size = new System.Drawing.Size(234, 23);
            this.txtStudentName.TabIndex = 50;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(823, 81);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 49;
            this.label1.Text = "Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(819, 141);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 17);
            this.label3.TabIndex = 47;
            this.label3.Text = "Phone:";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(880, 111);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(234, 23);
            this.txtEmail.TabIndex = 46;
            this.txtEmail.Tag = "CourseTitle";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(826, 111);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 45;
            this.label2.Text = "Email:";
            // 
            // grpAddToClasslist
            // 
            this.grpAddToClasslist.BackColor = System.Drawing.Color.White;
            this.grpAddToClasslist.Controls.Add(this.txtStudentId2);
            this.grpAddToClasslist.Controls.Add(this.label6);
            this.grpAddToClasslist.Controls.Add(this.txtPhone2);
            this.grpAddToClasslist.Controls.Add(this.txtAddress2);
            this.grpAddToClasslist.Controls.Add(this.btnAdd);
            this.grpAddToClasslist.Controls.Add(this.label7);
            this.grpAddToClasslist.Controls.Add(this.txtStudentName2);
            this.grpAddToClasslist.Controls.Add(this.label8);
            this.grpAddToClasslist.Controls.Add(this.label9);
            this.grpAddToClasslist.Controls.Add(this.txtEmail2);
            this.grpAddToClasslist.Controls.Add(this.label10);
            this.grpAddToClasslist.Controls.Add(this.dgvAllStudents);
            this.grpAddToClasslist.Location = new System.Drawing.Point(26, 410);
            this.grpAddToClasslist.Name = "grpAddToClasslist";
            this.grpAddToClasslist.Size = new System.Drawing.Size(1138, 374);
            this.grpAddToClasslist.TabIndex = 3;
            this.grpAddToClasslist.TabStop = false;
            this.grpAddToClasslist.Text = "Add Students to Classlist";
            // 
            // txtStudentId2
            // 
            this.txtStudentId2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStudentId2.Location = new System.Drawing.Point(880, 50);
            this.txtStudentId2.Margin = new System.Windows.Forms.Padding(4);
            this.txtStudentId2.Name = "txtStudentId2";
            this.txtStudentId2.ReadOnly = true;
            this.txtStudentId2.Size = new System.Drawing.Size(234, 23);
            this.txtStudentId2.TabIndex = 59;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(796, 50);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 17);
            this.label6.TabIndex = 58;
            this.label6.Text = "Student Id:";
            // 
            // txtPhone2
            // 
            this.txtPhone2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhone2.Location = new System.Drawing.Point(880, 141);
            this.txtPhone2.Margin = new System.Windows.Forms.Padding(4);
            this.txtPhone2.Name = "txtPhone2";
            this.txtPhone2.ReadOnly = true;
            this.txtPhone2.Size = new System.Drawing.Size(234, 23);
            this.txtPhone2.TabIndex = 57;
            this.txtPhone2.Tag = "CourseTitle";
            // 
            // txtAddress2
            // 
            this.txtAddress2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress2.Location = new System.Drawing.Point(880, 171);
            this.txtAddress2.Margin = new System.Windows.Forms.Padding(4);
            this.txtAddress2.Name = "txtAddress2";
            this.txtAddress2.ReadOnly = true;
            this.txtAddress2.Size = new System.Drawing.Size(234, 23);
            this.txtAddress2.TabIndex = 56;
            // 
            // btnAdd
            // 
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(898, 211);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(204, 58);
            this.btnAdd.TabIndex = 55;
            this.btnAdd.Text = "Add to Classlist";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(808, 171);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 17);
            this.label7.TabIndex = 51;
            this.label7.Text = "Address:";
            // 
            // txtStudentName2
            // 
            this.txtStudentName2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStudentName2.Location = new System.Drawing.Point(880, 81);
            this.txtStudentName2.Margin = new System.Windows.Forms.Padding(4);
            this.txtStudentName2.Name = "txtStudentName2";
            this.txtStudentName2.ReadOnly = true;
            this.txtStudentName2.Size = new System.Drawing.Size(234, 23);
            this.txtStudentName2.TabIndex = 50;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(823, 81);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 17);
            this.label8.TabIndex = 49;
            this.label8.Text = "Name:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(819, 141);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 17);
            this.label9.TabIndex = 47;
            this.label9.Text = "Phone:";
            // 
            // txtEmail2
            // 
            this.txtEmail2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail2.Location = new System.Drawing.Point(880, 111);
            this.txtEmail2.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmail2.Name = "txtEmail2";
            this.txtEmail2.ReadOnly = true;
            this.txtEmail2.Size = new System.Drawing.Size(234, 23);
            this.txtEmail2.TabIndex = 46;
            this.txtEmail2.Tag = "CourseTitle";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(826, 111);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 17);
            this.label10.TabIndex = 45;
            this.label10.Text = "Email:";
            // 
            // dgvAllStudents
            // 
            this.dgvAllStudents.AllowUserToAddRows = false;
            this.dgvAllStudents.BackgroundColor = System.Drawing.Color.White;
            this.dgvAllStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllStudents.Location = new System.Drawing.Point(13, 23);
            this.dgvAllStudents.Name = "dgvAllStudents";
            this.dgvAllStudents.RowHeadersWidth = 51;
            this.dgvAllStudents.RowTemplate.Height = 24;
            this.dgvAllStudents.Size = new System.Drawing.Size(776, 323);
            this.dgvAllStudents.TabIndex = 1;
            this.dgvAllStudents.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAllStudents_CellClick);
            // 
            // frmClasslist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(181)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(1193, 796);
            this.Controls.Add(this.grpAddToClasslist);
            this.Controls.Add(this.grpClasslist);
            this.Controls.Add(this.cmbCourses);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmClasslist";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Classlist";
            this.Load += new System.EventHandler(this.Classlist_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClasslist)).EndInit();
            this.grpClasslist.ResumeLayout(false);
            this.grpClasslist.PerformLayout();
            this.grpAddToClasslist.ResumeLayout(false);
            this.grpAddToClasslist.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllStudents)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbCourses;
        private System.Windows.Forms.DataGridView dgvClasslist;
        private System.Windows.Forms.GroupBox grpClasslist;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtStudentName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtStudentId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox grpAddToClasslist;
        private System.Windows.Forms.TextBox txtStudentId2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPhone2;
        private System.Windows.Forms.TextBox txtAddress2;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtStudentName2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtEmail2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dgvAllStudents;
    }
}