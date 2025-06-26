using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Parking.Application.DTO;
using Parking.Core.Entities;
using Parking.Core.Interfaces.Repositories;

namespace Parking.Application.Services;

public class ParkingAreaService : IParkingArea
{
    private readonly IParkingAreaRepository _parkingAreaRepository;

    public ParkingAreaService(IParkingAreaRepository parkingAreaRepository)
    {
        _parkingAreaRepository = parkingAreaRepository;
    }

    public async Task CreateAsync(ParkingAreaDto parkingArea)
    {
        var parkingAreaDb = new ParkingArea(Guid.NewGuid().ToString(), parkingArea.Name, parkingArea.WeekdayHourlyRate,
            parkingArea.WeekendHourlyRate, parkingArea.DiscountPercentage);

        await _parkingAreaRepository.AddAsync(parkingAreaDb);
    }
    
    public async Task<List<ParkingAreaDto>> GetAllAsync()
    {
        var db = await _parkingAreaRepository.GetAllAsync();

        return db.Select(item => new ParkingAreaDto(item.Id, item.Name, item.WeekdayHourlyRate, item.WeekendHourlyRate,
            item.DiscountPercentage)).ToList();
    }

    public async Task UpdateAsync(ParkingAreaDto parkingArea)
    {
        var parkingAreaDb = new ParkingArea(parkingArea.Id, parkingArea.Name, parkingArea.WeekdayHourlyRate,
            parkingArea.WeekendHourlyRate, parkingArea.DiscountPercentage);
        await _parkingAreaRepository.UpdateAsync(parkingAreaDb);
    }

    public async Task DeleteAsync(string id)
    {
        await _parkingAreaRepository.DeleteAsync(id);
    }
}