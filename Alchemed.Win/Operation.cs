using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alchemed.DataModel;

namespace ConsultWill
{
    public class Operation
    {
        Patient Patient { get; set; }
        Person Surgeon { get; set; }
        Person Assistant { get; set; }
        Person Anaesthetist { get; set; }

        string OperationType { get; set; }
        DateTime Date { get; set; }

        string Hospital { get; set; }
        string Position { get; set; }

        string Side { get; set; }
        string Technique { get; set; }
        string Findings { get; set; }
        string WoundClosure { get; set; }
        string PostOp { get; set; }
    }

}
