
using MediatR;

namespace Movies.BusinessLogic
{
    public class GetAgentByIdQuery : IRequest<Agent>
    {
        public int AgentId { get; }

        public GetAgentByIdQuery(int agentId)
        {
            this.AgentId = agentId;
        }
    }
}
