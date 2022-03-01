

using MediatR;

namespace Movies.BusinessLogic
{
    public class AddActorAgentCommand : IRequest<int>
    {
        public ActorAgent ActorAgent { get; set; }

        public AddActorAgentCommand(ActorAgent actorAgent)
        {
            this.ActorAgent = actorAgent;
        }
    }
}
