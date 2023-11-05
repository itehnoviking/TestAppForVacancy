using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Npgsql.TypeMapping;
using TestAppForVacancy.Core.DTO;
using TestAppForVacancy.CQRS.Models.Queries.OrderQueries;
using TestAppForVacancy.Data;

namespace TestAppForVacancy.CQRS.Handlers.QueryHandlers.OrderQueryHandlers;

public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, OrdersListDto>
{
    private readonly TestAppForVacancyContext _database;
    private readonly IMapper _mapper;

    public GetAllOrdersQueryHandler(TestAppForVacancyContext database, IMapper mapper)
    {
        _database = database;
        _mapper = mapper;
    }

    public async Task<OrdersListDto> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
    {
        var list = await _database.Orders
            .AsNoTracking()
            .OrderByDescending(order => order.Date)
            .ToListAsync(cancellationToken: cancellationToken);

        return _mapper.Map<OrdersListDto>(list);
        
    }
}