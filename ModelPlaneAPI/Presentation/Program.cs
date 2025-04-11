using Microsoft.EntityFrameworkCore;
using ModelPlaneAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var rawUrl = Environment.GetEnvironmentVariable("DATABASE_URL");

if (string.IsNullOrEmpty(rawUrl))
{
    throw new InvalidOperationException("DATABASE_URL environment variable is not set.");
}

var connectionString = rawUrl.StartsWith("postgres://")
    ? ConvertDatabaseUrlToNpgsql(rawUrl)
    : rawUrl;

builder.Services.AddDbContext<PlaneContext>(options =>
    options.UseNpgsql(connectionString));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());
builder.Services.AddScoped<IPlaneRepository, PlaneRepository>();
builder.Services.AddSingleton<JwtTokenCreator>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("https://model-plane-client.vercel.app") // Replace with your Vercel domain
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});


var app = builder.Build();

static string ConvertDatabaseUrlToNpgsql(string databaseUrl)
{
    var uri = new Uri(databaseUrl);
    var userInfo = uri.UserInfo.Split(':');

    return $"Host={uri.Host};Port={uri.Port};Database={uri.AbsolutePath.TrimStart('/')};Username={userInfo[0]};Password={userInfo[1]};Ssl Mode=Require;Trust Server Certificate=true";
}

// Configure the HTTP request pipeline.
app.UseCors("AllowFrontend");

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseStaticFiles(); // For serving static files

app.Run();
