namespace TestAppForVacancy.MVC.Models;

public class OrderItemDeleteViewModel
{
    public string Name { get; set; }
    public decimal Quantity { get; set; }
    public string Unit { get; set; }
    public int OrderId { get; set; }
}