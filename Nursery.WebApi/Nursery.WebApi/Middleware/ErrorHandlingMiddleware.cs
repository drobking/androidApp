using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Nursery.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Nursery.WebApi.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;
        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex, _logger);
            }
        }
        private async Task HandleExceptionAsync(HttpContext context, Exception ex, ILogger<ErrorHandlingMiddleware> logger)
        {
            object errors = null;

            switch (ex)
            {
                case RestException rest:
                    logger.LogError(ex, "Rest error");
                    errors = new
                        {
                            status = (int)rest.Code,
                            errors= rest.Errors
                        };
                    context.Response.StatusCode = (int)rest.Code;
                    break;
                // ReSharper disable once PatternAlwaysOfType
                case Exception e:
                    logger.LogError(ex, "Server error");
                    errors = string.IsNullOrWhiteSpace(e.Message) ? "error" : e.Message;
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            context.Response.ContentType = "appliation/json";

            if (errors != null)
            {
                var result = JsonConvert.SerializeObject(
                    errors
                );

                await context.Response.WriteAsync(result);
            }
        }
    }
}
