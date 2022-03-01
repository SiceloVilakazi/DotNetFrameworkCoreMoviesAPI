
using MediatR;

namespace Movies.BusinessLogic
{
    public class GetActorAgentByIdQuery : IRequest<ActorAgent>
    {
        public int ActorAgentId { get; }

        public GetActorAgentByIdQuery(int actorAgentId)
        {
            this.ActorAgentId = actorAgentId;
        }
    }
}
