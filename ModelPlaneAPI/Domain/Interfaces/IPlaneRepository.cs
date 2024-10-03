using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IPlaneRepository
{
    Task<List<Plane>> GetAllPlanesAsync();
    Task<Plane> GetPlaneByIdAsync(Guid id);
    Task<Plane> AddPlaneAsync(Plane plane);
    Task UpdatePlaneAsync(Plane plane);
    Task DeletePlaneAsync(Guid id);
    IQueryable<Plane> GetPlanes();

    Task<List<Plane>> SearchPlanes(
        string manufacturer = null,  // Changed to string
        string scale = null,  // Changed to string
        string airline = null,  // Changed to string
        string model = null,  // Replacing aircraft with model
        string country = null,
        string continent = null,
        string partNumber = null,
        string registration = null,
        string productionYears = null,
        bool? rollingGears = null,
        string notes = null,
        string engines = null,
        int? unitsMade = null,
        bool? includesStand = null,
        string modelId = null,
        string sortBy = null);
}
