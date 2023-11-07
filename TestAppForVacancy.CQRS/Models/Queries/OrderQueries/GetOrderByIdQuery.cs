using MediatR;
using TestAppForVacancy.Core.DTO;

namespace TestAppForVacancy.CQRS.Models.Queries.OrderQueries;

public class GetOrderWithOrderItemByIdQuery : IRequest<OrderDto>
{
    public GetOrderWithOrderItemByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}