namespace ConsultWill
{
    partial class frmConsult
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsult));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.moreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configurationToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.orderCoffeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.picCoffee = new System.Windows.Forms.PictureBox();
            this.flowDocuments = new System.Windows.Forms.FlowLayoutPanel();
            this.flowMain = new System.Windows.Forms.FlowLayoutPanel();
            this.flowMain1 = new System.Windows.Forms.FlowLayoutPanel();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.txtMsgshort = new System.Windows.Forms.TextBox();
            this.lblChat = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCoffee)).BeginInit();
            this.statusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moreToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1217, 24);
            this.menuStrip1.TabIndex = 17;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // moreToolStripMenuItem
            // 
            this.moreToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.moreToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configurationToolStripMenuItem1,
            this.orderCoffeeToolStripMenuItem});
            this.moreToolStripMenuItem.Name = "moreToolStripMenuItem";
            this.moreToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.moreToolStripMenuItem.Text = "More";
            // 
            // configurationToolStripMenuItem1
            // 
            this.configurationToolStripMenuItem1.Name = "configurationToolStripMenuItem1";
            this.configurationToolStripMenuItem1.Size = new System.Drawing.Size(148, 22);
            this.configurationToolStripMenuItem1.Text = "Configuration";
            this.configurationToolStripMenuItem1.Click += new System.EventHandler(this.configurationToolStripMenuItem1_Click);
            // 
            // orderCoffeeToolStripMenuItem
            // 
            this.orderCoffeeToolStripMenuItem.Name = "orderCoffeeToolStripMenuItem";
            this.orderCoffeeToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.orderCoffeeToolStripMenuItem.Text = "Order Coffee";
            this.orderCoffeeToolStripMenuItem.Click += new System.EventHandler(this.orderCoffeeToolStripMenuItem_Click);
            // 
            // picCoffee
            // 
            this.picCoffee.Image = ((System.Drawing.Image)(resources.GetObject("picCoffee.Image")));
            this.picCoffee.InitialImage = ((System.Drawing.Image)(resources.GetObject("picCoffee.InitialImage")));
            this.picCoffee.Location = new System.Drawing.Point(878, 34);
            this.picCoffee.Margin = new System.Windows.Forms.Padding(2);
            this.picCoffee.Name = "picCoffee";
            this.picCoffee.Size = new System.Drawing.Size(40, 38);
            this.picCoffee.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCoffee.TabIndex = 23;
            this.picCoffee.TabStop = false;
            this.picCoffee.Visible = false;
            this.picCoffee.Click += new System.EventHandler(this.picCoffee_Click);
            // 
            // flowDocuments
            // 
            this.flowDocuments.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.flowDocuments.Location = new System.Drawing.Point(963, 254);
            this.flowDocuments.Name = "flowDocuments";
            this.flowDocuments.Size = new System.Drawing.Size(486, 249);
            this.flowDocuments.TabIndex = 0;
            // 
            // flowMain
            // 
            this.flowMain.Location = new System.Drawing.Point(12, 361);
            this.flowMain.Name = "flowMain";
            this.flowMain.Size = new System.Drawing.Size(1133, 233);
            this.flowMain.TabIndex = 34;
            // 
            // flowMain1
            // 
            this.flowMain1.Location = new System.Drawing.Point(12, 27);
            this.flowMain1.Name = "flowMain1";
            this.flowMain1.Size = new System.Drawing.Size(620, 312);
            this.flowMain1.TabIndex = 35;
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusBar.Location = new System.Drawing.Point(0, 622);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(1217, 22);
            this.statusBar.TabIndex = 36;
            this.statusBar.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // txtMessage
            // 
            this.txtMessage.Enabled = false;
            this.txtMessage.Location = new System.Drawing.Point(683, 76);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessage.Size = new System.Drawing.Size(235, 108);
            this.txtMessage.TabIndex = 37;
            // 
            // txtMsgshort
            // 
            this.txtMsgshort.Location = new System.Drawing.Point(683, 190);
            this.txtMsgshort.Name = "txtMsgshort";
            this.txtMsgshort.Size = new System.Drawing.Size(235, 20);
            this.txtMsgshort.TabIndex = 38;
            this.txtMsgshort.TextChanged += new System.EventHandler(this.txtMsgshort_TextChanged);
            this.txtMsgshort.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMsgshort_KeyDown);
            // 
            // lblChat
            // 
            this.lblChat.AutoSize = true;
            this.lblChat.Location = new System.Drawing.Point(680, 50);
            this.lblChat.Name = "lblChat";
            this.lblChat.Size = new System.Drawing.Size(29, 13);
            this.lblChat.TabIndex = 39;
            this.lblChat.Text = "Chat";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(725, 269);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 40;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmConsult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1217, 644);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblChat);
            this.Controls.Add(this.txtMsgshort);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.picCoffee);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.flowMain1);
            this.Controls.Add(this.flowMain);
            this.Controls.Add(this.flowDocuments);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmConsult";
            this.Text = "Mr William Haynes Consulting - Version 0.3";
            this.Load += new System.EventHandler(this.frmConsult_Load);
            this.Resize += new System.EventHandler(this.frmConsult_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCoffee)).EndInit();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.PictureBox picCoffee;
        private System.Windows.Forms.FlowLayoutPanel flowDocuments;
        private System.Windows.Forms.FlowLayoutPanel flowMain;
        private System.Windows.Forms.FlowLayoutPanel flowMain1;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem moreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configurationToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem orderCoffeeToolStripMenuItem;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.TextBox txtMsgshort;
        private System.Windows.Forms.Label lblChat;
        private System.Windows.Forms.Button button1;
    }
}

