using System;
using MediatR;
using System.Collections.Generic;

namespace ModelPlaneApp.Application.Commands
{
    public class CreatePlaneCommand : IRequest<Guid>
    {
        public int Wings900Id { get; set; }  // Unique ID from wings900
        public string Manufacturer { get; set; }  // String instead of Enum
        public string Scale { get; set; }  // String instead of Enum
        public string Airline { get; set; }  // String instead of Enum
        public string Model { get; set; }  // Combined Make and Model as String
        public string PartNumber { get; set; }
        public string Registration { get; set; }
        public string Country { get; set; }
        public string Continent { get; set; }  // Add Continent as a string
        public string ProductionYears { get; set; }
        public bool RollingGears { get; set; }
        public string Notes { get; set; }
        public string Engines { get; set; }
        public int UnitsMade { get; set; }
        public bool IncludesStand { get; set; }

        // List of image URLs or file paths
        public List<string> ImageUrls { get; set; }
    }
}
