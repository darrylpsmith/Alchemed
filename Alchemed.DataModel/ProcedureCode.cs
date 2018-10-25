using System;
using System.Collections.Generic;
using System.Text;
using RipaD.Core;

namespace Alchemed.DataModel
{
    public class ProcedureCode
    {
        [PrimaryKey]
        public string Id { get; set; }
        [UniqueKey]
        public string Name{ get; set; }
    }
}
