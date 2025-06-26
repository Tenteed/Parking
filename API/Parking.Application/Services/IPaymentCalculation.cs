using System.Threading.Tasks;
using Parking.Application.DTO;

namespace Parking.Application.Services;

public interface IPaymentCalculation
{
    Task<decimal> CalculatePrice(GetPaymentCalculationRequest request);
}