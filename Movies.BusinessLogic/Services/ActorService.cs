
using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace Movies.BusinessLogic;

public class ActorService
{
    private readonly DataContext context;
    private readonly MovieActorService _movieActorService;
    private readonly ActorAgentService _actorAgentService;
    public ActorService(DataContext dataContext,MovieService movieService,
           MovieActorService movieActorService,ActorAgentService actorAgentService)
    {
        context = dataContext;
        _movieActorService = movieActorService;
        _actorAgentService = actorAgentService;
    }

    #region Read Methods
    public async Task<List<Actor>> GetAllAsync()
    {
        var actors = await context.actors.ToListAsync();
        return actors;
    }

    public async Task<Actor> GetByIdAsync(int id)
    {
        var actor = await context.actors.FirstOrDefaultAsync(x => x.Id == id);

        return actor;
    }

    public async Task<List<Actor>> GetActorsByMovie(string MovieName)
    {
        var search=MovieName.ToLower();

        var actors= await (from actor in  context.actors  join actorMovie in context.movieActors
                   on actor.Id equals actorMovie.ActorId join movie in context.movies
                   on actorMovie.MovieId equals movie.Id where movie.Title.ToLower().Contains(search) 
                   select actor).ToListAsync();
        return actors;
    }

    #endregion

    #region Write methods
    public async Task<int> AddAsync(Actor actor)
    {
        try
        {
            context.Add(actor);
            await context.SaveChangesAsync();
            return actor.Id;
        }
        catch
        {
            throw new InvalidOperationException("cannot add actor");
        }
    }
    public async Task<int> RemoveAsync(int Id)
    {
        try
        {
             _movieActorService.RemoveByActorId(Id);
             _actorAgentService.RemoveByActorId(Id);
            var actor = await context.actors.FirstOrDefaultAsync(x => x.Id == Id);
            if (actor != null)
                context.Remove(actor);
            await context.SaveChangesAsync();
          return Id;
        }
        catch { throw new InvalidOperationException("cannot delete actor"); }

    }

    public async Task<int> EditAsync(Actor actor)
    {
        try
        {
            context.Update(actor);
            await context.SaveChangesAsync();

            return actor.Id;
        }
        catch { throw new InvalidOperationException("cannot update Actor"); }
    }
    #endregion 
}

