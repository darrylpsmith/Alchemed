namespace ConsultWill
{
    partial class ButtonsControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCreatePatient = new System.Windows.Forms.Button();
            this.btnAddTodaysConsults = new System.Windows.Forms.Button();
            this.btnInstructionsForPa = new System.Windows.Forms.Button();
            this.btnViewPatientFile = new System.Windows.Forms.Button();
            this.btnCompleteConsult = new System.Windows.Forms.Button();
            this.btnPostOp = new System.Windows.Forms.Button();
            this.flowButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowButtons
            // 
            this.flowButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowButtons.Controls.Add(this.btnCreatePatient);
            this.flowButtons.Controls.Add(this.btnAddTodaysConsults);
            this.flowButtons.Controls.Add(this.btnInstructionsForPa);
            this.flowButtons.Controls.Add(this.btnViewPatientFile);
            this.flowButtons.Controls.Add(this.btnCompleteConsult);
            this.flowButtons.Controls.Add(this.btnPostOp);
            this.flowButtons.Location = new System.Drawing.Point(3, 3);
            this.flowButtons.Name = "flowButtons";
            this.flowButtons.Size = new System.Drawing.Size(196, 296);
            this.flowButtons.TabIndex = 24;
            // 
            // btnCreatePatient
            // 
            this.btnCreatePatient.Location = new System.Drawing.Point(2, 2);
            this.btnCreatePatient.Margin = new System.Windows.Forms.Padding(2);
            this.btnCreatePatient.Name = "btnCreatePatient";
            this.btnCreatePatient.Size = new System.Drawing.Size(194, 45);
            this.btnCreatePatient.TabIndex = 1;
            this.btnCreatePatient.Text = "New Patient";
            this.btnCreatePatient.UseVisualStyleBackColor = true;
            this.btnCreatePatient.Click += new System.EventHandler(this.btnCreatePatient_Click);
            // 
            // btnAddTodaysConsults
            // 
            this.btnAddTodaysConsults.Enabled = false;
            this.btnAddTodaysConsults.Location = new System.Drawing.Point(2, 51);
            this.btnAddTodaysConsults.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddTodaysConsults.Name = "btnAddTodaysConsults";
            this.btnAddTodaysConsults.Size = new System.Drawing.Size(194, 45);
            this.btnAddTodaysConsults.TabIndex = 2;
            this.btnAddTodaysConsults.Text = "Add to Todays Consults";
            this.btnAddTodaysConsults.UseVisualStyleBackColor = true;
            this.btnAddTodaysConsults.Click += new System.EventHandler(this.btnAddTodaysConsults_Click);
            // 
            // btnInstructionsForPa
            // 
            this.btnInstructionsForPa.Location = new System.Drawing.Point(2, 100);
            this.btnInstructionsForPa.Margin = new System.Windows.Forms.Padding(2);
            this.btnInstructionsForPa.Name = "btnInstructionsForPa";
            this.btnInstructionsForPa.Size = new System.Drawing.Size(194, 45);
            this.btnInstructionsForPa.TabIndex = 8;
            this.btnInstructionsForPa.Text = "Add Clipboard Instructions";
            this.btnInstructionsForPa.UseVisualStyleBackColor = true;
            this.btnInstructionsForPa.Click += new System.EventHandler(this.btnInstructionsForPa_Click);
            // 
            // btnViewPatientFile
            // 
            this.btnViewPatientFile.Enabled = false;
            this.btnViewPatientFile.Location = new System.Drawing.Point(2, 149);
            this.btnViewPatientFile.Margin = new System.Windows.Forms.Padding(2);
            this.btnViewPatientFile.Name = "btnViewPatientFile";
            this.btnViewPatientFile.Size = new System.Drawing.Size(194, 45);
            this.btnViewPatientFile.TabIndex = 16;
            this.btnViewPatientFile.Text = "View Patient File";
            this.btnViewPatientFile.UseVisualStyleBackColor = true;
            this.btnViewPatientFile.Click += new System.EventHandler(this.btnViewPatientFile_Click);
            // 
            // btnCompleteConsult
            // 
            this.btnCompleteConsult.Enabled = false;
            this.btnCompleteConsult.Location = new System.Drawing.Point(2, 198);
            this.btnCompleteConsult.Margin = new System.Windows.Forms.Padding(2);
            this.btnCompleteConsult.Name = "btnCompleteConsult";
            this.btnCompleteConsult.Size = new System.Drawing.Size(194, 45);
            this.btnCompleteConsult.TabIndex = 7;
            this.btnCompleteConsult.Text = "Add Clinical Notes";
            this.btnCompleteConsult.UseVisualStyleBackColor = true;
            this.btnCompleteConsult.Click += new System.EventHandler(this.btnCompleteConsult_Click);
            // 
            // btnPostOp
            // 
            this.btnPostOp.Enabled = false;
            this.btnPostOp.Location = new System.Drawing.Point(2, 247);
            this.btnPostOp.Margin = new System.Windows.Forms.Padding(2);
            this.btnPostOp.Name = "btnPostOp";
            this.btnPostOp.Size = new System.Drawing.Size(194, 45);
            this.btnPostOp.TabIndex = 17;
            this.btnPostOp.Text = "Operation Notes";
            this.btnPostOp.UseVisualStyleBackColor = true;
            this.btnPostOp.Click += new System.EventHandler(this.btnPostOp_Click);
            // 
            // ButtonsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowButtons);
            this.Name = "ButtonsControl";
            this.Size = new System.Drawing.Size(202, 302);
            this.flowButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowButtons;
        private System.Windows.Forms.Button btnCreatePatient;
        private System.Windows.Forms.Button btnAddTodaysConsults;
        private System.Windows.Forms.Button btnInstructionsForPa;
        private System.Windows.Forms.Button btnViewPatientFile;
        private System.Windows.Forms.Button btnCompleteConsult;
        private System.Windows.Forms.Button btnPostOp;
    }
}
