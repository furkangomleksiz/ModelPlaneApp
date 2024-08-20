using System.Collections.Generic;
using MediatR;
using ModelPlaneAPI.Models;

namespace ModelPlaneApp.Application.Queries
{
    public class GetAllPlanesQuery : IRequest<List<Plane>>
    {
    }
}
