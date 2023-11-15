using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestAppForVacancy.Core.DTO;
using TestAppForVacancy.Core.Interfaces.Services;
using TestAppForVacancy.MVC.Models;

namespace TestAppForVacancy.MVC.Controllers
{
    public class OrderItemController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IOrderItemService _orderItemService;

        public OrderItemController(IMapper mapper, IOrderItemService orderItemService)
        {
            _mapper = mapper;
            _orderItemService = orderItemService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> OrderItemFilter(OrderItemFilterViewModel viewModel)
        {
            var dto = _mapper.Map<OrderItemFilterDto>(viewModel);

            var orderItemList = await _orderItemService.GetOrderItemByFilter(dto);

            return View(orderItemList);
        }
    }
}
