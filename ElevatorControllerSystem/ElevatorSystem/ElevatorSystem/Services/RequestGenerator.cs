using ElevatorSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSystem.Services
{
    public static class RequestGenerator
    {
        private static readonly Random _random = new();

        public static Request Generate()
        {
            int floor = _random.Next(1, 11);
            Direction direction = floor switch
            {
                1 => Direction.Up,
                10 => Direction.Down,
                _ => _random.Next(0, 2) == 0 ? Direction.Up : Direction.Down
            };

            var request = new Request(floor, direction);
            Console.WriteLine($"Generated: {request}");
            return request;
        }
    }
}
