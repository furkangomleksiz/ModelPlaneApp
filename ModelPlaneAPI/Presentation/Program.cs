using Microsoft.EntityFrameworkCore;
using ModelPlaneAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("PostgreSQLConnection") 
                       ?? Environment.GetEnvironmentVariable("DATABASE_URL");

builder.Services.AddDbContext<PlaneContext>(options =>
    options.UseNpgsql(connectionString));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());
builder.Services.AddScoped<IPlaneRepository, PlaneRepository>();
builder.Services.AddSingleton<JwtTokenCreator>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("https://your-vercel-domain.vercel.app") // Replace with your Vercel domain
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors("AllowFrontend");

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseStaticFiles(); // For serving static files

app.Run();
