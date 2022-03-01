

using MediatR;

namespace Movies.BusinessLogic
{
    public class AddAgentHandler : IRequestHandler<AddAgentCommand, int>
    {
        private readonly AgentService _agentService;

        public AddAgentHandler(AgentService agentService)
        {
            _agentService = agentService;
        }
        public async Task<int> Handle(AddAgentCommand request, CancellationToken cancellationToken)
        {
            return await _agentService.AddAsync(request.Agent);
        }
    }
}
