using System.ComponentModel.DataAnnotations.Schema;

namespace TestAppForVacancy.Core.DTO;

public class OrderItemDto
{
    public string Name { get; set; }
    public decimal Quantity { get; set; }
    public string Unit { get; set; }
}