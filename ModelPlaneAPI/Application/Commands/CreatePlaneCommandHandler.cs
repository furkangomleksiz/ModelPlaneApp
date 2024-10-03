using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using System.Collections.Generic;

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
                Id = Guid.NewGuid(),  // Generate UUID for the plane
                Wings900Id = request.Wings900Id,  // Unique wings900 ID

                Manufacturer = request.Manufacturer,  // Now a string
                Scale = request.Scale,  // Now a string
                Airline = request.Airline,  // Now a string
                Model = request.Model,  // Replacing Aircraft with Model (combined make + model)
                PartNumber = request.PartNumber,
                Registration = request.Registration,
                Country = request.Country,
                Continent = request.Continent,  // Adding the Continent attribute
                ProductionYears = request.ProductionYears,
                RollingGears = request.RollingGears,
                Notes = request.Notes,
                Engines = request.Engines,
                UnitsMade = request.UnitsMade,
                IncludesStand = request.IncludesStand,

                // Adding images from the request
                Images = new List<string>(request.ImageUrls)
            };

            // Save the plane to the repository
            await _planeRepository.AddPlaneAsync(plane);

            return plane.Id;  // Return UUID
        }
    }
}
