//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using Alchemed.DataModel;
//using Newtonsoft.Json;
//using RipaD.Client.JsonAccess;
//using Alchemed.DataModel;

//namespace ConsultWill
//{
//    public class Patient 
//    {

//        private string _patientString = "";

//        public string PatientNumber { get; set; }

//        public string Surname { get; set; }
//        public string FirstName { get; set; }

//        public string GetPatientString()
//        {
//            return _patientString;
//        }
//        public Patient(string patientString)
//        {
//            _patientString = patientString;
//            PatientNumber = patientString.Substring(patientString.LastIndexOf(' '));
//            Surname = patientString.Substring(0, patientString.IndexOf(','));
//            FirstName = patientString.Substring(patientString.IndexOf(',') + 1);
//            FirstName = FirstName.Substring(0, FirstName.LastIndexOf(' ')).Trim();
//        }

//        public Patient(string firstName, string lastName, string patientNumber)
//        {
//            _patientString = "";
//            PatientNumber = patientNumber;
//            Surname = lastName;
//            FirstName = firstName;
//            _patientString = Surname + ", " + FirstName + " " + PatientNumber;

//        }


//        public bool PatientExists ()
//        {
//            return StaticFunctions.DataInterface().PatientExists(this);
//        }
//        public void Store ()
//        {

//            StaticFunctions.DataInterface().AddPatient(this);

//            //if (StaticFunctions.UseCloadStorage)
//            //{
//            //    Patient entity = new Patient { FirstName = this.FirstName, LastName = Surname, PatientNo = PatientNumber };
//            //    FabricJsonAccess jsonAccess = new FabricJsonAccess(StaticFunctions.CloudStorageUrl, "");
//            //    Alchemed.DataModel.Patient entityCreated = (Patient)AsyncHelpers.RunSync<Patient>(() => jsonAccess.CreateEntity<Patient>(entity));
//            //    //jsonAccess.CreateEntity<Alchemed.DataModel.Patient>(entity);

//            //    string entityJson = JsonConvert.SerializeObject(entityCreated, Formatting.Indented);
//            //}
//            //else

//            //{

                
//            //}

//        }

//    }

//}
