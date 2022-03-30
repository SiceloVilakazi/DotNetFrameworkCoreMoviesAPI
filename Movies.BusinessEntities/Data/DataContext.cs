using Microsoft.EntityFrameworkCore;

namespace Movies.BusinessEntities;

public class DataContext : DbContext
{
    public DataContext()
    { }

    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<Movie> movies { get; set; }

    public DbSet<MovieActor> movieActors { get; set; }

    public DbSet<Actor> actors { get; set; }

    public DbSet<Agent> agents { get; set; }

    public DbSet<Users> users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        if (!options.IsConfigured)
        {
            options.UseSqlServer("server=DVTLF3GQVG3\\MSSQLSERVER_2019;Database=WolfStudio_DB;trusted_connection=true");
        }
    }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}


