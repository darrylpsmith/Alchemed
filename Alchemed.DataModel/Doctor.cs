using System;
using System.Collections.Generic;
using System.Text;
using RipaD.Core;

namespace Alchemed.DataModel
{
    public class Doctor
    {
        [PrimaryKey]
        public string Id { get; set; }
        [UniqueKey]
        public string PracticeNo { get; set; }
        [UniqueKey]
        public string LastName { get; set; }
        [UniqueKey]
        public string FirstName { get; set; }
        public string Email { get; set; }
    }
}
