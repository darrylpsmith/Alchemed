﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.16.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace test.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;

    public partial class PatientReferal
    {
        /// <summary>
        /// Initializes a new instance of the PatientReferal class.
        /// </summary>
        public PatientReferal() { }

        /// <summary>
        /// Initializes a new instance of the PatientReferal class.
        /// </summary>
        public PatientReferal(string id = default(string), string patientId = default(string), string doctorId = default(string), DateTime? date = default(DateTime?))
        {
            Id = id;
            PatientId = patientId;
            DoctorId = doctorId;
            Date = date;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Id")]
        public string Id { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "PatientId")]
        public string PatientId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "DoctorId")]
        public string DoctorId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Date")]
        public DateTime? Date { get; set; }

    }
}
