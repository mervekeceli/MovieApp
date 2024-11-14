using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieApp.Web.Entity
{
    public class Genre
    {
        //[Key, DatabaseGenerated(DatabaseGeneratedOption.None)] -> otomatik artmasını engelleme (genelde Id için kullanılır)
        public int GenreId { get; set; }
        public string Name { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
