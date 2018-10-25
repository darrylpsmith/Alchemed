namespace ConsultWill
{
    partial class ScheduledPeople
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
            this.lblTodaysPatients = new System.Windows.Forms.Label();
            this.btnClearTodaysConsults = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lvwTodaysPatients = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lblTodaysPatients
            // 
            this.lblTodaysPatients.AutoSize = true;
            this.lblTodaysPatients.Location = new System.Drawing.Point(-2, 0);
            this.lblTodaysPatients.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTodaysPatients.Name = "lblTodaysPatients";
            this.lblTodaysPatients.Size = new System.Drawing.Size(83, 13);
            this.lblTodaysPatients.TabIndex = 23;
            this.lblTodaysPatients.Text = "Todays Patients";
            // 
            // btnClearTodaysConsults
            // 
            this.btnClearTodaysConsults.Location = new System.Drawing.Point(110, 274);
            this.btnClearTodaysConsults.Name = "btnClearTodaysConsults";
            this.btnClearTodaysConsults.Size = new System.Drawing.Size(87, 23);
            this.btnClearTodaysConsults.TabIndex = 26;
            this.btnClearTodaysConsults.Text = "Clear All";
            this.btnClearTodaysConsults.UseVisualStyleBackColor = true;
            this.btnClearTodaysConsults.Click += new System.EventHandler(this.btnClearTodaysConsults_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnRefresh.Location = new System.Drawing.Point(33, 274);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(72, 24);
            this.btnRefresh.TabIndex = 27;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lvwTodaysPatients
            // 
            this.lvwTodaysPatients.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvwTodaysPatients.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lvwTodaysPatients.Location = new System.Drawing.Point(2, 16);
            this.lvwTodaysPatients.MultiSelect = false;
            this.lvwTodaysPatients.Name = "lvwTodaysPatients";
            this.lvwTodaysPatients.Size = new System.Drawing.Size(196, 252);
            this.lvwTodaysPatients.TabIndex = 28;
            this.lvwTodaysPatients.UseCompatibleStateImageBehavior = false;
            this.lvwTodaysPatients.View = System.Windows.Forms.View.Details;
            this.lvwTodaysPatients.SelectedIndexChanged += new System.EventHandler(this.lvwTodaysPatients_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Patient";
            this.columnHeader1.Width = 180;
            // 
            // ScheduledPeople
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lvwTodaysPatients);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lblTodaysPatients);
            this.Controls.Add(this.btnClearTodaysConsults);
            this.Name = "ScheduledPeople";
            this.Size = new System.Drawing.Size(200, 300);
            this.Load += new System.EventHandler(this.ScheduledPeople_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTodaysPatients;
        private System.Windows.Forms.Button btnClearTodaysConsults;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ListView lvwTodaysPatients;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}
