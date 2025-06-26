using Microsoft.AspNetCore.Mvc;
using Parking.Application.DTO;
using Parking.Application.Services;

namespace Parking.Controllers;

[ApiController]
[Route("parking-areas")]
public class ParkingAreaController : ControllerBase
{
    private readonly IParkingArea _parkingAreaService;

    public ParkingAreaController(IParkingArea parkingAreaService)
    {
        _parkingAreaService = parkingAreaService;
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] ParkingAreaDto parkingArea)
    {
        await _parkingAreaService.CreateAsync(parkingArea);
        return Ok();
    }

    [HttpGet]
    public async Task<ActionResult<List<ParkingAreaDto>>> GetAll()
    {
        var records = await _parkingAreaService.GetAllAsync();
        return Ok(records);
    }

    [HttpPut]
    public async Task<ActionResult> Put([FromBody] ParkingAreaDto parkingArea)
    {
        await _parkingAreaService.UpdateAsync(parkingArea);
        return Ok();
    }
    
    [HttpDelete]
    public async Task<ActionResult> Delete([FromBody] string id)
    {
        await _parkingAreaService.DeleteAsync(id);
        return Ok();
    }
}