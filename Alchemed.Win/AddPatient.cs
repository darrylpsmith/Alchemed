using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Word = Microsoft.Office.Interop.Word;
using Alchemed.DataModel;
using RipaD.Client.JsonAccess;
using Newtonsoft.Json;

namespace ConsultWill
{
    public partial class AddPatient : Form
    {

        public Patient AddedPatient { get; set; }
        public AddPatient()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

            //Alchemint.Client.JsonAccess.FabricJsonAccess fabricJsonAccess = new Alchemint.Client.JsonAccess.FabricJsonAccess("https://localhost:5001", "");
            //fabricJsonAccess.CreateEntity(new Alchemint);
            

            int wdToggle = 9999998;
            int wdLine = 5;

            try
            {
                string patient = txtLasteName.Text + ", " + txtFirstName.Text + " " + txtPatientNumber.Text;

                Patient patientToAdd = new Patient(txtFirstName.Text, txtLasteName.Text, txtPatientNumber.Text);
                string folderName = StaticFunctions.GetSelectedPatientFolder(patient, false); //  txtLasteName.Text.Substring(0, 1).ToUpper() + "\\" + txtLasteName.Text + ", " + txtFirstName.Text + " " + txtPatientNumber.Text;
                folderName = folderName.ToUpper();

                if (StaticFunctions.DataInterface().PatientExists(patientToAdd) == false)
                {
                    StaticFunctions.DataInterface().AddPatient(patientToAdd);


                //if (Directory.Exists(folderName) == false)
                //{


                    //Directory.CreateDirectory(folderName);
                    if (StaticFunctions.UseDropBoxStorage == true)
                    {
                        string FileName = folderName + "\\" + StaticFunctions.ClinicalNotesFileName;

                        this.Hide();
                        Application.UseWaitCursor = true;
                        Application.DoEvents();

                        var doc = StaticFunctions.CreateWordDoc(FileName, false);


                        doc.Application.Selection.TypeText(Text: txtLasteName.Text + ", " + txtFirstName.Text + " " + txtPatientNumber.Text);
                        doc.Application.Selection.TypeParagraph();
                        doc.Range(0, 0).Select();
                        doc.Application.Selection.MoveEnd(wdLine);

                        doc.Application.Selection.Font.Size = 20;
                        doc.Application.Selection.Font.Bold = wdToggle;

                        doc.Save();
                        doc.Application.Quit(false);
                        Application.UseWaitCursor = false;



                    }



                    AddedPatient = patientToAdd;


                    if (txtReferringDocFname.Text.Length > 0 || txtReferringDocLname.Text.Length > 0)
                    {
                        Doctor referringDoc = new Doctor(txtReferringDocLname.Text, txtReferringDocFname.Text, txtReferEmail.Text);
                        StaticFunctions.StoreReferringDoctor(patient, referringDoc);
                    }
                    this.DialogResult = DialogResult.OK;
                    this.Hide();

                }
                else
                {
                    Application.UseWaitCursor = false;
                    MessageBox.Show("That patient already exists", "Patient Exists", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                StaticFunctions.HandleException(ex);
            }

        }

        private void AddPatient_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtFirstName;
            this.BackColor = Properties.Settings.Default.BackColor;
            
        }
    }
}
