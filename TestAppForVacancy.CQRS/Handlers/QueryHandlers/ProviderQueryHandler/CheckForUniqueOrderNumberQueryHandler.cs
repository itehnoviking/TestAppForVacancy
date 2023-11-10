using MediatR;
using Microsoft.EntityFrameworkCore;
using TestAppForVacancy.CQRS.Models.Queries.ProviderQueries;
using TestAppForVacancy.Data;

namespace TestAppForVacancy.CQRS.Handlers.QueryHandlers.ProviderQueryHandler;

public class CheckForUniqueOrderNumberQueryHandler : IRequestHandler<CheckForUniqueOrderNumberQuery, bool>
{
    private readonly TestAppForVacancyContext _database;

    public CheckForUniqueOrderNumberQueryHandler(TestAppForVacancyContext database)
    {
        _database = database;
    }

    public async Task<bool> Handle(CheckForUniqueOrderNumberQuery request, CancellationToken cancellationToken)
    {
        var provider = await _database.Providers.Where(p => p.Id.Equals(request.ProviderId))
            .Include(p => p.Orders)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);

        var result = provider.Orders.Select(o => o.Number).Contains(request.NumberOrder);

        return result;
    }
}