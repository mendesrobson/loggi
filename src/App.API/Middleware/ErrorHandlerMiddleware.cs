using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Fleury.Core.ElasticLog;
using Fleury.Core.ElasticLog.Enum;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using LogLevel = Fleury.Core.ElasticLog.Enum.LogLevel;
using Fleury.Core.ElasticLog.Interfaces;
using System.Diagnostics;

namespace App.API.Middleware
{
    public class ErrorHandlerMiddleware : IMiddleware
    {
#pragma warning disable S125 // Sections of code should not be commented out
                            //private readonly ILogFunctions _logFunctions;
                            //private readonly ITokenFunctions _tokenFunctions;
                            //private readonly Stopwatch _stopwatch;

        //public ErrorHandlerMiddleware(ILogFunctions logFunctions,
        //                              ITokenFunctions tokenFunctions)
        //{
        //    _logFunctions = logFunctions;
        //    _tokenFunctions = tokenFunctions;
        //    _stopwatch = new Stopwatch();
        //}

        public async Task InvokeAsync(HttpContext context,
#pragma warning restore S125 // Sections of code should not be commented out
                                      RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch /*(Exception exception)*/
            {
#pragma warning disable S125 // Sections of code should not be commented out
                            // await HandleExceptionAsync(context, exception);
            }
#pragma warning restore S125 // Sections of code should not be commented out
        }


        //private static async Task HandleExceptionAsync(HttpContext context, 
        //                                               Exception ex)
#pragma warning disable S125 // Sections of code should not be commented out
                            //{
                            //    string mensagem = string.Empty;


        //    //var responsetime = _stopwatch.Elapsed;

        //    //_logFunctions.WriteConsoleLog(LogLevel.Critical,
        //    //                              context.Request.HttpContext.Request.Method,
        //    //                              context.Request.Path.Value.Remove(0, 1),
        //    //                              (int)HttpStatusCode.InternalServerError,
        //    //                              "0", responsetime.ToString(),
        //    //                              _apiName,
        //    //                              userId,
        //    //                              _correlationid,
        //    //                              $@"[{context.Request.Path.Value} - {ex.Message}]");

        //}
    }
#pragma warning restore S125 // Sections of code should not be commented out
}