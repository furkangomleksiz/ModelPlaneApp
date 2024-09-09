using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
namespace ModelPlaneApp.Application.Queries
{
    public class GetAllPlanesQueryHandler : IRequestHandler<GetAllPlanesQuery, List<Plane>>
    {
        private readonly IPlaneRepository _planeRepository;

        public GetAllPlanesQueryHandler(IPlaneRepository planeRepository)
        {
            _planeRepository = planeRepository;
        }

        public async Task<List<Plane>> Handle(GetAllPlanesQuery request, CancellationToken cancellationToken)
        {
            return await _planeRepository.GetAllPlanesAsync();
        }
    }
}
