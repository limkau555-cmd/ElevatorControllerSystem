
using System;
using Microsoft.Extensions.Logging;
using ElevatorControlSystem.Core.Models;

namespace ElevatorControlSystem.Core.Services
{
    public class RequestGenerator
    {
        private static readonly Random _random = new();
        private readonly ILogger<RequestGenerator> _logger;

        public RequestGenerator(ILogger<RequestGenerator> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Generates a random request from a floor with a valid direction.
        /// </summary>
        /// <returns>A new Request object.</returns>
        public Request Generate()
        {
            int floor = _random.Next(1, 11); // Floors 1 to 10
            Direction direction = floor switch
            {
                1 => Direction.Up,
                10 => Direction.Down,
                _ => _random.Next(0, 2) == 0 ? Direction.Up : Direction.Down
            };

            var request = new Request(floor, direction);
            _logger.LogInformation("Generated: {Request}", request);
            return request;
        }
    }
}
