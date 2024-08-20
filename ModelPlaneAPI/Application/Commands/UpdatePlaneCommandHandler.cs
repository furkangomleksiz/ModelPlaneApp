using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace ModelPlaneApp.Application.Commands
{
    public class UpdatePlaneCommandHandler : IRequestHandler<UpdatePlaneCommand, bool>
    {
        private readonly IPlaneRepository _planeRepository;

        public UpdatePlaneCommandHandler(IPlaneRepository planeRepository)
        {
            _planeRepository = planeRepository;
        }

        public async Task<bool> Handle(UpdatePlaneCommand request, CancellationToken cancellationToken)
        {
            var plane = await _planeRepository.GetPlaneByIdAsync(request.Id);
            if (plane == null)
            {
                return false;
            }

            plane.Name = request.Name;
            plane.Manufacturer = request.Manufacturer;
            plane.ManufactureDate = request.ManufactureDate;
            plane.Model = request.Model;
            plane.Scale = request.Scale;
            plane.ImageUrl = request.ImageUrl;

            await _planeRepository.UpdatePlaneAsync(plane);
            return true;
        }
    }
}
