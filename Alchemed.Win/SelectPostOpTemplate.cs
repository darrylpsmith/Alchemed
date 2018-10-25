using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ConsultWill
{
    public partial class SelectPostOpTemplate : Form
    {
        public SelectPostOpTemplate()
        {
            InitializeComponent();

            LoadPatientList();

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Hide();
        }

        public string SelectedTemplate()
        {
            if (lstTemplates.SelectedIndex >=0)
            {
                return lstTemplates.SelectedItem.ToString();
            }
            else
            {
                return null;
            }

        }

        private void LoadPatientList()
        {
            lstTemplates.Items.Clear();
            string subFolder = StaticFunctions.TemplatesFolder;

            if (Directory.Exists(subFolder))
            {
                string[] dirs = Directory.GetFiles(subFolder);

                foreach (var dir in dirs)
                {
                    string lastFolderName = Path.GetFileName(dir);
                    lstTemplates.Items.Add(lastFolderName);
                }

            }

        }

        private void SelectPostOpTemplate_Load(object sender, EventArgs e)
        {

        }

        private void lstTemplates_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lstTemplates_DoubleClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Hide();
        }
    }
}
