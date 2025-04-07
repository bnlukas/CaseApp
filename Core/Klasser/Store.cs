﻿using System; 
namespace Core;

public class Store
{
    public int Id { get; set; }
    public string Category { get; set; } = string.Empty;
    public int PhoneNumber { get; set; }
    public int Price {get; set;}
    public string Color { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public string Description { get; set; } = String.Empty;
    public bool Udlånt { get; set; } = false;
    public string? ImageUrl { get; set; } = string.Empty;   
    
}