namespace Zadanie6.Models;

public class Reservation
{
    int Id { get; set; }
    int RoomId { get; set; }
    string OrganizerName { get; set; }
    string Topic { get; set; }
    DateTime Date { get; set; }
    DateTime StartTime { get; set; }
    DateTime EndTime { get; set; }
    string Status { get; set; }
}