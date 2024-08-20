using System;
using MediatR;

namespace ModelPlaneApp.Application.Commands
{
    public class CreatePlaneCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public DateTime ManufactureDate { get; set; }  // New property
        public string Model { get; set; }  // New property
        public string Scale { get; set; }
        public string ImageUrl { get; set; }
    }
}