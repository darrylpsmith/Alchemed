namespace ConsultWill
{
    partial class frmClinicalNotes
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.datepickNoteDate = new System.Windows.Forms.DateTimePicker();
            this.rtbNotes = new System.Windows.Forms.RichTextBox();
            this.rtfExistingNotes = new System.Windows.Forms.RichTextBox();
            this.lvwClinicalNotes = new System.Windows.Forms.ListView();
            this.colId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNote = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(684, 570);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(56, 25);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(605, 570);
            this.btnOk.Margin = new System.Windows.Forms.Padding(2);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(74, 25);
            this.btnOk.TabIndex = 8;
            this.btnOk.Text = "Add Note";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // datepickNoteDate
            // 
            this.datepickNoteDate.Location = new System.Drawing.Point(22, 570);
            this.datepickNoteDate.Name = "datepickNoteDate";
            this.datepickNoteDate.Size = new System.Drawing.Size(200, 20);
            this.datepickNoteDate.TabIndex = 11;
            // 
            // rtbNotes
            // 
            this.rtbNotes.Location = new System.Drawing.Point(12, 408);
            this.rtbNotes.Name = "rtbNotes";
            this.rtbNotes.Size = new System.Drawing.Size(740, 156);
            this.rtbNotes.TabIndex = 12;
            this.rtbNotes.Text = "";
            // 
            // rtfExistingNotes
            // 
            this.rtfExistingNotes.Location = new System.Drawing.Point(12, 180);
            this.rtfExistingNotes.Name = "rtfExistingNotes";
            this.rtfExistingNotes.Size = new System.Drawing.Size(740, 202);
            this.rtfExistingNotes.TabIndex = 13;
            this.rtfExistingNotes.Text = "";
            // 
            // lvwClinicalNotes
            // 
            this.lvwClinicalNotes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colId,
            this.colDate,
            this.colNote});
            this.lvwClinicalNotes.Location = new System.Drawing.Point(12, 12);
            this.lvwClinicalNotes.Name = "lvwClinicalNotes";
            this.lvwClinicalNotes.Size = new System.Drawing.Size(740, 162);
            this.lvwClinicalNotes.TabIndex = 14;
            this.lvwClinicalNotes.UseCompatibleStateImageBehavior = false;
            this.lvwClinicalNotes.View = System.Windows.Forms.View.Details;
            // 
            // colId
            // 
            this.colId.Text = "Id";
            // 
            // colDate
            // 
            this.colDate.Text = "Date";
            this.colDate.Width = 111;
            // 
            // colNote
            // 
            this.colNote.Text = "Note";
            this.colNote.Width = 586;
            // 
            // frmClinicalNotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 620);
            this.ControlBox = false;
            this.Controls.Add(this.lvwClinicalNotes);
            this.Controls.Add(this.rtfExistingNotes);
            this.Controls.Add(this.rtbNotes);
            this.Controls.Add(this.datepickNoteDate);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmClinicalNotes";
            this.Text = "Clinical Notes";
            this.Load += new System.EventHandler(this.frmClinicalNotes_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.DateTimePicker datepickNoteDate;
        private System.Windows.Forms.RichTextBox rtbNotes;
        private System.Windows.Forms.RichTextBox rtfExistingNotes;
        private System.Windows.Forms.ListView lvwClinicalNotes;
        private System.Windows.Forms.ColumnHeader colId;
        private System.Windows.Forms.ColumnHeader colDate;
        private System.Windows.Forms.ColumnHeader colNote;
    }
}