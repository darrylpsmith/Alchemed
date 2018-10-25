using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsultWill
{
    public partial class Configure : Form
    {

        public Configure()
        {
            InitializeComponent();

            this.BackColor = Properties.Settings.Default.BackColor;
        }

        private void btnChooseFolder_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog folderDlg = new FolderBrowserDialog();
                folderDlg.ShowNewFolderButton = true;
                // Show the FolderBrowserDialog.  
                DialogResult result = folderDlg.ShowDialog();
                if (result == DialogResult.OK)
                {
                    if (folderDlg.SelectedPath != null)
                        txtStorageFolder.Text = folderDlg.SelectedPath;
                }
            }
            catch (Exception ex)
            {
                StaticFunctions.HandleException(ex);
            }

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtStorageFolder.Text.Length > 0)
            {
                StaticFunctions.StorageFolder = txtStorageFolder.Text.Trim();
            }

            if (radModeDoctor.Checked)
                StaticFunctions.UserMode = UserMode.Doctor;
            else if (radModePA.Checked)
                StaticFunctions.UserMode = UserMode.PA;

            StaticFunctions.UseCloadStorage = chkUseCloud.Checked;
            StaticFunctions.UseDropBoxStorage = chkUseDropBox.Checked;


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void Configure_Load(object sender, EventArgs e)
        {
            if (StaticFunctions.StorageFolder != null)
                txtStorageFolder.Text = StaticFunctions.StorageFolder;

            if (StaticFunctions.CloudStorageUrl != null)
                txtCloudUrl.Text = StaticFunctions.CloudStorageUrl;

            radModeDoctor.Checked = (StaticFunctions.UserMode == UserMode.Doctor);
            radModePA.Checked = (StaticFunctions.UserMode == UserMode.PA);

            chkUseCloud.Checked = StaticFunctions.UseCloadStorage;
            chkUseDropBox.Checked = StaticFunctions.UseDropBoxStorage;

        }
    }
}
