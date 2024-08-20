using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace ModelPlaneApp.Application.Commands
{
    public class DeletePlaneCommandHandler : IRequestHandler<DeletePlaneCommand, bool>
    {
        private readonly IPlaneRepository _planeRepository;

        public DeletePlaneCommandHandler(IPlaneRepository planeRepository)
        {
            _planeRepository = planeRepository;
        }

        public async Task<bool> Handle(DeletePlaneCommand request, CancellationToken cancellationToken)
        {
            var plane = await _planeRepository.GetPlaneByIdAsync(request.Id);
            if (plane == null)
            {
                return false;
            }

            await _planeRepository.DeletePlaneAsync(request.Id);
            return true;
        }
    }
}
