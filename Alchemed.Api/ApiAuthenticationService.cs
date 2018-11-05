using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using RipaD.Core.ApiFramework.Interfaces;

namespace Alchemed.Api
{
    public class ApiAuthenticationService : IApiAuthenticationService
    {

        private const string _validTestApiKey = "*********************";
        public bool Authenticated(ActionExecutingContext context)
        {
            string apiKey = context.HttpContext.Request.Headers["ApiKey"];

            if (apiKey == null)
            {
                return false;
            }
            else
            {
                return (apiKey == _validTestApiKey);
            }

        }

        public string ApiKey
        {
            get { return _validTestApiKey; }
        }
            

    }
}
