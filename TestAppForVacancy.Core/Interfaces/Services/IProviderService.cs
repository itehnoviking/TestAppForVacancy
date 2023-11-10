using System.Xml;
using TestAppForVacancy.Core.DTO;

namespace TestAppForVacancy.Core.Interfaces.Services;

public interface IProviderService
{
    Task<IList<ProviderNameAndIdDto>> GetAllProviderNameAndId();
    Task<bool> CheckForUniqueOrderNumber(int providerId, string orderName);
}