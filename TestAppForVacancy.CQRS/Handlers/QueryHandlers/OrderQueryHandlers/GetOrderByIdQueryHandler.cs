using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TestAppForVacancy.Core.DTO;
using TestAppForVacancy.CQRS.Models.Queries.OrderQueries;
using TestAppForVacancy.Data;

namespace TestAppForVacancy.CQRS.Handlers.QueryHandlers.OrderQueryHandlers;

public class GetOrderWithOrderItemByIdQueryHandler : IRequestHandler<GetOrderWithOrderItemByIdQuery, OrderDto>
{
    private readonly TestAppForVacancyContext _database;
    private readonly IMapper _mapper;


    public GetOrderWithOrderItemByIdQueryHandler(TestAppForVacancyContext database, IMapper mapper)
    {
        _database = database;
        _mapper = mapper;
    }

    public async Task<OrderDto> Handle(GetOrderWithOrderItemByIdQuery request, CancellationToken cancellationToken)
    {
        var order = await _database.Orders
            .AsNoTracking()
            .Where(o => o.Id.Equals(request.Id))
            .Include(o => o.OrderItems)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);

        var orderDto = _mapper.Map<OrderDto>(order);

        return orderDto;
    }
}