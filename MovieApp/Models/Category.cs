﻿namespace MovieApp.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public List<MovieCategory> MovieCategories { get; set; }
    }
}
