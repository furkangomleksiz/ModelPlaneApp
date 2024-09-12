public enum Manufacturer
{
    AdmiralToys,
    Herpa,
    GeminiJets,
    DragonWings,
    PhoenixModels,
    AeroClassics,
    JCWings,
    HoganWings
}

public enum Scale
{
    OneEightySeven = 1,  // 1:87
    TwoHundred,          // 1:200
    FourHundred,         // 1:400
    FiveHundred,         // 1:500
    SixHundred           // 1:600
}

public enum Airline
{
    Airline1,
    Airline2,
    Airline3,
    BelgianAirForce,
    MartinairHolland,
    AmericanAirlines,
    DeltaAirLines,
    Lufthansa,
    BritishAirways,
    Emirates,
    QatarAirways,
    SingaporeAirlines
}

public enum Aircraft
{
    Aircraft1,
    Aircraft2,
    Aircraft3,
    Cessna172,
    A300,
    A310,
    A318,
    A319,
    A320,
    A321,
    A330,
    A340,
    A350,
    A380,
    B707,
    B727,
    B737,
    B747,
    B757,
    B767,
    B777,
    B787,
    DC10,
    L1011,
    CRJ,
    VC10
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
