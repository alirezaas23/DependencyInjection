using DI.Interfaces;
using DI.Services;
using DI.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace DI.Models
{
    public static class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            //services.AddTransient<ISmsService, KavenegarService>();

            // Work fot all
            services.AddTransient(typeof(ISmsService), typeof(ParsGreenService));

            services.Configure<KevenegarApiViewModel>(configuration.GetSection("KavenegarAPI"));
            services.Configure<PasargadBankViewModel>(configuration.GetSection("PasargadBank"));
            services.AddTransient<TransientService>();

            services.AddScoped<ScopedService>();
            //services.AddScoped(typeof(ScopedService));

            //services.AddSingleton<SingletonService>();
            // Just work in singleton
            services.AddSingleton(new SingletonService());

            // If we had a ISmsService injection before, this injection not working.
            services.TryAddScoped<ISmsService, KavenegarService>();


            // If you want to inject in views use => Inject<TransientService> TransientSerivce. Dont forget to using requirments :).
         }
    }
}
