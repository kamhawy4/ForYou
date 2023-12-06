using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForYou.Application.Middleware
{
    public class CustomExceptionHandlingMiddleware
    {

        private readonly RequestDelegate _next;

        private readonly ILogger<CustomExceptionHandlingMiddleware> _logger;

        public CustomExceptionHandlingMiddleware(RequestDelegate next, ILogger<CustomExceptionHandlingMiddleware> logger) { 
          _next = next; 
          _logger = logger;
        }

        private async Task HandleExceptionAsync(HttpContext context,Exception exception)
        {

            context.Response.ContentType = "application/json";


        }


    }
}
