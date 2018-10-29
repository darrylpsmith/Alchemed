using System;
using System.Collections.Generic;
using System.Text;

using RipaD.Core;
using System.Drawing;
namespace Alchemed.DataModel
{
    public class MedicalArtifact
    {
        [PrimaryKey]
        public string Id { get; set; }

        public string Name { get; set; }

        public string PatientId { get; set; }
        
        public string TypeId { get; set; }

        public DateTime Date { get; set; }

        public string BlobId { get; set; }
        public string OriginalFullFilePath { get; set; }
        
    }
}
