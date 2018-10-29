using System;
using System.Collections.Generic;
using System.Text;

using RipaD.Core;

namespace Alchemed.DataModel
{
    public class Patient
    {
        [PrimaryKey]
        public string Id { get; set; }

        [UniqueKey]
        public string PatientNo { get; set; }
        [UniqueKey]
        public string LastName { get; set; }
        [UniqueKey]
        public string FirstName { get; set; }

        public string GetPatientString()
        {
            return LastName + ", " + FirstName + " " + PatientNo; 
        }

        public Patient()
        {

        }

        public Patient(string patientString)
        {
            PatientNo = patientString.Substring(patientString.LastIndexOf(' ')).Trim();
            LastName = patientString.Substring(0, patientString.IndexOf(','));
            FirstName = patientString.Substring(patientString.IndexOf(',') + 1);
            FirstName = FirstName.Substring(0, FirstName.LastIndexOf(' ')).Trim();
        }

        public Patient(string firstName, string lastName, string patientNumber)
        {
            PatientNo = patientNumber;
            LastName = lastName;
            FirstName = firstName;
        }



    }
}
