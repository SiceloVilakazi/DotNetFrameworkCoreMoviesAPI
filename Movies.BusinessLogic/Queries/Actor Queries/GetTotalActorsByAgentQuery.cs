
using MediatR;

namespace Movies.BusinessLogic
{
    public class GetTotalActorsByAgentQuery : IRequest<int>
    {
        public string AgentName { get; }

        public GetTotalActorsByAgentQuery(string agentName)
        {
            AgentName = agentName;
        }
    }
}
