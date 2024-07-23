using DoorsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;


namespace DoorsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoorsController : ControllerBase
    {
        private static List<Door> doors = new List<Door>
    {
        new Door { Id = 1, Name = "Door One", IsOpen = "Open", IsLocked = "Unlocked", IsAlarmed = "Inactive" },
        new Door { Id = 2, Name = "Door Two", IsOpen = "Closed", IsLocked = "Unlocked", IsAlarmed = "Inactive" },
        new Door { Id = 3, Name = "Door Three", IsOpen = "Closed", IsLocked = "Locked", IsAlarmed = "Alarmed" }
    };

        [HttpGet]
        public ActionResult<IEnumerable<Door>> GetDoors()
        {
            return doors;
        }

        [HttpGet("{id}")]
        public ActionResult<Door> GetDoor(int id)
        {
            var door = doors.FirstOrDefault(d => d.Id == id);
            if (door == null)
            {
                return NotFound();
            }
            return door;
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDoor(int id, [FromBody] Door updatedDoor)
        {
            var door = doors.FirstOrDefault(d => d.Id == id);
            if (door == null)
            {
                return NotFound();
            }
            door.IsOpen = updatedDoor.IsOpen;
            door.IsLocked = updatedDoor.IsLocked;
            door.IsAlarmed = updatedDoor.IsAlarmed;
            return NoContent();
        }
    }
}
