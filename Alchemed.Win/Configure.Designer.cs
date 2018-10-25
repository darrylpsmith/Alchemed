namespace ConsultWill
{
    partial class Configure
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
            this.directoryEntry1 = new System.DirectoryServices.DirectoryEntry();
            this.btnChooseFolder = new System.Windows.Forms.Button();
            this.txtStorageFolder = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblStorageFolder = new System.Windows.Forms.Label();
            this.radModePA = new System.Windows.Forms.RadioButton();
            this.radModeDoctor = new System.Windows.Forms.RadioButton();
            this.chkUseDropBox = new System.Windows.Forms.CheckBox();
            this.chkUseCloud = new System.Windows.Forms.CheckBox();
            this.lblCloudUrl = new System.Windows.Forms.Label();
            this.txtCloudUrl = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnChooseFolder
            // 
            this.btnChooseFolder.Location = new System.Drawing.Point(411, 47);
            this.btnChooseFolder.Margin = new System.Windows.Forms.Padding(2);
            this.btnChooseFolder.Name = "btnChooseFolder";
            this.btnChooseFolder.Size = new System.Drawing.Size(26, 20);
            this.btnChooseFolder.TabIndex = 0;
            this.btnChooseFolder.Text = "...";
            this.btnChooseFolder.UseVisualStyleBackColor = true;
            this.btnChooseFolder.Click += new System.EventHandler(this.btnChooseFolder_Click);
            // 
            // txtStorageFolder
            // 
            this.txtStorageFolder.Location = new System.Drawing.Point(9, 47);
            this.txtStorageFolder.Margin = new System.Windows.Forms.Padding(2);
            this.txtStorageFolder.Name = "txtStorageFolder";
            this.txtStorageFolder.Size = new System.Drawing.Size(398, 20);
            this.txtStorageFolder.TabIndex = 1;
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(290, 223);
            this.btnOk.Margin = new System.Windows.Forms.Padding(2);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(56, 19);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(351, 223);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(56, 19);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblStorageFolder
            // 
            this.lblStorageFolder.AutoSize = true;
            this.lblStorageFolder.Location = new System.Drawing.Point(7, 31);
            this.lblStorageFolder.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStorageFolder.Name = "lblStorageFolder";
            this.lblStorageFolder.Size = new System.Drawing.Size(124, 13);
            this.lblStorageFolder.TabIndex = 4;
            this.lblStorageFolder.Text = "DropBox Folder Location";
            // 
            // radModePA
            // 
            this.radModePA.AutoSize = true;
            this.radModePA.Location = new System.Drawing.Point(9, 156);
            this.radModePA.Name = "radModePA";
            this.radModePA.Size = new System.Drawing.Size(69, 17);
            this.radModePA.TabIndex = 5;
            this.radModePA.TabStop = true;
            this.radModePA.Text = "PA Mode";
            this.radModePA.UseVisualStyleBackColor = true;
            // 
            // radModeDoctor
            // 
            this.radModeDoctor.AutoSize = true;
            this.radModeDoctor.Location = new System.Drawing.Point(9, 184);
            this.radModeDoctor.Name = "radModeDoctor";
            this.radModeDoctor.Size = new System.Drawing.Size(87, 17);
            this.radModeDoctor.TabIndex = 6;
            this.radModeDoctor.TabStop = true;
            this.radModeDoctor.Text = "Doctor Mode";
            this.radModeDoctor.UseVisualStyleBackColor = true;
            // 
            // chkUseDropBox
            // 
            this.chkUseDropBox.AutoSize = true;
            this.chkUseDropBox.Location = new System.Drawing.Point(10, 1);
            this.chkUseDropBox.Name = "chkUseDropBox";
            this.chkUseDropBox.Size = new System.Drawing.Size(128, 17);
            this.chkUseDropBox.TabIndex = 7;
            this.chkUseDropBox.Text = "Use Dropbox Storage";
            this.chkUseDropBox.UseVisualStyleBackColor = true;
            // 
            // chkUseCloud
            // 
            this.chkUseCloud.AutoSize = true;
            this.chkUseCloud.Location = new System.Drawing.Point(9, 81);
            this.chkUseCloud.Name = "chkUseCloud";
            this.chkUseCloud.Size = new System.Drawing.Size(115, 17);
            this.chkUseCloud.TabIndex = 8;
            this.chkUseCloud.Text = "Use Cloud Storage";
            this.chkUseCloud.UseVisualStyleBackColor = true;
            // 
            // lblCloudUrl
            // 
            this.lblCloudUrl.AutoSize = true;
            this.lblCloudUrl.Location = new System.Drawing.Point(8, 103);
            this.lblCloudUrl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCloudUrl.Name = "lblCloudUrl";
            this.lblCloudUrl.Size = new System.Drawing.Size(90, 13);
            this.lblCloudUrl.TabIndex = 11;
            this.lblCloudUrl.Text = "Cloud Storage Url";
            // 
            // txtCloudUrl
            // 
            this.txtCloudUrl.Location = new System.Drawing.Point(10, 119);
            this.txtCloudUrl.Margin = new System.Windows.Forms.Padding(2);
            this.txtCloudUrl.Name = "txtCloudUrl";
            this.txtCloudUrl.Size = new System.Drawing.Size(398, 20);
            this.txtCloudUrl.TabIndex = 10;
            // 
            // Configure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 247);
            this.ControlBox = false;
            this.Controls.Add(this.lblCloudUrl);
            this.Controls.Add(this.txtCloudUrl);
            this.Controls.Add(this.chkUseCloud);
            this.Controls.Add(this.chkUseDropBox);
            this.Controls.Add(this.radModeDoctor);
            this.Controls.Add(this.radModePA);
            this.Controls.Add(this.lblStorageFolder);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtStorageFolder);
            this.Controls.Add(this.btnChooseFolder);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Configure";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Configure";
            this.Load += new System.EventHandler(this.Configure_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.DirectoryServices.DirectoryEntry directoryEntry1;
        private System.Windows.Forms.Button btnChooseFolder;
        private System.Windows.Forms.TextBox txtStorageFolder;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblStorageFolder;
        private System.Windows.Forms.RadioButton radModePA;
        private System.Windows.Forms.RadioButton radModeDoctor;
        private System.Windows.Forms.CheckBox chkUseDropBox;
        private System.Windows.Forms.CheckBox chkUseCloud;
        private System.Windows.Forms.Label lblCloudUrl;
        private System.Windows.Forms.TextBox txtCloudUrl;
    }
}