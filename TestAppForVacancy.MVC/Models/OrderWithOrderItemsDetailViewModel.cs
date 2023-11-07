using TestAppForVacancy.Core.DTO;

namespace TestAppForVacancy.MVC.Models;

public class OrderWithOrderItemsDetailViewModel
{
    public int Id { get; set; }
    public string Number { get; set; }
    public DateTime Date { get; set; }
    public int ProviderId { get; set; }
    public virtual IEnumerable<OrderItemDto> OrderItems { get; set; }
}