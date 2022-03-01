using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace Movies.BusinessLogic;

public class AgentService
{
    private readonly DataContext context;
    private readonly ActorAgentService _actorAgentService;

    public AgentService(DataContext dataContext,ActorAgentService actorAgentService)
    {
        context = dataContext;
        _actorAgentService = actorAgentService;
    }

    #region Read Methods
    public async Task<List<Agent>> GetAllAsync()
    {
        var movies = await context.agents.ToListAsync();
        return movies;
    }

    public async Task<Agent> GetByIdAsync(int id)
    {
        var agent = new Agent();
            agent = await context.agents.FirstOrDefaultAsync(x => x.Id == id);

        return agent;
    }
    #endregion

    #region Write Methods
    public async Task<int> AddAsync(Agent agent)
    {
        try
        {
            context.Add(agent);
            await context.SaveChangesAsync();
            return agent.Id;
        }
        catch { throw new InvalidOperationException("cannot add agent"); }
     
    }
    public async Task<int> RemoveAsync(int Id)
    {
        try
        {
            _actorAgentService.RemoveByAgentId(Id);
            var agent = await context.agents.FirstOrDefaultAsync(x => x.Id == Id);
            if (agent != null)
                context.Remove(agent);
            await context.SaveChangesAsync();
            return Id;
        }
        catch { throw new InvalidOperationException("cannot remove agent"); }

    }

    public async Task<int> EditAsync(Agent agent)
    {
        context.Update(agent);
        await context.SaveChangesAsync();
        return agent.Id;
    }

    #endregion

    #region Validation
    #endregion
}

