using DI.Interfaces;
using DI.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DI.Models
{
    public static class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<ISmsService, KavenegarService>();
        }
    }
}
