namespace TestAppForVacancy.Core.DTO;

public class OrderFilterDto
{
    public DateTime FirstDate { get; set; }
    public DateTime SecondDate { get; set; }
    public IList<string> Numbers { get; set; }
    public IList<string> Providers { get; set; }
}