namespace MovieApp.Models
{
    public class Actor: BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateOnly BirthDate { get; set; }
        public List<MovieActor> MovieActors { get; set; }
    }
}
