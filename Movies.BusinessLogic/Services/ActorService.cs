using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace Movies.BusinessLogic;

public class ActorService
{
    private readonly DataContext context;
    private readonly MovieActorService _movieActorService;
    public ActorService(DataContext dataContext, MovieService movieService,
           MovieActorService movieActorService)
    {
        context = dataContext;
        _movieActorService = movieActorService;
    }

    #region Read Methods
    public async Task<List<Actor>> GetAllAsync()
    {
        var actors = await context.actors.Where(a=>a.isDeleted !=true).ToListAsync();
        return actors;
    }

    public async Task<Actor> GetByIdAsync(int id)
    {
        var actor = await context.actors.Where(a => a.isDeleted != true).FirstOrDefaultAsync(x => x.Id == id);

        return actor;
    }

    public async Task<List<Actor>> GetActorsByMovie(string MovieName)
    {
        var search = MovieName.Trim().ToLower();

        var actors = await (from actor in context.actors
                            join actorMovie in context.movieActors on actor.Id equals actorMovie.ActorId
                            join movie in context.movies on actorMovie.MovieId equals movie.Id
                            where actor.isDeleted.Equals(0) &&
                            movie.Title.Trim().ToLower().Contains(search)
                            select actor).ToListAsync();
        return actors;
    }

    public async Task<int> GetTotalActorsByAgent(string AgentName)
    {
        var search = AgentName.Trim().ToLower();

        var actors = await (from actor in context.actors
                            join agent in context.agents on actor.AgentId equals agent.Id
                            where actor.isDeleted.Equals(0) &&
                            agent.Name.ToLower().Trim().Contains(search) ||
                            agent.CompanyName.ToLower().Trim().Contains(search)
                            select actor).ToListAsync();
        return actors.Count;
    }

    #endregion

    #region Write methods
    public async Task<int> AddAsync(Actor actor)
    {
        try
        {
            actor.agents = null;
            context.Add(actor);
            await context.SaveChangesAsync();
            return actor.Id;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
    public async Task<int> RemoveAsync(int Id)
    {
        try
        {
            var actor = await GetByIdAsync(Id);
            actor.isDeleted = true;
            context.Update(actor);
            await context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
        return Id;
    }

    public async Task<int> EditAsync(Actor actor)
    {
        try
        {
            context.Update(actor);
            await context.SaveChangesAsync();

            return actor.Id;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
    #endregion 
}

