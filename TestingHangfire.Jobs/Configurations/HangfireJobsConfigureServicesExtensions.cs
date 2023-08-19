using Microsoft.Extensions.DependencyInjection;
using TestingHangfire.Data;

namespace TestingHangfire.Jobs.Configurations
{
    public static class HangfireJobsConfigureServicesExtensions
    {
        public static IServiceCollection ConfigureJobsServices(this IServiceCollection services )
        {

            services.AddScoped<TestHeavyLoadService>();
            services.AddScoped<TestingRepo>();
            services.AddScoped<ITestHeavyLoadService, TestHeavyLoadService>();
            services.AddScoped<ITestingRepo, TestingRepo>();
            return services;
        }

    }

    
}
