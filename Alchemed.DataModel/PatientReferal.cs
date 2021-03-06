﻿using System;
using System.Collections.Generic;
using System.Text;

using RipaD.Core;

namespace Alchemed.DataModel
{
    public class PatientReferal
    {
        [PrimaryKey]
        public string Id { get; set; }

        [UniqueKey]
        public string PatientId { get; set; }
        [UniqueKey]
        public string DoctorId { get; set; }

        [UniqueKey]
        public DateTime Date { get; set; }
    }
}
