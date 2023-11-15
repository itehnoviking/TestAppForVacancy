using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TestAppForVacancy.Core.DTO;
using TestAppForVacancy.CQRS.Models.Queries.OrderQueries;
using TestAppForVacancy.Data;
using TestAppForVacancy.Data.Entities;

namespace TestAppForVacancy.CQRS.Handlers.QueryHandlers.OrderQueryHandlers;

public class GetOrderByFilterQueryHandler : IRequestHandler<GetOrderByFilterQuery, IList<OrderDto>>
{
    private readonly TestAppForVacancyContext _database;
    private readonly IMapper _mapper;

    public GetOrderByFilterQueryHandler(TestAppForVacancyContext database, IMapper mapper)
    {
        _database = database;
        _mapper = mapper;
    }

    public async Task<IList<OrderDto>> Handle(GetOrderByFilterQuery request, CancellationToken cancellationToken)
    {
        IQueryable<Order> orders = _database.Orders
            .AsNoTracking()
            .Include(o => o.Provider);

        if (request.FirstDate != null & request.SecondDate != null)
        {
            orders = orders
                .AsNoTracking()
                .Where(o => o.Date <= request.SecondDate & o.Date >= request.FirstDate);
        }

        if (!request.Numbers.IsNullOrEmpty())
        {

            var filteredOrders = orders
                .AsNoTracking()
                .Where(o => request.Numbers.Contains(o.Number));

            orders = filteredOrders;
        }

        if (!request.Providers.IsNullOrEmpty())
        {
            var filteredOrders = orders
                .AsNoTracking()
                .Where(o => request.Providers.Contains(o.Provider.Name));

            orders = filteredOrders;
        }


        var listOrders = await orders
            .AsNoTracking()
            .OrderByDescending(o => o.Date)
            .ToListAsync(cancellationToken: cancellationToken);

        return _mapper.Map<IList<OrderDto>>(listOrders);
    }
}