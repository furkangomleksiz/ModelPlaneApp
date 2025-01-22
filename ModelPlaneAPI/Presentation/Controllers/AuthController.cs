// Controllers/AuthController.cs
using Microsoft.AspNetCore.Mvc;
using BCrypt.Net;
using System.Threading.Tasks;
using ModelPlaneAPI.Data;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly PlaneContext _context;
    private readonly JwtTokenCreator _jwtTokenCreator;

    public AuthController(PlaneContext context, JwtTokenCreator jwtTokenCreator)
    {
        _context = context;
        _jwtTokenCreator = jwtTokenCreator;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == request.Username);
        if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
        {
            return Unauthorized("Invalid username or password.");
        }

        // Generate a JWT token upon successful login
        var token = _jwtTokenCreator.CreateToken(user);
        return Ok(new { Token = token });
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        if (_context.Users.Any(u => u.Username == request.Username))
            return BadRequest("Username already exists.");

        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);

        var user = new User
        {
            Id = Guid.NewGuid(),
            Username = request.Username,
            PasswordHash = hashedPassword
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return Ok("User registered successfully.");
    }
}

public class RegisterRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
}
public class LoginRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
}
