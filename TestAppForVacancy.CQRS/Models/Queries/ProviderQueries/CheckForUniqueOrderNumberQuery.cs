using MediatR;

namespace TestAppForVacancy.CQRS.Models.Queries.ProviderQueries;

public class CheckForUniqueOrderNumberQuery : IRequest<bool>
{
    public CheckForUniqueOrderNumberQuery(int providerId, string numberOrder)
    {
        ProviderId = providerId;
        NumberOrder = numberOrder;
    }

    public int ProviderId { get; set; }
    public string NumberOrder { get; set; }
}