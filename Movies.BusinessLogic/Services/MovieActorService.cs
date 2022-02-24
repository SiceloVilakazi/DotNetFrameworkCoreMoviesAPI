using Microsoft.EntityFrameworkCore;

namespace Movies.BusinessLogic;

public class MovieActorService
{
    private readonly DataContext context;

    public MovieActorService(DataContext dataContext)
    {
        context = dataContext;
    }

    #region Read Methods
    public async Task<List<MovieActor>> GetAllAsync()
    {
        var movieActors = await context.movieActors.ToListAsync();
        return movieActors;
    }

    public async Task<MovieActor> GetByIdAsync(int id)
    {
        var movieActor = new MovieActor();
     //   if (MovieExists(id))
            movieActor = await context.movieActors.FirstOrDefaultAsync(x => x.Id == id);

        return movieActor;
    }
    #endregion

    #region Write Methods
    public async Task AddAsync(MovieActor movieActor)
    {
        //Validate(movie);
        context.Add(movieActor);
        await context.SaveChangesAsync();
    }
    public async Task RemoveAsync(int Id)
    {
        var movieActor = await context.movieActors.FirstOrDefaultAsync(x => x.Id == Id);
        if (movieActor != null)
            context.Remove(movieActor);
        await context.SaveChangesAsync();
    }

    public void RemoveByMovieId(int Id)
    {
        var movieActor =  context.movieActors.FirstOrDefault(x => x.ActorId == Id);
        if (movieActor != null)
            context.Remove(movieActor);
        context.SaveChanges();
    }

    public void RemoveByActorId(int Id)
    {
        var movieActor =  context.movieActors.FirstOrDefault(x => x.ActorId == Id);
        if (movieActor != null)
            context.Remove(movieActor);
         context.SaveChanges();
        
    }

    public async Task EditAsync(MovieActor movieActor)
    {
        context.Update(movieActor);
        await context.SaveChangesAsync();
    }
    #endregion
}

