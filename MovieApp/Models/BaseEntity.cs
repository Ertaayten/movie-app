using System.ComponentModel.DataAnnotations.Schema;

namespace MovieApp.Models
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        [NotMapped]
        public DateTime? CreatedAt { get; set; }
        [NotMapped]
        public DateTime? UpdatedAt { get; set; }
    }
}
