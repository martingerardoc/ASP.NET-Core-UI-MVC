
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;

namespace MvcMovie.Data;

public class MvcMovieSqlServerContext : DbContext
{
    public MvcMovieSqlServerContext(
        DbContextOptions<MvcMovieSqlServerContext> options)
        : base(options)
    {
    }

    public DbSet<Movie> Movie { get; set; } = default!;
}
