using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using TestAppForVacancy.Core.DTO;
using TestAppForVacancy.Data.Entities;

namespace TestAppForVacancy.MVC.Models;

public class OrderCreateViewModel : BaseEditAndCreateModel
{
    public int Id { get; set; }
    public string Number { get; set; }
    public DateTime Date { get; set; }
    public int ProviderId { get; set; }
    public IList<OrderItemViewModel> OrderItems { get; set; }
    public IEnumerable<SelectListItem> ProviderNameAndIdModels { get; set; }
}