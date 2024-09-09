using System.Collections.Generic;
using MediatR;

namespace ModelPlaneApp.Application.Queries
{
    public class GetAllPlanesQuery : IRequest<List<Plane>>
    {
    }
}
