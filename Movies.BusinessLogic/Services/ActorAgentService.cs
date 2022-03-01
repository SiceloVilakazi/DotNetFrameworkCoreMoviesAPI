using Microsoft.EntityFrameworkCore;

namespace Movies.BusinessLogic;

public class ActorAgentService
{
    private readonly DataContext context;

    public ActorAgentService(DataContext dataContext)
    {
        context = dataContext;
    }

    #region Read Methods
    public async Task<List<ActorAgent>> GetAllAsync()
    {
        var actorAgents = await context.actorAgents.ToListAsync();
        return actorAgents;
    }

    public async Task<ActorAgent> GetByIdAsync(int id)
    {
       var actorAgent = new ActorAgent();
        
       actorAgent = await context.actorAgents.FirstOrDefaultAsync(x => x.Id == id);
       return actorAgent;

    }
    #endregion

    #region Add Methods
    public async Task<int> AddAsync(ActorAgent actorAgent)
    {
        try
        {
            context.Add(actorAgent);
            await context.SaveChangesAsync();
            return actorAgent.Id;
        }
        catch
        {
            throw new InvalidOperationException("cannot add Actor Agent");
        }
    }
    public async Task<int> RemoveAsync(int Id)
    {

        try
        {
            var actorAgents = await context.actorAgents.FirstOrDefaultAsync(x => x.Id == Id);
            if (actorAgents != null)
                context.Remove(actorAgents);
            await context.SaveChangesAsync();
            return Id;
        }
        catch
        {
            throw new InvalidOperationException("cannot remove Actor Agent");
        }
   
    }

    public void RemoveByAgentId(int Id)
    {
        var actorAgent = context.actorAgents.FirstOrDefault(x => x.AgentId == Id);
        if (actorAgent != null)
            context.Remove(actorAgent);
        context.SaveChanges();
    }

    public void RemoveByActorId(int Id)
    {
        var actorAgent = context.actorAgents.FirstOrDefault(x => x.ActorId == Id);
        if (actorAgent != null)
            context.Remove(actorAgent);
        context.SaveChanges();

    }

    public async Task<int> EditAsync(ActorAgent actorAgent)
    {
        try
        {
            context.Update(actorAgent);
            await context.SaveChangesAsync();
            return actorAgent.Id;
        }
        catch
        {
            throw new InvalidOperationException("cannot update the Actor Agent");
        }
       
    }
    #endregion
}

