using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using WebAPI.BLL.Exceptions;

namespace WebAPI.Middleware
{
    // промежуточная ПО
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate context)
        {
            _next = context;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }
        
        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError; // 500 status code

            if (exception is ValidationException) code = HttpStatusCode.BadRequest; // 400 status code
            if (exception is NotFoundException) code = HttpStatusCode.NotFound; // 404 status code 

            var result = JsonConvert.SerializeObject(new {error = exception.Message});
            
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}