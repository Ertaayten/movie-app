namespace MovieApp.Models
{
    public class Movie : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        public int Time { get; set; }
        public string AgeLimit { get; set; }
        public Guid DirectorId { get; set; }

        // Navigation property
        public Director? Director { get; set; }
        public List<MovieActor>? MovieActors { get; set; }
        public List<MovieCategory>? MovieCategories { get; set; }

    }
}
