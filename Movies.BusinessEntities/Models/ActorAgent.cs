using System.ComponentModel.DataAnnotations.Schema;

namespace Movies.BusinessEntities;

public class ActorAgent
{
    public int Id { get; set; }

    public int AgentId { get; set; }

    public Agent? agents { get; set; }

    public int ActorId { get; set; }

    public Actor? actors { get; set; }
  
}

