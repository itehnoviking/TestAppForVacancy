using System.ComponentModel.DataAnnotations.Schema;

namespace TestAppForVacancy.Data.Entities
{
    public class Order : BaseEntity
    {
        [Column(TypeName = "nvarchar(max)")]
        public string Number { get; set; }

        [Column(TypeName = "datetime2(7)")]
        public DateTime Date { get; set; }

        public int ProviderId { get; set; }
        public virtual Provider Provider { get; set; } 

        public virtual IEnumerable<OrderItem> OrderItems { get; set; }
    }
}