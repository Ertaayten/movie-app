namespace MovieApp.Models
{
    public class Director : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateOnly BirthDate { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
