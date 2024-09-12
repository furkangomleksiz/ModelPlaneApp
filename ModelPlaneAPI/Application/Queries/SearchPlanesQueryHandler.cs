using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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
            var query = _planeRepository.GetPlanes();

            if (request.Manufacturer.HasValue)
            {
                query = query.Where(p => p.Manufacturer == (Manufacturer)request.Manufacturer.Value);
            }

            if (request.Scale.HasValue)
            {
                query = query.Where(p => p.Scale == (Scale)request.Scale.Value);
            }

            if (request.Airline.HasValue)
            {
                query = query.Where(p => p.Airline == (Airline)request.Airline.Value);
            }

            if (request.Aircraft.HasValue)
            {
                query = query.Where(p => p.Aircraft == (Aircraft)request.Aircraft.Value);
            }

            if (!string.IsNullOrEmpty(request.PartNumber))
            {
                query = query.Where(p => p.PartNumber.Contains(request.PartNumber));
            }

            if (!string.IsNullOrEmpty(request.ModelId))
            {
                query = query.Where(p => p.Wings900Id.ToString().Contains(request.ModelId));
            }

            return await query.ToListAsync();
        }
    }
}
