public class Plane
{
    public Guid Id { get; set; }  // The database UUID for internal identification
    public int Wings900Id { get; set; }  // The unique identifier from wings900
    
    public string Manufacturer { get; set; }  // Replacing enum with string
    public string Scale { get; set; }  // Replacing enum with string
    public string Airline { get; set; }  // Replacing enum with string
    public string Model { get; set; }  // Combining make and model
    public string PartNumber { get; set; }
    public string Registration { get; set; }
    public string Country { get; set; }
    public string Continent { get; set; }  
    public string ProductionYears { get; set; }
    public bool RollingGears { get; set; }
    public string Notes { get; set; }
    public string Engines { get; set; }
    public int UnitsMade { get; set; }
    public bool IncludesStand { get; set; }

    // List of image URLs or file paths for uploaded model photos
    public List<string> Images { get; set; } = new List<string>();
}
