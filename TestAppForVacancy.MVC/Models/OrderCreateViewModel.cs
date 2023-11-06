using Microsoft.AspNetCore.Mvc.Rendering;
using TestAppForVacancy.Core.DTO;
using TestAppForVacancy.Data.Entities;

namespace TestAppForVacancy.MVC.Models;

public class OrderCreateViewModel
{
    public string Number { get; set; }
    public DateTime Date { get; set; }
    public int ProviderId { get; set; }
    public IEnumerable<OrderItem> OrderItems { get; set; }
    public IEnumerable<SelectListItem> ProviderNameAndIdModels { get; set; }
    public IEnumerable<SelectListItem> OrderItemsNameAndIdModels { get; set; }
}