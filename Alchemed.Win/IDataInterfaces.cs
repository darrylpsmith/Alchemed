using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alchemed.DataModel;
using System.IO;
using System.Drawing;

namespace ConsultWill
{
    public interface IDataInterfaces
    {

        List<Patient> GetPatients(string wildCard);

        void AddPatient(Patient newPatient);

        bool PatientExists(Patient patient);

        List<Consult> GetTodaysConsults();

        List<Patient> GetTodaysOperations(string wildCard);

        IEnumerable<MedicalArtifact> GetPatientMedicalArtifacts(Patient patient, string Folder);

        void AddToTodaysConsults(Consult consult);

        //Patient GetPatientFromConsult(Consult consult);

        Patient GetPatientById(string Id);

        void AssignPatientFile(MedicalArtifact artifact, string selectedFile, string targetFolder, string relativeFolder, string fileName, bool RemoveSourceFilesWhenAssigningToFolder);

        Image LaunchPatientFile(Patient patient, string folder, string file);

        MedicalArtifactThumbNail GetPatientMedicalArtifactThumbnail(string ArtifactId);

        Image GetPatientMedicalArtifactThumbnailImage(Patient patient, string folder, MedicalArtifact Artifact);

        string GetPatientCommentsForConsult(Consult consult);

        void AddClinicalNotes(Patient patient);

        List<ClinicalNotes> GetClinicalNotes(Patient patient);

        void StoreClinicalNote(ClinicalNotes note);

        void AddOperationNotes(Patient patient);

        void StoreOperationNotes(OperationDetails operation);
    }
}
