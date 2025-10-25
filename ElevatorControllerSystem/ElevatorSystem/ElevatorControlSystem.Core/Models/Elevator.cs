using Microsoft.Extensions.Logging;

namespace ElevatorControlSystem.Core.Models
{
    public class Elevator
    {
        public int Id { get; set; }
        public int CurrentFloor { get; set; } = 1;
        public Direction Direction { get; set; } = Direction.Idle;
        public Queue<int> Destinations { get; set; } = new();

        private readonly ILogger _logger;

        public Elevator(int id, ILogger logger)
        {
            Id = id;
            _logger = logger;
        }

        public void AddDestination(int floor)
        {
            if (!Destinations.Contains(floor))
                Destinations.Enqueue(floor); ;
        }

        public void Move()
        {
            if (Destinations.Count == 0)
            {
                Direction = Direction.Idle;
                return;
            }

            int target = Destinations.Peek();

            if (CurrentFloor < target)
            {
                Direction = Direction.Up;
                CurrentFloor++;
            }
            else if (CurrentFloor > target)
            {
                Direction = Direction.Down;
                CurrentFloor--;
            }
            else
            {
                Console.WriteLine($"Elevator {Id} stopped at floor {CurrentFloor}");
                Destinations.Dequeue();
                Direction = Destinations.Count > 0
                    ? (CurrentFloor < Destinations.Peek() ? Direction.Up : Direction.Down)
                    : Direction.Idle;
            }
        }

        public override string ToString()
        {
            return $"Elevator {Id} is on floor {CurrentFloor} going {Direction}";
        }
    }
}
