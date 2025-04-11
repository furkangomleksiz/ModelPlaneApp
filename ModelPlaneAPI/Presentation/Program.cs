using Microsoft.EntityFrameworkCore;
using ModelPlaneAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// ✅ Use connection string directly from Render's environment variable
var connectionString = builder.Configuration["PostgreSQLConnection"];

if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("PostgreSQLConnection environment variable is not set.");
}

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PlaneContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());
builder.Services.AddScoped<IPlaneRepository, PlaneRepository>();
builder.Services.AddSingleton<JwtTokenCreator>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("https://model-plane-client.vercel.app") // ✅ Update this to your actual Vercel frontend URL
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// ✅ Configure the HTTP request pipeline
app.UseCors("AllowFrontend");

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();
app.UseStaticFiles();

app.Run();
