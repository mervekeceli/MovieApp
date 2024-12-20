﻿using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieApp.Web.Entity;
using System.Collections.Generic;
using System.Linq;

namespace MovieApp.Web.Data
{
    public static class DataSeeding
    {
        public static void Seed(IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetService<MovieContext>();

            context.Database.Migrate(); //dotnet ef database update

            var genres = new List<Genre>() {
                            new Genre{
                                    Name="Macera", Movies=
                                    new List<Movie>(){
                                        new Movie{Title = "Yeni Macera Filmi 1", Description= "Aciklama 1", ImageUrl = "1.jpg"},
                                        new Movie{Title = "Yeni macera filmi 2", Description= "Aciklama 2", ImageUrl = "2.jpg"},
                                    }
                            },
                            new Genre{Name="Komedi"},
                            new Genre{Name="Romantik"},
                            new Genre{Name="Bilim Kurgu"},
                            new Genre{Name="Aksiyon"},
                    };

            var movies = new List<Movie>() {
                        new Movie{Title = "Film 1", Description= "Aciklama 1", ImageUrl = "1.jpg", Genres = new List<Genre>(){genres[0], new Genre() { Name="Yeni Tür"} } },
                        new Movie{Title = "Film 2", Description= "Aciklama 2", ImageUrl = "2.jpg", Genres = new List<Genre>(){genres[1]} },
                        new Movie{Title = "Film 3", Description= "Aciklama 3", ImageUrl = "3.jpg", Genres = new List<Genre>(){genres[2]} },
                        new Movie{Title = "Film 4", Description= "Aciklama 4", ImageUrl = "1.jpg", Genres = new List<Genre>(){genres[0]} },
                        new Movie{Title = "Film 5", Description= "Aciklama 5", ImageUrl = "2.jpg", Genres = new List<Genre>(){genres[0]} },
                        new Movie{Title = "Film 6", Description= "Aciklama 6", ImageUrl = "3.jpg", Genres = new List<Genre>(){genres[0]} }
                    };

            var users = new List<User>() {
                new User(){UserName = "usera", Email="usera@gmail.com", Password="12345", ImageUrl="person1.jpg"},
                new User(){UserName = "userb", Email="userb@gmail.com", Password="12345", ImageUrl="person2.jpg"},
                new User(){UserName = "userc", Email="userc@gmail.com", Password="12345", ImageUrl="person2.jpg",
                    Person= new Person(){
                        Name="Personel 1",
                        Biography = "Tanıtım 1"
                    }
                },
                new User(){UserName = "userd", Email="userd@gmail.com", Password="12345", ImageUrl="person4.jpg",
                    Person= new Person(){
                        Name="Personel 2",
                        Biography = "Tanıtım 2"
                    }
                }
            };

            var people = new List<Person>() {
                new Person()
                {
                    Name = "Person 1",
                    Biography = "Tanıtım 1",
                    User= users[0]
                },
                new Person()
                {
                    Name = "Person 2",
                    Biography = "Tanıtım 2",
                    User= users[1]
                }
            };

            var crews = new List<Crew>()
            {
                new Crew(){Movie=movies[0], Person = people[0], Job="Yönetmen"},
                new Crew(){Movie=movies[0], Person = people[1], Job="Yönetmen Yardımcısı"}

            };

            var cast = new List<Cast>()
            {
                new Cast(){ Movie = movies[0], Person=people[0], Name="Oyuncu Adı 1", Caracter="Başrol 1"},
                new Cast(){ Movie = movies[0], Person=people[0], Name="Oyuncu Adı 2", Caracter="Başrol 2"},
            };

            if (context.Database.GetPendingMigrations().Count() == 0)
            {
                if (context.Genres.Count() == 0)
                {
                    context.Genres.AddRange(genres);
                }
                if (context.Movies.Count() == 0)
                {
                    context.Movies.AddRange(movies);
                }
                if (context.Users.Count() == 0)
                {
                    context.Users.AddRange(users);
                }
                if (context.People.Count() == 0)
                {
                    context.People.AddRange(people);
                }

                if (context.Crews.Count() == 0)
                {
                    context.Crews.AddRange(crews);
                }
                if (context.Casts.Count() == 0)
                {
                    context.Casts.AddRange(cast);
                }

                context.SaveChanges();
            }
        }
    }
}
