using AutoMapper;
using TestAppForVacancy.Core.DTO;
using TestAppForVacancy.Data.Entities;

namespace TestAppForVacancy.MVC.Mappers;

public class ProviderProfile : Profile
{
    public ProviderProfile()
    {
        CreateMap<Provider, ProviderNameAndIdDto>().ReverseMap();
    }
}