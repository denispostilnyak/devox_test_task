using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevoxTestTask.BLL.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace DevoxTestTask.WebAPI.ExceptionsMiddleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex);
            }
        }

        private Task HandleException(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            switch (exception)
            {
                case NotFoundException _:
                {
                    context.Response.StatusCode = 404;
                    break;
                }
                case ArgumentNullException _:
                {
                    context.Response.StatusCode = 400;
                    break;
                }
                case DbUpdateException _:
                {
                    context.Response.StatusCode = 400;
                    break;
                }
                case Exception _: {
                    context.Response.StatusCode = 400;
                    break;
                }
                default:
                {
                    context.Response.StatusCode = 500;
                    break;
                }
            }

            return context.Response.WriteAsync(exception.Message);
        }
    }
}
