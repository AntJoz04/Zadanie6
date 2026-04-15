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
            new Room() { Id = 1, Name = "room1", Capacity = 5 },
            new Room() { Id = 2, Name = "room2", Capacity = 50 },
            new Room() { Id = 3, Name = "room3", Capacity = 55 }
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
        //204
        //return
        //409
        
    }
}
