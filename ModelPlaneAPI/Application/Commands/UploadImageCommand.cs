using MediatR;
using Microsoft.AspNetCore.Http;

public class UploadImageCommand : IRequest<string>
{
    public Guid PlaneId { get; set; }  // The UUID of the plane
    public IFormFile File { get; set; }  // The uploaded file
}
