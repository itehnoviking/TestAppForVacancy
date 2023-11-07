using AutoMapper;
using TestAppForVacancy.Core.DTO;
using TestAppForVacancy.Data.Entities;
using TestAppForVacancy.MVC.Models;

namespace TestAppForVacancy.MVC.Mappers;

public class OrderItemProfile : Profile
{
    public OrderItemProfile()
    {
        CreateMap<OrderItem, OrderItemDto>().ReverseMap();
        CreateMap<OrderItem, OrderItemNameAndIdDto>().ReverseMap();

        CreateMap<OrderItemDto, OrderItemDeleteViewModel>().ReverseMap();
        CreateMap<OrderItemDto, OrderItemViewModel>().ReverseMap();
    }
}