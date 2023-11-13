using MediatR;

namespace TestAppForVacancy.CQRS.Models.Queries.ProviderQueries;

public class CheckForUniqueOrderNumberQuery : IRequest<bool>
{
    public CheckForUniqueOrderNumberQuery(int providerId, string numberOrder, int orderId)
    {
        ProviderId = providerId;
        NumberOrder = numberOrder;
        OrderId = orderId;
    }

    public int OrderId { get; set; }
    public int ProviderId { get; set; }
    public string NumberOrder { get; set; }
}