using System;
using MediatR;
using ModelPlaneAPI.Models;

namespace ModelPlaneApp.Application.Queries
{
    public class GetPlaneByIdQuery : IRequest<Plane>
    {
        public Guid Id { get; set; }
    }
}
