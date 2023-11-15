using TestAppForVacancy.Core.DTO;

namespace TestAppForVacancy.Core.Interfaces.Services;

public interface IOrderItemService
{
    Task<IList<OrderItemNameAndIdDto>> GetAllOrderItemNameAndId();
    Task<IList<OrderItemDto>> GetOrderItemByFilter(OrderItemFilterDto dto);
}