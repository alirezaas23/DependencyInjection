using DI.Interfaces;
using DI.Services;
using DI.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DI.Models
{
    public static class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ISmsService, KavenegarService>();
            services.Configure<KevenegarApiViewModel>(configuration.GetSection("KavenegarAPI"));
            services.Configure<PasargadBankViewModel>(configuration.GetSection("PasargadBank"));
        }
    }
}
