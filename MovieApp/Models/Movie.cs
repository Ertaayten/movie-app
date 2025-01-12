namespace MovieApp.Models
{
    public class Movie : BaseEntity
    {
        public string Title { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        public int Time { get; set; }
        public string AgeLimit { get; set; }
        public Guid DirectorId { get; set; }

        // Navigation property
        public List<Category> Categories { get; set; }
        public Director Director { get; set; }
        public List<Actor> Actors { get; set; }

    }
}
