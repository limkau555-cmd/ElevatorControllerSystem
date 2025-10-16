
namespace ElevatorSystem.Models
{
    public class Request
    {
        public int Floor { get; }
        public Direction Direction { get; }

        public Request(int floor, Direction direction)
        {
            Floor = floor;
            Direction = direction;
        }

        public override string ToString()
        {
            return $"{Direction} request on floor {Floor}";
        }
    }
}
