using System;
using System.Collections.Generic;
using System.Text;
using RipaD.Core;

namespace Alchemed.DataModel
{
    public class BillingScedule
    {
        [PrimaryKey]
        public string Id { get; set; }

        public string PatientId { get; set; }
        public string ProcedureCodeId { get; set; }
        public string OperationId { get; set; }

        public DateTime Date { get; set; }
        public bool Billed { get; set; }

    }
}
