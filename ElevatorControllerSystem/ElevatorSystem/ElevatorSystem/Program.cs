using ElevatorControlSystem.Core.Services;
using ElevatorSystem;
using Microsoft.Extensions.DependencyInjection;

public class Program
{
    static void Main()
    {

        var startup = new Startup();
        var serviceProvider = startup.ConfigureServices();

        ElevatorController? controller = serviceProvider.GetRequiredService<ElevatorController>();
        var requestGenerator = serviceProvider.GetRequiredService<RequestGenerator>();

        while (true)
        {
            var request = requestGenerator.Generate();
            controller.AssignElevator(request);

            // Simulate elevator movement for 10 seconds (1 step per second)
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(1000); // Simulate 1 second delay
                controller.Step();
            }

            Console.WriteLine("==============================================");
        }
    }
}
