using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alchemint.Core;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;

namespace Alchemed.Api
{
    internal static class StaticFunctions
    {

        //TODO: DS - Speak to KN about application logging strategy to use

        public static class ApplicationLogging
        {
            private static LoggerFactory _logFact = new LoggerFactory();

            public static ILoggerFactory LoggerFactory
            {
                get
                {
                    _logFact.AddConsole();
                    //_logFact.AddDebug();
                    return _logFact;
                }

            }
            public static ILogger CreateLogger<T>() =>
              LoggerFactory.CreateLogger<T>();
        }

    }
}
