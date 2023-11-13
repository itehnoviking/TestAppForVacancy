using System.ComponentModel.DataAnnotations;
using TestAppForVacancy.MVC.Models;

namespace TestAppForVacancy.MVC.AttributeValidation;

public class OrderNumberValidationAttribute : ValidationAttribute
{
    public IEnumerable<OrderItemViewModel> OrderItems;

    public OrderNumberValidationAttribute(IList<OrderItemViewModel> orderItems)
    {
        OrderItems = orderItems;
    }

    public override bool IsValid(object? value)
    {
        var orderNumber = value.ToString();

        foreach (var orderItem in OrderItems)
        {
            if (orderItem.Name.Equals(orderNumber))
            {
                return false;
            }
        }

        return true;
    }
}