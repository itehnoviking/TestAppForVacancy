using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AutoMapper;
using TestAppForVacancy.Core.Interfaces.Services;
using TestAppForVacancy.MVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TestAppForVacancy.MVC.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IOrderItemService _orderItemService;
        private readonly IProviderService _providerService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService, IMapper mapper, IProviderService providerService, IOrderItemService orderItemService)
        {
            _orderService = orderService;
            _mapper = mapper;
            _providerService = providerService;
            _orderItemService = orderItemService;
        }

        public async Task<IActionResult> Index()
        {
            var orders = (await _orderService.GetAllOrdersAsync())
                .Select(order => _mapper.Map<OrderListViewModel>(order))
                .OrderByDescending(order => order.Date)
                .ToList();

            return View(orders);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            try
            {
                var providers = await _providerService.GetAllProviderNameAndId();
                var orderItems = await _orderItemService.GetAllOrderItemNameAndId();

                var viewModel = new OrderCreateViewModel()
                {
                    ProviderNameAndIdModels = providers.Select(provider => new SelectListItem(provider.Name, provider.Id.ToString())),
                    OrderItemsNameAndIdModels = orderItems.Select(orderItem => new SelectListItem(orderItem.Name, orderItem.Id.ToString()))
                };

                if (viewModel != null)
                {
                    return View(viewModel);
                }

                else
                {
                    throw new ArgumentException();
                }
            }
            catch (Exception e)
            {
                //Log.Fatal(e, $"{e.Message} \n Stack trace:{e.StackTrace}");

                return BadRequest();
            }
        }
    }
}