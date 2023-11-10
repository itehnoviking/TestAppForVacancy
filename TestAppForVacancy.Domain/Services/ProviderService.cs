using MediatR;
using TestAppForVacancy.Core.DTO;
using TestAppForVacancy.Core.Interfaces.Services;
using TestAppForVacancy.CQRS.Models.Queries.OrderItemQuery;
using TestAppForVacancy.CQRS.Models.Queries.ProviderQueries;

namespace TestAppForVacancy.Domain.Services;

public class ProviderService : IProviderService
{
    private readonly IMediator _mediator;

    public ProviderService(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IList<ProviderNameAndIdDto>> GetAllProviderNameAndId()
    {
        var providerItemNameAndIdDto = await _mediator.Send(new GetAllProviderNameAndIdQuery(), new CancellationToken());

        return providerItemNameAndIdDto;
    }

    public async Task<bool> CheckForUniqueOrderNumber(int providerId, string orderName)
    {
        var resultCheckForUniqueOrderName = await _mediator.Send(new CheckForUniqueOrderNumberQuery(providerId, orderName), new CancellationToken());
        return resultCheckForUniqueOrderName;
    }
}