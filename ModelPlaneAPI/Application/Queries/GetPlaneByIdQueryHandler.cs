using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace ModelPlaneApp.Application.Queries
{
    public class GetPlaneByIdQueryHandler : IRequestHandler<GetPlaneByIdQuery, Plane>
    {
        private readonly IPlaneRepository _planeRepository;

        public GetPlaneByIdQueryHandler(IPlaneRepository planeRepository)
        {
            _planeRepository = planeRepository;
        }

        public async Task<Plane> Handle(GetPlaneByIdQuery request, CancellationToken cancellationToken)
        {
            return await _planeRepository.GetPlaneByIdAsync(request.Id);
        }
}
}
