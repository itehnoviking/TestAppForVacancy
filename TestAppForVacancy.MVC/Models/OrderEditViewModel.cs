using Microsoft.AspNetCore.Mvc.Rendering;

namespace TestAppForVacancy.MVC.Models;

public class OrderEditViewModel
{
    public string Number { get; set; }
    public DateTime Date { get; set; }
    public int ProviderId { get; set; }
    public IEnumerable<OrderItemViewModel> OrderItems { get; set; }
    public IEnumerable<SelectListItem> ProviderNameAndIdModels { get; set; }
}