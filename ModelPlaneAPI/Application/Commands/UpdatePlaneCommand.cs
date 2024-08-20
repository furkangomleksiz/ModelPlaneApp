using System;
using MediatR;

namespace ModelPlaneApp.Application.Commands
{
    public class UpdatePlaneCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public DateTime ManufactureDate { get; set; }
        public string Model { get; set; }
        public string Scale { get; set; }
        public string ImageUrl { get; set; }
    }
}
