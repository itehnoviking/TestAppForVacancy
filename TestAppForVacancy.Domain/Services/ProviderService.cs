using TestAppForVacancy.Core.DTO;
using TestAppForVacancy.Core.Interfaces.Services;

namespace TestAppForVacancy.Domain.Services;

public class ProviderService : IProviderService
{
    public Task<IList<ProviderNameAndIdDto>> GetAllProviderNameAndId()
    {
        throw new NotImplementedException();
    }
}