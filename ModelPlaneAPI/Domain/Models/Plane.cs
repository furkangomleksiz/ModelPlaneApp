public enum Manufacturer
{
    AdmiralToys,
    Herpa,
    // Add other manufacturers here
}

public enum Scale
{
    OneEightySeven = 1,  // 1:87
    TwoHundred,          // 1:200
    // Add other scales here
}

public enum Airline
{
    MartinairHolland,
    // Add other airlines here
}

public enum Aircraft
{
    Cessna172,
    // Add other aircraft here
}

public class Plane
{
    public Guid Id { get; set; }  // The database UUID for internal identification
    public int Wings900Id { get; set; }  // The unique identifier from wings900
    
    public Manufacturer Manufacturer { get; set; }
    public Scale Scale { get; set; }
    public Airline Airline { get; set; }
    public Aircraft Aircraft { get; set; }
    public string PartNumber { get; set; }
    public string Registration { get; set; }
    public string Country { get; set; }
    public string ProductionYears { get; set; }
    public bool RollingGears { get; set; }
    public string Notes { get; set; }
    public string Engines { get; set; }
    public int UnitsMade { get; set; }
    public bool IncludesStand { get; set; }

    // List of image URLs or file paths for uploaded model photos
    public List<string> Images { get; set; } = new List<string>();
}
