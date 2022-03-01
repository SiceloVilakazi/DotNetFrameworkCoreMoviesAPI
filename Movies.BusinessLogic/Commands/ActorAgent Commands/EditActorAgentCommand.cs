

using MediatR;

namespace Movies.BusinessLogic
{
    public class EditActorAgentCommand : IRequest<int>
    {
        public ActorAgent ActorAgent { get; set; }

        public EditActorAgentCommand(ActorAgent actorAgent)
        {
            this.ActorAgent = actorAgent;
        }
    }
}
