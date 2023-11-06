using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TestAppForVacancy.Core.DTO;
using TestAppForVacancy.CQRS.Models.Queries.ProviderQueries;
using TestAppForVacancy.Data;

namespace TestAppForVacancy.CQRS.Handlers.QueryHandlers.ProviderQueryHandler;

public class GetAllProviderNameAndIdQueryHandler : IRequestHandler<GetAllProviderNameAndIdQuery, IList<ProviderNameAndIdDto>>
{
    private readonly TestAppForVacancyContext _database;
    private readonly IMapper _mapper;

    public GetAllProviderNameAndIdQueryHandler(TestAppForVacancyContext database, IMapper mapper)
    {
        _database = database;
        _mapper = mapper;
    }

    public async Task<IList<ProviderNameAndIdDto>> Handle(GetAllProviderNameAndIdQuery request, CancellationToken cancellationToken)
    {
        var providerNameAndId = await _database.Providers
            .AsNoTracking()
            .Select(provider => _mapper.Map<ProviderNameAndIdDto>(provider))
            .ToListAsync(cancellationToken: cancellationToken);

        return providerNameAndId;
    }
}