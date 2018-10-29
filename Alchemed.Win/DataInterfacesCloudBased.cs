using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Alchemed.DataModel;
using RipaD.Client.JsonAccess;
using Newtonsoft.Json;
using System.Drawing;

namespace ConsultWill
{
    class DataInterfacesCloudBased : IDataInterfaces
    {
        public void AddPatient(Patient newPatient)
        {
            Patient entity = newPatient;
            FabricJsonAccess jsonAccess = new FabricJsonAccess(StaticFunctions.CloudStorageUrl, "");
            Alchemed.DataModel.Patient entityCreated = (Patient)AsyncHelpers.RunSync<Patient>(() => jsonAccess.CreateEntity<Patient>(entity));
            //jsonAccess.CreateEntity<Alchemed.DataModel.Patient>(entity);

            string entityJson = JsonConvert.SerializeObject(entityCreated, Formatting.Indented);

        }

        public void AddToTodaysConsults(Consult consult)
        {
            FabricJsonAccess jsonAccess = new FabricJsonAccess(StaticFunctions.CloudStorageUrl, "");
            Consult entityCreated = (Consult)AsyncHelpers.RunSync<Consult>(() => jsonAccess.CreateEntity<Consult>(consult));
            //jsonAccess.CreateEntity<Alchemed.DataModel.Patient>(entity);

            string entityJson = JsonConvert.SerializeObject(entityCreated, Formatting.Indented);
        }

        public Patient GetPatientById(string Id)
        {
            Patient entity = new Patient() { Id = Id }; // { FirstName = newPatient.FirstName, LastName = newPatient.Surname, PatientNo = newPatient.PatientNumber };
            FabricJsonAccess jsonAccess = new FabricJsonAccess(StaticFunctions.CloudStorageUrl, "");
            Patient entityCreated = (Patient)AsyncHelpers.RunSync<Patient>(() => jsonAccess.GetEntityById<Patient>(entity));
            return entityCreated;
        }

        public IEnumerable<MedicalArtifact> GetPatientMedicalArtifacts(Patient patient, string relativeFolder)
        {

            MedicalArtifact entity = new MedicalArtifact(); // { FirstName = newPatient.FirstName, LastName = newPatient.Surname, PatientNo = newPatient.PatientNumber };
            entity.TypeId = relativeFolder;
            entity.PatientId = patient.Id;
            FabricJsonAccess jsonAccess = new FabricJsonAccess(StaticFunctions.CloudStorageUrl, "");
            object entityCreated = (object)AsyncHelpers.RunSync<object>(() => jsonAccess.GetEntities<object>(entity, new List<string> { "TypeId", "PatientId"} ));
            if (entityCreated != null)
            {
                var artifacts = JsonConvert.DeserializeObject<IEnumerable<MedicalArtifact>>(entityCreated.ToString());
                return artifacts;
            }
            else
            {
                return null;
            }

        }
        public Image GetPatientMedicalArtifactThumbnailImage(Patient patient, string folder, MedicalArtifact Artifact)
        {
            MedicalArtifactThumbNail thumb = this.GetPatientMedicalArtifactThumbnail(Artifact.Id);

            string radFolder = StaticFunctions.GetSelectedPatientDocumentFolder(patient.GetPatientString(), folder, true);
            //System.Diagnostics.Process.Start(radFolder + "/" + file);

            FabricJsonAccess jsonAccess = new FabricJsonAccess(StaticFunctions.CloudStorageUrl, "");
            byte[] fresult = (byte[])AsyncHelpers.RunSync<byte[]>(() => jsonAccess.DownloadFileAsync(radFolder, thumb.Name));


            return byteArrayToImage(fresult);

            //string radLocalFolder = StaticFunctions.GetSelectedPatientDocumentFolder(patient.GetPatientString(), folder, false);

            //if (Directory.Exists(radLocalFolder) == false)
            //{
            //    Directory.CreateDirectory(radLocalFolder);
            //}

            //string localFile = radLocalFolder + "/" + thumb.Name;
            //File.WriteAllBytes(localFile, fresult);

            //System.Diagnostics.Process.Start(localFile);



        }

        private Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
        
        public MedicalArtifactThumbNail GetPatientMedicalArtifactThumbnail(string ArtifactId)
        {
            MedicalArtifactThumbNail entity = new MedicalArtifactThumbNail(); // { FirstName = newPatient.FirstName, LastName = newPatient.Surname, PatientNo = newPatient.PatientNumber };
            entity.ArtifactId = ArtifactId;
            FabricJsonAccess jsonAccess = new FabricJsonAccess(StaticFunctions.CloudStorageUrl, "");
            MedicalArtifactThumbNail entityCreated = (MedicalArtifactThumbNail)AsyncHelpers.RunSync<MedicalArtifactThumbNail>(() => jsonAccess.GetEntity<MedicalArtifactThumbNail>(entity, new List<string> { "ArtifactId" }));

            return entityCreated;

        }
        //public Patient GetPatientFromConsult(Consult consult)
        //{
        //    Patient entity = new Patient(); // { FirstName = newPatient.FirstName, LastName = newPatient.Surname, PatientNo = newPatient.PatientNumber };
        //    entity.Id = consult.PatientId;

        //    FabricJsonAccess jsonAccess = new FabricJsonAccess(StaticFunctions.CloudStorageUrl, "");
        //    object entityCreated = (object)AsyncHelpers.RunSync<object>(() => jsonAccess.GetEntity<object>(entity, new List<string> { "Id" }));
        //    if (entityCreated != null)
        //    {
        //        var patient = JsonConvert.DeserializeObject<Patient>(entityCreated.ToString());

        //        if (patient != null)
        //        {
        //            Patient found = patient;
        //            return patient;
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //    else
        //    {
        //        throw new Exception("Missing Patient");
        //    }


        //}

        public List<Patient> GetPatients(string wildCard)
        {
            Patient entity = new Patient(); // { FirstName = newPatient.FirstName, LastName = newPatient.Surname, PatientNo = newPatient.PatientNumber };

            FabricJsonAccess jsonAccess = new FabricJsonAccess(StaticFunctions.CloudStorageUrl, "");
            object entityCreated = (object)AsyncHelpers.RunSync<object>(() => jsonAccess.GetEntities<object>(entity, null));
            var patients =  JsonConvert.DeserializeObject<IEnumerable<Patient>>(entityCreated.ToString());

            List<Patient> foundPatients = new List<Patient>();

            foreach (var pt in patients)
            {
                if (wildCard == "")
                {
                    foundPatients.Add(new Patient(pt.FirstName, pt.LastName, pt.PatientNo) { Id = pt.Id});
                }
                else if (pt.LastName.ToUpper().StartsWith(wildCard.ToUpper()))
                {
                    foundPatients.Add(new Patient(pt.FirstName, pt.LastName, pt.PatientNo) { Id = pt.Id});
                }
            }

            return foundPatients;

            //jsonAccess.CreateEntity<Alchemed.DataModel.Patient>(entity);

            string entityJson = JsonConvert.SerializeObject(entityCreated, Formatting.Indented);


            return new List<Patient>();

        }

        public List<Consult> GetTodaysConsults()
        {


            Consult entity = new Consult(); // { FirstName = newPatient.FirstName, LastName = newPatient.Surname, PatientNo = newPatient.PatientNumber };

            FabricJsonAccess jsonAccess = new FabricJsonAccess(StaticFunctions.CloudStorageUrl, "");
            object entityCreated = (object)AsyncHelpers.RunSync<object>(() => jsonAccess.GetEntities<object>(entity, null));
            var consults = JsonConvert.DeserializeObject<IEnumerable<Consult>>(entityCreated.ToString());

            return consults.ToList<Consult>();

            //List<Patient> foundConsults = new List<Patient>();

            //foreach (var con in consults)
            //{
            //    if(con.Date.Date == DateTime.UtcNow.Date)
            //    {
            //        foundConsults.Add(new Patient(con.PatientId , pt.LastName, pt.PatientNo));
            //    }
                    
            //}

            //return foundConsults;
            //return new List<Patient>();

        }

        public List<Patient> GetTodaysOperations(string wildCard)
        {
            throw new NotImplementedException();
        }

        public bool PatientExists(Patient patient)
        {


            FabricJsonAccess jsonAccess = new FabricJsonAccess(StaticFunctions.CloudStorageUrl, "");
            object fetchedEntity = (object)AsyncHelpers.RunSync<object>(() => jsonAccess.GetEntity<object>(patient, new List<string> { "FirstName", "LastName", "PatientNo" }));
            if (fetchedEntity != null)
            {
                var patients = JsonConvert.DeserializeObject<Patient>(fetchedEntity.ToString());
                return patients != null;
            }
            else
            {
                return false;
            }

        }

        public void AssignPatientFile(MedicalArtifact artifact, string selectedFile, string targetFolder, string relativeFolder, string fileName, bool RemoveSourceFilesWhenAssigningToFolder)
        {

            System.IO.Stream st = File.OpenRead(selectedFile);
            FabricJsonAccess jsonAccess = new FabricJsonAccess(StaticFunctions.CloudStorageUrl, "");
            bool fresult= (bool)AsyncHelpers.RunSync<bool>(() => jsonAccess.UploadFileAsync(st, fileName, relativeFolder));
            //File.Copy(selectedFile, targetFolder + fileName);


            MedicalArtifact entity = artifact;
            MedicalArtifact entityCreated = (MedicalArtifact)AsyncHelpers.RunSync<MedicalArtifact>(() => jsonAccess.CreateEntity<MedicalArtifact>(entity));
            //jsonAccess.CreateEntity<Alchemed.DataModel.Patient>(entity);

            MedicalArtifactThumbNail thumb = new MedicalArtifactThumbNail();
            thumb.Id = Guid.NewGuid().ToString();
            thumb.ArtifactId = entityCreated.Id;
            thumb.Name = "_thumb_" + thumb.Id + ".bmp"; ;

            ThumbNailer tn = new ThumbNailer();
            string thumbFile = tn.CreateAndSaveThumbNailstring(selectedFile, thumb.Name);
            if (thumbFile != null)
            {
                System.IO.Stream stThumb = File.OpenRead(thumbFile);
                fresult = (bool)AsyncHelpers.RunSync<bool>(() => jsonAccess.UploadFileAsync(stThumb, thumb.Name, relativeFolder));
                MedicalArtifactThumbNail entityCreatedThumb = (MedicalArtifactThumbNail)AsyncHelpers.RunSync<MedicalArtifactThumbNail>(() => jsonAccess.CreateEntity<MedicalArtifactThumbNail>(thumb));
                File.Delete(thumbFile);
            }

            if (RemoveSourceFilesWhenAssigningToFolder)
                File.Delete(selectedFile);

        }

        public void LaunchPatientFile(Patient patient, string folder, string file)
        {
            string radFolder = StaticFunctions.GetSelectedPatientDocumentFolder(patient.GetPatientString(), folder, true);
            //System.Diagnostics.Process.Start(radFolder + "/" + file);

            
            FabricJsonAccess jsonAccess = new FabricJsonAccess(StaticFunctions.CloudStorageUrl, "");
            byte[] fresult = (byte[])AsyncHelpers.RunSync<byte[]>(() => jsonAccess.DownloadFileAsync(radFolder, file));

            string radLocalFolder = StaticFunctions.GetSelectedPatientDocumentFolder(patient.GetPatientString(), folder, false);

            if (Directory.Exists(radLocalFolder) == false)
            {
                Directory.CreateDirectory(radLocalFolder);
            }

            string localFile = radLocalFolder + "/" + file;
            File.WriteAllBytes(localFile, fresult);

            System.Diagnostics.Process.Start(localFile);

            //File.WriteAllBytes("Foo.txt", arrBytes);

            //System.IO.Stream st = File.OpenRead(selectedFile);

            //File.Copy(selectedFile, targetFolder + fileName);
        }
    }
}
