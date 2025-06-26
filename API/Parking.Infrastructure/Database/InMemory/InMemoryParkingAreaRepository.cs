using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Parking.Core.Entities;
using Parking.Core.Interfaces;

namespace Parking.Infrastructure.Database.InMemory;

public class InMemoryParkingAreaRepository// : IParkingAreaRepository
{
    private readonly List<ParkingArea> _parkingAreas;
    
    public InMemoryParkingAreaRepository(ITime time)
    {
        _parkingAreas = new List<ParkingArea>();
    }

    public async Task<IEnumerable<ParkingArea>> GetAllAsync()
    {
        await Task.CompletedTask;
        return _parkingAreas;
    }

    public async Task<ParkingArea> GetAsync(string id)
    {
        await Task.CompletedTask;
        return _parkingAreas.SingleOrDefault(x => x.Id == id);
    }

    public Task AddAsync(ParkingArea parkingArea)
    {
        _parkingAreas.Add(parkingArea);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(ParkingArea parkingArea) => Task.CompletedTask;
    public Task DeleteAsync(Guid id)
    {
        return Task.CompletedTask;
    }
}