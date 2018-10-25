using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alchemed.DataModel;
namespace ConsultWill
{
    public interface IDataInterfaces
    {

        List<Patient> GetPatients(string wildCard);

        void AddPatient(Patient newPatient);

        bool PatientExists(Patient patient);

        List<Consult> GetTodaysConsults();

        List<Patient> GetTodaysOperations(string wildCard);

        List<string> GetPatientFiles(string Folder);

        void AddToTodaysConsults(Consult consult);

        //Patient GetPatientFromConsult(Consult consult);

        Patient GetPatientById(string Id);

    }
}
