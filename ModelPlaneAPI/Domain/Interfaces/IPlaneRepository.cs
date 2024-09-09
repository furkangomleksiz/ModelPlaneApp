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
}