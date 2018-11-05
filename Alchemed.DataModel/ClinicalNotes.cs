using System;
using System.Collections.Generic;
using System.Text;
using RipaD.Core;

namespace Alchemed.DataModel
{
    public class ClinicalNotes
    {

        [PrimaryKey]
        public string Id { get; set; }


        public string PatientId { get; set; }

        public DateTime Date { get; set; }

        public string Content { get; set; }

        public string UnformattedContent { get; set; }
    }
}
