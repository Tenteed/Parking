using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Parking.Application.DTO;

namespace Parking.Application.Services;

public interface IParkingArea
{
    Task CreateAsync(ParkingAreaDto parkingArea);
    Task DeleteAsync(string id);
    Task<List<ParkingAreaDto>> GetAllAsync();
    Task UpdateAsync(ParkingAreaDto parkingArea);
}