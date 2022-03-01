

using MediatR;

namespace Movies.BusinessLogic
{
    public class AddActorAgentHandler : IRequestHandler<AddActorAgentCommand, int>
    {
        private readonly ActorAgentService _actorAgentService;

        public AddActorAgentHandler(ActorAgentService actorAgentService)
        {
            _actorAgentService = actorAgentService;
        }
        public async Task<int> Handle(AddActorAgentCommand request, CancellationToken cancellationToken)
        {
            return await _actorAgentService.AddAsync(request.ActorAgent);
        }
    }
}
