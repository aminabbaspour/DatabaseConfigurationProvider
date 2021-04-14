using DatabaseConfigurationProvider.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseConfigurationProvider.Middleware
{
    public class DisplayConfigurationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _config;

        public DisplayConfigurationMiddleware(RequestDelegate next, IConfiguration config)
        {
            _next = next;
            _config = config;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var firstName =  _config.GetValue<string>("FirstName");
            var lastName = _config.GetValue<string>("LastName");
            var age = _config.GetValue<string>("Age");

            await context.Response.WriteAsync($"Configuration Info:\nFirstName = {firstName} , LastName = {lastName}, Age = {age}\n\n");
            await _next(context);

        }
    }
}
