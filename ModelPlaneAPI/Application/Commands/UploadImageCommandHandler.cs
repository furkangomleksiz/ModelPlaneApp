// File: Application/Commands/UploadImageCommandHandler.cs
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

public class UploadImageCommandHandler : IRequestHandler<UploadImageCommand, string>
{
    private readonly IPlaneRepository _planeRepository;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public UploadImageCommandHandler(IPlaneRepository planeRepository, IWebHostEnvironment webHostEnvironment)
    {
        _planeRepository = planeRepository;
        _webHostEnvironment = webHostEnvironment;
    }

    public async Task<string> Handle(UploadImageCommand request, CancellationToken cancellationToken)
    {
        // Validate the file
        if (request.File == null || request.File.Length == 0)
        {
            throw new ArgumentException("No file uploaded.");
        }

        // Get the plane from the repository
        var plane = await _planeRepository.GetPlaneByIdAsync(request.PlaneId);
        if (plane == null)
        {
            throw new ArgumentException("Plane not found.");
        }

        // Ensure the 'images/planes' directory exists
        var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images", "planes");
        Directory.CreateDirectory(uploadsFolder);

        // Generate a unique file name
        var fileName = $"{request.PlaneId}_{Path.GetFileName(request.File.FileName)}";
        var filePath = Path.Combine(uploadsFolder, fileName);

        // Save the file
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await request.File.CopyToAsync(stream);
        }

        // Update the plane with the image URL
        var imageUrl = $"/images/planes/{fileName}";
        plane.ImageUrl = imageUrl;
        await _planeRepository.UpdatePlaneAsync(plane);

        return imageUrl;
    }
}
