using System;
using MediatR;

namespace ModelPlaneApp.Application.Commands
{
    public class DeletePlaneCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}