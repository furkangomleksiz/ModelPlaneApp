using System;
using MediatR;

namespace ModelPlaneApp.Application.Queries
{
    public class GetPlaneByIdQuery : IRequest<Plane>
    {
        public Guid Id { get; set; }
    }
}
