namespace ElevatorSystem.Services
{
    public class ElevatorController
    {
        private readonly List<Elevator> _elevators;

        public ElevatorController(int elevatorCount)
        {
            _elevators = Enumerable.Range(1, elevatorCount)
                                   .Select(id => new Elevator(id))
                                   .ToList();
        }

        public void AssignElevator(Request request)
        {
            var elevator = _elevators.OrderBy(e => Math.Abs(e.CurrentFloor - request.Floor)).First();
            elevator.AddDestination(request.Floor);
            Console.WriteLine($"{request} assigned to Elevator {elevator.Id}");
        }

        public void Step()
        {
            foreach (var elevator in _elevators)
            {
                elevator.Move();
                Console.WriteLine(elevator);
            }
        }
    }
}
