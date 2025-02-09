namespace MovieApp.Models
{
    public class MovieCategory: BaseEntity
    {
        public Guid MovieId { get; set; }
        public Guid CategoryId { get; set; }
        public Movie Movie { get; set; }
        public Category Category { get; set; }
    }
}
