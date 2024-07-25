using DoorsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DoorsAPI.Controllers
{
    public interface IDoorsController
    {
        ActionResult<IEnumerable<Door>> GetDoors();
        ActionResult<Door> GetDoor(int id);
        IActionResult UpdateDoor(int id, Door updatedDoor);
    }
}
