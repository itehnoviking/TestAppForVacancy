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
        CreateMap<OrderDto, OrderViewModel>().ReverseMap();
        CreateMap<OrderFilterDto, OrderListViewModel>().ReverseMap();
        CreateMap<OrderFilterDto, Order>().ReverseMap();

        CreateMap<OrderListViewModel, OrderListDto>().ReverseMap();

        CreateMap<CreateOrderCommand, Order>().ReverseMap();

        CreateMap<OrderCreateViewModel, OrderDto>().ReverseMap();
        CreateMap<OrderListViewModel, OrderDto>().ReverseMap();
        CreateMap<OrderWithOrderItemsDetailViewModel, OrderDto>().ReverseMap();

        CreateMap<OrderDto, OrderDeleteViewModel>().ReverseMap();
        CreateMap<OrderDto, OrderEditViewModel>().ReverseMap();
        CreateMap<Order, EditOrderCommand>().ReverseMap();

        CreateMap<IList<Order>, OrderListDto>()
            .ForMember(dest => dest.Orders, opt => opt.MapFrom(src => src));
    
    }
    
}