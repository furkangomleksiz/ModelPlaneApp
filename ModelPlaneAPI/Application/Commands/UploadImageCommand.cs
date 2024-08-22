// Application/Commands/UploadImageCommand.cs
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;

public class UploadImageCommand : IRequest<string>
{
    public Guid PlaneId { get; set; }
    public IFormFile File { get; set; }
}
