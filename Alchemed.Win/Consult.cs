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
using Alchemed.DataModel;
using System.Drawing;
using System.Drawing.Drawing2D;
namespace ConsultWill
{


    public partial class frmConsult : Form
    {
        private bool m_bLayoutCalled = false;
        private DateTime m_dt;


        PersonSearch _personSearch = null;
        ScheduledPeople _scheduledPeople = null;
        ButtonsControl _buttonsContainer = null;

        List<DocumentStore> _patientDocumentControls = new List<DocumentStore>();
        DocumentStore _opearionsDocuments = null;

        FileSystemWatcher _coffeeWatcher = new FileSystemWatcher();
        FileSystemWatcher _patientWatcher = new FileSystemWatcher();
        FileSystemWatcher _doctorMessageWatcher = new FileSystemWatcher();
        FileSystemWatcher _paMessageWatcher = new FileSystemWatcher();
        

        //private UserMode _mode = UserMode.Doctor;
        public frmConsult()
        {
            InitializeComponent();

            try
            {
                _personSearch = new PersonSearch();
                _scheduledPeople = new ScheduledPeople();
                _buttonsContainer = new ButtonsControl();
            }
            catch (Exception ex)
            {
                StaticFunctions.HandleException(ex);
                this.Close();
            }



            //this.Layout += new System.Windows.Forms.LayoutEventHandler(this.TestSplashScreen_Layout);

        }

        private void BuildForm()
        {
            //this.Height= 770;
            //this.Width = 660;
            //flowShowDetails.Anchor = AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Top; // AnchorStyles.Left |


            _personSearch.selectedPersonChanged += personSearch_Changed;
            _personSearch.personDoubleClicked += _personSearch_personDoubleClicked;
            _buttonsContainer.personCreated += _buttonsContainer_personCreated;
            _buttonsContainer.addPersonToTodayConsults += _buttonsContainer_addPersonToTodayConsults;
            _buttonsContainer.addPersonButtonPressed += _buttonsContainer_addPersonButtonPressed;
            _buttonsContainer.addPersonButtonCancelled += _buttonsContainer_addPersonButtonCancelled;
            _scheduledPeople.selectedPersonChanged += _scheduledPeople_selectedPersonChanged;
            _buttonsContainer.addOperationButtonPressed += _buttonsContainer_addOperationButtonPressed;
            _buttonsContainer.statusMessagee += _buttonsContainer_statusMessagee;
            this.flowMain1.Controls.Add(_personSearch);
            this.flowMain1.Controls.Add(_buttonsContainer);
            this.flowMain1.Controls.Add(_scheduledPeople);


            int Y = 0;
            int X = 5;
            int GAP = 5;



            tabArtifacts.TabPages.Clear();

            foreach (var docType in StaticFunctions.PatientDocumentConfig())
            {
                flowDocuments.AutoSize = true;
                //flowMain.AutoSize = true;
                Y = Y + GAP;
                DocumentStore ds = new DocumentStore(docType, X, Y, docType.UseLargeImages);
                _patientDocumentControls.Add(ds);
                _opearionsDocuments = ds;
                _opearionsDocuments.selectedImageChanged += _opearionsDocuments_selectedImageChanged;

                var tabPage = new TabPage();

                tabArtifacts.TabPages.Add(tabPage);
                tabPage.Text = docType.DisplayName;

                //this.pnlDocuments.Controls.Add(ds);
                //this.flowDocuments.Controls.Add(ds);

                tabPage.Controls.Add(ds);
                ds.Dock = DockStyle.Fill;
                //this.flowMain.Controls.Add(ds);
                //this.flowMain.Controls.Add(ds);


                //this.tableLayoutPanel1.Controls.Add(ds);
                ds.Visible = true;
                Y = Y + ds.Height + GAP;
            }

            toolStripStatusLabel1.Text = "";

            this.BackColor = Properties.Settings.Default.BackColor;
            foreach (var ctl in this.Controls)
            {
               //ctl.
            }


        }

        private void _opearionsDocuments_selectedImageChanged(Image image)
        {

            frmViewImage frmView = new frmViewImage(image);
            frmView.MdiParent = this.MdiParent;
            frmView.Show();

            //image.Save("C:/temp/1.jpg");
            //image.Save("C:/temp/1.bmp");
            //image.Save("C:/temp/1.png");
        }


        private void _buttonsContainer_statusMessagee(string Status, bool DisableUI)
        {
            toolStripStatusLabel1.Text = Status;
            this.Enabled = !DisableUI;
        }

        private void _buttonsContainer_addPostOpButtonPComplete()
        {
            toolStripStatusLabel1.Text = "";
            this.Enabled = true;
        }

        private void _buttonsContainer_addPostOpButtonPressed()
        {
            toolStripStatusLabel1.Text = "Adding Post Operation Document....";
            this.Enabled = false;
        }

        private void _buttonsContainer_addOperationButtonPressed()
        {
            _opearionsDocuments.PopulatePatientAttachedFiles();
        }

        private void _buttonsContainer_addPersonButtonCancelled()
        {
            this.Enabled = true;
            toolStripStatusLabel1.Text = "";
        }

        private void _buttonsContainer_addPersonButtonPressed()
        {
            toolStripStatusLabel1.Text = "Adding Patient....";
            this.Enabled = false;
        }

        private void _personSearch_personDoubleClicked(Patient Patient)
        {
            _buttonsContainer.ViewPatientFile(Patient);
        }

        private void _scheduledPeople_selectedPersonChanged(Patient Person)
        {
            SelectedPersonChanged(Person);
        }

        private void _buttonsContainer_addPersonToTodayConsults(Consult Consult)
        {
            _scheduledPeople.AddToToday(Consult);
        }

        private void _buttonsContainer_personCreated(Patient Person)
        {
            SelectedPersonChanged(Person);
            this.Enabled = true;
            toolStripStatusLabel1.Text = "";
        }

        private void SelectedPersonChanged(Patient Person)
        {
            _buttonsContainer_statusMessagee("Selecting...", true);
            _personSearch.SetSearch(Person);
            foreach (var ctl in _patientDocumentControls)
            {
                ctl.CurrentPerson = Person;
            }
            _buttonsContainer_statusMessagee("", false);
        }


        //beforePrintevent handler
        void personSearch_Changed(Patient selectedPatient, bool NoSelection)
        {
            if (NoSelection)
            {
                _buttonsContainer.CurrentPerson = null;
            }
            else
            {
                _buttonsContainer.CurrentPerson = selectedPatient;
                //SelectedPersonChanged(Patient);
                foreach (var ctl in _patientDocumentControls)
                {
                    ctl.CurrentPerson = selectedPatient;
                }
            }
            
        }


        private void frmConsult_Load(object sender, EventArgs e)
        {

            try
            {

                



                WatchForCoffee();

                if  (StaticFunctions.UserMode == UserMode.Doctor)
                {
                    WatchForChangesToTodaysPatients();
                    WatchForPAMessage();
                }

                if (StaticFunctions.UserMode == UserMode.PA)
                {
                    WatchForChangesToTodaysPatients();
                    WatchForDoctorMessage();
                }



                orderCoffeeToolStripMenuItem.Enabled = (StaticFunctions.UserMode == UserMode.Doctor);
                

                BuildForm();


                //WatchForChangesToTodaysPatients();
            }
            catch (Exception ex)
            {
                StaticFunctions.HandleException(ex);
            }

        }





        private void btnCompleteConsult_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    string patientFolder = GetSelectedPatientFolder();
            //    string clinicalNotesFile = patientFolder + "\\" + StaticFunctions.ClinicalNotesFileName;
            //    StaticFunctions.OpenWordDoc(clinicalNotesFile);
            //}
            //catch (Exception ex)
            //{
            //    StaticFunctions.HandleException(ex);
            //}

        }








        //private void btnAttachFile_Click(object sender, EventArgs e)
        //{

        //    try
        //    {
        //        string radFolder = GetSelectedPatientRadiologyFolder();
        //        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        //        if (openFileDialog1.ShowDialog() == DialogResult.OK)
        //        {
        //            if (!Directory.Exists(radFolder))
        //                Directory.CreateDirectory(radFolder);


        //            string selectedFile = openFileDialog1.FileName;
        //            string fileName = Path.GetFileName(selectedFile);

        //            File.Copy(selectedFile, radFolder + fileName);
        //            File.Delete(selectedFile);
        //            PopulatePatientAttachedFiles();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        StaticFunctions.HandleException(ex);
        //    }
        //}

        private void lstPatients_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        private void lstPatientFiles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //private void lstPatientFiles_DoubleClick(object sender, EventArgs e)
        //{

        //    try
        //    {
        //        if (lstPatientFiles.SelectedItem != null)
        //        {
        //            if (lstPatientFiles.SelectedItem.ToString().Length != 0)
        //            {
        //                string radFolder = StaticFunctions.GetSelectedPatientRadiologyFolder();
        //                string file = radFolder + lstPatientFiles.SelectedItem.ToString();
        //                System.Diagnostics.Process.Start(file);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        StaticFunctions.HandleException(ex);
        //    }

        //}

        public void WatchForCoffee ()
        {
            WatchForChangesToFile(_coffeeWatcher, StaticFunctions.ConsultTrackerFolder, StaticFunctions.CoffeeFile, new FileSystemEventHandler(coffeeFileChanged));
        }

        public void WatchForPAMessage()
        {
            WatchForChangesToFile(_paMessageWatcher, StaticFunctions.ConsultTrackerFolder, StaticFunctions.PAMessageFile, new FileSystemEventHandler(paMessageFileChanged));
        }

        public void WatchForDoctorMessage()
        {
            WatchForChangesToFile(_doctorMessageWatcher, StaticFunctions.ConsultTrackerFolder, StaticFunctions.DoctorMessageFile, new FileSystemEventHandler(doctorMessageFileChanged));
        }

        private void coffeeFileChanged(object sender, EventArgs e)
        {
            try
            {
                ShowCoffeeImage(picCoffee);
            }
            catch (Exception ex)
            {
                StaticFunctions.HandleException(ex);
            }
        }

        private void doctorMessageFileChanged(object sender, EventArgs e)
        {
            try
            {
                ShowDoctorMessage(txtMessage);
            }
            catch (Exception ex)
            {
                StaticFunctions.HandleException(ex);
            }
        }

        private void paMessageFileChanged(object sender, EventArgs e)
        {
            try
            {
                ShowPAMessage(txtMessage);
            }
            catch (Exception ex)
            {
                StaticFunctions.HandleException(ex);
            }
        }




        delegate void ShowCoffeeImageUpdateText(Control ctl);
        
        private void ShowCoffeeImage(Control ctl)
        {
            if (ctl.InvokeRequired)
            {
                ShowCoffeeImageUpdateText callbackMethod = new ShowCoffeeImageUpdateText(ShowCoffeeImage);
                this.Invoke(callbackMethod, ctl);
            }
            else
            {
                ctl.Visible = true;
            }
        }



        delegate void ShowDoctorMessageUpdateText(Control ctl);

        private void ShowDoctorMessage(Control ctl)
        {
            if (ctl.InvokeRequired)
            {
                ShowDoctorMessageUpdateText callbackMethod = new ShowDoctorMessageUpdateText(ShowDoctorMessage);
                this.Invoke(callbackMethod, ctl);
            }
            else
            {
                ((TextBox)ctl).AppendText ("Doctor: " + StaticFunctions.DoctorMessage + Environment.NewLine + Environment.NewLine);
            }
        }

        delegate void ShowPAMessageUpdateText(Control ctl);

        private void ShowPAMessage(Control ctl)
        {
            if (ctl.InvokeRequired)
            {
                ShowPAMessageUpdateText callbackMethod = new ShowPAMessageUpdateText(ShowPAMessage);
                this.Invoke(callbackMethod, ctl);
            }
            else
            {
                ((TextBox)ctl).AppendText("PA: " + StaticFunctions.PAMessage + Environment.NewLine + Environment.NewLine);
            }
        }


        private void todaysPatientsChanged(object sender, EventArgs e)
        {
            try
            {
                //TODO
                LoadTodaysPatients2(_scheduledPeople);
            }
            catch (Exception ex)
            {
                StaticFunctions.HandleException(ex);
            }
        }

        delegate void LoadTodaysPatients2Update(Control ctl);

        private void LoadTodaysPatients2(Control ctl)
        {
            
            if (ctl.InvokeRequired)
            {
                LoadTodaysPatients2Update callbackMethod = new LoadTodaysPatients2Update(LoadTodaysPatients2);
                this.Invoke(callbackMethod, ctl);
            }
            else
            {
                ((ScheduledPeople)ctl).Refresh();
                ctl.Visible = true;
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnOrderCoffee_Click(object sender, EventArgs e)
        {


        }

        private void btnViewPatientFile_Click(object sender, EventArgs e)
        {
            //try
            //{

            //    string patientFolder = GetSelectedPatientFolder();
            //    string patientDetailsFilePng = patientFolder + "\\" + StaticFunctions.PatientFilePng;
            //    string patientDetailsFilePdf = patientFolder + "\\" + StaticFunctions.PatientFilePdf;

            //    if (File.Exists(patientDetailsFilePng))
            //        System.Diagnostics.Process.Start(patientDetailsFilePng);
            //    else if (File.Exists(patientDetailsFilePdf))
            //        System.Diagnostics.Process.Start(patientDetailsFilePdf);
            //    else
            //        MessageBox.Show(patientDetailsFilePng + " does not exist", "Missing Patient File", MessageBoxButtons.OK, MessageBoxIcon.Information);            }
            //catch (Exception ex)
            //{
            //    StaticFunctions.HandleException(ex);
            //}
        }







        private void picCoffee_Click(object sender, EventArgs e)
        {
            picCoffee.Visible = false;
        }

        private void frmConsult_Resize(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = this.Width.ToString() + " " + this.Height.ToString();
        }

        private void configurationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                Configure cfg = new Configure();
                cfg.ShowDialog();
                orderCoffeeToolStripMenuItem.Enabled = (StaticFunctions.UserMode == UserMode.Doctor);
            }
            catch (Exception ex)
            {
                StaticFunctions.HandleException(ex);
            }
        }

        private void orderCoffeeToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                //_mode = UserMode.Doctor;

                if (_coffeeWatcher != null)
                {
                    _coffeeWatcher.EnableRaisingEvents = false;
                    _coffeeWatcher = null;
                }

                string coffeeFile = StaticFunctions.ConsultTrackerFolder + "\\" + StaticFunctions.CoffeeFile;

                File.WriteAllText(coffeeFile, "COFFEE : " + DateTime.UtcNow.ToString());

                MessageBox.Show("Coffee ordered.", "Coffee Ordered", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                StaticFunctions.HandleException(ex);
            }
        }





        public void WatchForChangesToFile(FileSystemWatcher Watcher, string Folder, string File, FileSystemEventHandler EventHandler)
        {
            try
            {

                Watcher.Path = Folder;
                Watcher.Filter = File ;

                // Watch for all changes specified in the NotifyFilters
                //enumeration.
                //Watcher.NotifyFilter = NotifyFilters.Attributes |
                //NotifyFilters.CreationTime |
                //NotifyFilters.DirectoryName |
                //NotifyFilters.FileName |
                //NotifyFilters.LastAccess |
                //NotifyFilters.LastWrite |
                //NotifyFilters.Security |
                //NotifyFilters.Size;


                Watcher.NotifyFilter = NotifyFilters.LastWrite;

                Watcher.Changed += EventHandler ;

                Watcher.EnableRaisingEvents = true;
            }
            catch (Exception ex)
            {
                StaticFunctions.HandleException(ex);
            }
        }
        

        public void WatchForChangesToTodaysPatients()
        {
            WatchForChangesToFile(_patientWatcher, StaticFunctions.ConsultTrackerFolder, StaticFunctions.ConsultTrackerTodaysFile, new FileSystemEventHandler(todaysPatientsChanged));
        }

        private void sendMessageToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void txtMsgshort_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                try
                {

                    string messageFile = "";

                    if (StaticFunctions.UserMode == UserMode.Doctor)
                        messageFile = StaticFunctions.ConsultTrackerFolder + "\\" + StaticFunctions.DoctorMessageFile;
                    else if (StaticFunctions.UserMode == UserMode.PA)
                        messageFile = StaticFunctions.ConsultTrackerFolder + "\\" + StaticFunctions.PAMessageFile;

                    File.WriteAllText(messageFile, txtMsgshort.Text);

                    txtMessage.AppendText(StaticFunctions.UserMode.ToString() + ": ");
                    txtMessage.AppendText(txtMsgshort.Text + Environment.NewLine + Environment.NewLine);
                    txtMsgshort.Text = "";

                }
                catch (Exception ex)
                {
                    StaticFunctions.HandleException(ex);
                }
            }
        }

        private void txtMsgshort_TextChanged(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void TestSplashScreen_Layout(object sender, System.Windows.Forms.LayoutEventArgs e)
        {
            if (m_bLayoutCalled == false)
            {
                m_bLayoutCalled = true;
                m_dt = DateTime.Now;
                this.Activate();
                SplashScreen.CloseForm();
            }
        }

        private void button1_Click(object sender, EventArgs e)


        {
            //File.WriteAllText("C:/temp/text.txt", "HELLO WORLD");

            //StaticFunctions.DataInterface().AssignPatientFile(null,"C:/temp/text.txt", "ABC", "ABC", "test.txt", true);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }


}
