using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using System.Collections.Generic;

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
            // Fetch the plane from the repository using the UUID
            var plane = await _planeRepository.GetPlaneByIdAsync(request.Id);

            if (plane == null)
            {
                throw new Exception($"Plane with Id {request.Id} not found");
            }

            // Update all the properties
            plane.Wings900Id = request.Wings900Id;
            plane.Manufacturer = request.Manufacturer;  // Now a string
            plane.Scale = request.Scale;  // Now a string
            plane.Airline = request.Airline;  // Now a string
            plane.Model = request.Model;  // Replacing Aircraft with Model (combined make + model)
            plane.PartNumber = request.PartNumber;
            plane.Registration = request.Registration;
            plane.Country = request.Country;
            plane.ProductionYears = request.ProductionYears;
            plane.RollingGears = request.RollingGears;
            plane.Notes = request.Notes;
            plane.Engines = request.Engines;
            plane.UnitsMade = request.UnitsMade;
            plane.IncludesStand = request.IncludesStand;

            // Replace the existing image URLs with the new ones
            plane.Images = new List<string>(request.ImageUrls);

            // Save the updated plane back to the repository
            await _planeRepository.UpdatePlaneAsync(plane);

            return true;
        }
    }
}
