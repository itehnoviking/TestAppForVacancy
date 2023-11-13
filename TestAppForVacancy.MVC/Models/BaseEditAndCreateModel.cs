using AutoMapper.Execution;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using TestAppForVacancy.Data.Entities;

namespace TestAppForVacancy.MVC.Models;

public class BaseEditAndCreateModel : IValidatableObject
{

    public int Id { get; set; }
    public string Number { get; set; }
    public DateTime Date { get; set; }
    public int ProviderId { get; set; }
    public IList<OrderItemViewModel> OrderItems { get; set; }
    public IEnumerable<SelectListItem> ProviderNameAndIdModels { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {

        List<ValidationResult> validationResults = new List<ValidationResult>();

        if (OrderItems != null)
        {
            foreach (var orderItem in OrderItems)
            {
                if (orderItem.Name.Equals(Number))
                {
                    validationResults.Add(new ValidationResult("Number cannot be the same as any of the OrderItem names",
                        new[] { "Number" }));

                    break;

                }
            }
        }
        return validationResults;
    }
}