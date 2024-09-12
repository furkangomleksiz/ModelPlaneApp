using MediatR;

namespace ModelPlaneApp.Application.Queries
{
    public class SearchPlanesQuery : IRequest<IEnumerable<Plane>>
    {
        public int? Manufacturer { get; set; }
        public int? Scale { get; set; }
        public int? Airline { get; set; }
        public int? Aircraft { get; set; }
        public string? PartNumber { get; set; }
        public string? ModelId { get; set; }
    }
}
