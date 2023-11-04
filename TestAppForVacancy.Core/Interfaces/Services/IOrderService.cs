using TestAppForVacancy.Core.DTO;

namespace TestAppForVacancy.Core.Interfaces.Services;

public interface IOrderService
{
    Task CreateOrderAsync(OrderDto dto);
    Task<IList<OrderDto>> GetAllOrdersAsync();

}