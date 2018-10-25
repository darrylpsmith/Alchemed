using System;
using RipaD.Core;

namespace Alchemed.DataModel
{

    public class OperationDetails
    {

        [PrimaryKey]
        public string Id { get; set; }
        public string PatientId { get; set; }
        public DateTime Date { get; set; }
        public string SurgeonId { get; set; }

        public string Assistant { get; set; }

        public string Anaesthetist { get; set; }
        public string OperationTypeId { get; set; }
        public string OperationName { get; set; }

        public string Position { get; set; }

        public string Side { get; set; }

        public string Technique { get; set; }

        public string Findings { get; set; }

        public string WoundClosure { get; set; }
        public string PostOp { get; set; }
    }
}
