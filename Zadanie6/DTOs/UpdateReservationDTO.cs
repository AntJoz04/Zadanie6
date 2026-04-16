using System.ComponentModel.DataAnnotations;

namespace Zadanie6.DTOs;

public class UpdateReservationDTO
{
    [Required]
    [StringLength(100)]
    [MinLength(3)]
    public string OrganizerName { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string Topic { get; set; } = string.Empty;

    public int RoomId { get; set; }

    public DateTime Date { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    [Required]
    public string Status { get; set; } = string.Empty;

}