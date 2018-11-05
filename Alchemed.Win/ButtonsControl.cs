using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Alchemed.DataModel;

namespace ConsultWill
{
    public partial class ButtonsControl : UserControl
    {

        public delegate void PersonCreated(Patient Person);
        public event PersonCreated personCreated;

        public delegate void AddPersonToTodayConsults(Consult Consult);
        public event AddPersonToTodayConsults addPersonToTodayConsults;

        public delegate void AddPersonButtonPressed();
        public event AddPersonButtonPressed addPersonButtonPressed;

        public delegate void AddPersonButtonCancelled();
        public event AddPersonButtonCancelled addPersonButtonCancelled;

        public delegate void AddOperationButtonPressed();
        public event AddOperationButtonPressed addOperationButtonPressed;



        public delegate void StatusMessagee(string Status, bool DisableUI);
        public event StatusMessagee statusMessagee;


        Patient _currPerson = null;
        public ButtonsControl()
        {
            InitializeComponent();
        }

        public Patient CurrentPerson
        {
            set
            {
                _currPerson = value;

                btnCompleteConsult.Enabled = (_currPerson != null);
                btnInstructionsForPa.Enabled = (_currPerson != null);
                btnAddTodaysConsults.Enabled = (_currPerson != null);
                btnViewPatientFile.Enabled = (_currPerson != null);
                btnPostOp.Enabled = (_currPerson != null);
            }
                
            get
            {
                return _currPerson;
            }
        }

        private void btnCreatePatient_Click(object sender, EventArgs e)
        {

            // Set cursor as hourglass
            Cursor.Current = Cursors.WaitCursor;

            // Execute your time-intensive hashing code here...

            // Set cursor as default arrow
            Cursor.Current = Cursors.Default;
            try
            {

                addPersonButtonPressed();

                AddPatient add = new AddPatient();
                add.ShowDialog();
                Patient addedPatient = add.AddedPatient;
                var res = add.DialogResult;

                add.Close();
                add = null;

                if (res == DialogResult.OK)
                {
                    personCreated(addedPatient);
                }
                else
                {
                    addPersonButtonCancelled();
                }
            }
            catch (Exception ex)
            {
                StaticFunctions.HandleException(ex);
            }

        }

        private void btnViewPatientFile_Click(object sender, EventArgs e)
        {
            try
            {
                statusMessagee("View patient file...", true);

                string patientFolder = StaticFunctions.GetSelectedPatientFolder(_currPerson.GetPatientString(), false);
                string patientDetailsFilePng = patientFolder + "\\" + StaticFunctions.PatientFilePng;
                string patientDetailsFilePdf = patientFolder + "\\" + StaticFunctions.PatientFilePdf;

                if (File.Exists(patientDetailsFilePng))
                    System.Diagnostics.Process.Start(patientDetailsFilePng);
                else if (File.Exists(patientDetailsFilePdf))
                    System.Diagnostics.Process.Start(patientDetailsFilePdf);
                else
                    MessageBox.Show(patientDetailsFilePng + " does not exist", "Missing Patient File", MessageBoxButtons.OK, MessageBoxIcon.Information);

                statusMessagee("", false);
            }
            catch (Exception ex)
            {
                StaticFunctions.HandleException(ex);
            }
        }

        private void btnCompleteConsult_Click(object sender, EventArgs e)
        {
            try
            {

                statusMessagee("Launching Clinical Notes...", true);

                StaticFunctions.DataInterface().AddClinicalNotes(_currPerson);

                statusMessagee("", false);
            }
            catch (Exception ex)
            {
                StaticFunctions.HandleException(ex);
                statusMessagee("", false);
            }


        }


        private void AddClinicalNotesDropboxVersion ()
        {
        }



        private void btnInstructionsForPa_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(StaticFunctions.ClipBoardFile))
                    StaticFunctions.OpenWordDoc(StaticFunctions.ClipBoardFile);
                else
                    MessageBox.Show(StaticFunctions.ClipBoardFile + " file does not exist.", "Missing File", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                StaticFunctions.HandleException(ex);
            }

        }


        private void btnAddTodaysConsults_Click(object sender, EventArgs e)
        {
            var todaysConsults = StaticFunctions.GetTodaysConsults();
            bool exists = false;
            foreach(var pat in todaysConsults)
            {
                if (pat.PatientId == _currPerson.Id)
                {
                    exists = true;
                }
            }



            if (exists)
            {
                MessageBox.Show("The patient is already in todays Patient list", "Patient Already Scheduled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                addPersonToTodayConsults(new Consult { PatientId = _currPerson.Id , Date = DateTime.Now.Date, DoctorId = "", Description = _currPerson.GetPatientString()} );
            }
        }

        public void ViewPatientFile(Patient Person)
        {
            CurrentPerson = Person;
            btnViewPatientFile_Click(this, null);
        }

        private void btnOrderCoffee_Click(object sender, EventArgs e)
        {

        }

        private void btnPostOp_Click(object sender, EventArgs e)
        {
            try
            {


                statusMessagee("Adding post Operation document...", true);

                StaticFunctions.DataInterface().AddOperationNotes(_currPerson);

                statusMessagee("", false);

                addOperationButtonPressed();
            }
            catch (Exception ex)
            {
                StaticFunctions.HandleException(ex);
            }



        }
    }


}
