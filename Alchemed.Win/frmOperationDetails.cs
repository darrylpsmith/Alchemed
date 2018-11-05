using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Alchemed.DataModel;

namespace ConsultWill
{
    public partial class frmOperationDetails : Form
    {
        Patient _patient = null;

        public frmOperationDetails(Patient patient)
        {
            _patient = patient;
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Hide();

        }

        public OperationDetails OpDetails
        {
            get
            {
                return new OperationDetails()
                {
                    Id = Guid.NewGuid().ToString(),
                    Date = dateTimePicker1.Value,
                    Anaesthetist = txtAnaethetist.Text,
                    Assistant = txtAssistant.Text,
                    OperationName = txtOperationType.Text,
                    OperationTypeId = txtOperationType.Text,
                    Findings = txtFindings.Text,
                    PatientId = _patient.Id,
                    Position = txtPosition.Text,
                    PostOp = txtPostOp.Text,
                    Side = txtSide.Text,
                    SurgeonId = txtSurgeon.Text,
                    Technique = txtTechnique.Text,
                    WoundClosure = txtWoundClosure.Text
                };

            }

        }

        private void lblOperationCode_Click(object sender, EventArgs e)
        {

        }

        private void cboOperationCode_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
