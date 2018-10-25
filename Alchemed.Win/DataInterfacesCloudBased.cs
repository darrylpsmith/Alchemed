using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Alchemed.DataModel;
using RipaD.Client.JsonAccess;
using Newtonsoft.Json;

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

        public List<string> GetPatientFiles(string Folder)
        {
            throw new NotImplementedException();
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
            object entityCreated = (object)AsyncHelpers.RunSync<object>(() => jsonAccess.GetEntity<object>(entity, null));
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
            object entityCreated = (object)AsyncHelpers.RunSync<object>(() => jsonAccess.GetEntity<object>(entity, null));
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

            //System.Windows.Forms.MessageBox.Show("Test connectivity");

            Patient entity = patient;
            FabricJsonAccess jsonAccess = new FabricJsonAccess(StaticFunctions.CloudStorageUrl, "");
            Patient fetchedEntity = (Patient)AsyncHelpers.RunSync<Patient>(() => jsonAccess.GetEntity<Patient>(entity, new List<string> { "FirstName", "LastName", "PatientNo" }));
            //jsonAccess.CreateEntity<Alchemed.DataModel.Patient>(entity);
            if (fetchedEntity == null)
            {
                return false;
            }
            else
            {
                return true;
            }
           // string entityJson = JsonConvert.SerializeObject(entityCreated, Formatting.Indented);

        }
    }
}
