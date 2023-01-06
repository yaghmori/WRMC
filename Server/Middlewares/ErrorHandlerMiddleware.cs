using Azure;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using WRMC.Core.Shared.ResultWrapper;
using WRMC.Server.Extensions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WRMC.Server.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                var responseModel = await Result<string>.FailAsync(error.GetMessages().ToList());

                switch (error)
                {

                    case KeyNotFoundException e:
                        // not found error
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    default:
                        // unhandled error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                var result = JsonConvert.SerializeObject(responseModel);
                await response.WriteAsync(result);
            }
            //finally
            //{
            //    //if (context.Response?.StatusCode == 400)
            //    //{
            //    //    //var response = context.Response;
            //    //    //response.ContentType = "application/json";
            //    //    //var responseModel = await Result<string>.FailAsync(context.Response.Body);
            //    //    //context.Request.Body.Position = 0;
            //    //}
            //}

        }
    }

}
