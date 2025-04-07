using CaseApp.Repositories;
namespace CaseApp.Klasser;

public class Store
{
    public int Id { get; set; }
    public string Category { get; set; } = string.Empty;
    public int PhoneNumber { get; set; }
    public int Price {get; set;}
    public string Color { get; set; }
    public string Brand { get; set; } = string.Empty;
    public string Description { get; set; } = String.Empty;
    
    
}