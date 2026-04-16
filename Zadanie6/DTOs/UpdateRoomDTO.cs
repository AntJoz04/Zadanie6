using System.ComponentModel.DataAnnotations;

namespace Zadanie6.DTOs;

public class UpdateRoomDTO
{
    [Required]
    [StringLength(100)]
    [MinLength(3)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [StringLength(10)]
    public string BuildingCode { get; set; } = string.Empty;

    [Range(0, 20)]
    public int Floor { get; set; }

    [Range(1, 1000)]
    public int Capacity { get; set; }

    public bool HasProjector { get; set; }

    public bool IsActive { get; set; }
}