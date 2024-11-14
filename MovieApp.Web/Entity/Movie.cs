using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Collections.Generic;

namespace MovieApp.Web.Entity
{
    public class Movie
    { 
        public int MovieId { get; set; }
        public string Title { get; set; }

        [MaxLength]
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public List<Genre> Genres { get; set; } //navigation property
    }
}
