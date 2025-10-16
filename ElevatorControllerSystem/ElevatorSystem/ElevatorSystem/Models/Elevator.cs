using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSystem.Models
{
    public class Elevator
    {
        public int Id { get; }
        public int CurrentFloor { get; private set; } = 1;
        public Direction Direction { get; private set; } = Direction.Idle;
        public Queue<int> Destinations { get; } = new();

        public Elevator(int id)
        {
            Id = id;
        }

        public void AddDestination(int floor)
        {
            if (!Destinations.Contains(floor))
                Destinations.Enqueue(floor);
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
