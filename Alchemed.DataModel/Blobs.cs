using System;
using System.Collections.Generic;
using System.Text;
using RipaD.Core;

namespace Alchemed.DataModel
{
    public class Blobs
    {
        [PrimaryKey]
        public string Id { get; set; }
        
        public string Name { get; set; }
        
        public string Type { get; set; }
    }
}
