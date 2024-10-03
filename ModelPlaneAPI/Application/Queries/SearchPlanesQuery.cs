using MediatR;
using System.Collections.Generic;

namespace ModelPlaneApp.Application.Queries
{
    public class SearchPlanesQuery : IRequest<IEnumerable<Plane>>
    {
        public string? Manufacturer { get; set; }  // Changed to string
        public string? Scale { get; set; }  // Changed to string
        public string? Airline { get; set; }  // Changed to string
        public string? Model { get; set; }  // Replacing Aircraft with Model (combined make + model)
        public string? Country { get; set; }
        public string? Continent { get; set; }  // Continent remains a string
        public string? PartNumber { get; set; }
        public string? Registration { get; set; }
        public string? ProductionYears { get; set; }
        public bool? RollingGears { get; set; }
        public string? Notes { get; set; }
        public string? Engines { get; set; }
        public int? UnitsMade { get; set; }
        public bool? IncludesStand { get; set; }
        public string? ModelId { get; set; }
        public string? SortBy { get; set; }
    }
}
