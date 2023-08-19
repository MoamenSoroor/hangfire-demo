
using Hangfire;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using TestingHangfire.Jobs;
using TestingHangfire.Jobs.Configurations;
using Topshelf;
using static System.Net.Mime.MediaTypeNames;

internal partial class Program
{
    private static void Main(string[] args)
    {

        ConfigurationBuilder configBuilder = new ConfigurationBuilder();
        configBuilder.AddJsonFile("appsettings.json");

        IConfiguration configuration = configBuilder.Build();

        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File(@"logs\RouteDelivery-Service.txt",rollingInterval: RollingInterval.Day)
            .CreateLogger();

        IServiceCollection services = new ServiceCollection();
        services.AddSingleton<IConfiguration>(configuration);
        services.ConfigureJobsServices();

        var serviceProvider = services.BuildServiceProvider();


        //Hangfire Job Storage 
        GlobalConfiguration.Configuration.UseSqlServerStorage(configuration.GetConnectionString("hangfireDb"));
        GlobalConfiguration.Configuration.UseActivator(new MyJobActivator(serviceProvider));
        
        //Topshelf
        HostFactory.Run(x =>
        {
            x.UseSerilog();
            x.Service<HangfireRunningService>(s =>
            {
                s.ConstructUsing(name => new HangfireRunningService());
                s.WhenStarted(rs => rs.Start());
                s.WhenStopped(rs => rs.Stop());
            });
            x.RunAsLocalSystem();

            x.SetDescription("Test Hangfire Service");
            x.SetDisplayName("HangfireTestServer");
            x.SetServiceName("HangfireTestServer");
        });
    }
}