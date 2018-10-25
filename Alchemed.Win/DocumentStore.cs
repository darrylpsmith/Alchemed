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

        }

        public Patient CurrentPerson
        {
            set
            {

                _currPerson = value;
                PopulatePatientAttachedFiles();
            }

            get
            {
                return _currPerson;
            }
        }

        private void DocumentStore_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string radFolder = StaticFunctions.GetSelectedPatientDocumentFolder(_currPerson.GetPatientString(), _docFolder.FolderName);
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Multiselect = true;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (!Directory.Exists(radFolder))
                        Directory.CreateDirectory(radFolder);

                    foreach (String selectedFile in openFileDialog1.FileNames)
                    {
                        string fileName = Path.GetFileName(selectedFile);

                        File.Copy(selectedFile, radFolder + fileName);

                        if (_docFolder.RemoveSourceFilesWhenAssigningToFolder)
                            File.Delete(selectedFile);
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
            string radFolder = StaticFunctions.GetSelectedPatientDocumentFolder(_currPerson.GetPatientString(), _docFolder.FolderName);
            if (Directory.Exists(radFolder))
            {
                DirectoryInfo DirInfo = new DirectoryInfo(radFolder);

                var filesInOrder = from f in DirInfo.EnumerateFiles()
                                   orderby f.CreationTime descending
                                   select f;

                foreach (var file in filesInOrder)
                {
                    string fileName = Path.GetFileName(file.FullName);
                    ListViewItem it = new ListViewItem(fileName);

                    var itm = lvwDocuments.Items.Add(it);

                    try
                    {
                        if (_largeImages)
                        {
                            imgThumbnails.Images.Add(file.FullName, GetThumbnail(file.FullName));
                            itm.ImageKey = file.FullName;
                        }
                    }
                    catch
                    { }


                }
            }
        }

        public bool ThumbnailCallback()
        {
            return true;
        }

        private Image GetThumbnail(string FileName)
        {

            Image.GetThumbnailImageAbort callback =
                new Image.GetThumbnailImageAbort(ThumbnailCallback);
            Image image = new Bitmap(FileName);
            Image pThumbnail = image.GetThumbnailImage(100, 100, callback, new
               IntPtr());

            return pThumbnail;


            //Image image = Image.FromFile(fileName);
            //Image thumb = image.GetThumbnailImage(120, 120, () => false, IntPtr.Zero);
            //thumb.Save(Path.ChangeExtension(fileName, "thumb"));

            //e.Graphics.DrawImage(
            //   pThumbnail,
            //   10,
            //   10,
            //   pThumbnail.Width,
            //   pThumbnail.Height);
        }


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
                        string radFolder = StaticFunctions.GetSelectedPatientDocumentFolder(_currPerson.GetPatientString(), _docFolder.FolderName);
                        string file = radFolder + lvwDocuments.SelectedItems[0].SubItems[0].Text;
                        System.Diagnostics.Process.Start(file);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
