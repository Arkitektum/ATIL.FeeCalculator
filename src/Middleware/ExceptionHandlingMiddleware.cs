using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ATIL.FeeCalculator.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        public RequestDelegate requestDelegate;
        public ExceptionHandlingMiddleware(RequestDelegate requestDelegate)
        {
            this.requestDelegate = requestDelegate;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await requestDelegate(context);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex);
            }
        }
        private static Task HandleException(HttpContext context, Exception ex)
        {
            var errorMessage = JsonConvert.SerializeObject(new { Message = ex.Message });
            var statuscode = (int)HttpStatusCode.InternalServerError;

            if (ex is ArgumentException)
            {
                statuscode = (int)HttpStatusCode.BadRequest;
            }
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statuscode;

            return context.Response.WriteAsync(errorMessage);
        }
    }
}
