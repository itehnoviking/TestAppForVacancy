using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TestAppForVacancy.Core.DTO;
using TestAppForVacancy.CQRS.Models.Queries.OrderItemQuery;
using TestAppForVacancy.Data;

namespace TestAppForVacancy.CQRS.Handlers.QueryHandlers.OrderItemQueryHandlers;

public class GetAllOrderItemNameAndIdQueryHandler : IRequestHandler<GetAllOrderItemNameAndIdQuery, IList<OrderItemNameAndIdDto>>
{
    private readonly IMapper _mapper;
    private readonly TestAppForVacancyContext _database;

    public GetAllOrderItemNameAndIdQueryHandler(IMapper mapper, TestAppForVacancyContext database)
    {
        _mapper = mapper;
        _database = database;
    }

    public async Task<IList<OrderItemNameAndIdDto>> Handle(GetAllOrderItemNameAndIdQuery request, CancellationToken cancellationToken)
    {
        var orderItemsNameAndId = await _database.OrderItems
            .AsNoTracking()
            .Select(orderItem => _mapper.Map<OrderItemNameAndIdDto>(orderItem))
            .ToListAsync(cancellationToken: cancellationToken);

        return orderItemsNameAndId;

    }
}