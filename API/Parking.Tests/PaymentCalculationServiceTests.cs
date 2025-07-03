using AutoFixture;
using AutoFixture.Kernel;
using NSubstitute;
using Parking.Application.DTO;
using Parking.Application.Services;
using Parking.Core.Entities;
using Parking.Core.Interfaces;
using Parking.Core.Interfaces.Repositories;

namespace Parking.Tests;

[TestClass]
public sealed class PaymentCalculationServiceTests
{
    private IParkingArea _parkingAreaService;
    private IPaymentCalculation _paymentCalculationService;
    private ITime _timeService;
    
    [TestInitialize]
    public void Initialize()
    {
        var fixture = new Fixture();
        
        _parkingAreaService = Substitute.For<IParkingArea>();
        _parkingAreaService.GetAllAsync().Returns(new List<ParkingAreaDto>()
        {
            new("acb30515-9b04-4bfd-85b3-94792d800867", "A1", 2, 4, 0)
        });
        fixture.Inject(_parkingAreaService);
        
        _timeService = Substitute.For<ITime>();
        fixture.Inject(_timeService);
        
        _paymentCalculationService = fixture.Create<PaymentCalculationService>();
    }
    
    [TestMethod]
    public async Task CalculatePrice_Weekday()
    {
        _timeService.GetCurrentTime().Returns(new DateTime(2020, 1, 1, 00, 0, 0, DateTimeKind.Utc));

        var request = new GetPaymentCalculationRequest()
        {
            SpotId = "acb30515-9b04-4bfd-85b3-94792d800867",
            Day = _timeService.GetCurrentTime(),
            From = _timeService.GetCurrentTime().AddHours(10),
            To = _timeService.GetCurrentTime().AddHours(13),
        };
        
        var result = await _paymentCalculationService.CalculatePrice(request);
        
        Assert.AreEqual(360, result);
    }

    [TestMethod]
    public async Task CalculatePrice_Weekend()
    {
        _timeService.GetCurrentTime().Returns(new DateTime(2020, 1, 4, 00, 0, 0, DateTimeKind.Utc));
        
        var request = new GetPaymentCalculationRequest()
        {
            SpotId = "acb30515-9b04-4bfd-85b3-94792d800867",
            Day = _timeService.GetCurrentTime(),
            From = _timeService.GetCurrentTime().AddHours(10),
            To = _timeService.GetCurrentTime().AddHours(13),
        };
        
        var result = await _paymentCalculationService.CalculatePrice(request);
        
        Assert.AreEqual(720, result);
    }

    [TestMethod]
    [ExpectedException(typeof(ApplicationException),
        "Spot not found")]
    public async Task CalculatePrice_TheSpotDoesNotExist()
    {
        _timeService.GetCurrentTime().Returns(new DateTime(2020, 1, 4, 00, 0, 0, DateTimeKind.Utc));
        
        var request = new GetPaymentCalculationRequest()
        {
            SpotId = "wrong-id",
            Day = _timeService.GetCurrentTime(),
            From = _timeService.GetCurrentTime().AddHours(10),
            To = _timeService.GetCurrentTime().AddHours(13),
        };
        
        var result = await _paymentCalculationService.CalculatePrice(request);
    }
}