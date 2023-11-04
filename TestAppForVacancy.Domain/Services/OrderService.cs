using TestAppForVacancy.Core.DTO;
using TestAppForVacancy.Core.Interfaces.Services;

namespace TestAppForVacancy.Domain.Services;

public class OrderService : IOrderService
{
    public Task CreateOrderAsync(OrderDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<IList<OrderDto>> GetAllOrdersAsync()
    {
        throw new NotImplementedException();
    }
}