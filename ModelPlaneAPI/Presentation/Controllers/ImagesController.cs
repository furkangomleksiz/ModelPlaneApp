using Microsoft.AspNetCore.Mvc;
using System.IO;

[ApiController]
[Route("api/[controller]")]
public class ImagesController : ControllerBase
{
    [HttpGet("{fileName}")]
    public IActionResult GetImage(string fileName)
    {
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "planes", fileName);

        if (!System.IO.File.Exists(filePath))
        {
            return NotFound();
        }

        var image = System.IO.File.ReadAllBytes(filePath);
        var contentType = "image/jpeg";  // Change if necessary

        return File(image, contentType);
    }

}
