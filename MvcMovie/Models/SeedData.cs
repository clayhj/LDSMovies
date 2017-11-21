using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<DbContextOptions<MvcMovieContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movie.AddRange(
                     new Movie
                     {
                         Title = "Meet The Mormons",
                         ReleaseDate = DateTime.Parse("2014-10-10"),
                         Genre = "Documentary",
                         Rating = "PG",
                         Price = 7.99M
                     },

                     new Movie
                     {
                         Title = "17 Miracles",
                         ReleaseDate = DateTime.Parse("2011-6-3"),
                         Genre = "History/Adventure",
                         Rating = "PG",
                         Price = 6.99M
                     },

                     new Movie
                     {
                         Title = "The Singles Ward",
                         ReleaseDate = DateTime.Parse("2002-1-1"),
                         Genre = "Comedy",
                         Rating = "PG",
                         Price = 5.99M
                     },

                   new Movie
                   {
                       Title = "The Other Side of Heaven",
                       ReleaseDate = DateTime.Parse("2001-12-14"),
                       Genre = "Drama",
                       Rating = "PG",
                       Price = 3.99M
                   }
                );
                context.SaveChanges();
            }
        }
    }
}