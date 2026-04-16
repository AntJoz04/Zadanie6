using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zadanie6.DTOs;
using Zadanie6.Models;

namespace Zadanie6.Controllers
{
    //         adres/api/rooms
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        public static List<Room> rooms = new List<Room>()
        {
            new Room() { Id = 1, Name = "room1", Capacity = 5, BuildingCode = "A", Floor = 3, HasProjector = false ,isActive = true},
            new Room() { Id = 2, Name = "room2", Capacity = 25, BuildingCode = "A", Floor = 3, HasProjector = true ,isActive = true },
            new Room() { Id = 3, Name = "room3", Capacity = 50, BuildingCode = "B", Floor = 2, HasProjector = false ,isActive = true},
            new Room() { Id = 4, Name = "room4", Capacity = 15, BuildingCode = "B", Floor = 1, HasProjector = true ,isActive = true}
        };
        // GET /api/rooms
       
       
        // GET /api/rooms/{id}
        //get /api/rooms/3
        [HttpGet]
        public IActionResult GetFromlotsQuery([FromQuery] int? minCapacity, [FromQuery] bool? hasProjector, [FromQuery] bool? activeOnly)
        {
            var query = rooms.AsQueryable();

            if (minCapacity != null)
            {
                query = query.Where(r => r.Capacity >= minCapacity);
            }

            if (hasProjector != null)
            {
                query = query.Where(r => r.HasProjector == hasProjector.Value);
            }

            if (activeOnly != null)
            {
                if (activeOnly.Value)
                {
                    query = query.Where(r => r.isActive == activeOnly.Value);
                }
            }

            return Ok(query);
        }
        [Route("{id}")]
        [HttpGet]
        public IActionResult GetById(int id)
        {
            var room = rooms.FirstOrDefault(r=>r.Id == id);
            if (room == null)
            {
                return NotFound();
            }
            return Ok(room);
        }

        [Route("building/{buildingCode}")]
        [HttpGet]
        public IActionResult GetByBuildingCode(string buildingCode)
        {
            var roomsbybc = rooms.Where(r => r.BuildingCode == buildingCode);
            if (!roomsbybc.Any())
            {
                return NotFound();
            }
            return Ok(roomsbybc);
        }
        //POST /api/rooms {"name": "Room4", "capacity" : 30}
        [HttpPost]
        public IActionResult Post([FromBody] CreateRoomDTO createRoomDTO)
        {
            var room = new Room()
            {
                Id = rooms.Count + 1,
                Name = createRoomDTO.Name,
                Capacity = createRoomDTO.Capacity
            };
            rooms.Add(room);
            //201
            return CreatedAtAction(nameof(GetById), new { id = room.Id }, room);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id,[FromBody] UpdateRoomDTO updateRoomDTO)
        {
            var roombyid =  rooms.FirstOrDefault(r => r.Id == id);
            if (roombyid == null)
            {
                return NotFound();
            }
            roombyid.Name = updateRoomDTO.Name;
            roombyid.BuildingCode = updateRoomDTO.BuildingCode;
            roombyid.Floor = updateRoomDTO.Floor;
            roombyid.Capacity = updateRoomDTO.Capacity;
            roombyid.HasProjector = updateRoomDTO.HasProjector;
            roombyid.isActive= updateRoomDTO.IsActive;
            return  Ok(roombyid);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var room = rooms.FirstOrDefault(r=> r.Id == id);
            if (room == null)
            {
                return NotFound();
            }
            var hasRes = ReservationController.reservations.Any(r => r.RoomId==id);
            if (hasRes)
            {
                return Conflict();
            }
            rooms.Remove(room);
            return NoContent();
        }
        
        
        
    }
}
