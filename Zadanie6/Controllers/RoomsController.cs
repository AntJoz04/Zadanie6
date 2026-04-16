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
        [HttpGet]
        public IActionResult Get([FromQuery]int? minCapacity=0)
        {
           //200 ok
           return Ok(rooms.Where(r => r.Capacity >= minCapacity));
        }
        // GET /api/rooms/{id}
        //get /api/rooms/3
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
        
        
        
    }
}
