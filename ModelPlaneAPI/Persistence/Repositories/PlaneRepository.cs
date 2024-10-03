using Microsoft.EntityFrameworkCore;
using ModelPlaneAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class PlaneRepository : IPlaneRepository
{
    private readonly PlaneContext _context;

    public PlaneRepository(PlaneContext context)
    {
        _context = context;
    }

    public async Task<Plane> GetPlaneByIdAsync(Guid id)
    {
        // Retrieve the plane by Id
        var plane = await _context.Planes
            .Where(p => p.Id == id)
            .FirstOrDefaultAsync();

        // You can add any additional filtering or processing here if needed

        return plane;
    }

    public async Task<List<Plane>> GetAllPlanesAsync()
    {
        return await _context.Planes
            .ToListAsync();
    }

    public async Task<Plane> AddPlaneAsync(Plane plane)
    {
        await _context.Planes.AddAsync(plane);
        await _context.SaveChangesAsync();
        return plane; // Return the created plane
    }

    public async Task UpdatePlaneAsync(Plane plane)
    {
        _context.Planes.Update(plane);
        await _context.SaveChangesAsync();
    }

    public async Task DeletePlaneAsync(Guid id)
    {
        var plane = await GetPlaneByIdAsync(id);
        if (plane != null)
        {
            _context.Planes.Remove(plane);
            await _context.SaveChangesAsync();
        }
    }

    public IQueryable<Plane> GetPlanes()
    {
        return _context.Planes.AsQueryable();
    }

    public async Task<List<Plane>> SearchPlanes(
    string manufacturer = null,  // Changed to string
    string scale = null,  // Changed to string
    string airline = null,  // Changed to string
    string model = null,  // Replacing aircraft with model
    string country = null,
    string continent = null,  // Continent as a string
    string partNumber = null,
    string registration = null,
    string productionYears = null,
    bool? rollingGears = null,
    string notes = null,
    string engines = null,
    int? unitsMade = null,
    bool? includesStand = null,
    string modelId = null,
    string sortBy = null)
{
    var query = _context.Planes.AsQueryable();

    if (!string.IsNullOrEmpty(manufacturer))
    {
        query = query.Where(p => p.Manufacturer == manufacturer);
    }

    if (!string.IsNullOrEmpty(scale))
    {
        query = query.Where(p => p.Scale == scale);
    }

    if (!string.IsNullOrEmpty(airline))
    {
        query = query.Where(p => p.Airline == airline);
    }

    if (!string.IsNullOrEmpty(model))
    {
        query = query.Where(p => p.Model == model);  // Replacing aircraft with model
    }

    if (!string.IsNullOrEmpty(country))
    {
        query = query.Where(p => p.Country == country);
    }

    if (!string.IsNullOrEmpty(continent))
    {
        query = query.Where(p => p.Continent == continent);  // Continent as string filter
    }

    if (!string.IsNullOrEmpty(partNumber))
    {
        query = query.Where(p => p.PartNumber.Contains(partNumber));
    }

    if (!string.IsNullOrEmpty(registration))
    {
        query = query.Where(p => p.Registration.Contains(registration));
    }

    if (!string.IsNullOrEmpty(productionYears))
    {
        query = query.Where(p => p.ProductionYears.Contains(productionYears));
    }

    if (rollingGears.HasValue)
    {
        query = query.Where(p => p.RollingGears == rollingGears.Value);
    }

    if (!string.IsNullOrEmpty(notes))
    {
        query = query.Where(p => p.Notes.Contains(notes));
    }

    if (!string.IsNullOrEmpty(engines))
    {
        query = query.Where(p => p.Engines.Contains(engines));
    }

    if (unitsMade.HasValue)
    {
        query = query.Where(p => p.UnitsMade == unitsMade.Value);
    }

    if (includesStand.HasValue)
    {
        query = query.Where(p => p.IncludesStand == includesStand.Value);
    }

    if (!string.IsNullOrEmpty(modelId))
    {
        query = query.Where(p => p.Wings900Id.ToString().Contains(modelId));
    }

    // Sorting logic remains the same
    if (!string.IsNullOrEmpty(sortBy))
    {
        query = sortBy.ToLower() switch
        {
            "airline" => query.OrderBy(p => p.Airline),
            "manufacturer" => query.OrderBy(p => p.Manufacturer),
            "modelid" => query.OrderBy(p => p.Wings900Id),
            "country" => query.OrderBy(p => p.Country),
            "scale" => query.OrderBy(p => p.Scale),
            _ => query.OrderBy(p => p.Airline) // Default sorting
        };
    }

    return await query.ToListAsync();
}


}
