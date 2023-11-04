using System.ComponentModel.DataAnnotations.Schema;

namespace TestAppForVacancy.Data.Entities;

public class OrderItem : BaseEntity
{
    [Column(TypeName = "nvarchar(max)")]
    public string Name { get; set; }

    [Column(TypeName = "decimal(18, 3)")]
    public decimal Quantity { get; set; }

    [Column(TypeName = "nvarchar(max)")]
    public string Unit { get; set; }

    public int OrderId { get; set; }
    public virtual Order Order { get; set; }
}