using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TestAppForVacancy.Core.DTO;
using TestAppForVacancy.CQRS.Models.Queries.OrderItemQuery;
using TestAppForVacancy.Data;
using TestAppForVacancy.Data.Entities;

namespace TestAppForVacancy.CQRS.Handlers.QueryHandlers.OrderItemQueryHandlers;

public class GetOrderItemByFilterQueryHandler : IRequestHandler<GetOrderItemByFilterQuery, IList<OrderItemDto>>
{
    private readonly TestAppForVacancyContext _database;
    private readonly IMapper _mapper;

    public GetOrderItemByFilterQueryHandler(TestAppForVacancyContext database, IMapper mapper)
    {
        _database = database;
        _mapper = mapper;
    }

    public async Task<IList<OrderItemDto>> Handle(GetOrderItemByFilterQuery request, CancellationToken cancellationToken)
    {
        IQueryable<OrderItem> orderItems = _database.OrderItems
            .AsNoTracking();

        if (!request.Names.IsNullOrEmpty())
        {
            foreach (var name in request.Names)
            {
                orderItems = orderItems
                    .AsNoTracking()
                    .Where(o => o.Name.Equals(name));
            }
        }

        if (!request.Units.IsNullOrEmpty())
        {
            foreach (var unit in request.Units)
            {
                orderItems = orderItems
                    .AsNoTracking()
                    .Where(o => o.Unit.Equals(unit));
            }
        }

        var listOrders = await orderItems
            .AsNoTracking()
            .ToListAsync(cancellationToken: cancellationToken);

        return _mapper.Map<IList<OrderItemDto>>(listOrders);
    }
}