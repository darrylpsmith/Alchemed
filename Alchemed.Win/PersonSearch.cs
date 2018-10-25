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
    public partial class PersonSearch : UserControl
    {

        // declare delegate 
        public delegate void SelectedPersonChanged (Patient Patient, bool NoSelection);

        //declare event of type delegate
        public event SelectedPersonChanged selectedPersonChanged;


        // declare delegate 
        public delegate void PersonDoubleClicked(Patient Patient);

        //declare event of type delegate
        public event PersonDoubleClicked personDoubleClicked;

        public PersonSearch()
        {
            InitializeComponent();
        }

        public void SetSearch(Patient Search)
        {
            txtFindPatient.Text = "";
            LoadPatientList(Search);
            //txtFindPatient.Text = Search.LastName;
            //txtFindPatient_TextChanged(this, null);
        }
        private void txtFindPatient_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LoadPatientList();
            }
            catch (Exception ex)
            {
                StaticFunctions.HandleException(ex);
            }
        }


        private void LoadPatientList(Patient selectedPatient = null)
        {
            
            lvwPatients.Items.Clear();
            lvwPatients.SelectedItems.Clear();
            lvwPatients_SelectedValueChanged(this, null);
            List<Patient> patients = null;
            if (selectedPatient != null)
            {
                patients = new List<Patient> { selectedPatient };
            }
            else if (txtFindPatient.Text.Trim().Length <= 0)
            {
                return;
            }
            else
            {
                patients = StaticFunctions.GetPatientsByWildCard(txtFindPatient.Text);
            }

            if (patients != null)
            {
                foreach (var pt in patients)
                {
                    var itm = lvwPatients.Items.Add(pt.GetPatientString());
                    itm.Tag = pt;
                }
                if (lvwPatients.Items.Count == 1)
                {
                    lvwPatients.Items[0].Selected = true;
                    lvwPatients_SelectedValueChanged(this, null);
                }

            }




            //public void lstPatients_SelectedValueChanged(object sender, EventArgs e)
            //{


            //}

        }

        private void lvwPatients_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                bool noneSelected = (lvwPatients.SelectedItems.Count <= 0);
                Patient patient = null;
                if (!noneSelected)
                    patient = (Patient)lvwPatients.SelectedItems[0].Tag;


                selectedPersonChanged(patient, noneSelected);

                //btnCompleteConsult.Enabled = (lstPatients.SelectedItem != null);
                //btnInstructionsForPa.Enabled = (lstPatients.SelectedItem != null);
                //btnAttachFile.Enabled = (lstPatients.SelectedItem != null);
                //btnAddTodaysConsults.Enabled = (lstPatients.SelectedItem != null);
                //btnViewPatientFile.Enabled = (lstPatients.SelectedItem != null);
                //PopulatePatientAttachedFiles();

            }
            catch (Exception ex)
            {
                StaticFunctions.HandleException(ex);
            }
        }

        private void lvwPatients_SelectedValueChanged(object sender, EventArgs e)
        {

        }


        private void lvwPatients_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (lvwPatients.SelectedItems.Count > 0)
                {
                    if (lvwPatients.SelectedItems[0].Tag != null)
                    {
                        personDoubleClicked((Patient)lvwPatients.SelectedItems[0].Tag);
                    }
                }
            }
            catch (Exception ex)
            {
                StaticFunctions.HandleException(ex);
            }
        }

        private void lblFindPatient_Click(object sender, EventArgs e)
        {

        }

        private void PersonSearch_Load(object sender, EventArgs e)
        {

        }
    }
}
