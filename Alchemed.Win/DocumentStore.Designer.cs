namespace ConsultWill
{
    partial class DocumentStore
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
            this.components = new System.ComponentModel.Container();
            this.lblDescription = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lvwDocuments = new System.Windows.Forms.ListView();
            this.colPatient = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imgThumbnails = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(0, 11);
            this.lblDescription.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(28, 13);
            this.lblDescription.TabIndex = 15;
            this.lblDescription.Text = "Files";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(199, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(30, 23);
            this.btnAdd.TabIndex = 17;
            this.btnAdd.Text = "...";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lvwDocuments
            // 
            this.lvwDocuments.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colPatient});
            this.lvwDocuments.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lvwDocuments.Location = new System.Drawing.Point(3, 32);
            this.lvwDocuments.Name = "lvwDocuments";
            this.lvwDocuments.Size = new System.Drawing.Size(224, 197);
            this.lvwDocuments.TabIndex = 25;
            this.lvwDocuments.UseCompatibleStateImageBehavior = false;
            this.lvwDocuments.SelectedIndexChanged += new System.EventHandler(this.lvwDocuments_SelectedIndexChanged);
            this.lvwDocuments.DoubleClick += new System.EventHandler(this.lvwDocuments_DoubleClick);
            // 
            // colPatient
            // 
            this.colPatient.Text = "File";
            this.colPatient.Width = 180;
            // 
            // imgThumbnails
            // 
            this.imgThumbnails.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imgThumbnails.ImageSize = new System.Drawing.Size(16, 16);
            this.imgThumbnails.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // DocumentStore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lvwDocuments);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblDescription);
            this.Name = "DocumentStore";
            this.Size = new System.Drawing.Size(230, 231);
            this.Load += new System.EventHandler(this.DocumentStore_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListView lvwDocuments;
        private System.Windows.Forms.ColumnHeader colPatient;
        private System.Windows.Forms.ImageList imgThumbnails;
    }
}
