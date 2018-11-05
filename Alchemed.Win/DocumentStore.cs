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
    public partial class DocumentStore : UserControl
    {

        public delegate void SelectedImageChanged(Image image);
        public event SelectedImageChanged selectedImageChanged;


        DocumentAssignmentFolder _docFolder = null;
        private Patient _currPerson = null;
        private bool _largeImages = false;
        public DocumentStore(DocumentAssignmentFolder DocFolder, int Left, int Top, bool LargeImages)
        {
            InitializeComponent();

            _docFolder = DocFolder;
            this.Left = Left;
            this.Top = Top;

            this.lblDescription.Text = DocFolder.DisplayName;
            _docFolder.UseLargeImages = LargeImages;
            _largeImages = LargeImages;
            this.Enabled = false;
        }

        public Patient CurrentPerson
        {
            set
            {

                _currPerson = value;
                PopulatePatientAttachedFiles();

                if (_currPerson == null)
                {
                    this.Enabled = false;
                }
                else
                {
                    this.Enabled = true;
                }



            }

            get
            {
                return _currPerson;
            }
        }



        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {

                string documentFolder = StaticFunctions.GetSelectedPatientDocumentFolder(_currPerson.GetPatientString(), _docFolder.FolderName, false);
                string relativeFolder = StaticFunctions.GetSelectedPatientDocumentFolder(_currPerson.GetPatientString(), _docFolder.FolderName, true);

                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Multiselect = true;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (!Directory.Exists(documentFolder))
                        Directory.CreateDirectory(documentFolder);

                    foreach (String selectedFile in openFileDialog1.FileNames)
                    {
                        string fileName = Path.GetFileName(selectedFile);

                        MedicalArtifact md = new MedicalArtifact { Id = Guid.NewGuid().ToString(), BlobId = Guid.NewGuid().ToString(), Date = DateTime.UtcNow, Name = fileName, TypeId = _docFolder.FolderName, PatientId = _currPerson.Id };

                        StaticFunctions.DataInterface().AssignPatientFile(md, selectedFile, documentFolder, relativeFolder, fileName, _docFolder.RemoveSourceFilesWhenAssigningToFolder);



                        //File.Copy(selectedFile, documentFolder + fileName);

                        //if (_docFolder.RemoveSourceFilesWhenAssigningToFolder)
                        //    File.Delete(selectedFile);
                    }


                    PopulatePatientAttachedFiles();
                }
            }
            catch (Exception ex)
            {
                StaticFunctions.HandleException(ex);
            }
        }




        public void PopulatePatientAttachedFiles()
        {
            if (_largeImages)
            {
                imgThumbnails.ImageSize = new Size(100, 100);
                lvwDocuments.LargeImageList = imgThumbnails;
                lvwDocuments.View = View.LargeIcon;
            }
            else
            {
                lvwDocuments.View = View.Details;
            }

            lvwDocuments.Items.Clear();

            var medicalArtifacts = StaticFunctions.DataInterface().GetPatientMedicalArtifacts(_currPerson, _docFolder.FolderName);
            
            if (medicalArtifacts != null)
            {
                foreach (var artifact in medicalArtifacts)
                {
                    string fileName = Path.GetFileName(artifact.Name);
                    ListViewItem it = new ListViewItem(fileName);
                    it.Tag = artifact;
                    var itm = lvwDocuments.Items.Add(it);

                    Image thumb = null;
                    try
                    {
                        thumb = StaticFunctions.DataInterface().GetPatientMedicalArtifactThumbnailImage(_currPerson, _docFolder.FolderName, artifact);
                    }
                    catch (Exception)
                    {
                    }
                    

                    try
                    {
                        if (_largeImages)
                        {

                            //imgThumbnails.Images.Add(file.Name, tn.GetThumbnail(file.OriginalFullFilePath));
                            if (thumb != null)
                            {
                                imgThumbnails.Images.Add(artifact.Id, thumb);
                                itm.ImageKey = artifact.Id; // file.Name;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        if (artifact.Name.ToUpper().EndsWith(".PNG"))
                        {
                            ex = ex;
                        }
                            

                    }
                }
            }
        }


        //public Image GetThumbnail(string FileName)
        //{

        //    Image.GetThumbnailImageAbort callback =
        //        new Image.GetThumbnailImageAbort(ThumbnailCallback);
        //    Image image = new Bitmap(FileName);
        //    Image pThumbnail = image.GetThumbnailImage(100, 100, callback, new
        //       IntPtr());

        //    return pThumbnail;


        //    //Image image = Image.FromFile(fileName);
        //    //Image thumb = image.GetThumbnailImage(120, 120, () => false, IntPtr.Zero);
        //    //thumb.Save(Path.ChangeExtension(fileName, "thumb"));

        //    //e.Graphics.DrawImage(
        //    //   pThumbnail,
        //    //   10,
        //    //   10,
        //    //   pThumbnail.Width,
        //    //   pThumbnail.Height);
        //}


        //public bool ThumbnailCallback()
        //{
        //    return true;
        //}
        private void lstDocuments_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lvwDocuments_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lvwDocuments_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (lvwDocuments.SelectedItems.Count > 0)
                {
                    if (lvwDocuments.SelectedItems[0].SubItems[0].Text.Length != 0)
                    {
                        MedicalArtifact file = (MedicalArtifact) lvwDocuments.SelectedItems[0].Tag;
                        Image img = StaticFunctions.DataInterface().LaunchPatientFile(_currPerson, file.TypeId, file.Name);


                        if (img != null)
                        {
                            selectedImageChanged(img);
                        }

                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void DocumentStore_Load(object sender, EventArgs e)
        {

        }
    }
}
