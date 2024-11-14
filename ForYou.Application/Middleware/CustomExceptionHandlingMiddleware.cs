﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                _logger.LogError( 
                    exception, "Exception occurred: {Message}", exception.Message);

                var problemDetails = new ProblemDetails
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Title = "Server Error"
                };

                context.Response.StatusCode =
                    StatusCodes.Status500InternalServerError;

                await context.Response.WriteAsJsonAsync(problemDetails);
            }
        }


    }
}
