﻿namespace StudentCourseHub
{
    partial class frmInstructors
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
            this.grpInstructors = new System.Windows.Forms.GroupBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtInstructorId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtInstructorName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.grpInstructors.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpInstructors
            // 
            this.grpInstructors.BackColor = System.Drawing.Color.White;
            this.grpInstructors.Controls.Add(this.txtPhone);
            this.grpInstructors.Controls.Add(this.txtEmail);
            this.grpInstructors.Controls.Add(this.label5);
            this.grpInstructors.Controls.Add(this.txtInstructorId);
            this.grpInstructors.Controls.Add(this.label1);
            this.grpInstructors.Controls.Add(this.btnLast);
            this.grpInstructors.Controls.Add(this.btnFirst);
            this.grpInstructors.Controls.Add(this.btnPrevious);
            this.grpInstructors.Controls.Add(this.btnNext);
            this.grpInstructors.Controls.Add(this.label3);
            this.grpInstructors.Controls.Add(this.txtInstructorName);
            this.grpInstructors.Controls.Add(this.lblName);
            this.grpInstructors.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grpInstructors.Font = new System.Drawing.Font("Century Gothic", 10.2F);
            this.grpInstructors.Location = new System.Drawing.Point(60, 32);
            this.grpInstructors.Margin = new System.Windows.Forms.Padding(4);
            this.grpInstructors.Name = "grpInstructors";
            this.grpInstructors.Padding = new System.Windows.Forms.Padding(4);
            this.grpInstructors.Size = new System.Drawing.Size(643, 407);
            this.grpInstructors.TabIndex = 11;
            this.grpInstructors.TabStop = false;
            this.grpInstructors.Text = "Instructor Information";
            // 
            // txtPhone
            // 
            this.txtPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.txtPhone.Location = new System.Drawing.Point(91, 245);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(4);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(447, 27);
            this.txtPhone.TabIndex = 35;
            this.txtPhone.Tag = "Phone";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.txtEmail.Location = new System.Drawing.Point(91, 183);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(447, 27);
            this.txtEmail.TabIndex = 34;
            this.txtEmail.Tag = "Email";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(90, 221);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 21);
            this.label5.TabIndex = 29;
            this.label5.Text = "Phone:";
            // 
            // txtInstructorId
            // 
            this.txtInstructorId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.txtInstructorId.Location = new System.Drawing.Point(91, 67);
            this.txtInstructorId.Margin = new System.Windows.Forms.Padding(4);
            this.txtInstructorId.Name = "txtInstructorId";
            this.txtInstructorId.ReadOnly = true;
            this.txtInstructorId.Size = new System.Drawing.Size(447, 27);
            this.txtInstructorId.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(87, 43);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 21);
            this.label1.TabIndex = 27;
            this.label1.Text = "Instructor Id:";
            // 
            // btnLast
            // 
            this.btnLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLast.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.btnLast.Location = new System.Drawing.Point(462, 309);
            this.btnLast.Margin = new System.Windows.Forms.Padding(4);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(129, 53);
            this.btnLast.TabIndex = 22;
            this.btnLast.Text = "Last";
            this.btnLast.UseVisualStyleBackColor = true;
            this.btnLast.Click += new System.EventHandler(this.Navigation_Handler);
            // 
            // btnFirst
            // 
            this.btnFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFirst.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.btnFirst.Location = new System.Drawing.Point(51, 309);
            this.btnFirst.Margin = new System.Windows.Forms.Padding(4);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(129, 53);
            this.btnFirst.TabIndex = 21;
            this.btnFirst.Text = "First";
            this.btnFirst.UseVisualStyleBackColor = true;
            this.btnFirst.Click += new System.EventHandler(this.Navigation_Handler);
            // 
            // btnPrevious
            // 
            this.btnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevious.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.btnPrevious.Location = new System.Drawing.Point(188, 309);
            this.btnPrevious.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(129, 53);
            this.btnPrevious.TabIndex = 20;
            this.btnPrevious.Text = "Previous";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.Navigation_Handler);
            // 
            // btnNext
            // 
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.btnNext.Location = new System.Drawing.Point(325, 309);
            this.btnNext.Margin = new System.Windows.Forms.Padding(4);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(129, 53);
            this.btnNext.TabIndex = 19;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.Navigation_Handler);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(89, 159);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Email:";
            // 
            // txtInstructorName
            // 
            this.txtInstructorName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.txtInstructorName.Location = new System.Drawing.Point(91, 120);
            this.txtInstructorName.Margin = new System.Windows.Forms.Padding(4);
            this.txtInstructorName.Name = "txtInstructorName";
            this.txtInstructorName.Size = new System.Drawing.Size(447, 27);
            this.txtInstructorName.TabIndex = 1;
            this.txtInstructorName.Tag = "InstructorName";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(87, 96);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(61, 21);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            // 
            // frmInstructors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(232)))), ((int)(((byte)(189)))));
            this.ClientSize = new System.Drawing.Size(800, 468);
            this.Controls.Add(this.grpInstructors);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmInstructors";
            this.Text = "Instructors";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Instructors_FormClosing);
            this.Load += new System.EventHandler(this.Instructors_Load);
            this.grpInstructors.ResumeLayout(false);
            this.grpInstructors.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpInstructors;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtInstructorId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtInstructorName;
        private System.Windows.Forms.Label lblName;
    }
}