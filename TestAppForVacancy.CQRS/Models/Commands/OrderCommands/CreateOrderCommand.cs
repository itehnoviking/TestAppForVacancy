using MediatR;
using TestAppForVacancy.Core.DTO;

namespace TestAppForVacancy.CQRS.Models.Commands.OrderCommands;

public class CreateOrderCommand : IRequest<bool>
{
    public CreateOrderCommand(OrderDto dto)
    {
        Number = dto.Number;
        Date = dto.Date;
        ProviderId = dto.ProviderId;
        OrderItems = dto.OrderItems;
    }

    public string Number { get; set; }
    public DateTime Date { get; set; }
    public int ProviderId { get; set; }
    public virtual IEnumerable<OrderItemDto> OrderItems { get; set; }

}