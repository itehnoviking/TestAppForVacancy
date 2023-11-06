using AutoMapper;
using TestAppForVacancy.Core.DTO;
using TestAppForVacancy.CQRS.Models.Commands.OrderCommands;
using TestAppForVacancy.Data.Entities;
using TestAppForVacancy.MVC.Models;

namespace TestAppForVacancy.MVC.Mappers;

public class OrderProfile : Profile
{
    public OrderProfile()
    {
        CreateMap<Order, OrderDto>().ReverseMap();

        CreateMap<IList<Order>, OrdersListDto>().ReverseMap();

        CreateMap<CreateOrderCommand, Order>().ReverseMap();

        CreateMap<OrderCreateViewModel, OrderDto>().ReverseMap();
        CreateMap<OrderListViewModel, OrderDto>().ReverseMap();
    }
    
}