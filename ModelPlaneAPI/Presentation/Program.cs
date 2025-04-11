using Microsoft.EntityFrameworkCore;
using ModelPlaneAPI.Data;
using CloudinaryDotNet;
using Microsoft.Extensions.Options;
using ModelPlaneAPI.Presentation.Settings;

var builder = WebApplication.CreateBuilder(args);

// ✅ Read PostgreSQL connection string
var connectionString = builder.Configuration["PostgreSQLConnection"];
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("PostgreSQLConnection environment variable is not set.");
}

// ✅ Register database
builder.Services.AddDbContext<PlaneContext>(options =>
    options.UseNpgsql(connectionString));

// ✅ Register Cloudinary settings from environment variables
builder.Services.Configure<CloudinarySettings>(builder.Configuration.GetSection("CloudinarySettings"));

builder.Services.AddSingleton(sp =>
{
    var settings = sp.GetRequiredService<IOptions<CloudinarySettings>>().Value;
    var account = new Account(settings.CloudName, settings.ApiKey, settings.ApiSecret);
    return new Cloudinary(account);
});

// ✅ Register other services
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());
builder.Services.AddScoped<IPlaneRepository, PlaneRepository>();
builder.Services.AddSingleton<JwtTokenCreator>();

// ✅ Enable CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins(
            "https://model-plane-app.vercel.app",
            "https://www.model-plane-app.vercel.app"
        )
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors("AllowFrontend");

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseStaticFiles();

app.Run();
