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
    public partial class frmClinicalNotes : Form
    {
        public frmClinicalNotes()
        {
            InitializeComponent();
        }

        private void frmClinicalNotes_Load(object sender, EventArgs e)
        {

        }

        public DateTime NoteDateTime
        {
            get { return datepickNoteDate.Value; }
        }

        public string Content
        {
            get { return rtbNotes.Rtf; }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ClinicalNotes newNote = new ClinicalNotes
            {
                Id = Guid.NewGuid().ToString(),
                Content = rtbNotes.Rtf,
                UnformattedContent = rtbNotes.Text, 
                Date = datepickNoteDate.Value   
            };

            StaticFunctions.DataInterface().StoreClinicalNote(newNote);
            LoadNote(newNote);
        }

        public void LoadNote (ClinicalNotes note)
        {
            rtfExistingNotes.AppendText(note.Date.ToShortDateString());
            rtfExistingNotes.AppendText(Environment.NewLine);
            rtfExistingNotes.SelectionStart = rtfExistingNotes.Text.Length;
            rtfExistingNotes.SelectionLength = 0;
            rtfExistingNotes.SelectedRtf = note.Content;
            rtfExistingNotes.AppendText("------------------------------------------------------------------------------");
            rtfExistingNotes.AppendText(Environment.NewLine);

            
            string[] subItems = new string[] { note.Id, note.Date.ToShortDateString(), note.UnformattedContent };
            ListViewItem itm = new ListViewItem(subItems);
            lvwClinicalNotes.Items.Add(itm);
            //itm.Text = note.Id;
            //itm.SubItems = subItems;
        }
    }
}
