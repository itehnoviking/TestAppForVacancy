using MediatR;
using TestAppForVacancy.Core.DTO;

namespace TestAppForVacancy.CQRS.Models.Queries.ProviderQueries;

public class GetAllProviderNameAndIdQuery : IRequest<IList<ProviderNameAndIdDto>>
{
    
}