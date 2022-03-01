using MediatR;

namespace Movies.BusinessLogic
{
    public class DeleteAgentHandler : IRequestHandler<DeleteAgentCommand, int>
    {
        private readonly AgentService _agentService;

        public DeleteAgentHandler(AgentService agentService)
        {
            _agentService = agentService;
        }
        public async Task<int> Handle(DeleteAgentCommand request, CancellationToken cancellationToken)
        {
            return await _agentService.RemoveAsync(request.AgentId);
        }
    }
}
