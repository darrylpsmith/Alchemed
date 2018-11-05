namespace ConsultWill
{
    partial class frmOperationDetails
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
            this.lblOperationCode = new System.Windows.Forms.Label();
            this.cboOperationCode = new System.Windows.Forms.ComboBox();
            this.lstOperationCodes = new System.Windows.Forms.ListBox();
            this.lblOperationCodes = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lblOperationDate = new System.Windows.Forms.Label();
            this.txtSurgeon = new System.Windows.Forms.TextBox();
            this.lblSurgeon = new System.Windows.Forms.Label();
            this.lblAnaethetist = new System.Windows.Forms.Label();
            this.txtAnaethetist = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.lblAsssitant = new System.Windows.Forms.Label();
            this.txtAssistant = new System.Windows.Forms.TextBox();
            this.lblOperationType = new System.Windows.Forms.Label();
            this.txtOperationType = new System.Windows.Forms.TextBox();
            this.lblPosition = new System.Windows.Forms.Label();
            this.txtPosition = new System.Windows.Forms.TextBox();
            this.lblSide = new System.Windows.Forms.Label();
            this.txtSide = new System.Windows.Forms.TextBox();
            this.lblTechnique = new System.Windows.Forms.Label();
            this.txtTechnique = new System.Windows.Forms.TextBox();
            this.lblFindings = new System.Windows.Forms.Label();
            this.txtFindings = new System.Windows.Forms.TextBox();
            this.lblWoundClosure = new System.Windows.Forms.Label();
            this.txtWoundClosure = new System.Windows.Forms.TextBox();
            this.lblPostOp = new System.Windows.Forms.Label();
            this.txtPostOp = new System.Windows.Forms.TextBox();
            this.btnAddOpCode = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblOperationCode
            // 
            this.lblOperationCode.AutoSize = true;
            this.lblOperationCode.Location = new System.Drawing.Point(384, 4);
            this.lblOperationCode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOperationCode.Name = "lblOperationCode";
            this.lblOperationCode.Size = new System.Drawing.Size(81, 13);
            this.lblOperationCode.TabIndex = 0;
            this.lblOperationCode.Text = "Operation Code";
            this.lblOperationCode.Click += new System.EventHandler(this.lblOperationCode_Click);
            // 
            // cboOperationCode
            // 
            this.cboOperationCode.FormattingEnabled = true;
            this.cboOperationCode.Location = new System.Drawing.Point(386, 21);
            this.cboOperationCode.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboOperationCode.Name = "cboOperationCode";
            this.cboOperationCode.Size = new System.Drawing.Size(169, 21);
            this.cboOperationCode.TabIndex = 1;
            this.cboOperationCode.SelectedIndexChanged += new System.EventHandler(this.cboOperationCode_SelectedIndexChanged);
            // 
            // lstOperationCodes
            // 
            this.lstOperationCodes.FormattingEnabled = true;
            this.lstOperationCodes.Location = new System.Drawing.Point(387, 71);
            this.lstOperationCodes.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lstOperationCodes.Name = "lstOperationCodes";
            this.lstOperationCodes.Size = new System.Drawing.Size(310, 199);
            this.lstOperationCodes.TabIndex = 2;
            // 
            // lblOperationCodes
            // 
            this.lblOperationCodes.AutoSize = true;
            this.lblOperationCodes.Location = new System.Drawing.Point(385, 54);
            this.lblOperationCodes.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOperationCodes.Name = "lblOperationCodes";
            this.lblOperationCodes.Size = new System.Drawing.Size(86, 13);
            this.lblOperationCodes.TabIndex = 3;
            this.lblOperationCodes.Text = "Operation Codes";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(11, 22);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(151, 20);
            this.dateTimePicker1.TabIndex = 4;
            // 
            // lblOperationDate
            // 
            this.lblOperationDate.AutoSize = true;
            this.lblOperationDate.Location = new System.Drawing.Point(9, 6);
            this.lblOperationDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOperationDate.Name = "lblOperationDate";
            this.lblOperationDate.Size = new System.Drawing.Size(79, 13);
            this.lblOperationDate.TabIndex = 5;
            this.lblOperationDate.Text = "Operation Date";
            // 
            // txtSurgeon
            // 
            this.txtSurgeon.Location = new System.Drawing.Point(12, 63);
            this.txtSurgeon.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSurgeon.Name = "txtSurgeon";
            this.txtSurgeon.Size = new System.Drawing.Size(150, 20);
            this.txtSurgeon.TabIndex = 6;
            this.txtSurgeon.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // lblSurgeon
            // 
            this.lblSurgeon.AutoSize = true;
            this.lblSurgeon.Location = new System.Drawing.Point(10, 47);
            this.lblSurgeon.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSurgeon.Name = "lblSurgeon";
            this.lblSurgeon.Size = new System.Drawing.Size(47, 13);
            this.lblSurgeon.TabIndex = 7;
            this.lblSurgeon.Text = "Surgeon";
            // 
            // lblAnaethetist
            // 
            this.lblAnaethetist.AutoSize = true;
            this.lblAnaethetist.Location = new System.Drawing.Point(11, 85);
            this.lblAnaethetist.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAnaethetist.Name = "lblAnaethetist";
            this.lblAnaethetist.Size = new System.Drawing.Size(60, 13);
            this.lblAnaethetist.TabIndex = 9;
            this.lblAnaethetist.Text = "Anaethetist";
            // 
            // txtAnaethetist
            // 
            this.txtAnaethetist.Location = new System.Drawing.Point(13, 102);
            this.txtAnaethetist.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtAnaethetist.Name = "txtAnaethetist";
            this.txtAnaethetist.Size = new System.Drawing.Size(149, 20);
            this.txtAnaethetist.TabIndex = 8;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(641, 296);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(56, 25);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(580, 296);
            this.btnOk.Margin = new System.Windows.Forms.Padding(2);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(56, 25);
            this.btnOk.TabIndex = 10;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblAsssitant
            // 
            this.lblAsssitant.AutoSize = true;
            this.lblAsssitant.Location = new System.Drawing.Point(12, 127);
            this.lblAsssitant.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAsssitant.Name = "lblAsssitant";
            this.lblAsssitant.Size = new System.Drawing.Size(49, 13);
            this.lblAsssitant.TabIndex = 13;
            this.lblAsssitant.Text = "Assistant";
            // 
            // txtAssistant
            // 
            this.txtAssistant.Location = new System.Drawing.Point(14, 144);
            this.txtAssistant.Margin = new System.Windows.Forms.Padding(2);
            this.txtAssistant.Name = "txtAssistant";
            this.txtAssistant.Size = new System.Drawing.Size(149, 20);
            this.txtAssistant.TabIndex = 12;
            // 
            // lblOperationType
            // 
            this.lblOperationType.AutoSize = true;
            this.lblOperationType.Location = new System.Drawing.Point(13, 176);
            this.lblOperationType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOperationType.Name = "lblOperationType";
            this.lblOperationType.Size = new System.Drawing.Size(80, 13);
            this.lblOperationType.TabIndex = 15;
            this.lblOperationType.Text = "Operation Type";
            // 
            // txtOperationType
            // 
            this.txtOperationType.Location = new System.Drawing.Point(15, 193);
            this.txtOperationType.Margin = new System.Windows.Forms.Padding(2);
            this.txtOperationType.Name = "txtOperationType";
            this.txtOperationType.Size = new System.Drawing.Size(149, 20);
            this.txtOperationType.TabIndex = 14;
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Location = new System.Drawing.Point(14, 223);
            this.lblPosition.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(44, 13);
            this.lblPosition.TabIndex = 17;
            this.lblPosition.Text = "Position";
            // 
            // txtPosition
            // 
            this.txtPosition.Location = new System.Drawing.Point(16, 240);
            this.txtPosition.Margin = new System.Windows.Forms.Padding(2);
            this.txtPosition.Name = "txtPosition";
            this.txtPosition.Size = new System.Drawing.Size(149, 20);
            this.txtPosition.TabIndex = 16;
            // 
            // lblSide
            // 
            this.lblSide.AutoSize = true;
            this.lblSide.Location = new System.Drawing.Point(15, 268);
            this.lblSide.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSide.Name = "lblSide";
            this.lblSide.Size = new System.Drawing.Size(28, 13);
            this.lblSide.TabIndex = 19;
            this.lblSide.Text = "Side";
            // 
            // txtSide
            // 
            this.txtSide.Location = new System.Drawing.Point(17, 285);
            this.txtSide.Margin = new System.Windows.Forms.Padding(2);
            this.txtSide.Name = "txtSide";
            this.txtSide.Size = new System.Drawing.Size(149, 20);
            this.txtSide.TabIndex = 18;
            // 
            // lblTechnique
            // 
            this.lblTechnique.AutoSize = true;
            this.lblTechnique.Location = new System.Drawing.Point(181, 5);
            this.lblTechnique.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTechnique.Name = "lblTechnique";
            this.lblTechnique.Size = new System.Drawing.Size(58, 13);
            this.lblTechnique.TabIndex = 21;
            this.lblTechnique.Text = "Technique";
            // 
            // txtTechnique
            // 
            this.txtTechnique.Location = new System.Drawing.Point(183, 22);
            this.txtTechnique.Margin = new System.Windows.Forms.Padding(2);
            this.txtTechnique.Name = "txtTechnique";
            this.txtTechnique.Size = new System.Drawing.Size(149, 20);
            this.txtTechnique.TabIndex = 20;
            // 
            // lblFindings
            // 
            this.lblFindings.AutoSize = true;
            this.lblFindings.Location = new System.Drawing.Point(181, 47);
            this.lblFindings.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFindings.Name = "lblFindings";
            this.lblFindings.Size = new System.Drawing.Size(46, 13);
            this.lblFindings.TabIndex = 23;
            this.lblFindings.Text = "Findings";
            // 
            // txtFindings
            // 
            this.txtFindings.Location = new System.Drawing.Point(183, 64);
            this.txtFindings.Margin = new System.Windows.Forms.Padding(2);
            this.txtFindings.Name = "txtFindings";
            this.txtFindings.Size = new System.Drawing.Size(149, 20);
            this.txtFindings.TabIndex = 22;
            // 
            // lblWoundClosure
            // 
            this.lblWoundClosure.AutoSize = true;
            this.lblWoundClosure.Location = new System.Drawing.Point(182, 88);
            this.lblWoundClosure.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblWoundClosure.Name = "lblWoundClosure";
            this.lblWoundClosure.Size = new System.Drawing.Size(83, 13);
            this.lblWoundClosure.TabIndex = 25;
            this.lblWoundClosure.Text = "Wound Closure ";
            // 
            // txtWoundClosure
            // 
            this.txtWoundClosure.Location = new System.Drawing.Point(184, 105);
            this.txtWoundClosure.Margin = new System.Windows.Forms.Padding(2);
            this.txtWoundClosure.Name = "txtWoundClosure";
            this.txtWoundClosure.Size = new System.Drawing.Size(149, 20);
            this.txtWoundClosure.TabIndex = 24;
            // 
            // lblPostOp
            // 
            this.lblPostOp.AutoSize = true;
            this.lblPostOp.Location = new System.Drawing.Point(181, 127);
            this.lblPostOp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPostOp.Name = "lblPostOp";
            this.lblPostOp.Size = new System.Drawing.Size(45, 13);
            this.lblPostOp.TabIndex = 27;
            this.lblPostOp.Text = "Post Op";
            // 
            // txtPostOp
            // 
            this.txtPostOp.Location = new System.Drawing.Point(183, 144);
            this.txtPostOp.Margin = new System.Windows.Forms.Padding(2);
            this.txtPostOp.Name = "txtPostOp";
            this.txtPostOp.Size = new System.Drawing.Size(149, 20);
            this.txtPostOp.TabIndex = 26;
            // 
            // btnAddOpCode
            // 
            this.btnAddOpCode.Location = new System.Drawing.Point(580, 19);
            this.btnAddOpCode.Name = "btnAddOpCode";
            this.btnAddOpCode.Size = new System.Drawing.Size(75, 23);
            this.btnAddOpCode.TabIndex = 28;
            this.btnAddOpCode.Text = "button1";
            this.btnAddOpCode.UseVisualStyleBackColor = true;
            // 
            // frmOperationDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 332);
            this.ControlBox = false;
            this.Controls.Add(this.btnAddOpCode);
            this.Controls.Add(this.lblPostOp);
            this.Controls.Add(this.txtPostOp);
            this.Controls.Add(this.lblWoundClosure);
            this.Controls.Add(this.txtWoundClosure);
            this.Controls.Add(this.lblFindings);
            this.Controls.Add(this.txtFindings);
            this.Controls.Add(this.lblTechnique);
            this.Controls.Add(this.txtTechnique);
            this.Controls.Add(this.lblSide);
            this.Controls.Add(this.txtSide);
            this.Controls.Add(this.lblPosition);
            this.Controls.Add(this.txtPosition);
            this.Controls.Add(this.lblOperationType);
            this.Controls.Add(this.txtOperationType);
            this.Controls.Add(this.lblAsssitant);
            this.Controls.Add(this.txtAssistant);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblAnaethetist);
            this.Controls.Add(this.txtAnaethetist);
            this.Controls.Add(this.lblSurgeon);
            this.Controls.Add(this.txtSurgeon);
            this.Controls.Add(this.lblOperationDate);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.lblOperationCodes);
            this.Controls.Add(this.lstOperationCodes);
            this.Controls.Add(this.cboOperationCode);
            this.Controls.Add(this.lblOperationCode);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOperationDetails";
            this.Text = "Operation Notes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblOperationCode;
        private System.Windows.Forms.ComboBox cboOperationCode;
        private System.Windows.Forms.ListBox lstOperationCodes;
        private System.Windows.Forms.Label lblOperationCodes;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label lblOperationDate;
        private System.Windows.Forms.TextBox txtSurgeon;
        private System.Windows.Forms.Label lblSurgeon;
        private System.Windows.Forms.Label lblAnaethetist;
        private System.Windows.Forms.TextBox txtAnaethetist;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lblAsssitant;
        private System.Windows.Forms.TextBox txtAssistant;
        private System.Windows.Forms.Label lblOperationType;
        private System.Windows.Forms.TextBox txtOperationType;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.TextBox txtPosition;
        private System.Windows.Forms.Label lblSide;
        private System.Windows.Forms.TextBox txtSide;
        private System.Windows.Forms.Label lblTechnique;
        private System.Windows.Forms.TextBox txtTechnique;
        private System.Windows.Forms.Label lblFindings;
        private System.Windows.Forms.TextBox txtFindings;
        private System.Windows.Forms.Label lblWoundClosure;
        private System.Windows.Forms.TextBox txtWoundClosure;
        private System.Windows.Forms.Label lblPostOp;
        private System.Windows.Forms.TextBox txtPostOp;
        private System.Windows.Forms.Button btnAddOpCode;
    }
}