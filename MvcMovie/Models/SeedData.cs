
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;

namespace MvcMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = new MvcMovieSqlServerContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MvcMovieSqlServerContext>>());

        var movies = new Movie[]
        {
            new Movie
            {
                Title = "When Harry Met Sally",
                ReleaseDate = DateTime.Parse("1989-02-12"),
                Genre = "Romantic Comedy",
                Price = 7.99M
            },
            new Movie
            {
                Title = "Ghostbusters",
                ReleaseDate = DateTime.Parse("1984-03-13"),
                Genre = "Comedy",
                Price = 8.99M
            },
            new Movie
            {
                Title = "Ghostbusters 2",
                ReleaseDate = DateTime.Parse("1986-02-23"),
                Genre = "Comedy",
                Price = 9.99M
            },
            new Movie
            {
                Title = "Rio Bravo",
                ReleaseDate = DateTime.Parse("1959-04-15"),
                Genre = "Western",
                Price = 3.99M
            }
        };

        foreach (var movie in movies)
        {
            if (!context.Movie.Any(m => m.Title == movie.Title))
            {
                context.Movie.Add(movie);
            }
        }

        context.SaveChanges();
    }
}

