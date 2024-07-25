using DoorsAPI.Controllers;
using DoorsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace DoorManagementAPI.Tests
{
    public class DoorsControllerTests
    {
        private readonly Mock<IDoorsController> _mockController;
        private readonly IDoorsController _controller;

        public DoorsControllerTests()
        {
            // Arrange
            _mockController = new Mock<IDoorsController>();
            _controller = _mockController.Object;

            // Setup initial mock data
            var doors = new List<Door>
            {
                new Door { Id = 0, Name = "Door One", IsOpen = "Open", IsLocked = "Unlocked", IsAlarmed = "Inactive" },
                new Door { Id = 1, Name = "Door Two", IsOpen = "Closed", IsLocked = "Unlocked", IsAlarmed = "Inactive" },
                new Door { Id = 2, Name = "Door Three", IsOpen = "Closed", IsLocked = "Locked", IsAlarmed = "Alarmed" }
            };

            _mockController.Setup(m => m.GetDoors()).Returns(new ActionResult<IEnumerable<Door>>(doors));
            _mockController.Setup(m => m.GetDoor(It.IsAny<int>())).Returns((int id) =>
            {
                var door = doors.FirstOrDefault(d => d.Id == id);
                if (door != null)
                {
                    return new ActionResult<Door>(door);
                }
                return new ActionResult<Door>(new NotFoundResult());
            });
            _mockController.Setup(m => m.UpdateDoor(It.IsAny<int>(), It.IsAny<Door>())).Returns((int id, Door updatedDoor) =>
            {
                var door = doors.FirstOrDefault(d => d.Id == id);
                if (door != null)
                {
                    door.IsOpen = updatedDoor.IsOpen;
                    door.IsLocked = updatedDoor.IsLocked;
                    door.IsAlarmed = updatedDoor.IsAlarmed;
                    return new OkResult();
                }
                return new NotFoundResult();
            });
        }

        [Fact]
        public void GetDoors_ReturnsAllDoors()
        {
            // Act
            var result = _controller.GetDoors();

            // Assert
            var doors = Assert.IsAssignableFrom<IEnumerable<Door>>(result.Value);
            Assert.Equal(3, ((List<Door>)doors).Count);
        }

        [Fact]
        public void GetDoor_ReturnsDoor_WhenIdIsValid()
        {
            // Act
            var result = _controller.GetDoor(1);

            // Assert
            var door = Assert.IsType<Door>(result.Value);
            Assert.Equal(1, door.Id);
        }

        [Fact]
        public void GetDoor_ReturnsNotFound_WhenIdIsInvalid()
        {
            // Act
            var result = _controller.GetDoor(99);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void UpdateDoor_ReturnsOK_WhenDoorIsUpdated()
        {
            // Arrange
            var updatedDoor = new Door { Id = 1, Name = "Door One", IsOpen = "Closed", IsLocked = "Locked", IsAlarmed = "Inactive" };

            // Act
            var result = _controller.UpdateDoor(1, updatedDoor);

            // Assert
            Assert.IsType<OkResult>(result);
            var door = _controller.GetDoor(1).Value;
            Assert.Equal("Closed", door.IsOpen);
            Assert.Equal("Locked", door.IsLocked);
            Assert.Equal("Inactive", door.IsAlarmed);
        }

        [Fact]
        public void UpdateDoor_ReturnsNotFound_WhenIdIsInvalid()
        {
            // Arrange
            var updatedDoor = new Door { Id = 99, Name = "Invalid Door", IsOpen = "Closed", IsLocked = "Locked", IsAlarmed = "Inactive" };

            // Act
            var result = _controller.UpdateDoor(99, updatedDoor);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
