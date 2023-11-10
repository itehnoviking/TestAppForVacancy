using MediatR;
using TestAppForVacancy.Core.DTO;
using TestAppForVacancy.Core.Interfaces.Services;
using TestAppForVacancy.CQRS.Models.Commands.OrderCommands;
using TestAppForVacancy.CQRS.Models.Queries.OrderQueries;

namespace TestAppForVacancy.Domain.Services;

public class OrderService : IOrderService
{
    private readonly IMediator _mediator;

    public OrderService(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task CreateOrderAsync(OrderDto dto)
    {
        await _mediator.Send(new CreateOrderCommand(dto), new CancellationToken());
    }

    public async Task<IList<OrderDto>> GetAllOrdersAsync()
    {
        var listOrdersDto = await _mediator.Send(new GetAllOrdersQuery(), new CancellationToken());
        return listOrdersDto;
    }

    public async Task<OrderDto> GetOrderWithOrderItemById(int id)
    {
        var orderDto = await _mediator.Send(new GetOrderWithOrderItemByIdQuery(id), new CancellationToken());

        return orderDto;
    }

    public async Task DeleteOrderByIdAsync(int id)
    {
        await _mediator.Send(new DeleteOrderByIdCommand(id), new CancellationToken());
    }

    public async Task OrderUpdateAsync(OrderDto orderDto)
    {
        await _mediator.Send(new EditOrderCommand(orderDto), new CancellationToken());
    }
}