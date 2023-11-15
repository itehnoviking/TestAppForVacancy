using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AutoMapper;
using TestAppForVacancy.Core.Interfaces.Services;
using TestAppForVacancy.MVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using TestAppForVacancy.Core.DTO;
using TestAppForVacancy.Data.Entities;
using TestAppForVacancy.Domain.Services;

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
            var ordersDto = await _orderService.GetAllOrdersAsync();

            var viewModel = _mapper.Map<OrderListViewModel>(ordersDto);

            var providers = await _providerService.GetAllProviderNameAndId();

            viewModel.Providers = providers.Select(p => p.Name).ToList();

            return View(viewModel);
        }

        
        public async Task<IActionResult> Detail(int id)
        {
            try
            {
                var order = await _orderService.GetOrderWithOrderItemById(id);

                var orderDetailViewModel = _mapper.Map<OrderWithOrderItemsDetailViewModel>(order);

                if (orderDetailViewModel != null)
                {
                    return View(orderDetailViewModel);
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

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            try
            {
                var providers = await _providerService.GetAllProviderNameAndId();

                var viewModel = new OrderCreateViewModel()
                {
                    ProviderNameAndIdModels = providers.Select(provider => new SelectListItem(provider.Name, provider.Id.ToString()))
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

        [HttpPost]
        public async Task<IActionResult> Create(OrderCreateViewModel viewModel)
        {
            try
            {
                var validationResults = new List<ValidationResult>();
                if (!Validator.TryValidateObject(viewModel, new ValidationContext(viewModel), validationResults, true))
                {
                    foreach (var validationResult in validationResults)
                    {
                        ModelState.AddModelError(validationResult.MemberNames.FirstOrDefault() ?? "", validationResult.ErrorMessage);
                    }
                    return View(viewModel);
                }

                var checkForUniqueOrderName = await _providerService.CheckForUniqueOrderNumber(viewModel.ProviderId, viewModel.Number, viewModel.Id);

                if (checkForUniqueOrderName)
                {
                    return StatusCode(412,
                        $"{viewModel.Number} already exists with this provider. You must use a different order number.");
                }

                await _orderService.CreateOrderAsync(_mapper.Map<OrderDto>(viewModel));

                if (viewModel != null)
                {
                    return RedirectToAction("Index", "Order");
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

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var order = await _orderService.GetOrderWithOrderItemById(id);
                var viewModel = _mapper.Map<OrderDeleteViewModel>(order);

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

        [HttpPost]
        public async Task<IActionResult> Delete(OrderDeleteViewModel viewModel)
        {
            try
            {
                await _orderService.DeleteOrderByIdAsync(viewModel.Id);

                if (viewModel != null)
                {
                    return RedirectToAction("Index", "Order");
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

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            try
            {
                var orderDto = await _orderService.GetOrderWithOrderItemById(id);
                var orderEditViewModel = _mapper.Map<OrderEditViewModel>(orderDto);
                orderEditViewModel.Id = id;

                var providers = await _providerService.GetAllProviderNameAndId();

                orderEditViewModel.ProviderNameAndIdModels = providers.Select(provider =>
                    new SelectListItem(provider.Name, provider.Id.ToString()));
                

                if (orderDto != null)
                {
                    return View(orderEditViewModel);
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

        [HttpPost]
        public async Task<IActionResult> Edit(OrderEditViewModel viewModel)
        {
            try
            {
                var validationResults = new List<ValidationResult>();
                if (!Validator.TryValidateObject(viewModel, new ValidationContext(viewModel), validationResults, true))
                {
                    foreach (var validationResult in validationResults)
                    {
                        ModelState.AddModelError(validationResult.MemberNames.FirstOrDefault() ?? "", validationResult.ErrorMessage);
                    }
                    return View(viewModel);
                }

                var checkForUniqueOrderName = await _providerService.CheckForUniqueOrderNumber(viewModel.ProviderId, viewModel.Number, viewModel.Id);

                if (checkForUniqueOrderName)
                {
                    return StatusCode(412,
                        $"{viewModel.Number} already exists with this provider. You must use a different order number.");
                }

                var orderDto = _mapper.Map<OrderDto>(viewModel);

                await _orderService.OrderUpdateAsync(orderDto);

                if (viewModel != null)
                {
                    return RedirectToAction("Index", "Order");
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

        [HttpPost]
        public async Task<IActionResult> OrderFilter(OrderListViewModel viewModel)
        {
            var dto = _mapper.Map<OrderFilterDto>(viewModel);

            var orderList = await _orderService.GetOrderByFilter(dto);

            var resultViewModel = _mapper.Map<IList<OrderViewModel>>(orderList);

            return View(resultViewModel);
        }



       


    }
}

   


