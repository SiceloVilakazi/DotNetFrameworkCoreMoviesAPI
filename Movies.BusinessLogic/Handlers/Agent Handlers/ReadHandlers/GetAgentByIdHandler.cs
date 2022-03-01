
using MediatR;

namespace Movies.BusinessLogic
{
    public class GetAgentByIdHandler : IRequestHandler<GetAgentByIdQuery, Agent>
    {
        private readonly AgentService _agentService;

        public GetAgentByIdHandler(AgentService agentService)
        {
            _agentService = agentService;
        }

        public async Task<Agent> Handle(GetAgentByIdQuery request, CancellationToken cancellationToken)
        {
            return await _agentService.GetByIdAsync(request.AgentId);
        }
    }
}
