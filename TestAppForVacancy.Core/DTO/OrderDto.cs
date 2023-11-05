using System.ComponentModel.DataAnnotations.Schema;

namespace TestAppForVacancy.Core.DTO;

public class OrderDto
{
    public int Id { get; set; }
    public string Number { get; set; }
    public DateTime Date { get; set; }
    public int ProviderId { get; set; }
    public virtual IEnumerable<OrderItemDto> OrderItems { get; set; }
}