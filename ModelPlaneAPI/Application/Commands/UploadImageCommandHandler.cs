using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

public class UploadImageCommandHandler : IRequestHandler<UploadImageCommand, string>
{
    private readonly IPlaneRepository _planeRepository;
    private readonly Cloudinary _cloudinary;

    public UploadImageCommandHandler(IPlaneRepository planeRepository, Cloudinary cloudinary)
    {
        _planeRepository = planeRepository;
        _cloudinary = cloudinary;
    }

    public async Task<string> Handle(UploadImageCommand request, CancellationToken cancellationToken)
    {
        if (request.File == null || request.File.Length == 0)
        {
            throw new ArgumentException("No file uploaded.");
        }

        var plane = await _planeRepository.GetPlaneByIdAsync(request.PlaneId);
        if (plane == null)
        {
            throw new ArgumentException("Plane not found.");
        }

        using var stream = request.File.OpenReadStream();
        var uploadParams = new ImageUploadParams
        {
            File = new FileDescription(request.File.FileName, stream),
            Folder = "model_planes", // Optional: keeps things organized in your Cloudinary account
            UseFilename = true,
            UniqueFilename = false,
            Overwrite = true
        };

        var uploadResult = await _cloudinary.UploadAsync(uploadParams, cancellationToken);

        if (uploadResult.StatusCode != System.Net.HttpStatusCode.OK)
        {
            throw new Exception("Image upload failed.");
        }

        var imageUrl = uploadResult.SecureUrl.ToString();

        plane.Images.Add(imageUrl);
        await _planeRepository.UpdatePlaneAsync(plane);

        return imageUrl;
    }
}
