using AutoMapper;
using TestAppForVacancy.Core.DTO;
using TestAppForVacancy.Data.Entities;

namespace TestAppForVacancy.MVC.Mappers;

public class OrderItemProfile : Profile
{
    public OrderItemProfile()
    {
        CreateMap<OrderItem, OrderItemDto>().ReverseMap();
    }
}