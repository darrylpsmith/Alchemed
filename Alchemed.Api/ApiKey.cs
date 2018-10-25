using System;
using System.Collections.Generic;
using System.Text;
using RipaD.Core;

namespace Sam.DataModel
{
    public class ApiKey
    {
        [PrimaryKey]
        public string Id { get; set; }
        [UniqueKey]
        public string ApiKeyValue { get; set; }

        [UniqueKey]
        public string TenantCode { get; set; }

    }
}
