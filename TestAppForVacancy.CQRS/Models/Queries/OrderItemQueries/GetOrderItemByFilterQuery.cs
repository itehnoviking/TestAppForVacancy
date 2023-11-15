using MediatR;
using TestAppForVacancy.Core.DTO;

namespace TestAppForVacancy.CQRS.Models.Queries.OrderItemQuery;

public class GetOrderItemByFilterQuery : IRequest<IList<OrderItemDto>>
{
    public GetOrderItemByFilterQuery(OrderItemFilterDto dto)
    {
        Names = dto.Names;
        Units = dto.Units;
    }

    public IList<string> Names { get; set; }
    public IList<string> Units { get; set; }
}