using ElevatorControlSystem.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ElevatorSystem
{

    public class Startup
    {
        public IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            // Add logging
            services.AddLogging(config =>
            {
                config.ClearProviders();
                config.AddConsole(options=>options.FormatterName = "simple");
                config.SetMinimumLevel(LogLevel.Information);
            });

            // Register ElevatorController with factory to inject ILogger
            services.AddSingleton<ElevatorController>(provider =>
            {
                var logger = provider.GetRequiredService<ILogger<ElevatorController>>();
                return new ElevatorController(4, logger);
            });


            services.AddSingleton<RequestGenerator>(provider =>
            {
                var logger = provider.GetRequiredService<ILogger<RequestGenerator>>();
                return new RequestGenerator(logger);
            });


            return services.BuildServiceProvider();
        }
    }

}
