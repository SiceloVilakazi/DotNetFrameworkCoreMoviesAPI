
using MediatR;

namespace Movies.BusinessLogic
{
    public class DeleteActorAgentHandler : IRequestHandler<DeleteActorAgentCommand, int>
    {
        private readonly ActorAgentService _actorAgentService;

        public DeleteActorAgentHandler(ActorAgentService actorAgentService)
        {
            _actorAgentService = actorAgentService;
        }

        public async Task<int> Handle(DeleteActorAgentCommand request, CancellationToken cancellationToken)
        {
            return await _actorAgentService.RemoveAsync(request.ActorAgentId);
        }
    }
}
