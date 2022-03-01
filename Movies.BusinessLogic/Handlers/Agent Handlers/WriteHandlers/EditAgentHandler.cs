using MediatR;

namespace Movies.BusinessLogic
{
    public class EditAgentHandler : IRequestHandler<EditAgentCommand, int>
    {
        private readonly AgentService _agentService;

        public EditAgentHandler(AgentService agentService)
        {
            _agentService = agentService;   
        }

        public async Task<int> Handle(EditAgentCommand request, CancellationToken cancellationToken)
        {
            return await _agentService.EditAsync(request.Agent);
        }
    }
}
