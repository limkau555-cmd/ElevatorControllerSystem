using ElevatorSystem.Services;

public class Program
{
    static void Main()
    {
        var controller = new ElevatorController(4);

        while (true)
        {
            var request = RequestGenerator.Generate();
            controller.AssignElevator(request);

            for (int i = 0; i < 10; i++) // simulate 10 seconds
            {
                Thread.Sleep(1000);
                controller.Step();
            }

            Console.WriteLine("-----");
        }
    }
}
