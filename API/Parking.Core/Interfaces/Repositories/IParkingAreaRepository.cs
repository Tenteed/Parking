using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Parking.Core.Entities;

namespace Parking.Core.Interfaces.Repositories;

public interface IParkingAreaRepository
{
    Task<IEnumerable<ParkingArea>> GetAllAsync();
    Task AddAsync(ParkingArea parkingArea);
    Task UpdateAsync(ParkingArea parkingArea);
    Task DeleteAsync(string id);
}