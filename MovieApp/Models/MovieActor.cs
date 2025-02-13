﻿namespace MovieApp.Models
{
    public class MovieActor: BaseEntity
    {
        public Guid MovieId { get; set; }
        public Guid ActorId { get; set; }
        public Movie Movie { get; set; }
        public Actor Actor { get; set; }
    }
}
