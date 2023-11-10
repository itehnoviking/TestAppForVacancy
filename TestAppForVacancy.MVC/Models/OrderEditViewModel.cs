using Microsoft.AspNetCore.Mvc.Rendering;

namespace TestAppForVacancy.MVC.Models;

public class OrderEditViewModel
{
    public int Id { get; set; }
    public string Number { get; set; }
    public DateTime Date { get; set; }
    public int ProviderId { get; set; }
    public IList<OrderItemViewModel> OrderItems { get; set; }
    public IEnumerable<SelectListItem> ProviderNameAndIdModels { get; set; }
}