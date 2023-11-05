using MediatR;
using TestAppForVacancy.Core.DTO;

namespace TestAppForVacancy.CQRS.Models.Queries.OrderItemQuery;

public class GetAllOrderItemNameAndIdQuery : IRequest<IList<OrderItemNameAndIdDto>>
{
    
}