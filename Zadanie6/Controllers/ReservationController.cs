using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zadanie6.Models;

namespace Zadanie6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        public static List<Reservation> reservations = new List<Reservation>()
        {
            new Reservation() 
            {
                Id = 1,
                RoomId = 1,
                OrganizerName = "Adam Walczuk",
                Topic = "Gambling",
                Date = new DateTime(2026, 5, 10),
                StartTime = new DateTime(2026, 5, 10, 9, 0, 0),
                EndTime = new DateTime(2026, 5, 10, 11, 0, 0),
                Status = "confirmed"
            },
            new Reservation()
            {
                Id = 2,
                RoomId = 1,
                OrganizerName = "Anna Kowalska",
                Topic = "REST API",
                Date = new DateTime(2026, 5, 10),
                StartTime = new DateTime(2026, 5, 10, 12, 0, 0),
                EndTime = new DateTime(2026, 5, 10, 14, 0, 0),
                Status = "planned"
            },
            new Reservation()
            {
                Id = 3,
                RoomId = 2,
                OrganizerName = "Piotr Nowak",
                Topic = "Bazy danych",
                Date = new DateTime(2026, 5, 11),
                StartTime = new DateTime(2026, 5, 11, 10, 0, 0),
                EndTime = new DateTime(2026, 5, 11, 12, 30, 0),
                Status = "confirmed"
            },
            new Reservation()
            {
                Id = 4,
                RoomId = 3,
                OrganizerName = "Maria Wiśniewska",
                Topic = "C# podstawy",
                Date = new DateTime(2026, 5, 12),
                StartTime = new DateTime(2026, 5, 12, 8, 30, 0),
                EndTime = new DateTime(2026, 5, 12, 10, 0, 0),
                Status = "cancelled"
            },
            new Reservation()
            {
                Id = 5,
                RoomId = 2,
                OrganizerName = "Tomasz Zieliński",
                Topic = "LINQ w praktyce",
                Date = new DateTime(2026, 5, 10),
                StartTime = new DateTime(2026, 5, 10, 13, 0, 0),
                EndTime = new DateTime(2026, 5, 10, 15, 0, 0),
                Status = "confirmed"
            }
        };
    }
}
