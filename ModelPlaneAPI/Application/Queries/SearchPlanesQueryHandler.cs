using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ModelPlaneApp.Application.Queries
{
    public class SearchPlanesQueryHandler : IRequestHandler<SearchPlanesQuery, IEnumerable<Plane>>
    {
        private readonly IPlaneRepository _planeRepository;

        public SearchPlanesQueryHandler(IPlaneRepository planeRepository)
        {
            _planeRepository = planeRepository;
        }

        public async Task<IEnumerable<Plane>> Handle(SearchPlanesQuery request, CancellationToken cancellationToken)
        {
            // Call the repository method with individual parameters from the query
            return await _planeRepository.SearchPlanes(
                request.Manufacturer,  // Now a string
                request.Scale,  // Now a string
                request.Airline,  // Now a string
                request.Model,  // Replacing Aircraft with Model (combined make + model)
                request.Country,
                request.Continent,  // Continent remains a string
                request.PartNumber,
                request.Registration,
                request.ProductionYears,
                request.RollingGears,
                request.Notes,
                request.Engines,
                request.UnitsMade,
                request.IncludesStand,
                request.Wings900Id,
                request.SortBy
            );
        }
    }
}
