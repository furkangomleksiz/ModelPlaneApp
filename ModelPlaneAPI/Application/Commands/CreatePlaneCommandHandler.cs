using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ModelPlaneAPI.Models;

namespace ModelPlaneApp.Application.Commands
{
    public class CreatePlaneCommandHandler : IRequestHandler<CreatePlaneCommand, Guid>
    {
        private readonly IPlaneRepository _planeRepository;

        public CreatePlaneCommandHandler(IPlaneRepository planeRepository)
        {
            _planeRepository = planeRepository;
        }

        public async Task<Guid> Handle(CreatePlaneCommand request, CancellationToken cancellationToken)
        {
            var plane = new Plane
            {
                Id = Guid.NewGuid(), // ID is generated here
                Name = request.Name,
                Manufacturer = request.Manufacturer,
                ManufactureDate = request.ManufactureDate,
                Model = request.Model,
                Scale = request.Scale,
                ImageUrl = request.ImageUrl
            };

            await _planeRepository.AddPlaneAsync(plane);

            return plane.Id;
        }
    }
}
