using AutoMapper;
using TestAppForVacancy.Core.DTO;
using TestAppForVacancy.CQRS.Models.Commands.OrderCommands;
using TestAppForVacancy.Data.Entities;

namespace TestAppForVacancy.MVC.Mappers;

public class OrderProfile : Profile
{
    public OrderProfile()
    {
        CreateMap<Order, OrderDto>().ReverseMap();

        CreateMap<IList<Order>, OrdersListDto>().ReverseMap();

        CreateMap<CreateOrderCommand, Order>().ReverseMap();
    }
    
}