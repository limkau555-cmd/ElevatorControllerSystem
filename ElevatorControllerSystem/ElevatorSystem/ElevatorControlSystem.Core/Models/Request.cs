
namespace ElevatorControlSystem.Core.Models
{
    public class Request
    {
        public int Floor { get; set; }
        public Direction Direction { get; set; }

        public Request(int floor, Direction direction)
        {

            if (floor < 1 || floor > 10)
            {
                throw new ArgumentOutOfRangeException(nameof(floor), "Floor must be between 1 and 10.");
            }

            Floor = floor;
            Direction = direction;
        }


        public override bool Equals(object obj)
        {
            return obj is Request other &&
                   Floor == other.Floor &&
                   Direction == other.Direction;
        }


        public override int GetHashCode()
        {
            return HashCode.Combine(Floor, Direction);
        }


        public override string ToString()
        {
            return $"{Direction} request on floor {Floor}";
        }
    }
}
