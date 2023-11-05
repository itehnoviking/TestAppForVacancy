using System.Collections;
using MediatR;
using TestAppForVacancy.Core.DTO;

namespace TestAppForVacancy.CQRS.Models.Queries.OrderQueries;

public class GetAllOrdersQuery : IRequest<OrdersListDto>
{
    
}