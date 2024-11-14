namespace MovieApp.Web.Entity
{
    public class User //Kulanıcılar(site kullanıcıları)
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ImageUrl { get; set; }
        public Person Person { get; set; }
    }


    public class Person
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string Biography { get; set; }
        public string Imdb { get; set; }
        public string HomePage { get; set; }
        public string PlaceOfBirth { get; set; }
        public string ImageUrl { get; set; }

        public User User { get; set; }
        public int UserId { get; set; } //Foreign Key, unique key
    }

    public class Crew
    {
        public int CrewId { get; set; }
        public Movie Movie { get; set; }
        public int MovieId { get; set; }
        public Person Person{ get; set; }
        public int PersonId { get; set; }
        public string Job { get; set; }
    }

    public class Cast //Oyuncu
    {
        public int CastId { get; set; }
        public Movie Movie { get; set; } 
        public int MovieId { get; set; }
        public Person Person{ get; set; }
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string Caracter { get; set; }
    }

}
