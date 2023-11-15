using MediatR;
using TestAppForVacancy.Core.DTO;

namespace TestAppForVacancy.CQRS.Models.Queries.OrderQueries;

public class GetOrderByFilterQuery : IRequest<IList<OrderDto>>
{
    public GetOrderByFilterQuery(OrderFilterDto dto)
    {
        FirstDate = dto.FirstDate;
        SecondDate = dto.SecondDate;
        Numbers = dto.Numbers;
        Providers = dto.Providers;
    }

    public DateTime FirstDate { get; set; }
    public DateTime SecondDate { get; set; }
    public IList<string> Numbers { get; set; }
    public IList<string> Providers { get; set; }
}