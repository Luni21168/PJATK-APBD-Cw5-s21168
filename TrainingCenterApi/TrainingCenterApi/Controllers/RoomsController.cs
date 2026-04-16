using Microsoft.AspNetCore.Mvc;
using TrainingCenterApi.Data;
using TrainingCenterApi.Models;

namespace TrainingCenterApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoomsController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Room>> GetRooms(
        [FromQuery] int? minCapacity,
        [FromQuery] bool? hasProjector,
        [FromQuery] bool? activeOnly)
    {
        var rooms = AppData.Rooms.AsEnumerable();

        if (minCapacity.HasValue)
        {
            rooms = rooms.Where(r => r.Capacity >= minCapacity.Value);
        }

        if (hasProjector.HasValue)
        {
            rooms = rooms.Where(r => r.HasProjector == hasProjector.Value);
        }

        if (activeOnly == true)
        {
            rooms = rooms.Where(r => r.IsActive);
        }

        return Ok(rooms);
    }

    [HttpGet("{id:int}")]
    public ActionResult<Room> GetRoomById([FromRoute] int id)
    {
        var room = AppData.Rooms.FirstOrDefault(r => r.Id == id);

        if (room == null)
        {
            return NotFound();
        }

        return Ok(room);
    }

    [HttpGet("building/{buildingCode}")]
    public ActionResult<IEnumerable<Room>> GetRoomsByBuilding([FromRoute] string buildingCode)
    {
        var rooms = AppData.Rooms
            .Where(r => string.Equals(r.BuildingCode, buildingCode, StringComparison.OrdinalIgnoreCase));

        return Ok(rooms);
    }

    [HttpPost]
    public ActionResult<Room> CreateRoom([FromBody] Room room)
    {
        var newId = AppData.Rooms.Any()
            ? AppData.Rooms.Max(r => r.Id) + 1
            : 1;

        room.Id = newId;
        AppData.Rooms.Add(room);

        return CreatedAtAction(nameof(GetRoomById), new { id = room.Id }, room);
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateRoom([FromRoute] int id, [FromBody] Room updatedRoom)
    {
        var existingRoom = AppData.Rooms.FirstOrDefault(r => r.Id == id);

        if (existingRoom == null)
        {
            return NotFound();
        }

        existingRoom.Name = updatedRoom.Name;
        existingRoom.BuildingCode = updatedRoom.BuildingCode;
        existingRoom.Floor = updatedRoom.Floor;
        existingRoom.Capacity = updatedRoom.Capacity;
        existingRoom.HasProjector = updatedRoom.HasProjector;
        existingRoom.IsActive = updatedRoom.IsActive;

        return Ok(existingRoom);
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteRoom([FromRoute] int id)
    {
        var room = AppData.Rooms.FirstOrDefault(r => r.Id == id);

        if (room == null)
        {
            return NotFound();
        }

        var hasReservations = AppData.Reservations.Any(r => r.RoomId == id);

        if (hasReservations)
        {
            return Conflict("Cannot delete room because it has reservations.");
        }

        AppData.Rooms.Remove(room);

        return NoContent();
    }
}