namespace Zadanie6.Models;

public class Room
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Capacity { get; set; }
    public string BuildingCode {get; set;}
    public int Floor {get; set;}
    public bool HasProjector {get; set;}
    public bool isActive {get; set;}
    
    
}