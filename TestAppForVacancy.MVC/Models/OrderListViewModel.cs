using Microsoft.AspNetCore.Mvc.Rendering;

namespace TestAppForVacancy.MVC.Models;

public class OrderListViewModel
{
    public IList<OrderViewModel> Orders { get; set; }

    public DateTime FirstDate { get; set; } = DateTime.Now.AddMonths(-1);
    public DateTime SecondDate { get; set; } = DateTime.Now;
    public IList<string> Numbers { get; set; }
    public IList<string> Providers { get; set; }
}