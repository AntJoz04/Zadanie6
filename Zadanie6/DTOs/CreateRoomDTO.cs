using System.ComponentModel.DataAnnotations;

namespace Zadanie6.DTOs;

public class CreateRoomDTO
{
    [StringLength(100)]
    [MinLength(3)]
    public string Name { get; set; } = string.Empty;
    [Range(1,100)]
    public int Capacity { get; set; }
    

}