using System.Data.Entity;

namespace MovieTelegramBot
{
    internal class MovieContext : DbContext
    {
        public MovieContext() : base("DbConnectionString") { }

        public DbSet<Movie> Movies { get; set; }
    }
}
