namespace MovieApp.Models.ViewModels
{

    public class MovieCreateViewModel : Movie
    {
        public List<Guid> Categories { get; set; }
        public List<Guid> Actors { get; set; }
    }
}
