using System.ComponentModel.DataAnnotations.Schema;

namespace TestAppForVacancy.Data.Entities;

public class Provider : BaseEntity
{
    [Column(TypeName = "nvarchar(max)")]
    public string Name { get; set; }
    public virtual IEnumerable<Order> Orders { get; set; }
}