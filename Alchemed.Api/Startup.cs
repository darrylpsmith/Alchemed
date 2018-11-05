using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Alchemint.Core;
using RipaD.Core.ApiFramework;
using RipaD.Core.BusinessObjects;
using RipaD.Core.Data;
using RipaD.Core.ApiFramework.Interfaces;
using Swashbuckle.AspNetCore;
using Swashbuckle.AspNetCore.Swagger;


// For now am just including Sam.DataModel as need the ApiKey class which for now is in that DLL but will
// be moved into the cored code and then this can be removed
using Alchemed.DataModel;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Alchemed.Api
{
    public class Startup
    {

        ILogger Logger { get; } =
            StaticFunctions.ApplicationLogging.CreateLogger<Startup>();

        IHostingEnvironment _currentEnvironment = null;
        public IConfiguration _configuration { get; }

        public Startup(IConfiguration configuration, IHostingEnvironment currentEnvironment)
        {
            _configuration = configuration;
            _currentEnvironment = currentEnvironment;


        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //if (string.IsNullOrEmpty(context.HttpContext.Request.Headers["ApiKey"]) == false)
            //{
            //    _apiKey = context.HttpContext.Request.Headers["ApiKey"];
            //}

            ServiceConfig sc = new ServiceConfig();
            sc.AddServicesToContainer(services, _configuration, _currentEnvironment, Logger, "Sam Api", "version 1.0");
            services.AddSingleton<IApiAuthenticationService>(new ApiAuthenticationService());


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            ServiceConfig sc = new ServiceConfig();
            sc.ConfigureHttpRequestPipeline(app, env);
        }

    }
}
