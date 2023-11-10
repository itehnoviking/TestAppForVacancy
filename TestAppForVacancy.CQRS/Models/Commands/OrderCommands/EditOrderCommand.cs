using MediatR;
using TestAppForVacancy.Core.DTO;

namespace TestAppForVacancy.CQRS.Models.Commands.OrderCommands;

public class EditOrderCommand : IRequest<bool>
{
    public EditOrderCommand(OrderDto orderDto)
    {
        Id = orderDto.Id;
        Number = orderDto.Number;
        Date = orderDto.Date;
        ProviderId = orderDto.ProviderId;
        OrderItems = orderDto.OrderItems;
    }

    public int Id { get; set; }
    public string Number { get; set; }
    public DateTime Date { get; set; }
    public int ProviderId { get; set; }
    public virtual IEnumerable<OrderItemDto> OrderItems { get; set; }
}