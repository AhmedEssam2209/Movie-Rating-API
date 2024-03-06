using Microsoft.EntityFrameworkCore;
using MovieRateApp.Models;

namespace MovieRateApp.Data
{
    public class AppDBcontext : DbContext
    {
        public AppDBcontext(DbContextOptions<AppDBcontext> options) : base(options) 
        { }
        public DbSet<Movie> Movies { get; set; }
    }
}
