using MediatR;
using TestAppForVacancy.Core.DTO;
using TestAppForVacancy.Core.Interfaces.Services;
using TestAppForVacancy.CQRS.Models.Queries.OrderItemQuery;
using TestAppForVacancy.CQRS.Models.Queries.OrderQueries;

namespace TestAppForVacancy.Domain.Services;

public class OrderItemService : IOrderItemService
{
    private readonly IMediator _mediator;

    public OrderItemService(IMediator mediator)
    {
        _mediator = mediator;
    }

    public Task<IList<OrderItemNameAndIdDto>> GetAllOrderItemNameAndId()
    {
        var listOrderItemNameAndIdDto = _mediator.Send(new GetAllOrderItemNameAndIdQuery(), new CancellationToken());

        return listOrderItemNameAndIdDto;
    }

    public async Task<IList<OrderItemDto>> GetOrderItemByFilter(OrderItemFilterDto dto)
    {
        var listOrderItems = await _mediator.Send(new GetOrderItemByFilterQuery(dto), new CancellationToken());

        return listOrderItems;
    }
}