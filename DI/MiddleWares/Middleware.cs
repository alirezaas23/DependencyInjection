using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using DI.Services;

namespace DI.MiddleWares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Middleware
    {
        private readonly RequestDelegate _next;

        public Middleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, TransientService transientService, ScopedService scopedService, SingletonService singletonService)
        {
            httpContext.Items.Add("TransientService", "Transient Guid from Middleware =" + transientService.GetGuid());
            httpContext.Items.Add("ScopedService", "Scoped Guid from Middlware =" + scopedService.GetGuid());
            httpContext.Items.Add("SingletonSerive", "Singleton Guid from Middleware =" + singletonService.GetGuid());
            await _next(httpContext);
        }
    }
}
