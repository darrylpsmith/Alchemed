using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Alchemed.DataModel;
using Newtonsoft.Json;

namespace ConsultWill
{
    class PautientFolderLookup
    {
        public string PatientId { get; set; }
        public string FolderPath { get; set; }
    }




    class DataInterfacesFileBased : IDataInterfaces
    {



        public bool PatientExists(Patient patient)
        {
            string folderName = StaticFunctions.GetSelectedPatientFolder(patient.GetPatientString());
            if (Directory.Exists(folderName) == false)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public void AddPatient(Patient newPatient)
        {
            
            string folderName = StaticFunctions.GetSelectedPatientFolder(newPatient.GetPatientString());
            folderName = folderName.ToUpper();
            if (Directory.Exists(folderName) == false)
            {
                Directory.CreateDirectory(folderName);
            }

            AddPatientToFolderLookupFile(newPatient);
        }


        public List<string> GetPatientFiles(string Folder)
        {
            throw new NotImplementedException();
        }

        public List<Patient> GetPatients(string wildCard)
        {
            string[] dirs;
            string subFolder = StaticFunctions.PatientsRootFolder + @"\" + wildCard.Substring(0, 1);
            string search = wildCard + "*";

            if (Directory.Exists(subFolder))
            {
                dirs = Directory.GetDirectories(subFolder, search);
                List<Patient> patients = new List<Patient>();
                foreach (var dir in dirs)
                {
                    string lastFolderName = Path.GetFileName(dir);
                    var patient = new Patient(lastFolderName);
                    patient.Id = GetOrGeneratePatientId(dir);
                    patients.Add(patient);
                }
                return patients;
            }
            else
            {
                return null;
            }

        }

        private string GetOrGeneratePatientId(string PatientFolder)
        {
            string patientIdFile = StaticFunctions.PatientJsonFileName(PatientFolder);
            if (File.Exists(patientIdFile))
            {
                var json = File.ReadAllText(patientIdFile);
                Patient patient = JsonConvert.DeserializeObject<Patient>(json);
                return patient.Id;
            }
            else
            {
                string lastFolderName = Path.GetFileName(PatientFolder);
                var patient = new Patient(lastFolderName);
                patient.Id = Guid.NewGuid().ToString();
                string json = JsonConvert.SerializeObject(patient);
                File.WriteAllText (patientIdFile, json);
                return patient.Id;
            }



        }

        private void AddPatientToFolderLookupFile(Patient patient)
        {
            string patientLookupFile = StaticFunctions.GetPatientLookupFilePath;
            List<PautientFolderLookup> patients = null;
            if (File.Exists(patientLookupFile))
            {
                string json = File.ReadAllText(patientLookupFile);
                patients = JsonConvert.DeserializeObject<List<PautientFolderLookup>>(json);
                var found = patients.Where(w => w.PatientId == patient.Id).Select(x => x);
                if (found.Count() >= 0)
                {
                }
                else
                {
                    patients.Add(new PautientFolderLookup { PatientId = patient.Id, FolderPath = patient.GetPatientString() });
                    string jsonSave = JsonConvert.SerializeObject(patients);
                    File.WriteAllText(patientLookupFile, jsonSave);
                }
            }
            else
            {
                patients = new List<PautientFolderLookup>();
                patients.Add(new PautientFolderLookup { PatientId = patient.Id, FolderPath = patient.GetPatientString() });
                string jsonSave = JsonConvert.SerializeObject(patients);
                File.WriteAllText(patientLookupFile, jsonSave);
            }
        }




        public List<Consult> GetTodaysConsults()
        {
            List<Consult> todaysConsults = new List<Consult>();

            string[] tdPats;
            if (Directory.Exists(StaticFunctions.ConsultTrackerFolder))
            {
                if (File.Exists(StaticFunctions.ConsultTrackerFolder + "\\" + StaticFunctions.ConsultTrackerTodaysFile))
                {
                    string todaysPatients = File.ReadAllText(StaticFunctions.ConsultTrackerFolder + "\\" + StaticFunctions.ConsultTrackerTodaysFile);
                    tdPats = todaysPatients.Split('|');

                    foreach(var pat in tdPats)
                    {
                        if (pat.Trim().Length > 0)
                        {
                            var consult = JsonConvert.DeserializeObject<Consult>(pat);
                            todaysConsults.Add(consult);
                        }
                        
                    }

                    return todaysConsults; // tdPats.Take(tdPats.Count() - 1).ToArray<string>();

                }
                else
                {
                    return todaysConsults;
                }
            }
            else
            {
                return todaysConsults;
            }
            
        }

        public List<Patient> GetTodaysOperations(string wildCard)
        {
            throw new NotImplementedException();
        }


        public void AddToTodaysConsults(Consult consult)
        {
            if (!Directory.Exists(StaticFunctions.ConsultTrackerFolder))
            {
                Directory.CreateDirectory(StaticFunctions.ConsultTrackerFolder);
            }

            File.AppendAllText(StaticFunctions.ConsultTrackerFolder + "\\" + StaticFunctions.ConsultTrackerTodaysFile, JsonConvert.SerializeObject(consult));
            File.AppendAllText(StaticFunctions.ConsultTrackerFolder + "\\" + StaticFunctions.ConsultTrackerTodaysFile, @"|");
            
            if (GetPatientById(consult.PatientId) == null)
            {
                AddPatientToFolderLookupFile(new Patient(consult.Description) { Id = consult.PatientId });
            }

        }

        //public Patient GetPatientFromConsult(Consult consult)
        //{
        //    string patientString = consult.PatientId;
        //    Patient x = new Patient(patientString);
        //    return x;
        //}

        public Patient GetPatientById(string Id)
        {
            string patientLookupFile = StaticFunctions.GetPatientLookupFilePath;
            List<PautientFolderLookup> patients = null;
            if (File.Exists(patientLookupFile))
            {
                string json = File.ReadAllText(patientLookupFile);
                patients = JsonConvert.DeserializeObject<List<PautientFolderLookup>>(json);
                var found = patients.Where(w => w.PatientId == Id).Select(x => x);
                if (found.Count() >=0)
                {
                    var pat = found.First();
                    Patient ret = new Patient(pat.FolderPath);
                    string idFile = StaticFunctions.PatientsRootFolder + @"\" + ret.LastName.Substring(0, 1) + "/" + pat.FolderPath;
                    ret.Id = GetOrGeneratePatientId(idFile);
                    return ret;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }

        }
    }
}
