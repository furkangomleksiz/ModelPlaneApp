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
}
