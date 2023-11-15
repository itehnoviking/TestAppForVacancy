using TestAppForVacancy.Core.DTO;

namespace TestAppForVacancy.Core.Interfaces.Services;

public interface IOrderService
{
    Task CreateOrderAsync(OrderDto dto);
    Task<OrderListDto> GetAllOrdersAsync();
    Task<OrderDto> GetOrderWithOrderItemById(int id);
    Task DeleteOrderByIdAsync(int id);
    Task OrderUpdateAsync(OrderDto order);
    Task<IList<OrderDto>> GetOrderByFilter(OrderFilterDto dto);
}