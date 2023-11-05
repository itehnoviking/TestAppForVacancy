using Microsoft.AspNetCore.Mvc.Rendering;
using TestAppForVacancy.Core.DTO;

namespace TestAppForVacancy.MVC.Models;

public class OrderCreateViewModel
{
    public string Number { get; set; }
    public DateTime Date { get; set; }
    public IEnumerable<SelectListItem> ProviderNameAndIdModels { get; set; }
    public virtual IEnumerable<SelectListItem> OrderItemsNameAndIdModels { get; set; }
}