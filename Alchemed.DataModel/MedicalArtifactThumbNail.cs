using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using RipaD.Core;

namespace Alchemed.DataModel
{

    public class MedicalArtifactThumbNail
    {
        [PrimaryKey]
        public string Id { get; set; }

        public string Name { get; set; }

        public string ArtifactId { get; set; }

    }
}
