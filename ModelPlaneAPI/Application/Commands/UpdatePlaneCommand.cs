using System;
using MediatR;
using System.Collections.Generic;

namespace ModelPlaneApp.Application.Commands
{
    public class UpdatePlaneCommand : IRequest<bool>
    {
        public Guid Id { get; set; }  // UUID of the plane being updated
        public int Wings900Id { get; set; }  // Unique ID from wings900

        public string Manufacturer { get; set; }  // Now a string
        public string Scale { get; set; }  // Now a string
        public string Airline { get; set; }  // Now a string
        public string Model { get; set; }  // Replacing Aircraft with Model (combined make + model)
        public string PartNumber { get; set; }
        public string Registration { get; set; }
        public string Country { get; set; }
        public string ProductionYears { get; set; }
        public bool RollingGears { get; set; }
        public string Notes { get; set; }
        public string Engines { get; set; }
        public int UnitsMade { get; set; }
        public bool IncludesStand { get; set; }

        // List of image URLs or file paths
        public List<string> ImageUrls { get; set; } = new List<string>();  // Default initialization to avoid null references
    }
}
