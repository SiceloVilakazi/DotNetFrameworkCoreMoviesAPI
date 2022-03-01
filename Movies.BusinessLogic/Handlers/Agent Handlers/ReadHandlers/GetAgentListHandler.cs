
using MediatR;

namespace Movies.BusinessLogic
{
    public class GetAgentListHandler : IRequestHandler<GetAgentListQuery, List<Agent>>
    {
        private readonly AgentService _agentService;

        public GetAgentListHandler(AgentService agentService)
        {
            _agentService = agentService;
        }
        public async Task<List<Agent>> Handle(GetAgentListQuery request, CancellationToken cancellationToken)
        {
            return await _agentService.GetAllAsync();
        }
    }
}
