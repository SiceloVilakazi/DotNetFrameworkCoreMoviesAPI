
using MediatR;

namespace Movies.BusinessLogic
{
    public class DeleteAgentCommand : IRequest<int>
    {
        public int AgentId { get; set; }

        public DeleteAgentCommand(int agentId)
        {
            this.AgentId = agentId;
        }
    }
}
