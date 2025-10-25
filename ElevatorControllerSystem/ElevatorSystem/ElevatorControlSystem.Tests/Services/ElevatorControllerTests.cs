using ElevatorControlSystem.Core.Models;
using ElevatorControlSystem.Core.Services;
using Microsoft.Extensions.Logging;
using Moq;

namespace ElevatorControlSystem.Tests
{
    [TestClass]
    public class ElevatorControllerDevTests
    {
        private Mock<ILogger<ElevatorController>> _mockControllerLogger;

        [TestInitialize]
        public void Setup()
        {
            _mockControllerLogger = new Mock<ILogger<ElevatorController>>();
        }

        [TestMethod]
        public void ElevatorController_ShouldRequestsOverTime()
        {
            // Arrange
            var controller = new ElevatorController(2, _mockControllerLogger.Object);
            var elevators = GetElevators(controller);

            // Simulate requests
            var request = new Request(3, Direction.Up);
            controller.AssignElevator(request);
            
            // Act: Simulate elevator movement over time
            for (int i = 0; i < 10; i++)
            {
                controller.Step();
                Thread.Sleep(100); // Simulate time passing
            }

            // Assert: All elevators should have processed their destinations
            foreach (var elevator in elevators)
            {
                Assert.AreEqual(0, elevator.Destinations.Count, $"Elevator {elevator.Id} still has pending destinations.");
                Assert.AreEqual(Direction.Idle, elevator.Direction, $"Elevator {elevator.Id} should be idle.");
            }
        }

        // Helper method to access private _elevators field using reflection
        private List<Elevator> GetElevators(ElevatorController controller)
        {
            var field = typeof(ElevatorController).GetField("_elevators", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            return field.GetValue(controller) as List<Elevator>;
        }
    }
}