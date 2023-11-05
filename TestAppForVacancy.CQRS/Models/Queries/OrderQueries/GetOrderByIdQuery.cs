using MediatR;
using TestAppForVacancy.Core.DTO;

namespace TestAppForVacancy.CQRS.Models.Queries.OrderQueries;

public class GetOrderByIdQuery : IRequest<OrderDto>
{
    public GetOrderByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}