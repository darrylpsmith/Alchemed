namespace ConsultWill
{
    partial class AddPatient
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
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblPatientNo = new System.Windows.Forms.Label();
            this.lblReferringDocFname = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLasteName = new System.Windows.Forms.TextBox();
            this.txtPatientNumber = new System.Windows.Forms.TextBox();
            this.txtReferringDocFname = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.txtReferEmail = new System.Windows.Forms.TextBox();
            this.lblReferringDocEmail = new System.Windows.Forms.Label();
            this.txtReferringDocLname = new System.Windows.Forms.TextBox();
            this.lblReferrringDocLName = new System.Windows.Forms.Label();
            this.grpPatient = new System.Windows.Forms.GroupBox();
            this.grpReferringDoctor = new System.Windows.Forms.GroupBox();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.grpPatient.SuspendLayout();
            this.grpReferringDoctor.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(9, 22);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(76, 17);
            this.lblFirstName.TabIndex = 0;
            this.lblFirstName.Text = "First Name";
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(201, 22);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(76, 17);
            this.lblLastName.TabIndex = 1;
            this.lblLastName.Text = "Last Name";
            // 
            // lblPatientNo
            // 
            this.lblPatientNo.AutoSize = true;
            this.lblPatientNo.Location = new System.Drawing.Point(399, 22);
            this.lblPatientNo.Name = "lblPatientNo";
            this.lblPatientNo.Size = new System.Drawing.Size(78, 17);
            this.lblPatientNo.TabIndex = 2;
            this.lblPatientNo.Text = "Patient No.";
            // 
            // lblReferringDocFname
            // 
            this.lblReferringDocFname.AutoSize = true;
            this.lblReferringDocFname.Location = new System.Drawing.Point(12, 23);
            this.lblReferringDocFname.Name = "lblReferringDocFname";
            this.lblReferringDocFname.Size = new System.Drawing.Size(76, 17);
            this.lblReferringDocFname.TabIndex = 3;
            this.lblReferringDocFname.Text = "First Name";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(9, 43);
            this.txtFirstName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(173, 22);
            this.txtFirstName.TabIndex = 0;
            // 
            // txtLasteName
            // 
            this.txtLasteName.Location = new System.Drawing.Point(204, 43);
            this.txtLasteName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtLasteName.Name = "txtLasteName";
            this.txtLasteName.Size = new System.Drawing.Size(172, 22);
            this.txtLasteName.TabIndex = 1;
            // 
            // txtPatientNumber
            // 
            this.txtPatientNumber.Location = new System.Drawing.Point(403, 41);
            this.txtPatientNumber.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPatientNumber.Name = "txtPatientNumber";
            this.txtPatientNumber.Size = new System.Drawing.Size(168, 22);
            this.txtPatientNumber.TabIndex = 2;
            // 
            // txtReferringDocFname
            // 
            this.txtReferringDocFname.Location = new System.Drawing.Point(15, 43);
            this.txtReferringDocFname.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtReferringDocFname.Name = "txtReferringDocFname";
            this.txtReferringDocFname.Size = new System.Drawing.Size(168, 22);
            this.txtReferringDocFname.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(511, 183);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 31);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(429, 183);
            this.btnOk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 31);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtReferEmail
            // 
            this.txtReferEmail.Location = new System.Drawing.Point(403, 43);
            this.txtReferEmail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtReferEmail.Name = "txtReferEmail";
            this.txtReferEmail.Size = new System.Drawing.Size(168, 22);
            this.txtReferEmail.TabIndex = 5;
            // 
            // lblReferringDocEmail
            // 
            this.lblReferringDocEmail.AutoSize = true;
            this.lblReferringDocEmail.Location = new System.Drawing.Point(399, 25);
            this.lblReferringDocEmail.Name = "lblReferringDocEmail";
            this.lblReferringDocEmail.Size = new System.Drawing.Size(151, 17);
            this.lblReferringDocEmail.TabIndex = 12;
            this.lblReferringDocEmail.Text = "Referring Doctor Email";
            // 
            // txtReferringDocLname
            // 
            this.txtReferringDocLname.Location = new System.Drawing.Point(208, 43);
            this.txtReferringDocLname.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtReferringDocLname.Name = "txtReferringDocLname";
            this.txtReferringDocLname.Size = new System.Drawing.Size(168, 22);
            this.txtReferringDocLname.TabIndex = 4;
            // 
            // lblReferrringDocLName
            // 
            this.lblReferrringDocLName.AutoSize = true;
            this.lblReferrringDocLName.Location = new System.Drawing.Point(205, 23);
            this.lblReferrringDocLName.Name = "lblReferrringDocLName";
            this.lblReferrringDocLName.Size = new System.Drawing.Size(113, 17);
            this.lblReferrringDocLName.TabIndex = 14;
            this.lblReferrringDocLName.Text = "Referring Doctor";
            // 
            // grpPatient
            // 
            this.grpPatient.Controls.Add(this.txtFirstName);
            this.grpPatient.Controls.Add(this.lblFirstName);
            this.grpPatient.Controls.Add(this.lblLastName);
            this.grpPatient.Controls.Add(this.lblPatientNo);
            this.grpPatient.Controls.Add(this.txtLasteName);
            this.grpPatient.Controls.Add(this.txtPatientNumber);
            this.grpPatient.Location = new System.Drawing.Point(13, 4);
            this.grpPatient.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpPatient.Name = "grpPatient";
            this.grpPatient.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpPatient.Size = new System.Drawing.Size(583, 81);
            this.grpPatient.TabIndex = 16;
            this.grpPatient.TabStop = false;
            this.grpPatient.Text = "Patient";
            // 
            // grpReferringDoctor
            // 
            this.grpReferringDoctor.Controls.Add(this.txtReferringDocLname);
            this.grpReferringDoctor.Controls.Add(this.lblReferringDocFname);
            this.grpReferringDoctor.Controls.Add(this.txtReferringDocFname);
            this.grpReferringDoctor.Controls.Add(this.lblReferrringDocLName);
            this.grpReferringDoctor.Controls.Add(this.lblReferringDocEmail);
            this.grpReferringDoctor.Controls.Add(this.txtReferEmail);
            this.grpReferringDoctor.Location = new System.Drawing.Point(13, 92);
            this.grpReferringDoctor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpReferringDoctor.Name = "grpReferringDoctor";
            this.grpReferringDoctor.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpReferringDoctor.Size = new System.Drawing.Size(583, 85);
            this.grpReferringDoctor.TabIndex = 8;
            this.grpReferringDoctor.TabStop = false;
            this.grpReferringDoctor.Text = "Referrring Doctor";
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(39, 273);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(547, 72);
            this.txtOutput.TabIndex = 17;
            // 
            // AddPatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 357);
            this.ControlBox = false;
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.grpReferringDoctor);
            this.Controls.Add(this.grpPatient);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddPatient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Patient";
            this.Load += new System.EventHandler(this.AddPatient_Load);
            this.grpPatient.ResumeLayout(false);
            this.grpPatient.PerformLayout();
            this.grpReferringDoctor.ResumeLayout(false);
            this.grpReferringDoctor.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblPatientNo;
        private System.Windows.Forms.Label lblReferringDocFname;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLasteName;
        private System.Windows.Forms.TextBox txtPatientNumber;
        private System.Windows.Forms.TextBox txtReferringDocFname;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox txtReferEmail;
        private System.Windows.Forms.Label lblReferringDocEmail;
        private System.Windows.Forms.TextBox txtReferringDocLname;
        private System.Windows.Forms.Label lblReferrringDocLName;
        private System.Windows.Forms.GroupBox grpPatient;
        private System.Windows.Forms.GroupBox grpReferringDoctor;
        private System.Windows.Forms.TextBox txtOutput;
    }
}