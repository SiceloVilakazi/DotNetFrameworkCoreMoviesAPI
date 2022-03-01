

using MediatR;

namespace Movies.BusinessLogic
{
    public class DeleteActorAgentCommand :IRequest<int>
    {
        public int ActorAgentId { get; set; }

        public DeleteActorAgentCommand(int actorAgentId)
        {
            this.ActorAgentId = actorAgentId;
        }
    }
}
