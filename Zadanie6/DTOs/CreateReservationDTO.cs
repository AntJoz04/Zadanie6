using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Zadanie6.DTOs;

public class CreateReservationDTO
{
    [Required]
    [StringLength(100)]
    [MinLength(3)]
    public string OrganizerName { get; set; } = string.Empty;
    [Required]
    [StringLength(100)]
    public string Topic { get; set; } = string.Empty;
    public int RoomId { get; set; }
    public DateTime Date{ get; set; }
    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }
}