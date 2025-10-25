using ElevatorControlSystem.Core.Models;
using Microsoft.Extensions.Logging;


namespace ElevatorControlSystem.Core.Services
{
    public class ElevatorController
    {
        private readonly List<Elevator> _elevators;

        private readonly ILogger<ElevatorController> _logger;

        public ElevatorController(int elevatorCount, ILogger<ElevatorController> logger)
        {
            _logger = logger;
            _elevators = Enumerable.Range(1, elevatorCount)
                                   .Select(id => new Elevator(id, logger))
                                   .ToList();
        }

        public void AssignElevator(Request request)
        {
            var elevator = _elevators.OrderBy(e => Math.Abs(e.CurrentFloor - request.Floor)).First();
            elevator.AddDestination(request.Floor);
            _logger.LogInformation($"{request} assigned to Elevator {elevator.Id}");
        }

        public void Step()
        {
            foreach (var elevator in _elevators)
            {
                elevator.Move();
                _logger.LogInformation(elevator.ToString());
            }
        }
    }
}
